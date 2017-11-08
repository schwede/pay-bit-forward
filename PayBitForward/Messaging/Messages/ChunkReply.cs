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

        public ChunkReply(Guid senderId, Guid convoId, int mesgCount, byte[] chunkData, int index) : base(senderId, convoId, mesgCount)
        {
            MessageId = MessageType.CHUNK_REPLY;
            ChunkData = chunkData;
            Index = index;
        }
    }
}
