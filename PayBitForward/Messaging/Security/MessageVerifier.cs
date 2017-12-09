using System;
using System.Security.Cryptography;



namespace PayBitForward.Messaging
{
    public class MessageVerifier
    {
        public static byte[] CreateSignature(byte[] data, RSAParameters rsaParams)
        {
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            provider.ImportParameters(rsaParams);

            RSAPKCS1SignatureFormatter formatter = new RSAPKCS1SignatureFormatter(provider);

            formatter.SetHashAlgorithm("SHA2");

            return provider.SignData(data, "SHA256");
        }

        public static bool CheckSignature(byte[] data, byte[] sig, RSAParameters rsaParams)
        {
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            provider.ImportParameters(rsaParams);

            RSAPKCS1SignatureDeformatter formatter = new RSAPKCS1SignatureDeformatter(provider);
            formatter.SetHashAlgorithm("SHA256");

            return formatter.VerifySignature(Hash(data), sig);
        }

        public static byte[] Hash(byte[] data)
        {
            using (var sha2 = new SHA256Managed())
            {
                return sha2.ComputeHash(data);
            }            
        }
    }
}
