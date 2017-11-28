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
        private string FileName { get; set; }

        private string FullPath { get; set; }

        public PersistenceManager()
        {
            FileName = "db.xml";
            FullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);
        }

        public void WriteContent(Content newContent)
        {
            var serializer = new XmlSerializer(typeof(List<Content>));

            var existing = ReadContent();

            existing.Add(newContent);

            using (var file = new StreamWriter(FullPath))
            {
                serializer.Serialize(file, existing);
            }
        }

        public List<Content> ReadContent()
        {
            var result = new List<Content>();
            var serializer = new XmlSerializer(typeof(List<Content>));

            try
            {
                using (var file = new StreamReader(FullPath))
                {
                    result = (List<Content>)serializer.Deserialize(file);
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
