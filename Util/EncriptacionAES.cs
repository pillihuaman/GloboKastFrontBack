using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Util
{    public static class EncriptacionAES
    {
        public static string GenerarKey()
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 32)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string Encriptar(string texto, string key)
        {
            RijndaelManaged aesEncryption = new RijndaelManaged();
            aesEncryption.KeySize = 256;
            aesEncryption.BlockSize = 128;
            aesEncryption.Mode = CipherMode.ECB;
            aesEncryption.Padding = PaddingMode.PKCS7;
            aesEncryption.Key = ASCIIEncoding.UTF8.GetBytes(key);
            byte[] plainText = ASCIIEncoding.UTF8.GetBytes(texto);
            ICryptoTransform crypto = aesEncryption.CreateEncryptor();
            byte[] cipherText = crypto.TransformFinalBlock(plainText, 0, plainText.Length);
            return Convert.ToBase64String(cipherText);
        }

        public static string Desencriptar(string texto, string key)
        {
            try
            {
              return Encriptar( texto,  key);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
