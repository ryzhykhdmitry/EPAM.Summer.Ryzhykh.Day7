using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLogicLayer;
using ParametersChecker;

namespace WorkWithBooks
{

    public class CompareByYear : Checker, IComparer<Book>
    {
        #region Public Methods
        public int Compare(Book first, Book second)
        {
            CheckRefOnNull(first);
            CheckRefOnNull(second);

            return first.Year.CompareTo(second.Year);
        }
        #endregion
    }
}
