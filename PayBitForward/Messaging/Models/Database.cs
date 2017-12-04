using System;
using System.Collections.Generic;

namespace PayBitForward.Models
{
    public class Database
    {
        public List<Content> LocalContent { get; set; }

        public List<Content> RemoteContent { get; set; }

        public Database()
        {
            LocalContent = new List<Content>();
            RemoteContent = new List<Content>();
        }
    }
}
