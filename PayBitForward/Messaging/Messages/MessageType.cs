
namespace PayBitForward.Messaging
{
    public enum MessageType
    {
        CHUNK_REQUEST,
        CHUNK_REPLY,
        ACKNOWLEDGE,
        UNKNOWN,
        CONTENT_LIST_REPLY,
        CONTENT_LIST_REQUEST,
        REGISTER_CONTENT_REQUEST,
        REGISTER_REPLY,
        REGISTER_REQUEST,
        SEEDER_AVAILABLE_REPLY,
        SEEDER_AVAILABLE_REQUEST,
        SELECT_CONTENT_REPLY,
        SELECT_CONTENT_REQUEST,
        UPDATE_BACKUP_REQUEST
    }
}
