using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class Library : Container<Book>
    {
        public IEnumerable<Book> SortedByDate()
        {
            return elements.OrderBy(e => e.dateAdded);
        }

        public void SerializeAll(string path)
        {
            var s = new XmlSerializer(typeof(List<Book>));
            using (var fs = new FileStream(path, FileMode.Create))
            {
                s.Serialize(fs, elements);
            }
        }

        public void Serialize(Func<int, string> pathGenerator)
        {
            var i = 0;
            foreach (var b in elements)
            {
                var path = pathGenerator(i);
                var s = new XmlSerializer(typeof(Book));
                using (var fs = new FileStream(path, FileMode.Create))
                {
                    s.Serialize(fs, b);
                }
                i += 1;
            }
        }

        public void ReadXMLFrom(string path)
        {
            var s = new XmlSerializer(typeof(List<Book>));
            using (var fs = new FileStream(path, FileMode.Open))
            {
                var newBooks = s.Deserialize(fs) as List<Book>;
                foreach (var newBook in newBooks)
                {
                        Add(newBook);
                }
            }
        }

        public void ReadXmlFrom(List<string> paths)
        {
            foreach (var path in paths)
            {
                var s = new XmlSerializer(typeof(Book));
                using (var fs = new FileStream(path, FileMode.Open))
                {
                    var newBook = s.Deserialize(fs) as Book;
                        Add(newBook);
                }

            }
        }
    }
}
