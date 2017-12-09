using System;
using System.Collections.Generic;

namespace PayBitForward.Messaging
{
    public class ChunkReply : Message
    {
        /// <summary>
        /// Contains the raw data for that chunk of the file
        /// </summary>
        public byte[] ChunkData { get; set; }

        /// <summary>
        /// Specifies the byte index so the data can be ordered properly
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Specifies the byte array that includes the cryptographic signature of the ChunkData
        /// </summary>
        public byte[] Signature { get; set; }

        public ChunkReply(Guid senderId, Guid convoId, int mesgCount, byte[] chunkData, int index, byte[] signature) : base(senderId, convoId, mesgCount)
        {
            MessageId = MessageType.CHUNK_REPLY;
            ChunkData = chunkData;
            Index = index;
            Signature = signature;
        }
    }
}
