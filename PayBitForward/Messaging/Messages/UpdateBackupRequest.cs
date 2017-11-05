using PayBitForward.Models;
using System;
using System.Collections.Generic;

namespace PayBitForward.Messaging
{
    public class UpdateBackupRequest : Message
    {
        /// <summary>
        /// Contains the list of content that has been added or removed
        /// </summary>
        public List<ContentChange> ContentChanges { get; set; }

        /// <summary>
        /// Contains the list of clients that have been added or removed
        /// </summary>
        public List<ClientChange> ClientChanges { get; set; }

        public UpdateBackupRequest(MessageType messageId, Guid convoId, List<ContentChange> contentChanges, List<ClientChange> clientChanges) : base(messageId, convoId)
        {
            ContentChanges = contentChanges;
            ClientChanges = clientChanges;
        }
    }
}
