using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLogicLayer;
using BookStorageInterface;
using System.IO;
using NLog;

namespace BookStorage
{
    public class BinaryBookListStorage : IBookListStorage
    {
        #region Fields
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static string FileName { get; private set; }
        #endregion

        #region Constructor
        public BinaryBookListStorage(string fileName)
        {
            if (fileName == null) throw new ArgumentNullException();
            FileName = fileName;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Load books from binary file
        /// </summary>
        /// <returns>Collection of books</returns>
        public IEnumerable<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();
            try
            {                
                using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.OpenOrCreate)))
                {
                    while (reader.PeekChar() != -1)
                    {
                        string author = reader.ReadString();
                        string title = reader.ReadString();
                        int year = reader.ReadInt32();
                        int pages = reader.ReadInt32();
                        books.Add(new Book(author, title, year, pages));
                    }
                    return books;
                }
            }
            catch
            {
                logger.Fatal("Load Exception");
                throw new IOException();                
            }

        }

        /// <summary>
        /// Save books in binary file
        /// </summary>
        /// <param name="books">Collection of books</param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            if (books == null) throw new ArgumentNullException();
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.OpenOrCreate)))
                {
                    foreach (var book in books)
                    {
                        writer.Write(book.Author);
                        writer.Write(book.Title);
                        writer.Write(book.Year);
                        writer.Write(book.Pages);
                    }
                }
            }
            catch
            {
                throw new IOException();
            }
        }
        #endregion
    }
}
