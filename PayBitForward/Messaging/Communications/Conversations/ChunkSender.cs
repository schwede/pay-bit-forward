using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using PayBitForward.Models;

namespace PayBitForward.Messaging
{
    public class ChunkSender : Converser
    {
        public Content FileInfo { get; set; }

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(ChunkSender));

        public ChunkSender(Content content, Guid convoId) : base(convoId)
        {
            FileInfo = content;
        }

        protected override void Run()
        {
            Log.Debug("Started sender");

            var persistence = new PersistenceManager();

            while (true)
            {
                if (Token.IsCancellationRequested)
                {
                    Log.Debug("Received request to stop");
                    return;
                }

                if (IncomingMessages.Count == 0)
                {
                    continue;
                }

                using (var file = File.Open(Path.Combine(FileInfo.LocalPath, FileInfo.FileName), FileMode.Open))
                using (var stream = new BinaryReader(file))
                {
                    while (IncomingMessages.Count > 0)
                    {
                        Message mesg;
                        if (IncomingMessages.TryDequeue(out mesg))
                        {
                            if (mesg.MessageId == MessageType.CHUNK_REQUEST)
                            {
                                var chunkReq = (ChunkRequest)mesg;

                                stream.BaseStream.Seek(chunkReq.Size * chunkReq.Index, SeekOrigin.Begin);
                                var bytes = stream.ReadBytes(chunkReq.Size);

                                var provider = new RSACryptoServiceProvider();
                                provider.ImportCspBlob(persistence.ReadContent().KeyInfo);

                                Log.DebugFormat("Building ChunkReply message for index {0}", chunkReq.Index);
                                var outMessage = new ChunkReply(Guid.NewGuid(), 
                                    chunkReq.ConversationId,
                                    chunkReq.MessageCount + 1,
                                    bytes,
                                    chunkReq.Index,
                                    MessageVerifier.CreateSignature(bytes, provider.ExportParameters(false)));
                                RaiseSendMessageEvent(outMessage);
                            }
                            else if (mesg.MessageId == MessageType.ACKNOWLEDGE)
                            {
                                Log.Info("Client acknowledged that it has received all the data");
                                CancelSource.Cancel();
                                RaiseEndConversationEvent();
                            }
                        }
                    }
                }
            }
        }
    }
}
