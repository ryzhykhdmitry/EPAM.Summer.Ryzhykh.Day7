using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLogicLayer;
using BookService;
using BookStorage;
using Serialization;
using WorkWithBooks;
using NLog;
using XMLExporter;
using XMLExporterInterface;

namespace BookServiceConsoleTest
{
    class Program
    {     
        
        static void Main(string[] args)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Error("hello, current time is {0}", DateTime.Now);

             

            BookListService libraryService = new BookListService(new BinaryBookListStorage("Library.txt"));

            Book book1 = new Book("Franz Kafka", "The Castle", 1926, 416);
            Book book2 = new Book("Michel Houellebecq", "Platform", 2001, 462);
            Book book3 = new Book("Haruki Murakami", "Norwegian wood", 1987, 365);
            Book book4 = new Book("George Orwell", "Nineteen Eighty-Four", 1949, 368);


            libraryService.AddBook(book1);
            libraryService.AddBook(book2);
            libraryService.AddBook(book3);
            libraryService.AddBook(book4);

            foreach (var book in libraryService.Books)
            {
                Console.WriteLine(book.ToString());
            }
            Console.WriteLine(new string('-', 30));
            Console.ReadKey();

            Console.WriteLine(libraryService.FindByAuthor("George Orwell").ToString());
            Console.WriteLine(libraryService.FindByTag((a) => a.Title.Contains("wood")).ToString());


            Console.ReadKey();
            Console.WriteLine(new string('-', 30));

            libraryService.SortBooks(new CompareByAuthor());
            foreach (var book in libraryService.Books)
            {
                Console.WriteLine(book.ToString());
            }

            BinarySerialization bin1 = new BinarySerialization("SerializeFile.doc");
            BookListService libraryTwoService = new BookListService(bin1);

            libraryTwoService.AddBook(book1);
            libraryTwoService.AddBook(book2);
            libraryTwoService.AddBook(book3);


            foreach (var x in libraryTwoService.Books)
            {
                Console.WriteLine(x.ToString());
            }
            Console.ReadKey();

            libraryService.ExportToXML("books.xml", new XMLExporterLINQ());
            libraryService.ExportToXML("booksWriter.xml", new XMLExporterXmlWriter());
        }
    }
}
