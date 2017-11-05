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

        public SelectContentReply(MessageType messageId, Guid convoId, List<SeederInfo> seederList) : base(messageId, convoId)
        {
            SeederList = seederList;
        }
    }
}
