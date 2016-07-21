using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLogicLayer;


namespace WorkWithBooks
{
    public class CompareByPages : IComparer<Book>
    {
        #region Public Methods
        public int Compare(Book first, Book second)
        {
            if (first == null || second == null) throw new ArgumentNullException();

            return first.Pages.CompareTo(second.Pages);
        }
        #endregion
    }
}
