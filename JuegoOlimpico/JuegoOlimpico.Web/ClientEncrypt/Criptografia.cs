using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace JuegoOlimpico.Web.ClientEncrypt
{
    public class Criptografia
    {
        private readonly int BlockSize = 128;

        public string encriptar(string textoOriginal, string textoClave, string textoIV)
        {
            string textoEncriptado = string.Empty;

            byte[] clave = Encoding.UTF8.GetBytes(textoClave);
            byte[] iv = Encoding.UTF8.GetBytes(textoIV);

            using (RijndaelManaged algoritmoEncriptacion = new RijndaelManaged())
            {

                algoritmoEncriptacion.Key = clave;
                algoritmoEncriptacion.IV = iv;
                algoritmoEncriptacion.Mode = CipherMode.CBC;
                algoritmoEncriptacion.Padding = PaddingMode.PKCS7;
                algoritmoEncriptacion.FeedbackSize = BlockSize;

                ICryptoTransform encriptador = algoritmoEncriptacion.CreateEncryptor(algoritmoEncriptacion.Key, algoritmoEncriptacion.IV);

                using (MemoryStream flujoEnMemoria = new MemoryStream())
                {
                    using (CryptoStream criptoFlujo = new CryptoStream(flujoEnMemoria, encriptador, CryptoStreamMode.Write))
                    {
                        using (StreamWriter flujoEscritura = new StreamWriter(criptoFlujo))
                        {
                            flujoEscritura.Write(textoOriginal);
                        }
                    }

                    textoEncriptado = Convert.ToBase64String(flujoEnMemoria.ToArray());
                }
            }

            return textoEncriptado;
        }

        public string desEncriptar(string textoEncriptado, string textoClave, string textoIV)
        {
            string textoDesEncriptado = string.Empty;


            byte[] clave = Encoding.UTF8.GetBytes(textoClave);
            byte[] iv = Encoding.UTF8.GetBytes(textoIV);

            byte[] encriptado = Convert.FromBase64String(textoEncriptado);

            using (RijndaelManaged algoritmoEncriptacion = new RijndaelManaged())
            {

                algoritmoEncriptacion.Key = clave;
                algoritmoEncriptacion.IV = iv;
                algoritmoEncriptacion.Mode = CipherMode.CBC;
                algoritmoEncriptacion.Padding = PaddingMode.PKCS7;
                algoritmoEncriptacion.FeedbackSize = BlockSize;

                ICryptoTransform desEncriptador = algoritmoEncriptacion.CreateDecryptor(algoritmoEncriptacion.Key, algoritmoEncriptacion.IV);

                using (MemoryStream flujoEnMemoria = new MemoryStream(encriptado))
                {
                    using (CryptoStream criptoFlujo = new CryptoStream(flujoEnMemoria, desEncriptador, CryptoStreamMode.Read))
                    {
                        using (StreamReader flujoLectura = new StreamReader(criptoFlujo))
                        {
                            textoDesEncriptado = flujoLectura.ReadToEnd();
                        }
                    }
                }
            }

            return textoDesEncriptado;
        }

    }
}