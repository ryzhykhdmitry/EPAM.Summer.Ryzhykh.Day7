using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    /// <summary>
    /// Describe rectangle
    /// </summary>
    public class Rectangle :CheckParameters, IFigure, IEquatable<Rectangle>
    {
        #region Fields
        private double sideA, sideB;
        #endregion

        #region Properties
        public double SideA 
        {
            get { return sideA; }
            private set
            {
                GoodSide(value);
                sideA = value;
            }
        }

        public double SideB
        {
            get { return sideB; }
            private set
            {
                GoodSide(value);
                sideB = value;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor(rectangle with sides 1 and 2)
        /// </summary>
        public Rectangle()
        {
            SideA = 1;
            SideB = 2;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="a">Higth</param>
        /// <param name="b">Width</param>
        public Rectangle(double a, double b)
        {
            SideA = a;
            SideB = b;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Count area
        /// </summary>
        /// <returns>Area</returns>
        public virtual double Area()
        {
            return SideA*SideB;
        }

        /// <summary>
        /// Count perimetr
        /// </summary>
        /// <returns>Perimetr</returns>
        public virtual double Perimeter()
        {
            return 2*(SideA + SideB);
        }

        /// <summary>
        /// Count length of diagonal
        /// </summary>
        /// <returns>Length of diagonal</returns>
        public virtual double GetDiagonal()
        {
            return Math.Pow(SideA*SideA + SideB*SideB, 0.5);
        }

        /// <summary>
        /// Count radius of circumcircle
        /// </summary>
        /// <returns>Radius of circumcircle</returns>
        public virtual double GetRadiusCircumcircle()
        {
            return (double)GetDiagonal()/2;
        }

        /// <summary>
        /// Compare two rectangles
        /// </summary>
        /// <param name="other">Second rectangle</param>
        /// <returns>True, if rectangle are equal</returns>
        public virtual bool Equals(Rectangle other)
        {
            ChekRefOnNull(this);
            ChekRefOnNull(other);
            return other.SideA.Equals(SideA) && other.SideB.Equals(SideB) ? true : false;
        }

        #endregion

    }
}
