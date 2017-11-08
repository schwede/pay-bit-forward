using System;

namespace PayBitForward.Messaging
{
    public delegate void SendMessage(IConverser converser, Message mesg);

    public delegate void EndConversation(IConverser converser);

    public interface IConverser
    {
        Guid ConversationId { get; set; }

        void Start();

        void Stop();

        void HandleMessage(Message mesg);

        event SendMessage OnMessageToSend;

        event EndConversation OnConversationOver;

    }
}
