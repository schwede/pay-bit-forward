using System;

namespace PayBitForward.Messaging
{
    public class SelectContentRequest : Message
    {
        /// <summary>
        /// Specifies the hash of the complete file for verification and identification
        /// </summary>
        public Byte[] ContentHash { get; set; }
        public SelectContentRequest(MessageType messageId, Guid convoId, Byte[] contentHash) : base(messageId, convoId)
        {
            ContentHash = contentHash;
        }
    }
}
