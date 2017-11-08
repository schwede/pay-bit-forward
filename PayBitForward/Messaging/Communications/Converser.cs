using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace PayBitForward.Messaging
{
    public class Converser : IConverser
    {
        public Guid ConversationId { get; set; }

        protected CancellationTokenSource CancelSource { get; set; } = new CancellationTokenSource();

        protected CancellationToken Token { get; set; }

        protected ConcurrentQueue<Message> IncomingMessages { get; set; } = new ConcurrentQueue<Message>();

        protected Thread WorkerThread { get; set; }

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Converser));

        public Converser(Guid convoId)
        {
            ConversationId = convoId;

            Token = CancelSource.Token;
            CancelSource.Cancel();
        }

        public virtual void Start()
        {
            Log.Debug("Attempting to start conversation worker");

            // Make sure the thread does not start twice
            if (Token.IsCancellationRequested)
            {
                CancelSource = new CancellationTokenSource();
                Token = CancelSource.Token;

                try
                {
                    WorkerThread = new Thread(Run);
                    WorkerThread.Start();
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                }
            }
        }

        public virtual void Stop()
        {
            Log.Debug("Requesting thread to stop");
            CancelSource.CancelAfter(500);
            // WorkerThread.Join();
        }

        public virtual void HandleMessage(Message mesg)
        {
            IncomingMessages.Enqueue(mesg);
        }

        public event SendMessage OnMessageToSend;

        public event EndConversation OnConversationOver;

        protected void RaiseEndConversationEvent()
        {
            Log.DebugFormat("Signalling end of conversation with id {0}", ConversationId);
            OnConversationOver?.Invoke(this);
        }

        protected void RaiseSendMessageEvent(Message mesg)
        {
            OnMessageToSend?.Invoke(this, mesg);
        }

        protected virtual void Run()
        {
            throw new NotImplementedException();
        }
    }
}
