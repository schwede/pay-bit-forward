using PayBitForward.Models;
using System;
using System.Collections.Generic;

namespace PayBitForward.Messaging
{
    public class ContentListReply : Message
    {
        /// <summary>
        /// A list of all available content to download
        /// </summary>
        public List<Content> ContentList { get; set; }

        public ContentListReply(MessageType messageId, Guid convoId, List<Content> contentList) : base(messageId, convoId)
        {
            ContentList = contentList;
        }
    }
}
