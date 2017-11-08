using System;

namespace PayBitForward.Messaging
{
    public class SelectContentRequest : Message
    {
        /// <summary>
        /// Specifies the hash of the complete file for verification and identification
        /// </summary>
        public byte[] ContentHash { get; set; }

        public SelectContentRequest(Guid senderId, Guid convoId, int mesgCount, byte[] contentHash) : base(senderId, convoId, mesgCount)
        {
            ContentHash = contentHash;
        }
    }
}
