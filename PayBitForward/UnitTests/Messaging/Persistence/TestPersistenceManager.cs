using NUnit.Framework;
using System;
using System.Linq;
using PayBitForward.Messaging;
using PayBitForward.Models;

namespace UnitTests.Messaging.Persistence
{
    [TestFixture]
    public class TestPersistenceManager
    {
        [Test]
        public void TestReadAndWriteContent()
        {
            var persister = new PersistenceManager();
            
            var content = new Content()
            {
                ContentHash = new byte[] { 0xBE, 0xEF },
                ByteSize = 1024,
                Description = "Test file",
                FileName = "data.txt",
                LocalPath = ".",
                Host = "127.0.0.1",
                Port = 5002
            };

            var contentList = persister.ReadContent();

            Assert.AreEqual(0, contentList.Count());

            persister.WriteContent(content);

            contentList = persister.ReadContent();

            Assert.AreEqual(1, contentList.Count());
            var storedContent = contentList.First();

            Assert.AreEqual(content.ContentHash, storedContent.ContentHash);
            Assert.AreEqual(content.ByteSize, storedContent.ByteSize);
            Assert.AreEqual(content.Description, storedContent.Description);
            Assert.AreEqual(content.FileName, storedContent.FileName);
            Assert.AreEqual(content.LocalPath, storedContent.LocalPath);
            Assert.AreEqual(content.Host, storedContent.Host);
            Assert.AreEqual(content.Port, storedContent.Port);
        }
    }
}
