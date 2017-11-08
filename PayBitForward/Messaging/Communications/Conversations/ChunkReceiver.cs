using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using PayBitForward.Models;

namespace PayBitForward.Messaging
{
    public class ChunkReceiver : Converser
    {
        private Content FileInfo { get; set; }

        private BinaryWriter Stream { get; set;  }

        private HashSet<int> NeededData { get; set; }

        private HashSet<int> ReceivedData { get; set; } = new HashSet<int>();

        private int ChunkSize { get; set; } = 256;

        private int MessageCount { get; set; } = 0;

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(ChunkReceiver));

        public ChunkReceiver(Content content, HashSet<int> neededData, Guid convoId) : base(convoId)
        {
            FileInfo = content;

            Stream = new BinaryWriter(File.Open(FileInfo.FileName, FileMode.OpenOrCreate));
            NeededData = neededData;
        }

        protected override void Run()
        {
            Log.Debug("Started receiver");

            while(true)
            {
                if(Token.IsCancellationRequested)
                {
                    Log.Debug("Received request to stop");
                    return;
                }

                Thread.Sleep(100);
                var chunkReq = new ChunkRequest(Guid.NewGuid(), ConversationId, MessageCount, NeededData.First(), FileInfo.ContentHash, ChunkSize);
                RaiseSendMessageEvent(chunkReq);
                MessageCount++;

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
                                Stream.Seek(chunkReply.Index * ChunkSize, SeekOrigin.Begin);
                                Stream.Write(chunkReply.ChunkData);

                                NeededData.Remove(chunkReply.Index);
                                ReceivedData.Add(chunkReply.Index);

                                if(NeededData.Count == 0)
                                {
                                    Log.Info("Download complete");
                                    var ack = new Acknowledge(Guid.NewGuid(), ConversationId, mesg.MessageCount + 1, "Download complete");
                                    Stream.Close();

                                    CancelSource.Cancel();
                                    RaiseSendMessageEvent(ack);
                                    RaiseEndConversationEvent();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
