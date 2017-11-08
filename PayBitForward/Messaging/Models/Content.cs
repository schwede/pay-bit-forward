using System;

namespace PayBitForward.Models
{
    public class Content
    {
        public string FileName { get; set; }

        public string LocalPath { get; set; }

        public string Description { get; set; }

        public byte[] ContentHash { get; set; }

        public int ByteSize { get; set; }

        public Content()
        {
        }
    }
}
