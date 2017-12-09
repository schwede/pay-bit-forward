using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using PayBitForward.Models;

namespace PayBitForward.Messaging
{
    public class ChunkReceiver : Converser
    {
        private Content FileInfo { get; set; }

        private HashSet<int> NeededData { get; set; }

        private HashSet<int> ReceivedData { get; set; } = new HashSet<int>();

        private ConcurrentDictionary<int, byte[]> DataStore { get; set; }

        private int ChunkSize { get; set; } = 256;

        private int MessageCount { get; set; } = 0;

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(ChunkReceiver));

        public ChunkReceiver(Content content, HashSet<int> neededData, ConcurrentDictionary<int, byte[]> store, Guid convoId) : base(convoId)
        {
            FileInfo = content;
            DataStore = store;
            NeededData = neededData;
        }

        protected override void Run()
        {
            Log.Debug("Started receiver");

            // Only request all packets five times
            while(true)
            {
                if(Token.IsCancellationRequested)
                {
                    Log.Debug("Received request to stop");
                    break;
                }

                foreach(var data in NeededData)
                {
                    var chunkReq = new ChunkRequest(Guid.NewGuid(), ConversationId, MessageCount, data, FileInfo.ContentHash, ChunkSize);
                    RaiseSendMessageEvent(chunkReq);
                    MessageCount++;
                }

                Thread.Sleep(250);

                while(IncomingMessages.Count > 0)
                {
                    Message mesg;
                    if(IncomingMessages.TryDequeue(out mesg))
                    {
                        if(mesg.MessageId == MessageType.CHUNK_REPLY)
                        {
                            var chunkReply = (ChunkReply)mesg;

                            if (NeededData.Contains(chunkReply.Index))
                            {
                                if(MessageVerifier.CheckSignature(chunkReply.ChunkData, chunkReply.Signature, FileInfo.PublicKeyInfo))
                                {
                                    DataStore[chunkReply.Index] = chunkReply.ChunkData;

                                    NeededData.Remove(chunkReply.Index);
                                    ReceivedData.Add(chunkReply.Index);

                                    if (NeededData.Count == 0)
                                    {
                                        Log.Info(string.Format("Conversation complete; Downloaded {0} packets", DataStore.Count));
                                        var ack = new Acknowledge(Guid.NewGuid(), ConversationId, mesg.MessageCount + 1, "Download complete");

                                        CancelSource.Cancel();
                                        RaiseSendMessageEvent(ack);
                                        break;
                                    }
                                }
                                else
                                {
                                    Log.Warn("Message signature is NOT verfied");
                                }
                            }
                        }
                    }
                }

                Thread.Sleep(250);
            }
            
            RaiseEndConversationEvent();
        }
    }
}
