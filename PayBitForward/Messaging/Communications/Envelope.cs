using System;
using System.Net;

namespace PayBitForward.Messaging
{
    public class Envelope
    {
        public Message MessageContent { get; set; }

        public IPEndPoint EndPoint { get; set; }

        public Envelope(Message content, IPEndPoint endPoint)
        {
            MessageContent = content;
            EndPoint = endPoint;
        }
    }
}
