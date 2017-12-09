using NUnit.Framework;
using System.Security.Cryptography;
using PayBitForward.Messaging;

namespace UnitTests.Messaging.Persistence
{
    [TestFixture]
    public class TestDigitalSignature
    {

        [Test]
        public void TestSignature()
        {
            var provider = new RSACryptoServiceProvider();
            var provider2 = new RSACryptoServiceProvider();


            var parameters = provider.ExportParameters(true);
            var paramaters2 = provider2.ExportParameters(true);
            byte[] HashValue = { 59, 4, 248, 102, 77, 97, 142, 201, 210, 12, 224, 93, 25, 41, 100, 197, 213, 134, 130, 135 };

            byte[] signedHash = MessageVerifier.CreateSignature(HashValue, parameters);


            Assert.IsTrue(MessageVerifier.CheckSignature(HashValue, signedHash, parameters));
            Assert.IsFalse(MessageVerifier.CheckSignature(HashValue, signedHash, paramaters2));
        }
    }
}
