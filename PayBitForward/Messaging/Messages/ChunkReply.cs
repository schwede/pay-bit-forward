using System;
using System.Collections.Generic;

namespace PayBitForward.Messaging
{
    public class ChunkReply : Message
    {
        /// <summary>
        /// Contains the raw data for that chunk of the file
        /// </summary>
        public Byte[] ChunkData { get; set; }

        public ChunkReply(Guid senderId, Guid convoId, int mesgCount, Byte[] chunkData) : base(senderId, convoId, mesgCount)
        {
            MessageId = MessageType.CHUNK_REPLY;
            ChunkData = chunkData;
        }
    }
}
