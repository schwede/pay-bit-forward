using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PayBitForward.Messaging
{
    public class ContentListSender : Converser
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(ContentListSender));

        public ContentListSender(Guid convoId) : base(convoId)
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

                Thread.Sleep(100);
                var req = new ContentListRequest(Guid.NewGuid(), ConversationId, 0, "");
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
                                persistence.WriteContent(content);
                            }

                            CancelSource.Cancel();
                            RaiseEndConversationEvent();
                            break;
                        }
                    }
                }
            }
        }
    }
}
