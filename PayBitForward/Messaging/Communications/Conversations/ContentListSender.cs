using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PayBitForward.Models;

namespace PayBitForward.Messaging
{
    public class ContentListSender : Converser
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(ContentListSender));

        private string Query { get; set; }

        public delegate void SearchResults(List<Content> list);

        public event SearchResults OnSearchResults;

        public ContentListSender(Guid convoId, string query) : base(convoId)
        {
            Query = query;
        }

        protected override void Run()
        {
            Log.Debug("Started sender");

            var persistence = new PersistenceManager();

            // Only try three times
            for(var i = 0; i < 3; i++)
            {
                if (Token.IsCancellationRequested)
                {
                    Log.Debug("Received request to stop");
                    break;
                }

                Thread.Sleep(250);
                var req = new ContentListRequest(Guid.NewGuid(), ConversationId, 0, Query);
                RaiseSendMessageEvent(req);

                while (IncomingMessages.Count > 0)
                {
                    Message mesg;
                    if (IncomingMessages.TryDequeue(out mesg))
                    {
                       if(mesg.MessageId == MessageType.CONTENT_LIST_REPLY)
                        {                            
                            var reply = (ContentListReply)mesg;

                            foreach(var content in reply.ContentList)
                            {
                                // TODO This is read the file on every call
                                persistence.WriteContent(content, PersistenceManager.StorageType.Remote);
                            }

                            OnSearchResults?.Invoke(reply.ContentList);

                            CancelSource.Cancel();
                            break;
                        }
                    }
                }
            }

            RaiseEndConversationEvent();
        }
    }
}
