using NUnit.Framework;
using PayBitForward.Messaging;
using System;
using System.Net;
using System.Threading;

namespace UnitTests
{
    [TestFixture]
    public class TestUdpCommunicator
    {
        JsonMessageConverter<Message> Converter = new JsonMessageConverter<Message>();

        IPEndPoint CommEndPoint1 = new IPEndPoint(IPAddress.Loopback, 4000);

        IPEndPoint CommEndPoint2 = new IPEndPoint(IPAddress.Loopback, 4001);

        Guid CommId1 = new Guid("cda1513e-6cf0-4c89-a69b-8982976ac618");

        Guid CommId2 = new Guid("97b300cb-67ac-4c56-944a-9598fac4be36");

        Guid ConvoId = new Guid("b536f5ed-38de-4ffc-99a9-c320678387c6");

        int WaitFactor = 10;

        [Test]
        public void TestStartAndStop()
        {
            var blockComm = new ManualResetEvent(false);

            var comm = new UdpCommunicator(CommEndPoint1, Converter);

            Assert.False(comm.IsRunning);

            comm.Start();

            Thread.Yield();
            Assert.True(comm.IsRunning);

            comm.Stop();

            Thread.Yield();
            Assert.False(comm.IsRunning);
        }

        [Test]
        public void TestSendAndReceive()
        {
            var blockComm1 = new ManualResetEvent(false);
            var blockComm2 = new ManualResetEvent(false);

            var expectedCount = 0;

            var comm1 = new UdpCommunicator(CommEndPoint1, Converter);
            var comm2 = new UdpCommunicator(CommEndPoint2, Converter);

            comm1.OnEnvelope += (Envelope env) =>
            {
                blockComm1.Set();
                Assert.True(env.MessageContent.SenderId == CommId2);
                Assert.True(env.MessageContent.ConversationId == ConvoId);
                Assert.True(env.MessageContent.MessageCount == expectedCount);

                expectedCount++;
            };

            comm2.OnEnvelope += (Envelope env) =>
            {
                blockComm2.Set();
                Assert.True(env.MessageContent.SenderId == CommId1);
                Assert.True(env.MessageContent.ConversationId == ConvoId);
                Assert.True(env.MessageContent.MessageCount == expectedCount);

                expectedCount++;
            };

            comm1.Start();
            comm2.Start();

            var startMessage = new Message()
            {
                SenderId = CommId1,
                MessageId = MessageType.UNKNOWN,
                ConversationId = ConvoId,
                MessageCount = expectedCount
            };

            comm1.SendEnvelope(new Envelope(startMessage, CommEndPoint2));

            Assert.True(blockComm2.WaitOne(UdpCommunicator.Timeout * WaitFactor), "Communicator 2 never received message");

            var nextMessage = new Message()
            {
                SenderId = CommId2,
                MessageId = MessageType.UNKNOWN,
                ConversationId = ConvoId,
                MessageCount = expectedCount
            };

            comm2.SendEnvelope(new Envelope(nextMessage, CommEndPoint1));

            Assert.True(blockComm1.WaitOne(UdpCommunicator.Timeout * WaitFactor), "Communicator 1 never received message");

            comm1.Stop();
            comm2.Stop();
        }
    }
}

