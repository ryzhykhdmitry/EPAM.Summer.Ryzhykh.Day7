using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersChecker
{
    public abstract class Checker
    {
        protected static void CheckRefOnNull(object obj)
        {
            if (ReferenceEquals(obj, null))
                throw new ArgumentNullException();
        }
    }
}
