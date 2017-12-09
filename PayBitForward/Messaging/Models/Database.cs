using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace PayBitForward.Models
{
    public class Database
    {
        public List<Content> LocalContent { get; set; }

        public List<Content> RemoteContent { get; set; }

        public RSAParameters KeyInfo { get; set; }

        public Database()
        {
            LocalContent = new List<Content>();
            RemoteContent = new List<Content>();

            var provider = new RSACryptoServiceProvider();
            KeyInfo = provider.ExportParameters(true);
        }
    }
}
