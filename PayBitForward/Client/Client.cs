using System;
using System.Collections.Generic;
using System.Net;
using PayBitForward.Messaging;
using PayBitForward.Models;

namespace Client
{
    public class Client
    {
        static void Main(string[] args)
        {
            var app = new Client();
            app.Start();
        }

        public void Start()
        {
            var converter = new JsonMessageConverter();
            var comm = new UdpCommunicator(new IPEndPoint(IPAddress.Any, 4000), converter);
            comm.Start();
            var router = new MessageRouter(comm);

            var content = new Content()
            {
                FileName = "test_file.txt",
                ByteSize = 1024,
                ContentHash = new byte[] { 0xDE, 0xAD, 0xBE, 0xEF },
                Description = "Test file",
                LocalPath = "."
            };

            var chunks = new HashSet<int>(new List<int>() { 0, 1, 2, 3 });

            var worker = new ChunkReceiver(content, chunks, new Guid("11f684d9-53a5-4fd9-948f-5526e881f60c"));
            router.AddConversation(worker, new IPEndPoint(IPAddress.Loopback, 4001));

            Console.ReadLine();
            comm.Stop();
        }
    }
}
