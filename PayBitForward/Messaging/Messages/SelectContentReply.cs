using PayBitForward.Models;
using System;
using System.Collections.Generic;

namespace PayBitForward.Messaging
{
    public class SelectContentReply : Message
    {
        /// <summary>
        /// Provides a list of the seeders network addresses that can provide the content
        /// </summary>
        public List<SeederInfo> SeederList { get; set; }

        public SelectContentReply(Guid senderId, Guid convoId, int mesgCount, List<SeederInfo> seederList) : base(senderId, convoId, mesgCount)
        {
            MessageId = MessageType.SELECT_CONTENT_REPLY;
            SeederList = seederList;
        }
    }
}
