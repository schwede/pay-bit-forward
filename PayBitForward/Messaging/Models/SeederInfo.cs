using System.Net;

namespace PayBitForward.Models
{
    public class SeederInfo
    {
        public IPAddress Ip { get; set; }

        public int Port { get; set; }

        public SeederInfo()
        {
        }
    }
}
