using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLogicLayer;
using ParametersChecker;

namespace WorkWithBooks
{
    public class CompareByTitle : Checker, IComparer<Book>
    {
        #region Public Methods
        public int Compare(Book first, Book second)
        {
            CheckRefOnNull(first);
            CheckRefOnNull(second);
            return first.Title.CompareTo(second.Title);
        }
        #endregion
    }
}
