using System;

namespace PayBitForward.Messaging
{
    public class Message
    {
        public Guid ConversationId { get; set; }

        public MessageType MessageId { get; set; }

        public Message(MessageType messageId, Guid convoId)
        {
            ConversationId = convoId;
            MessageId = messageId;
        }
    }
}
