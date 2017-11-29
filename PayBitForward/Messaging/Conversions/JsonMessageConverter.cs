using System;
using Newtonsoft.Json;
using System.Text;

namespace PayBitForward.Messaging
{
    public class JsonMessageConverter : IMessageConverter
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(JsonMessageConverter));

        public byte[] Serialize(Message message)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
        }

        public Message DeSerialize(byte[] blob)
        {
            var str = Encoding.UTF8.GetString(blob);
            var mesg = JsonConvert.DeserializeObject<Message>(str);

            switch(mesg.MessageId)
            {
                case MessageType.UNKNOWN:
                    return mesg;
                case MessageType.ACKNOWLEDGE:
                    return JsonConvert.DeserializeObject<Acknowledge>(str);
                case MessageType.CHUNK_REQUEST:
                    return JsonConvert.DeserializeObject<ChunkRequest>(str);
                case MessageType.CHUNK_REPLY:
                    return JsonConvert.DeserializeObject<ChunkReply>(str);
                case MessageType.REGISTER_CONTENT_REQUEST:
                    return JsonConvert.DeserializeObject<RegisterContentRequest>(str);
                case MessageType.CONTENT_LIST_REQUEST:
                    return JsonConvert.DeserializeObject<ContentListRequest>(str);
                case MessageType.CONTENT_LIST_REPLY:
                    return JsonConvert.DeserializeObject<ContentListReply>(str);
                default:
                    Log.ErrorFormat("Can not deserialize bytes with MessageId of {0}", mesg.MessageId);
                    throw new Exception("Can not deserialize bytes");
            }
        }
    }
}
