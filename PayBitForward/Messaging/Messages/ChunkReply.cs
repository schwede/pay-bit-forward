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

        public ChunkReply(MessageType messageId, Guid convoId, Byte[] chunkData) : base(messageId, convoId)
        {
            ChunkData = chunkData;
        }
    }
}
