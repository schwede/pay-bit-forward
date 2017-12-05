using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PayBitForward.Messaging
{
    public delegate IConverser RequestNewConversation(Message mesg);

    public class MessageRouter
    { 
        public INetworkCommunicator Communicator { get; private set; }

        private Dictionary<Guid, IConverser> Conversers = new Dictionary<Guid, IConverser>();

        private Dictionary<Guid, IPEndPoint> EndPoints = new Dictionary<Guid, IPEndPoint>();

        private List<Guid> DeadConversations = new List<Guid>();

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(MessageRouter));
        private readonly object locker = new object();

        public MessageRouter(INetworkCommunicator comm)
        {
            Log.Debug("Initializing message routing table");

            Communicator = comm;
            Communicator.OnEnvelope += HandleEnvelope;
        }

        public void AddConversation(IConverser converser, IPEndPoint endPoint)
        {
            Log.DebugFormat("Adding conversation with endpoint {0}:{1} and id {2}", endPoint.Address, endPoint.Port, converser.ConversationId);
            converser.OnMessageToSend += HandleMessage;
            converser.OnConversationOver += HandleConversationOver;

            Conversers.Add(converser.ConversationId, converser);
            EndPoints.Add(converser.ConversationId, endPoint);

            converser.Start();
        }

        public void EndAllConversations()
        {
            foreach(var c in Conversers)
            {
                c.Value.Stop();
                DeadConversations.Add(c.Key);
            }

            Conversers.Clear();
        }

        private void HandleEnvelope(Envelope env)
        {
            if(DeadConversations.Contains(env.MessageContent.ConversationId))
            {
                Log.Info(string.Format("Conversation with id {0} has already ended", env.MessageContent.ConversationId));
                return;
            }
            
            if (!Conversers.ContainsKey(env.MessageContent.ConversationId))
            {
                Log.DebugFormat("Conversation with id {0} does not exist; requesting new conversation worker from app", env.MessageContent.ConversationId);
                var c = OnConversationRequest?.Invoke(env.MessageContent);

                // Make sure we ignore an invalid response
                if (c == null)
                {
                    return;
                }

                AddConversation(c, env.EndPoint);
            }            

            Conversers[env.MessageContent.ConversationId].HandleMessage(env.MessageContent);
        }

        private void HandleMessage(IConverser converser, Message mesg)
        {
            if(EndPoints.ContainsKey(converser.ConversationId))
            {
                var env = new Envelope(mesg, EndPoints[converser.ConversationId]);
                Communicator.SendEnvelope(env);
            }
        }

        private void HandleConversationOver(IConverser converser)
        {
            Log.DebugFormat("Conversation with id {0} signaled that it is finished; stopping conversation", converser.ConversationId);
            if(Conversers.ContainsKey(converser.ConversationId))
            {
                Conversers[converser.ConversationId].Stop();

                Conversers.Remove(converser.ConversationId);
                EndPoints.Remove(converser.ConversationId);
                DeadConversations.Add(converser.ConversationId);
            }
        }

        public event RequestNewConversation OnConversationRequest;
    }
}
