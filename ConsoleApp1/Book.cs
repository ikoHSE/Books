using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Book: IComparable<Book>, IEquatable<Book>
    {
        public bool isSpecialEdition;
        public string author, name;
        public DateTime dateAdded;
        public int value = -1, pageCount;

        public int CompareTo(Book other)
        {
            return dateAdded.CompareTo(other.dateAdded);
        }

        public bool Equals(Book other)
        {
            return name == other.name && isSpecialEdition == other.isSpecialEdition && author == other.author && dateAdded == other.dateAdded && value == other.value && pageCount == other.pageCount;
        }

        public override string ToString() {
            return $"name: {name} \tauthor: {author} \tdate released: {dateAdded.ToShortDateString()} \tpage count: {pageCount} \tis special edition: {isSpecialEdition}" + (isSpecialEdition ? $" \tspecial edition value: {value}" : "");
        }
    }
}
