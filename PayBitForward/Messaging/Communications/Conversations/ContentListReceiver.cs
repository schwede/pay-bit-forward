using System;
using System.Linq;
using System.Threading;
using PayBitForward.Models;

namespace PayBitForward.Messaging
{
    public class ContentListReceiver : Converser
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(ContentListReceiver));

        public ContentListReceiver(Guid convoId) : base(convoId)
        {

        }

        protected override void Run()
        {
            Log.Debug("Started sender");
            var persistence = new PersistenceManager();

            while (true)
            {
                if (Token.IsCancellationRequested)
                {
                    Log.Debug("Received request to stop");
                    return;
                }

                // Slow down busy loop
                Thread.Sleep(100);

                while (IncomingMessages.Count > 0)
                {
                    Message mesg;
                    if (IncomingMessages.TryDequeue(out mesg))
                    {
                        if (mesg.MessageId == MessageType.CONTENT_LIST_REQUEST)
                        {
                            var req = (ContentListRequest)mesg;
                            var availableContent = persistence.ReadContent();
                            var reply = new ContentListReply(Guid.NewGuid(), ConversationId, req.MessageCount + 1, availableContent.LocalContent);

                            if (req.ContentQuery != "")
                            {
                                // String match the filenames and descriptions for searching content
                                reply.ContentList = availableContent.LocalContent.Where(content => 
                                content.Description.ToLower().Contains(req.ContentQuery)
                                || content.FileName.ToLower().Contains(req.ContentQuery)).ToList();
                            }

                            Log.Info(string.Format("Sending list of {0} content items", reply.ContentList.Count()));
                            RaiseSendMessageEvent(reply);
                            RaiseEndConversationEvent();
                            break;
                        }
                    }
                }
            }
        }
    }
}
