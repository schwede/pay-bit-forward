using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Serialization;
using PayBitForward.Models;

namespace PayBitForward.Messaging
{
    public class PersistenceManager
    {
        public enum StorageType { Local, Remote, KeyInfo };

        private string FileName { get; set; }

        private string FullPath { get; set; }

        public PersistenceManager()
        {
            FileName = "db.xml";
            FullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);
        }

        public void WriteKeyInfo(string rsaParams)
        {
            var serializer = new XmlSerializer(typeof(Database));

            var existing = ReadContent();
            existing.KeyInfo = rsaParams;

            using (var file = new StreamWriter(FullPath))
            {
                serializer.Serialize(file, existing);
            }
        }

        public void WriteContent(Content newContent, StorageType t)
        {
            var serializer = new XmlSerializer(typeof(Database));

            var existing = ReadContent();

            if(t == StorageType.Local)
            {
                if (existing.LocalContent.Where(c => c.ContentHash.SequenceEqual(newContent.ContentHash)
                && c.Host == newContent.Host
                && c.Port == newContent.Port).Count() == 0)
                {
                    existing.LocalContent.Add(newContent);
                }
            }
            else if(t == StorageType.Remote)
            {
                if (existing.RemoteContent.Where(c => c.ContentHash.SequenceEqual(newContent.ContentHash)
                && c.Host == newContent.Host
                && c.Port == newContent.Port).Count() == 0)
                {
                    existing.RemoteContent.Add(newContent);
                }
            }

            using (var file = new StreamWriter(FullPath))
            {
                serializer.Serialize(file, existing);
            }
        }

        public Database ReadContent()
        {
            var result = new Database();
            var serializer = new XmlSerializer(typeof(Database));

            try
            {
                using (var file = new StreamReader(FullPath))
                {
                  result = (Database)serializer.Deserialize(file);
                }
            }
            catch(FileNotFoundException)
            {
                using (var file = new StreamWriter(FullPath))
                {
                    serializer.Serialize(file, result);
                }
            }

            return result;
        }

        public void Clear(StorageType t)
        {
            var existing = ReadContent();
            var serializer = new XmlSerializer(typeof(Database));

            if(t == StorageType.Local)
            {
                existing.LocalContent = new List<Content>();
            }
            else if(t == StorageType.Remote)
            {
                existing.RemoteContent = new List<Content>();
            }

            using (var file = new StreamWriter(FullPath))
            {
                serializer.Serialize(file, existing);
            }
        }
    }
}
