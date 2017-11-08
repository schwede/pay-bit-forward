using System;
using NUnit.Framework;
using PayBitForward.Messaging;

namespace UnitTests
{
    [TestFixture]
    public class TestJsonMessageConverter
    {
        [Test]
        public void TestSerializeMessage()
        {
            var chunkReq = new Message()
            {
                SenderId = System.Guid.NewGuid(),
                ConversationId = System.Guid.NewGuid(),
                MessageId = MessageType.UNKNOWN,
                MessageCount = 0
            };

            var converter = new JsonMessageConverter();

            var blob = System.Text.Encoding.UTF8.GetString(converter.Serialize(chunkReq));

            var expected = string.Format("{{\"SenderId\":\"{0}\",\"MessageId\":{1},\"ConversationId\":\"{2}\",\"MessageCount\":{3}}}",
                chunkReq.SenderId.ToString(),
                (int)chunkReq.MessageId,
                chunkReq.ConversationId.ToString(),
                chunkReq.MessageCount);
            Assert.AreEqual(expected, blob);
        }

        [Test]
        public void TestDeSerializeAcknowledge()
        {
            var ack = new Acknowledge(Guid.NewGuid(), Guid.NewGuid(), 0, "Ack");

            var converter = new JsonMessageConverter();

            var blob = string.Format("{{\"SenderId\":\"{0}\",\"MessageId\":{1},\"ConversationId\":\"{2}\",\"MessageCount\":{3},\"StatusInformation\":\"{4}\"}}",
                ack.SenderId.ToString(),
                (int)ack.MessageId,
                ack.ConversationId.ToString(),
                ack.MessageCount,
                ack.StatusInformation);

            var message = (Acknowledge)converter.DeSerialize(System.Text.Encoding.UTF8.GetBytes(blob));

            Assert.AreEqual(ack.SenderId, message.SenderId);
            Assert.AreEqual(ack.MessageId, message.MessageId);
            Assert.AreEqual(ack.ConversationId, message.ConversationId);
            Assert.AreEqual(ack.MessageCount, message.MessageCount);
            Assert.AreEqual(ack.StatusInformation, message.StatusInformation);
        }

        [Test]
        public void TestDeSerializeMessage()
        {
            var chunkReq = new Message()
            {
                SenderId = System.Guid.NewGuid(),
                ConversationId = System.Guid.NewGuid(),
                MessageId = MessageType.UNKNOWN,
                MessageCount = 0
            };

            var converter = new JsonMessageConverter();

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
