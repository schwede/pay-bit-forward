using System;

namespace PayBitForward.Messaging
{
    public class Message
    {
        public Guid SenderId { get; set; }

        public MessageType MessageId { get; set; }

        public Guid ConversationId { get; set; }

        public int MessageCount { get; set; }

        public Message()
        {

        }

        public Message(Guid senderId, Guid convoId, int mesgCount)
        {
            SenderId = senderId;
            MessageId = MessageType.UNKNOWN;
            ConversationId = convoId;
            MessageCount = mesgCount;
        }
    }
}
