using System;
using System.Collections.Generic;

namespace PayBitForward.Messaging
{
    public class ChunkRequest : Message
    {
        /// <summary>
        /// Specifies the byte index so the data can be ordered properly
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Specifies the chunk size to send in bytes
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Specifies the hash of the complete file for verification and identification 
        /// </summary>
        public byte[] ContentHash { get; set; }

        public ChunkRequest(Guid senderId, Guid convoId, int mesgCount, int index, byte[] contentHash, int size) : base(senderId, convoId, mesgCount)
        {
            MessageId = MessageType.CHUNK_REQUEST;
            Index = index;
            ContentHash = contentHash;
            Size = size;
        }
    }
}
