using NUnit.Framework;
using PayBitForward.Messaging;

namespace UnitTests
{
    [TestFixture]
    public class TestJsonMessageConverter
    {
        [Test]
        public void TestSerialize()
        {
            var guid = System.Guid.NewGuid();
            var chunkReq = new Message(MessageType.CHUNK_REQUEST, guid);

            var converter = new JsonMessageConverter<Message>();

            var blob = System.Text.Encoding.UTF8.GetString(converter.Serialize(chunkReq));

            var expected = string.Format("{{\"ConversationId\":\"{0}\",\"MessageId\":{1}}}", guid.ToString(), (int)MessageType.CHUNK_REQUEST);
            Assert.AreEqual(expected, blob);
        }

        [Test]
        public void TestDeSerialize()
        {
            var guid = System.Guid.NewGuid();

            var converter = new JsonMessageConverter<Message>();

            var blob = string.Format("{{ \"ConversationId\" : \"{0}\", \"MessageId\" : {1} }}", guid.ToString(), (int)MessageType.CHUNK_REQUEST);
            var message = converter.DeSerialize(System.Text.Encoding.UTF8.GetBytes(blob));

            Assert.AreEqual(guid, message.ConversationId);
            Assert.AreEqual(MessageType.CHUNK_REQUEST, message.MessageId);
        }
    }
}
