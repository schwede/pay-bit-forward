
namespace PayBitForward.Messaging
{
    public interface IMessageConverter                               
    {
        byte[] Serialize(Message message);

        Message DeSerialize(byte[] blob);
    }
}
