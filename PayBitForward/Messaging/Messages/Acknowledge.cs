using System;

namespace PayBitForward.Messaging
{
    public class Acknowledge : Message
    {
        /// <summary>
        /// Status information
        /// </summary>
        public string StatusInformation { get; set; }

        public Acknowledge(MessageType messageId, Guid convoId, string statusInformation) : base(messageId, convoId)
        {
            StatusInformation = statusInformation;
        }
    }
}
