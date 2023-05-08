using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace RsaProject.RsaService
{
    public class RsaEncryption
    {
        private static RSACryptoServiceProvider csp=new RSACryptoServiceProvider(2048);
        private RSAParameters _privateKey;
        private RSAParameters _publicKey;
        public RsaEncryption()
        {
            _privateKey=csp.ExportParameters(true);
            _publicKey=csp.ExportParameters(false);
        }
        public string GetPublicKey() { 
            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));
            return sw.ToString();
        }
        public string Encrypt(string plainText)
        {
            csp = new RSACryptoServiceProvider();
            csp.ImportParameters(_publicKey);
            var data = Encoding.Unicode.GetBytes(plainText);
            var cypher = csp.Encrypt(data,false);
            return Convert.ToBase64String(cypher);
        }

        public string Decrypt(string cypherText)
        {
            var dataBytes=Convert.FromBase64String(cypherText);
            csp.ImportParameters(_privateKey);
            var plainText = csp.Decrypt(dataBytes,false);
            return Encoding.Unicode.GetString(plainText);
        }
    }
}
