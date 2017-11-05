using System;

namespace PayBitForward.Messaging
{
    public class RegisterReply : Message
    {
        public RegisterReply(Guid senderId, Guid convoId, int mesgCount) : base(senderId, convoId, mesgCount)
        {
            MessageId = MessageType.REGISTER_REPLY;
        }
    }
}
