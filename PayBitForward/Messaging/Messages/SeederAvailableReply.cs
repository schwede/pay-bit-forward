using System;

namespace PayBitForward.Messaging
{
    public class SeederAvailableReply : Message
    {
        /// <summary>
        /// State that describes the seeder’s readiness to server content
        /// </summary>
        public byte ReadyState { get; set; }

        public SeederAvailableReply(Guid senderId, Guid convoId, int mesgCount, byte readyState) : base(senderId, convoId, mesgCount)
        {
            MessageId = MessageType.SEEDER_AVAILABLE_REQUEST;
            ReadyState = readyState;
        }
    }
}
