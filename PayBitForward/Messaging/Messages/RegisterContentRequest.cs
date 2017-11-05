using System;

namespace PayBitForward.Messaging
{
    public class RegisterContentRequest : Message
    {
        /// <summary>
        /// Name of the file being added to the content list
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Size, in bytes, of the file being added
        /// </summary>
        public int FileSize { get; set; }

        /// <summary>
        /// Hash of file being added
        /// </summary>
        public Byte[] Hash { get; set; }

        /// <summary>
        /// Specifies the requester so the registry knows the origin
        /// </summary>
        public Guid ProcessID { get; set; }

        public RegisterContentRequest(MessageType messageId, Guid convoId, string name, int fileSize, Byte[] hash, Guid processID) : base(messageId, convoId)
        {
            Name = name;
            FileSize = fileSize;
            Hash = hash;
            ProcessID = processID;
        }
    }
}
