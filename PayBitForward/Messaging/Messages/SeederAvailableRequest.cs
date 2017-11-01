using System;

namespace PayBitForward.Messaging
{
    public class SeederAvailableRequest : Message
    {
        /// <summary>
        /// Check with seeder to make sure they have the content and are available for connections
        /// </summary>
        public Byte[] ContentHash { get; set; }

        public SeederAvailableRequest(MessageType messageId, Guid convoId, Byte[] contentHash) : base(messageId, convoId)
        {
            ContentHash = contentHash;
        }
    }
}
