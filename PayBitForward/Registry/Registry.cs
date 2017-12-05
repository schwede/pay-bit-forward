using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using PayBitForward.Messaging;
using PayBitForward.Models;
using System.Collections.Concurrent;

namespace Registry
{
    class Registry
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Registry));

        private UdpCommunicator Communicator { get; set; }

        private JsonMessageConverter Converter { get; set; }

        private MessageRouter Router { get; set; }

        private PersistenceManager Persistence { get; set; }

        public Registry()
        {
            Converter = new JsonMessageConverter();
            Communicator = new UdpCommunicator(new IPEndPoint(IPAddress.Any, 5000), Converter);
            Router = new MessageRouter(Communicator);
        }

        public void Start()
        {
            Log.Info("Starting Registry on port 5000");
            Communicator.Start();
            Router.OnConversationRequest += handleNewConversation;
            Console.ReadLine();
            Communicator.Stop();
        }

        static void Main(string[] args)
        {
            var app = new Registry();
            app.Start();
        }

        private IConverser handleNewConversation(Message msg)
        {
            Log.Debug("Handling a new conversation");
            switch(msg.MessageId)
            {
                case MessageType.REGISTER_CONTENT_REQUEST:
                    RegisterContentRequest req = (RegisterContentRequest)msg;
                    var content = new Content()
                    {
                        FileName = req.Name,
                        ContentHash = req.Hash,
                        ByteSize = req.FileSize,
                        Host = req.Host,
                        Port = req.Port,
                        Description = req.Description
                    };
                    Log.Info("Added " + req.Name);
                    return new RegisterContentReceiver(msg.ConversationId, content);
                case MessageType.CONTENT_LIST_REQUEST:
                    return new ContentListReceiver(msg.ConversationId);
                case MessageType.REGISTER_REQUEST:
                    break;
                default:
                    break;
            }
            return null;
        }
    }
}
