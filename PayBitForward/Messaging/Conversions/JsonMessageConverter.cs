using Newtonsoft.Json;

namespace PayBitForward.Messaging
{
    public class JsonMessageConverter<T> : IMessageConverter<T> where T : Message
    {
        public string Serialize(T message)
        {
            return JsonConvert.SerializeObject(message);
        }

        public T DeSerialize(string blob)
        {
            return JsonConvert.DeserializeObject<T>(blob);
        }
    }
}
