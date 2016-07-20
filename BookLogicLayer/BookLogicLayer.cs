using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParametersChecker;

namespace BookLogicLayer
{
    /// <summary>
    /// Books information class 
    /// </summary>
    public class Book : Checker, IEquatable<Book>, IComparable<Book>
    {
        #region Fields
        public string Author { get; private set; }
        public string Title { get; private set; }
        public int Year { get; private set; }
        public int Pages { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Create the instance of Book.
        /// </summary>
        /// <param name="author">Book's author.</param>
        /// <param name="title">Title.</param>
        /// <param name="year">Year of publishing.</param>
        /// <param name="pages">Number of pages.</param>
        public Book(string author, string title, int year, int pages)
        {
            CheckRefOnNull(author);
            CheckRefOnNull(title);
            if (pages <= 0 || year < 1454)
                throw new ArgumentException();
            Author = author;
            Title = title;
            Year = year;
            Pages = pages;
        }

        public Book() { }
        #endregion
        #region Methods

        /// <summary>
        /// Show book's info.
        /// </summary>
        /// <returns>Title, Author, Year, Pages.</returns>
        public override string ToString()
        {
            return string.Format("Author: {0} \r\nTitle: {1} \r\nYear: {2} \r\nPages: {3}\r\n", Author, Title, Year, Pages);
        }

        /// <summary>
        /// Compare books by title.
        /// </summary>
        /// <param name="other">Book to compare.</param>
        /// <returns>Int.</returns>
        public int CompareTo(Book other)
        {
            return this.Title.CompareTo(other.Title);
        }

        /// <summary>
        /// Compare book's equality.
        /// </summary>
        /// <param name="other">Other book.</param>
        /// <returns>True or false.</returns>
        public bool Equals(Book other)
        {
            if (other == null) return false;
            if (this.Title == other.Title && this.Author == other.Author && this.Year == other.Year) return true;
            return false;
        }

        /// <summary>
        /// Compare book's equality.
        /// </summary>
        /// <param name="obj">Other book.</param>
        /// <returns>True or false.</returns>
        public override bool Equals(Object obj)
        {
            if (obj == null) return false;

            Book book = obj as Book;
            if (book == null) return false;
            return Equals(book);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Book lhs, Book rhs)
        {
            if ((object)lhs == null || ((object)rhs) == null)
                return Object.Equals(lhs, rhs);
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Book lhs, Book rhs)
        {
            if (lhs == null || rhs == null) return !Object.Equals(lhs, rhs);

            return !(lhs.Equals(rhs));
        } 
        #endregion
    }
}
