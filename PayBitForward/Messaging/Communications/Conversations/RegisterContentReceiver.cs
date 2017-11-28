using System;
using PayBitForward.Messaging;
using PayBitForward.Models;

namespace Messaging.Communications.Conversations
{
    public class RegisterContentReceiver : Converser
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(RegisterContentReceiver));

        private Content ContentInfo { get; set; }

        private int MessageCount { get; set; }

        public RegisterContentReceiver(Guid convoId, Content contentInfo) : base(convoId)
        {
            ContentInfo = contentInfo;
        }

        protected override void Run()
        {
            Log.Debug("Started receiver");

            while (true)
            {
                if (Token.IsCancellationRequested)
                {
                    Log.Debug("Received request to stop");
                    return;
                }

                while (IncomingMessages.Count > 0)
                {
                    Message mesg;
                    if (IncomingMessages.TryDequeue(out mesg))
                    {
                        if (mesg.MessageId == MessageType.REGISTER_CONTENT_REQUEST)
                        {
                            var req = (RegisterContentRequest)mesg;

                            Log.Info(string.Format("Registering {0} with host {1} and port {2}", req.Name, req.Host, req.Port));

                            var ack = new Acknowledge(Guid.NewGuid(), ConversationId, req.MessageCount + 1, "Accepted register content request");
                            CancelSource.Cancel();
                            RaiseSendMessageEvent(ack);
                            RaiseEndConversationEvent();
                            break;
                        }
                    }
                }
            }
        }
    }
}
