using System.Collections.Generic;
using System.Security.Cryptography;

namespace SimReeferMiddlewareSystemWPF.Utils
{
    public class KeyGenerator
    {
        private static IEnumerable<byte> GenerateKey(int keySize)
        {
            byte[] array = new byte[keySize / 8];
            using RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
            rNGCryptoServiceProvider.GetBytes(array);
            return array;
        }

        public static IEnumerable<byte> GenerateAES128Key()
        {
            return GenerateKey(128);
        }

        public static IEnumerable<byte> GenerateAES192Key()
        {
            return GenerateKey(192);
        }

        public static IEnumerable<byte> GenerateAES256Key()
        {
            return GenerateKey(256);
        }

        public static IEnumerable<byte> GenerateAES128IV()
        {
            return GenerateKey(128);
        }

        public static IEnumerable<byte> GenerateAES192IV()
        {
            return GenerateKey(192);
        }

        public static IEnumerable<byte> GenerateAES256IV()
        {
            return GenerateKey(256);
        }

        public static IEnumerable<byte> Generate3DESKey()
        {
            return GenerateKey(192);
        }

        public static IEnumerable<byte> Generate3DESIV()
        {
            return GenerateKey(64);
        }

        public static IEnumerable<byte> GenerateDESKey()
        {
            return GenerateKey(64);
        }

        public static IEnumerable<byte> GenerateDESIV()
        {
            return GenerateKey(64);
        }

        public static IEnumerable<byte> GenerateSEEDKey()
        {
            return GenerateKey(128);
        }

        public static IEnumerable<byte> GenerateSEEDIV()
        {
            return GenerateKey(128);
        }
    }
}
