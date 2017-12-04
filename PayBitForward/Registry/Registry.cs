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
        private UdpCommunicator Communicator { get; set; }

        private JsonMessageConverter Converter { get; set; }

        private MessageRouter Router { get; set; }

        private PersistenceManager Persistence { get; set; }

        private BlockingCollection<ContentRecord> ContentList { get; set; }

        private BlockingCollection<Guid> SeederList { get; set; }

        public Registry()
        {
            Converter = new JsonMessageConverter();
            Communicator = new UdpCommunicator(new IPEndPoint(IPAddress.Any, 5000), Converter);
            Router = new MessageRouter(Communicator);
        }

        public void Start()
        {
            Console.WriteLine("Starting Registry on port 5000");
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
            switch(msg.MessageId)
            {
                case MessageType.REGISTER_CONTENT_REQUEST:
                    RegisterContentRequest req = (RegisterContentRequest)msg;
                    var content = new Content()
                    {
                        FileName = req.Name,
                        ContentHash = req.Hash,
                        ByteSize = req.FileSize,
                    };
                    var record = new ContentRecord()
                    {
                        FileName = req.Name,
                        // Description = req.Description,
                        ContentHash = req.Hash,
                        ByteSize = req.FileSize,
                    };
                    record.Seeders.Add(req.SenderId);
                    ContentList.Add(record);
                    Console.WriteLine("Added " + req.Name);
                    return new RegisterContentReceiver(msg.ConversationId, content);
                case MessageType.CONTENT_LIST_REQUEST:
                    break;
                case MessageType.REGISTER_REQUEST:
                    break;
                default:
                    break;
            }
            return null;
        }
    }
}
