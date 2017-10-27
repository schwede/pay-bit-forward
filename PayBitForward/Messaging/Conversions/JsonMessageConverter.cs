using Newtonsoft.Json;
using System.Text;

namespace PayBitForward.Messaging
{
    public class JsonMessageConverter<T> : IMessageConverter<T> where T : Message
    {
        public byte[] Serialize(T message)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
        }

        public T DeSerialize(byte[] blob)
        {
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(blob));
        }
    }
}
