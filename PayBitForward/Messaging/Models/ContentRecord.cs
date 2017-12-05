using System;
using System.Collections.Generic;

namespace PayBitForward.Models
{
    public class ContentRecord
    {
        public string FileName { get; set; }

        public string Description { get; set; }

        public byte[] ContentHash { get; set; }

        public int ByteSize { get; set; }

        public List<Guid> Seeders { get; set; } = new List<Guid>();

        public ContentRecord()
        {
        }
    }
}
