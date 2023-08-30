using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JuegoOlimpico.Transversal.Common
{
    public class Seguridad
    {
        public static string Encriptar(string textoEncriptar)
        {
            return Encriptar(textoEncriptar, Constantes.passBase, Constantes.saltValue, Constantes.hasAlgorithm, Constantes.passwordIterations, Constantes.initVector, Constantes.keySize);

        }
        /// <summary>
        /// Método para encriptar un texto plano usando el algoritmo (Rijndael)
        /// </summary>
        /// <returns>Texto encriptado</returns>
        public static string Encriptar(string textoEncriptar,
          string passBase, string saltValue, string hashAlgorithm,
          int passwordIterations, string initVector, int keySize)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(textoEncriptar);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passBase,
              saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged()
            {
                Mode = CipherMode.CBC
            };
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes,
              initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor,
             CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string cipherText = Convert.ToBase64String(cipherTextBytes);
            return cipherText;
        }

        public static string Desencriptar(string textoDesencriptar)
        {
            // return Desencriptar(textoDesencriptar, "pass75dc@avz10", "h@drsl", "MD5",1, "@1B2c3D4e5F6g7H8", 128);
            return Desencriptar(textoDesencriptar, Constantes.passBase, Constantes.saltValue, Constantes.hasAlgorithm, Constantes.passwordIterations, Constantes.initVector, Constantes.keySize);
        }
        /// <summary>
        /// Método para desencriptar un texto encriptado (Rijndael)
        /// </summary>
        /// <returns>Texto desencriptado</returns>
        public static string Desencriptar(string textoDesencriptar, string passBase,
          string saltValue, string hashAlgorithm, int passwordIterations,
          string initVector, int keySize)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] cipherTextBytes = Convert.FromBase64String(textoDesencriptar);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passBase,
              saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged()
            {
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.CBC
            };
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes,
              initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor,
              CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0,
              plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            string plainText = Encoding.UTF8.GetString(plainTextBytes, 0,
              decryptedByteCount);
            return plainText;
        }

        public static bool ValidateEMail(string email)
        {
            if (email == null || email == "") return false;

            Regex oRegExp = new Regex(@"^[A-Za-z0-9_.\-]+@[A-Za-z0-9_\-]+\.([A-Za-z0-9_\-]+\.)*[A-Za-z][A-Za-z]+$", RegexOptions.IgnoreCase);
            return oRegExp.Match(email).Success;
        }
    }
}
