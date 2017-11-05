using System;

namespace PayBitForward.Messaging
{
    public class Message
    {
        public Guid SenderId { get; set; }

        public MessageType MessageId { get; set; }

        public Guid ConversationId { get; set; }

        public int MessageCount { get; set; }
    }
}
