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
            var chunkReq = new Message()
            {
                SenderId = System.Guid.NewGuid(),
                ConversationId = System.Guid.NewGuid(),
                MessageId = MessageType.CHUNK_REQUEST,
                MessageCount = 0
            };

            var converter = new JsonMessageConverter<Message>();

            var blob = System.Text.Encoding.UTF8.GetString(converter.Serialize(chunkReq));

            var expected = string.Format("{{\"SenderId\":\"{0}\",\"MessageId\":{1},\"ConversationId\":\"{2}\",\"MessageCount\":{3}}}",
                chunkReq.SenderId.ToString(),
                (int)chunkReq.MessageId,
                chunkReq.ConversationId.ToString(),
                chunkReq.MessageCount);
            Assert.AreEqual(expected, blob);
        }

        [Test]
        public void TestDeSerialize()
        {
            var chunkReq = new Message()
            {
                SenderId = System.Guid.NewGuid(),
                ConversationId = System.Guid.NewGuid(),
                MessageId = MessageType.CHUNK_REQUEST,
                MessageCount = 0
            };

            var converter = new JsonMessageConverter<Message>();

            var blob = string.Format("{{\"SenderId\":\"{0}\",\"MessageId\":{1},\"ConversationId\":\"{2}\",\"MessageCount\":{3}}}",
                chunkReq.SenderId.ToString(),
                (int)chunkReq.MessageId,
                chunkReq.ConversationId.ToString(),
                chunkReq.MessageCount);

            var message = converter.DeSerialize(System.Text.Encoding.UTF8.GetBytes(blob));

            Assert.AreEqual(chunkReq.SenderId, message.SenderId);
            Assert.AreEqual(chunkReq.MessageId, message.MessageId);
            Assert.AreEqual(chunkReq.ConversationId, message.ConversationId);
            Assert.AreEqual(chunkReq.MessageCount, message.MessageCount);
        }
    }
}
