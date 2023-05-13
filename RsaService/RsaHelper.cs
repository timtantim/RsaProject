using System.IO;
using System;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System.ComponentModel;
using System.Text;

namespace RsaProject.RsaService
{
    public class RsaHelper
    {
        private static RsaHelper _instance;//存放實例字段
        private static readonly object _lock= new object();

        private RSACryptoServiceProvider _privateKey;
        private RSACryptoServiceProvider _publicKey;

        public static RsaHelper Instance(){
            if (_instance == null) {
                lock (_lock) {
                    if (_instance == null)
                    {
                        _instance= new RsaHelper();
                    }
                }
            }
            return _instance;
        }
        public RsaHelper()
        {
            string public_pem = @"C:\Users\User\source\repos\RsaProject\RsaKey\rsa.public";
            string private_pem = @"C:\Users\User\source\repos\RsaProject\RsaKey\rsa.private";


            _publicKey = GetPublicKeyFromPemFile(public_pem);
            _privateKey = GetPrivateKeyFromPemFile(private_pem);
        }
        public static RSACryptoServiceProvider GetPrivateKeyFromPemFile(string filePath)
        {
            using (TextReader privateKeyTextReader = new StringReader(File.ReadAllText(filePath)))
            {
                AsymmetricCipherKeyPair readKeyPair = (AsymmetricCipherKeyPair)new PemReader(privateKeyTextReader).ReadObject();

                RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)readKeyPair.Private);
                RSACryptoServiceProvider csp = new RSACryptoServiceProvider();// cspParams);
                csp.ImportParameters(rsaParams);
                return csp;
            }
        }

        public static RSACryptoServiceProvider GetPublicKeyFromPemFile(String filePath)
        {
            using (TextReader publicKeyTextReader = new StringReader(File.ReadAllText(filePath)))
            {
                RsaKeyParameters publicKeyParam = (RsaKeyParameters)new PemReader(publicKeyTextReader).ReadObject();

                RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaKeyParameters)publicKeyParam);

                RSACryptoServiceProvider csp = new RSACryptoServiceProvider();// cspParams);
                csp.ImportParameters(rsaParams);
                return csp;
            }
        }

        public string Encrypt(string text) {
            var encryptBytes= _publicKey.Encrypt(Encoding.UTF8.GetBytes(text),false);    
            return Convert.ToBase64String(encryptBytes);
        }
        public string Decrypt(string encrypted)
        {
            var decryptBytes = _privateKey.Decrypt(Convert.FromBase64String(encrypted), false);
            return Encoding.UTF8.GetString(decryptBytes);
        }
    }
}
