﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace _2_Praktinis
{
    public class AES
    {
        public static string EncryptString(string key, string plainText, string mode)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.ASCII.GetBytes(Get128BitString(key));
                aes.IV = iv;
                if(mode == "ECB")
                {
                    aes.Mode = CipherMode.ECB;
                }
                if(mode == "CBC")
                {
                    aes.Mode = CipherMode.CBC;
                }
                if(mode == "OFB")
                {
                    aes.Mode = CipherMode.OFB;
                }
                if(mode == "CFB")
                {
                    aes.Mode = CipherMode.CFB;
                }
                if(mode == "CTS")
                {
                    aes.Mode = CipherMode.CTS;
                }

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string key, string cipherText, string mode)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Get128BitString(key));
                aes.IV = iv;
                if (mode == "ECB")
                {
                    aes.Mode = CipherMode.ECB;
                }
                if (mode == "CBC")
                {
                    aes.Mode = CipherMode.CBC;
                }
                if (mode == "OFB")
                {
                    aes.Mode = CipherMode.OFB;
                }
                if (mode == "CFB")
                {
                    aes.Mode = CipherMode.CFB;
                }
                if (mode == "CTS")
                {
                    aes.Mode = CipherMode.CTS;
                }
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        public static string Get128BitString(string keyToConvert)
        {
            StringBuilder b = new StringBuilder();
            for (int i = 0; i < 16; i++)
            {
                b.Append(keyToConvert[i % keyToConvert.Length]);
            }
            keyToConvert = b.ToString();

            return keyToConvert;
        }
    }
}
