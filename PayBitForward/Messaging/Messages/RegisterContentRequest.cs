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
        public byte[] Hash { get; set; }

        public RegisterContentRequest(Guid senderId, Guid convoId, int mesgCount, string name, int fileSize, byte[] hash, Guid processID) : base(senderId, convoId, mesgCount)
        {
            MessageId = MessageType.REGISTER_CONTENT_REQUEST;
            Name = name;
            FileSize = fileSize;
            Hash = hash;
        }
    }
}
