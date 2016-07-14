using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComparers
{
    /// <summary>
    /// Comparer interface.
    /// </summary>
    public interface ICustomComparer
    {
        int Compare(int[] arr1, int[] arr2);
    }
}
