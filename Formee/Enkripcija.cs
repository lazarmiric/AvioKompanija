using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Formee
{
    public class Enkripcija
    {
        private Enkripcija()
        {
        }

        private static Enkripcija instance;
        public static Enkripcija Instance
        {
            get
            {
                if (instance == null) instance = new Enkripcija();
                return instance;
            }
        }

        string hash = "lazar";
        public string encrypt(string sifra)
        {
            string enkriptovan = "";
            byte[] data = UTF8Encoding.UTF8.GetBytes(sifra);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    enkriptovan = Convert.ToBase64String(results, 0, results.Length);
                }
            }
            return enkriptovan;
        }
        public string decrypt(string sifra)
        {
            string enkriptovan = "";
            byte[] data = Convert.FromBase64String(sifra);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                { 
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    enkriptovan = UTF8Encoding.UTF8.GetString(results);
                }
            }
            return enkriptovan;
        }
    }
}
