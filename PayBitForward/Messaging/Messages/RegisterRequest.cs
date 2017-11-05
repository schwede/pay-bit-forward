using System;

namespace PayBitForward.Messaging
{
    public class RegisterRequest : Message
    {
        public RegisterRequest(MessageType messageId, Guid convoId) : base(messageId, convoId)
        {
        }
    }
}
