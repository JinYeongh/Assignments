using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.Timers;   // 타이머

namespace serial_con
{
    public class scanner_con
    {
        private SerialPort _serialPort;               // 시리얼 포트
        private CancellationTokenSource _cts;         // 읽기 루프 중단용 토큰

        //폼으로 읽은 데이터를 넘겨줄 이벤트 (한 번 읽힌 바이트 덩어리)
        public event Action<byte[]> DataReceived;

        private readonly Queue<byte> _q = new Queue<byte>();   //수신 바이트 큐
        private readonly object _lock = new object();           //스레드 충돌 방지용

        private readonly List<byte> _buf = new List<byte>();    //stx~etx 사이 payload 누적 버퍼
        private const byte STX = 0x02;                          //시작 stx
        private const byte ETX = 0x03;                          //끝 etx

        private System.Timers.Timer _procTimer;                 // 큐 처리용 타이머

        public scanner_con()   //생성자
        {
        }

        public void Connect(string portName)             //포트 연결 함수 (폼에서 호출)
        {
            // 이미 열려있는 포트가 있다면 중복 실행 방지
            if (_serialPort != null && _serialPort.IsOpen)
                throw new InvalidOperationException("이미 연결된 포트가 있습니다.");

            try
            {
                // 시리얼포트 설정 포트번호는 각 폼에서 가져옴
                _serialPort = new SerialPort(portName, 9600);  //속도
                _serialPort.DataBits = 8;                     //데이터 비트
                _serialPort.Parity = Parity.None;             //패리티 x
                _serialPort.StopBits = StopBits.One;          //정지 비트 1
                _serialPort.Handshake = Handshake.None;       //흐름 제어 x

                _serialPort.Encoding = Encoding.UTF8;         //받은 데이터 인코딩은 utf8로
                _serialPort.ReceivedBytesThreshold = 1;       //이벤트 안씀 그래도 값 유지

                _serialPort.Open();                           //포트 열기

                // 읽기 루프 시작
                _cts = new CancellationTokenSource();         //중단용
                Task.Run(() => ReadLoop(_cts.Token));         //함수호출해서 읽기시작

                _procTimer = new System.Timers.Timer(30);      //30ms마다 한번씩 돌도록
                _procTimer.AutoReset = true;                  //계속 반복
                _procTimer.Elapsed += ProcessLoop;            //타이머 틱마다 큐 처리
                _procTimer.Start();
            }
            catch
            {
                // 폼에서 메시지 박스 띄우게
                //오류 방지 + 로직 섞임
                throw;
            }
        }

        public void Disconnect()            //포트 해제 함수 (폼에서 해제 버튼 누를 때 호출)
        {
            try
            {
                // 포트가 존재하고 열려 있을 때만 닫기
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _cts?.Cancel();      // 읽기 루프 중단 신호

                    if (_procTimer != null)
                    {
                        _procTimer.Stop();      // 타이머 중지
                        _procTimer.Dispose();   // 정리
                        _procTimer = null;
                    }

                    Thread.Sleep(20);    // 잠깐 기다렸다가

                    _serialPort.Close(); // 실제 포트 닫기
                }
            }
            catch
            {
                // 마찬가지로 폼에서 처리하게끔
                throw;
            }
        }

        // 읽기함수 (백그라운드 스레드에서 동작)
        private void ReadLoop(CancellationToken token)
        {
            var temp = new byte[1024]; //들어온 데이터를 잠깐 담는곳

            // 중단신호 안오고 포트 존재하고 포트 열려있을때까지 반복
            while (!token.IsCancellationRequested && _serialPort != null && _serialPort.IsOpen)
            {
                try
                {
                    int avail = _serialPort.BytesToRead; //읽을 수 있는 바이트 수
                    if (avail == 0)                      //바이트가 0일때
                    {
                        Thread.Sleep(5);                 //없으니까 잠간 쉬도록
                        continue;                        //while문으로 돌아감 계속 읽어야하니까
                    }

                    if (avail > temp.Length)             //1024보다 크면 1024로 맞춤
                        avail = temp.Length;

                    int n = _serialPort.Read(temp, 0, avail); //실제 읽기(temp에 0부터 avail만큼 채움)

                    if (n > 0)
                    {
                        // 읽은 raw 바이트를 큐에 쌓기
                        lock (_lock)
                        {
                            for (int i = 0; i < n; i++)
                            {
                                _q.Enqueue(temp[i]); // raw 바이트 한 개씩 저장
                            }
                        }
                    }
                }
                catch
                {
                    // 그냥 잠깐 쉬고 다시 시도
                    Thread.Sleep(50);
                }
            }
        }

        // 처리 루프 (큐에서 가져와서 stx/etx 프레임 처리)
        private void ProcessLoop(object sender, ElapsedEventArgs e)
        {
            try
            {
                while (true)
                {
                    byte b = 0;
                    bool hasData = false;

                    // 큐가 비었으면 읽을게 없음 → 조금 기다렸다가 다음 루프
                    lock (_lock)
                    {
                        if (_q.Count > 0)
                        {
                            b = _q.Dequeue();   // 큐에서 한 개 꺼냄
                            hasData = true;
                        }
                    }

                    if (!hasData)
                    {
                        // 큐 비었으면 이번 틱에서는 더 볼게 없으니까 탈출
                        break;
                    }

                    //여기부터 stx etx처리
                    if (b == STX)               //시작 stx 들어오면
                    {
                        _buf.Clear();           //이전에 남아있던 데이터 지우고 새 프레임 시작
                        continue;
                    }

                    if (b == ETX)               //끝 etx 들어오면
                    {
                        if (_buf.Count > 0)     //stx etx까지 담은 _buf가 끝이 날때까지
                        {
                            // 읽은 부분만 잘라서 새 배열 만들기
                            var chunk = _buf.ToArray();    //_buf에 누적된 payload만 배열로

                            // 이벤트로 폼에 넘김
                            DataReceived?.Invoke(chunk);   //chunk값 보내준다
                        }
                        _buf.Clear();           //프레임 하나 처리 끝났으니 초기화
                        continue;
                    }

                    _buf.Add(b);                //누적시킴
                }
            }
            catch
            {
                // 처리 중 오류가 나도 타이머는 계속 돌도록 함
            }
        }
    }
}
