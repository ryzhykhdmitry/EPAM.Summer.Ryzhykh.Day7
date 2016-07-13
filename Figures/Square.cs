using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    /// <summary>
    /// Describe square
    /// </summary>
    public class Square: Rectangle,IFigure
    {
        #region Constructors
        /// <summary>
        /// Constructor(square with side = 1)
        /// </summary>
        public Square() : base(1,1) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="a">Side of square</param>
        public Square(double a) : base(a, a)
        { }
        #endregion

        #region Public Methods

        /// <summary>
        /// Count radius of incircle
        /// </summary>
        /// <returns>Radius of incircle</returns>
        public double GetRadiusIncircal()
        {
            return (double) SideA/2;
        }
#endregion
    }

}
