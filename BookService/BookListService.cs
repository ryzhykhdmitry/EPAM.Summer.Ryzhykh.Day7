using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLogicLayer;
using BookStorageInterface;
using NLog;

namespace BookService
{
    public class BookListService 
    {
        #region Fields
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IBookListStorage repository;
        #endregion

        #region Properties
        public List<Book> Books { get; private set; }
        #endregion

        #region Constructors
        public BookListService(IBookListStorage repository)
        {
            if (repository == null) throw new ArgumentNullException();
            this.repository = repository;
            Books = repository.LoadBooks().ToList<Book>();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Add collection of books to the file
        /// </summary>
        /// <param name="books">Collection of books</param>
        public void AddBook(IEnumerable<Book> books)
        {
            if (books == null) throw new ArgumentNullException();
            foreach (var book in books)
            {
                AddBook(book);
            }
        }
        /// <summary>
        /// Add book to the file
        /// </summary>
        /// <param name="book">Book</param>
        public void AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException();
            try
            {
                if (this.Books.Contains<Book>(book))
                    throw new ArgumentException();
                Books.Add(book);
                repository.SaveBooks(this.Books);
            }
            catch (ArgumentException e)
            {
               // logger.Error("Cannot add books: {0}", e.Message);
            }
        }

        /// <summary>
        /// Remove book from the file
        /// </summary>
        /// <param name="book">Book</param>
        public void RemoveBook(Book book)
        {
            if (book == null) throw new ArgumentNullException();
            Books.Remove(book);
            repository.SaveBooks(this.Books);
        }

        /// <summary>
        /// Sort books in file
        /// </summary>
        /// <param name="comparer">IComparer</param>
        public void SortBooks(IComparer<Book> comparer)
        {
            if (comparer == null) throw new ArgumentNullException();
            SortBooks(comparer.Compare);
            repository.SaveBooks(Books);
        }
        /// <summary>
        /// Sort books in the file
        /// </summary>
        /// <param name="comparer">Comparision</param>
        public void SortBooks(Comparison<Book> comparer)
        {
            if (comparer == null) throw new ArgumentNullException();
            Books.Sort(comparer);
            repository.SaveBooks(Books);
        }

        /// <summary>
        /// Find book by tag
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>Book</returns>
        public Book FindByTag(Predicate<Book> predicate)
        {
            try
            {
                return Books.Find(predicate);
            }
            catch (ArgumentNullException e)
            {
                logger.Fatal("Predicate is null. " + e.Message);
                throw;
            }
        }
        /// <summary>
        /// Search book by title
        /// </summary>
        /// <param name="title">Title of the book</param>
        /// <returns>Book with title</returns>
        public Book FindByTitle(string title)
        {
            try
            {
                return FindByTag(book => book.Title == title);
            }
            catch (ArgumentNullException e)
            {
                logger.Fatal("Wrong argument. " + e.Message);
                throw;
            }
        }
        /// <summary>
        /// Search book by author
        /// </summary>
        /// <param name="author">Author of the book</param>
        /// <returns>Book with Author</returns>
        public Book FindByAuthor(string author)
        {
            try
            {
                return FindByTag(book => book.Author == author);
            }
            catch (ArgumentNullException e)
            {
                logger.Fatal("Wrong argument. " + e.Message);
                throw;
            }
        }
        #endregion
    }
}
