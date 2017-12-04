using System;
using System.Threading;
using PayBitForward.Messaging;

namespace PayBitForward.Messaging
{
    public class RegisterContentSender : Converser
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(RegisterContentSender));

        private int MessageCount { get; set; }

        private Message Request { get; set; }

        public RegisterContentSender(Guid convoId, RegisterContentRequest req) : base(convoId)
        {
            Request = req;
        }

        protected override void Run()
        {
            Log.Debug("Started sender");

            // Only try three times
            for (var i = 0; i < 3; i++)
            {
                if (Token.IsCancellationRequested)
                {
                    Log.Debug("Received request to stop");
                    break;
                }

                RaiseSendMessageEvent(Request);
                MessageCount++;

                while (IncomingMessages.Count > 0)
                {
                    Message mesg;
                    if (IncomingMessages.TryDequeue(out mesg))
                    {
                        if (mesg.MessageId == MessageType.ACKNOWLEDGE)
                        {
                            var ack = (Acknowledge)mesg;

                            Log.Info(string.Format("Recevied acknowledge with status: {0}", ack.StatusInformation));
                            CancelSource.Cancel();
                            break;
                        }
                    }
                }

                Thread.Sleep(250);
            }

            RaiseEndConversationEvent();
        }
    }
}
