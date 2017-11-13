using System;
using System.Net;
using PayBitForward.Messaging;
using PayBitForward.Models;

namespace Seeder
{
    public class Seeder
    {
        static void Main(string[] args)
        {
            var app = new Seeder();
            app.Start();
        }

        private Content ContentInfo { get; set; }

        public void Start()
        {
            var converter = new JsonMessageConverter();
            var comm = new UdpCommunicator(new IPEndPoint(IPAddress.Any, 4001), converter);
            comm.Start();
            var router = new MessageRouter(comm);
            router.OnConversationRequest += HandleNewConversation;

            ContentInfo = new Content()
            {
                FileName = "test_file.txt",
                ByteSize = 1024,
                ContentHash = new byte[] { 0xDE, 0xAD, 0xBE, 0xEF },
                Description = "Test file",
                LocalPath = "TestData"
            };            

            Console.ReadLine();
            comm.Stop();
        }

        private IConverser HandleNewConversation(Message mesg)
        {
            return new ChunkSender(ContentInfo, new Guid("11f684d9-53a5-4fd9-948f-5526e881f60c"));
        }
    }
}
