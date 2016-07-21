using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLogicLayer;

namespace WorkWithBooks
{
    public class CompareByAuthor : IComparer<Book>
    {
        #region Public Methods
        public int Compare(Book first, Book second)
        {
            if (first == null || second == null) throw new ArgumentNullException();

            return first.Author.CompareTo(second.Author);
        }
        #endregion
    }
}
