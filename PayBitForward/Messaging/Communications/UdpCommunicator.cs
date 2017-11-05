
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace PayBitForward.Messaging
{
    public class UdpCommunicator : INetworkCommunicator
    {
        public IPEndPoint EndPoint
        {
            get { return _endPoint; }
            set
            {
                // Make sure the thread is not running
                if(Token.IsCancellationRequested)
                {
                    _endPoint = value;
                }
            }
        }

        public bool IsRunning
        {
            get { return !Token.IsCancellationRequested; }
        }

        public static int Timeout { get; private set; }

        private IMessageConverter<Message> Converter { get; set; }

        private CancellationTokenSource CancelSource { get; set; }

        private CancellationToken Token { get; set; }

        private ConcurrentQueue<Envelope> OutgoingEnvelopes { get; set; }

        private IPEndPoint _endPoint;

        public UdpCommunicator(IPEndPoint endPoint, IMessageConverter<Message> converter)
        {
            _endPoint = endPoint;
            Converter = converter;

            Timeout = 100;

            OutgoingEnvelopes = new ConcurrentQueue<Envelope>();

            CancelSource = new CancellationTokenSource();
            Token = CancelSource.Token;
            CancelSource.Cancel();
        }

        public void Start()
        {
            // Make sure the thread does not start twice
            if(Token.IsCancellationRequested)
            {
                CancelSource = new CancellationTokenSource();
                Token = CancelSource.Token;

                Task.Factory.StartNew(Run, Token);
            }          
        }

        public void Stop()
        {
            CancelSource.Cancel();
        }

        public void SendEnvelope(Envelope env)
        {
            OutgoingEnvelopes.Enqueue(env);
        }

        public event EnvelopeReceived OnEnvelope;

        private void Run()
        {
            var remoteEndPoint = new IPEndPoint(IPAddress.Any, EndPoint.Port);

            using (var udp = new UdpClient(_endPoint))
            {
                udp.Client.ReceiveTimeout = 100;

                while (true)
                {
                    if (Token.IsCancellationRequested)
                    {
                        return;
                    }

                    try
                    {
                        var data = udp.Receive(ref remoteEndPoint);

                        if (data.Length > 0)
                        {
                            var message = Converter.DeSerialize(data);
                            OnEnvelope?.Invoke(new Envelope(message, remoteEndPoint));
                        }
                    }
                    catch(SocketException ex)
                    {
                        if(ex.SocketErrorCode != SocketError.TimedOut)
                        {
                            throw;
                        }
                    }
                    finally
                    {
                        Envelope envelopeToSend;

                        while(OutgoingEnvelopes.Count > 0)
                        {
                            if(OutgoingEnvelopes.TryDequeue(out envelopeToSend))
                            {
                                var bytes = Converter.Serialize(envelopeToSend.MessageContent);

                                try
                                {
                                    udp.Send(bytes, bytes.Length, envelopeToSend.EndPoint);
                                }
                                catch(SocketException)
                                {
                                    // Log error
                                }
                            }
                        }
                    }                   
                }
            }
        }
    }
}
