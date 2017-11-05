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

        public ContentListReply(Guid senderId, Guid convoId, int mesgCount, List<Content> contentList) : base(senderId, convoId, mesgCount)
        {
            MessageId = MessageType.CONTENT_LIST_REPLY;
            ContentList = contentList;
        }
    }
}
