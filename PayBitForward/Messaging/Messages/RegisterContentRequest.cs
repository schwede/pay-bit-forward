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

        /// <summary>
        /// Host to connect to for downloading
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Port to connect to for downloading
        /// </summary>
        public int Port { get; set; }

        public RegisterContentRequest(Guid senderId, Guid convoId, int mesgCount, string name, int fileSize, byte[] hash, string host, int port) : base(senderId, convoId, mesgCount)
        {
            MessageId = MessageType.REGISTER_CONTENT_REQUEST;
            Name = name;
            FileSize = fileSize;
            Hash = hash;
            Host = host;
            Port = port;
        }
    }
}
