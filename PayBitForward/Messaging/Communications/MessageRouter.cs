using System;
using System.Collections.Generic;
using System.Net;

namespace PayBitForward.Messaging
{
    public class MessageRouter
    { 
        public INetworkCommunicator Communicator { get; private set; }

        private Dictionary<Guid, IConverser> Conversers;

        private Dictionary<Guid, IPEndPoint> EndPoints;

        public MessageRouter(INetworkCommunicator comm)
        {
            Communicator = comm;
            Communicator.OnEnvelope += HandleEnvelope;

            Conversers = new Dictionary<Guid, IConverser>();
            EndPoints = new Dictionary<Guid, IPEndPoint>();
        }

        public void AddConversation(IConverser converser, IPEndPoint endPoint)
        {
            converser.OnMessageToSend += HandleMessage;
            converser.OnConversationOver += HandleConversationOver;

            Conversers.Add(converser.ConversationId, converser);
            EndPoints.Add(converser.ConversationId, endPoint);

            converser.Start();
        }

        private void HandleEnvelope(Envelope env)
        {
            if(Conversers.ContainsKey(env.MessageContent.ConversationId))
            {
                Conversers[env.MessageContent.ConversationId].HandleMessage(env.MessageContent);
            }
            else
            {
                if (env.MessageContent.MessageCount == 0)
                {
                    // Start of new conversation
                    // Need to create converser
                }
            }
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
            Conversers.Remove(converser.ConversationId);
            EndPoints.Remove(converser.ConversationId);
        }
    }
}
