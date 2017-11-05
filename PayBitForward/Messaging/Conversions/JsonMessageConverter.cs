using System;
using Newtonsoft.Json;
using System.Text;

namespace PayBitForward.Messaging
{
    public class JsonMessageConverter : IMessageConverter
    {
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
                default:
                    // Need to log here
                    throw new Exception("Can not deserialize bytes");
            }
        }
    }
}
