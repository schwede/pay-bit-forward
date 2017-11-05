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
        /// Specifies the hash of the complete file for verification and identification 
        /// </summary>
        public Byte[] ContentHash { get; set; }

        /// <summary>
        /// Specifies the requester so the seeder knows the origin
        /// </summary>
        public Guid ProcessID { get; set; }

        public ChunkRequest(MessageType messageId, Guid convoId, int index, Byte[] contentHash, Guid processID) : base(messageId, convoId)
        {
            Index = index;
            ContentHash = contentHash;
            ProcessID = processID;
        }
    }
}
