using System.Security.Cryptography;
using System.Linq;

namespace SimReeferMiddlewareSystemWPF.Utils
{
    public static class ExtensionForCrypto
    {
        private static IEnumerable<byte> Encrypt(this SymmetricAlgorithm symmertric, IEnumerable<byte> toEncryptData)
        {
            ICryptoTransform cryptoTransform = symmertric.CreateEncryptor(symmertric.Key, symmertric.IV);
            byte[] array = toEncryptData.ToArray();
            return cryptoTransform.TransformFinalBlock(array, 0, array.Length);
        }

        public static IEnumerable<byte> Encrypt(this SymmetricAlgorithm symmertric, IEnumerable<byte> toEncryptData, IEnumerable<byte> key, IEnumerable<byte> iv)
        {
            symmertric.Key = key.ToArray();
            symmertric.IV = iv.ToArray();
            return symmertric.Encrypt(toEncryptData);
        }

        private static IEnumerable<byte> Decrypt(this SymmetricAlgorithm symmertric, IEnumerable<byte> encryptedData)
        {
            ICryptoTransform cryptoTransform = symmertric.CreateDecryptor(symmertric.Key, symmertric.IV);
            byte[] array = encryptedData.ToArray();
            return cryptoTransform.TransformFinalBlock(array, 0, array.Length);
        }

        public static IEnumerable<byte> Decrypt(this SymmetricAlgorithm symmertric, IEnumerable<byte> encryptedData, IEnumerable<byte> key, IEnumerable<byte> iv)
        {
            symmertric.Key = key.ToArray();
            symmertric.IV = iv.ToArray();
            return symmertric.Decrypt(encryptedData);
        }

        internal static IEnumerable<byte> EncryptSymmetric(this IEnumerable<byte> toEncryptData, IEnumerable<byte> key, IEnumerable<byte> iv, SymmetricAlgorithm symmertric)
        {
            return symmertric.Encrypt(toEncryptData, key, iv);
        }

        internal static IEnumerable<byte> DecryptSymmetric(this IEnumerable<byte> encryptedData, IEnumerable<byte> key, IEnumerable<byte> iv, SymmetricAlgorithm symmertric)
        {
            return symmertric.Decrypt(encryptedData, key, iv);
        }

        public static IEnumerable<byte> EncryptSEED(this IEnumerable<byte> data, IEnumerable<byte> seedKey, bool cbcPad = true)
        {
            return SEED.Encrypt(data.ToArray(), seedKey.ToArray(), cbcPad);
        }

        public static IEnumerable<byte> DecryptSEED(this IEnumerable<byte> data, IEnumerable<byte> seedKey, bool cbcPad = true)
        {
            return SEED.Decrypt(data.ToArray(), seedKey.ToArray(), cbcPad);
        }
    }
}
