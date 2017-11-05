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

        public UpdateBackupRequest(Guid senderId, Guid convoId, int mesgCount, List<ContentChange> contentChanges, List<ClientChange> clientChanges) : base(senderId, convoId, mesgCount)
        {
            MessageId = MessageType.UPDATE_BACKUP_REQUEST;
            ContentChanges = contentChanges;
            ClientChanges = clientChanges;
        }
    }
}
