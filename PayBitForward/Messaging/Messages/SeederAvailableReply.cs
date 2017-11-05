using System;

namespace PayBitForward.Messaging
{
    public class SeederAvailableReply : Message
    {
        /// <summary>
        /// State that describes the seeder’s readiness to server content
        /// </summary>
        public Byte ReadyState { get; set; }

        public SeederAvailableReply(MessageType messageId, Guid convoId, Byte readyState) : base(messageId, convoId)
        {
            ReadyState = readyState;
        }
    }
}
