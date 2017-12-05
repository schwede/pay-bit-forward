using PayBitForward.Models;
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

        /// <summary>
        /// Discription of file
        /// </summary>
        public string Description { get; set; }

        public RegisterContentRequest()
        {

        }

        public RegisterContentRequest(Guid senderId, Guid convoId, int mesgCount, string filename, int filesize, Byte[] hash, string host, int port, string description) : base(senderId, convoId, mesgCount)
        {
            Console.WriteLine("Long constructor");
            MessageId = MessageType.REGISTER_CONTENT_REQUEST;
            Name = filename;
            FileSize = filesize;
            Hash = hash;
            Host = host;
            Port = port;
            Description = description;
        }

        public RegisterContentRequest(Guid senderId, Guid convoId, int mesgCount, Content content) : base(senderId, convoId, mesgCount)
        {
            Console.WriteLine("ContentConstructor");
            MessageId = MessageType.REGISTER_CONTENT_REQUEST;
            Name = content.FileName;
            FileSize = content.ByteSize;
            Hash = content.ContentHash;
            Host = content.Host;
            Port = content.Port;
            Description = content.Description;
        }
    }
}
