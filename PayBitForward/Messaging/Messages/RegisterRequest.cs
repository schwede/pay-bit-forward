using System;

namespace PayBitForward.Messaging
{
    public class RegisterRequest : Message
    {
        public RegisterRequest(Guid senderId, Guid convoId, int mesgCount) : base(senderId, convoId, mesgCount)
        {
            MessageId = MessageType.REGISTER_REQUEST;
        }
    }
}
