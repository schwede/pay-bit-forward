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

        public static int Timeout { get; private set; } = 100;

        private IMessageConverter Converter { get; set; }

        private CancellationTokenSource CancelSource { get; set; } = new CancellationTokenSource();

        private CancellationToken Token { get; set; }

        private ConcurrentQueue<Envelope> OutgoingEnvelopes { get; set; } = new ConcurrentQueue<Envelope>();

        private IPEndPoint _endPoint;

        private Thread WorkerThread;

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(UdpCommunicator));

        public UdpCommunicator(IPEndPoint endPoint, IMessageConverter converter)
        {
            _endPoint = endPoint;
            Converter = converter;
            
            Token = CancelSource.Token;
            CancelSource.Cancel();
        }

        public void Start()
        {
            Log.Debug("Attempting to start communicator");

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

        public void Stop()
        {
            Log.Debug("Requesting thread to stop");
            CancelSource.CancelAfter(500);
            WorkerThread.Join();
        }

        public void SendEnvelope(Envelope env)
        {
            // Log.Debug("Placing envelope onto queue");
            OutgoingEnvelopes.Enqueue(env);
        }

        public event EnvelopeReceived OnEnvelope;

        private void Run()
        {
            Log.Debug("Started communicator");
            var remoteEndPoint = new IPEndPoint(IPAddress.Any, EndPoint.Port);

            using (var udp = new UdpClient(_endPoint))
            {
                udp.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                udp.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, Timeout);

                while (true)
                {
                    if (Token.IsCancellationRequested)
                    {
                        Log.Debug("Received request to stop");
                        return;
                    }

                    try
                    {
                        if(udp.Available > 0)
                        {
                            var data = udp.Receive(ref remoteEndPoint);

                            if (data.Length > 0)
                            {
                                try
                                {
                                    var message = Converter.DeSerialize(data);
                                    OnEnvelope?.Invoke(new Envelope(message, remoteEndPoint));
                                }
                                catch(Exception ex)
                                {
                                    Log.Error(ex.Message);
                                }
                            }
                        }
                    }
                    catch(SocketException ex)
                    {
                        if(ex.SocketErrorCode != SocketError.TimedOut)
                        {
                            Log.Debug(ex.Message);
                        }
                    }
                    catch(Exception ex)
                    {
                        Log.Debug(ex.Message);
                    }
                    finally
                    {
                        while(OutgoingEnvelopes.Count > 0)
                        {
                            // Log.DebugFormat("Attempting to send 1 of {0} envelopes to send", OutgoingEnvelopes.Count);

                            Envelope envelopeToSend;
                            if (OutgoingEnvelopes.TryDequeue(out envelopeToSend))
                            {
                                var bytes = Converter.Serialize(envelopeToSend.MessageContent);

                                try
                                {
                                    // Log.DebugFormat("Attempting to send {0} bytes", bytes.Length);
                                    udp.Send(bytes, bytes.Length, envelopeToSend.EndPoint);
                                }
                                catch(SocketException ex)
                                {
                                    Log.Error(ex.Message);
                                }
                            }
                        }
                    }                   
                }
            }
        }
    }
}
