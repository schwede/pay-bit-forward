using System;

namespace PayBitForward.Messaging
{
    public class ContentListRequest : Message
    {
        /// <summary>
        /// Get a list of all the content that at least one seeder can provide.
        /// </summary>
        public Guid ProcessID { get; set; }

        /// <summary>
        /// String to search content by
        /// </summary>
        public string ContentQuery { get; set; }

        public ContentListRequest(MessageType messageId, Guid convoId, Guid processId, string contentQuery) : base(messageId, convoId)
        {
            ProcessID = processId;
            ContentQuery = contentQuery;
        }
    }
}
