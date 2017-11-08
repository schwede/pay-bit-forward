using System;

namespace PayBitForward.Messaging
{
    public class Acknowledge : Message
    {
        /// <summary>
        /// Status information
        /// </summary>
        public string StatusInformation { get; set; }

        public Acknowledge(Guid senderId, Guid convoId, int mesgCount, string statusInformation) : base(senderId, convoId, mesgCount)
        {
            MessageId = MessageType.ACKNOWLEDGE;
            StatusInformation = statusInformation;
        }
    }
}
