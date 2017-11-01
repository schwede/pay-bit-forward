using System;

namespace PayBitForward.Messaging
{
    public class RegisterReply : Message
    {
        /// <summary>
        /// The new process ID given to the process by the registry
        /// </summary>
        public Guid ProcessID { get; set; }
        public RegisterReply(MessageType messageId, Guid convoId, Guid processID) : base(messageId, convoId)
        {
            ProcessID = processID;
        }
    }
}
