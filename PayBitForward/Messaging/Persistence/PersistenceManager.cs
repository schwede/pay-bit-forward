using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using PayBitForward.Models;

namespace PayBitForward.Messaging
{
    public class PersistenceManager
    {
        public enum StorageType { Local, Remote };

        private string FileName { get; set; }

        private string FullPath { get; set; }

        public PersistenceManager()
        {
            FileName = "db.xml";
            FullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);
        }

        public void WriteContent(Content newContent, StorageType t)
        {
            var serializer = new XmlSerializer(typeof(Database));

            var existing = ReadContent();

            if(t == StorageType.Local)
            {
                existing.LocalContent.Add(newContent);
            }
            else
            {
                existing.RemoteContent.Add(newContent);
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
    }
}
