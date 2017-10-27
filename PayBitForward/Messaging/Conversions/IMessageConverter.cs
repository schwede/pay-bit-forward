
namespace PayBitForward.Messaging
{
    public interface IMessageConverter<T> where T : Message                                  
    {
        byte[] Serialize(T message);

        T DeSerialize(byte[] blob);
    }
}
