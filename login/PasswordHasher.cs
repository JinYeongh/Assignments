using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace login
{
    public static class PasswordHasher          //어디서나 쓸 수 있도록 static을 사용
    {
        public const int Iterations = 100000;   //이 숫자가 높을수록 해킹시간 지연을 함

        public static byte[] GenerateSalt(int length = 16)      //랜덤 바이트 배열을 만들어서 반환하는 함수
        {
            var salt = new byte[length];                        //16칸짜리 바이트 배열 만듬
            using (var rng = RandomNumberGenerator.Create())    //위에만든 배열안에 무작위 숫자 채워넣음 0~255까지
                rng.GetBytes(salt);
            return salt;                                        //위에서 만든 배열을 반환 이게 Hash()함수로 넘어감
        }

        public static byte[] Hash(string password, byte[] salt, int iterations = Iterations, int hashLen = 32)  //해시 만드는 함수
        //password = 사용자 입력 / salt위에서 만든 랜덤 바이트 / Iterations 반복횟수 / hashLen 바이트 크기 32
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations)) //여기서 해시가 만들어짐
                return pbkdf2.GetBytes(hashLen);
        }

        public static bool Verify(string password, byte[] salt, byte[] expectedHash, int iterations = Iterations)   //로그인할때 사용되는 검증 함수
        {
            //입력한 비번 -> Hash함수 호출 -> 내부에서 salt 섞어서 해시 -> got 변수에 저장
            var got = Hash(password, salt, iterations, expectedHash.Length);

            if (got.Length != expectedHash.Length) return false;        //혹시 길이가 다르면 리턴(실패)
            int diff = 0;               //비교변수
            for (int i = 0; i < got.Length; i++) diff |= got[i] ^ expectedHash[i];      //값을 하나하나 비교해서 다른게있으면 diff증가
            return diff == 0;           //diff가 0이아니면 false
        }
    }
}
