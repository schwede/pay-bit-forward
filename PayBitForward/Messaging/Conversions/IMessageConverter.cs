
namespace PayBitForward.Messaging
{
    public interface IMessageConverter<T> where T : Message                                  
    {
        string Serialize(T message);

        T DeSerialize(string blob);
    }
}
