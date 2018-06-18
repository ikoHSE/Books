using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Reader;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            var lib = new Library();
            while (true) {
                Console.WriteLine("1 - Add Book \n2- write file \n3 - read file \n4 - print library");
                switch (Console.ReadLine()) {
                    case "1":
                        var book = new Book() {
                            name = GetString("Book name:"),
                            author = GetString("Author name: "),
                            pageCount = GetInt("Page count: ", x => x > 0, "that is not a valid positive int."),
                            dateAdded = GetDate("Date released in dd.mm.yyyy: ", _ => true, "That is not a valid date."),
                            isSpecialEdition = GetBool("Is special edition: ", "That is not a valid bool.")
                        };
                        if (book.isSpecialEdition) {
                            book.value = GetInt("Special edition value: ", x => x > 0, "that is not a valid positive int.");
                        }
                        lib.Add(book);
                    break;
                    case "4":
                        foreach(var b in lib) {
                            Console.WriteLine(b);
                        }
                        break;
                    case "2":
                        lib.SerializeAll("../../../lib.xml");
                        break;
                    case "3":
                        lib.ReadXMLFrom("../../../lib.xml");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
