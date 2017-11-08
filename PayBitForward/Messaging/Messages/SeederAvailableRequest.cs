using System;

namespace PayBitForward.Messaging
{
    public class SeederAvailableRequest : Message
    {
        /// <summary>
        /// Check with seeder to make sure they have the content and are available for connections
        /// </summary>
        public byte[] ContentHash { get; set; }

        public SeederAvailableRequest(Guid senderId, Guid convoId, int mesgCount, byte[] contentHash) : base(senderId, convoId, mesgCount)
        {
            MessageId = MessageType.SEEDER_AVAILABLE_REQUEST;
            ContentHash = contentHash;
        }
    }
}
