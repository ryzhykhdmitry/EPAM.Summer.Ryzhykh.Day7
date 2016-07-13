using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public abstract class CheckParameters
    {
        protected void GoodSide(double a)
        {
            if (double.IsNaN(a) || double.IsInfinity(a) || a.Equals(0.0) || a < 0)
                throw new ArgumentException();
        }

        protected void ChekRefOnNull(object a)
        {
            if (ReferenceEquals(a, null))
                throw new ArgumentNullException();
        }
    }
}
