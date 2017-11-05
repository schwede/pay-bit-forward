using NUnit.Framework;
using PayBitForward.Messaging;
using System;
using System.Net;
using System.Threading;

namespace UnitTests
{
    [TestFixture]
    public class TestMessageRouter
    {
        public static Guid ConverserId1 = new Guid("1573d184-2802-4d96-8d82-8dff549a1401");

        public static Guid ConverserId2 = new Guid("b4e30f14-7010-4bcf-affe-5599a2bf936d");

        public static Guid ClientId = new Guid("4d0e5fe4-a982-4312-807a-1be94ff48324");

        IPEndPoint RemoteEndPoint = new IPEndPoint(IPAddress.Loopback, 5001);

        [Test]
        public void TestMessageRouting()
        {
            var blockConvo1 = new ManualResetEvent(false);
            var blockConvo2 = new ManualResetEvent(false);

            var comm = new MockCommunicator();
            var router = new MessageRouter(comm);

            var converser1 = new MockConverser()
            {
                ConversationId = ConverserId1
            };

            converser1.OnConversationOver += (IConverser c) =>
            {
                blockConvo1.Set();
            };

            var converser2 = new MockConverser()
            {
                ConversationId = ConverserId2
            };

            converser2.OnConversationOver += (IConverser c) =>
            {
                blockConvo2.Set();
            };

            // Conversations are implicitly started here
            router.AddConversation(converser1, RemoteEndPoint);
            router.AddConversation(converser2, RemoteEndPoint);

            Assert.True(blockConvo1.WaitOne(100), "Conversation 1 never finished");
            Assert.True(blockConvo2.WaitOne(100), "Conversation 2 never finsihed");
        }
    }

    public class MockCommunicator : INetworkCommunicator
    {
        public bool IsRunning { get; private set; }

        private IPEndPoint EndPoint = new IPEndPoint(IPAddress.Loopback, 5000);

        public void Start()
        {
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }

        public void SendEnvelope(Envelope env)
        {
            env.MessageContent.MessageCount++;
            OnEnvelope?.Invoke (new Envelope(env.MessageContent, EndPoint));
        }

        public event EnvelopeReceived OnEnvelope;
    }

    public class MockConverser : IConverser
    {
        public Guid ConversationId { get; set; }

        public void Start()
        {
            if (ConversationId == TestMessageRouter.ConverserId1)
            {
                var convoMessage1 = new Message()
                {
                    SenderId = TestMessageRouter.ClientId,
                    ConversationId = TestMessageRouter.ConverserId1,
                    MessageId = MessageType.CHUNK_REQUEST,
                    MessageCount = 0
                };

                OnMessageToSend?.Invoke(this, convoMessage1);
            }
            else if (ConversationId == TestMessageRouter.ConverserId2)
            {
                var convoMessage2 = new Message()
                {
                    SenderId = TestMessageRouter.ClientId,
                    ConversationId = TestMessageRouter.ConverserId2,
                    MessageId = MessageType.CHUNK_REPLY,
                    MessageCount = 0
                };

                OnMessageToSend?.Invoke(this, convoMessage2);
            }
        }

        public void Stop()
        {

        }

        public void HandleMessage(Message mesg)
        {
            if(ConversationId == TestMessageRouter.ConverserId1)
            {
                if(mesg.MessageCount >= 4)
                {
                    OnConversationOver?.Invoke(this);
                }
                else
                {
                    Assert.AreEqual(MessageType.CHUNK_REQUEST, mesg.MessageId);

                    mesg.MessageCount++;
                    OnMessageToSend?.Invoke(this, mesg);
                }
            }
            else if(ConversationId == TestMessageRouter.ConverserId2)
            {
                if (mesg.MessageCount >= 4)
                {
                    OnConversationOver?.Invoke(this);
                }
                else
                {
                    Assert.AreEqual(MessageType.CHUNK_REPLY, mesg.MessageId);

                    mesg.MessageCount++;
                    OnMessageToSend?.Invoke(this, mesg);
                }
            }
        }

        public event SendMessage OnMessageToSend;

        public event EndConversation OnConversationOver;
    }
}
