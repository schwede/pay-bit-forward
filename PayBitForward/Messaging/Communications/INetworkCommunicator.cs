
namespace PayBitForward.Messaging
{
    public delegate void EnvelopeReceived(Envelope env);

    public interface INetworkCommunicator
    {
        bool IsRunning { get; }

        void Start();

        void Stop();

        void SendEnvelope(Envelope env);

        event EnvelopeReceived OnEnvelope;
    }
}
