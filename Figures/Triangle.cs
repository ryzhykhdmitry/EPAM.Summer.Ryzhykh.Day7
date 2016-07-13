using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Triangle : CheckParameters, IFigure, IEquatable<Triangle>
    {
        /// <summary>
        /// Describe triangle
        /// </summary>
        #region Fields
        private double sideA, sideB, sideC;
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
            private set {
                GoodSide(value);
                sideB = value;
            }
        }

        public double SideC
        {
            get { return sideC; }
            private set {
                GoodSide(value);
                sideC = value;
            }
        }


        #endregion

        #region Constructors
        /// <summary>
        /// Conctructor
        /// </summary>
        public Triangle()
        {
            SideA = 1;
            SideB = 2;
            SideC = 3;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="a">First side</param>
        /// <param name="b">Second side</param>
        /// <param name="c">Third side</param>
        public Triangle(double a, double b, double c)
        {
            if(!IsExist(a,b,c))
                throw new ArgumentException();
            SideA = a;
            SideB = b;
            SideC = c;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Count area
        /// </summary>
        /// <returns>Area</returns>
        public double Area()
        {
            double halfPerimetr = Perimeter()*0.5;
            return Math.Pow(halfPerimetr*(halfPerimetr - SideA)*(halfPerimetr - SideB)*(halfPerimetr - SideC), 0.5);
        }

        /// <summary>
        /// Count perimetr
        /// </summary>
        /// <returns>Perimetr</returns>
        public double Perimeter()
        {
            return SideA + SideB + SideC;
        }

        /// <summary>
        /// Compare two triangles
        /// </summary>
        /// <param name="other">Second triangle</param>
        /// <returns>True, if triangles are equal</returns>
        public bool Equals(Triangle other)
        {
            ChekRefOnNull(this);
            ChekRefOnNull(other);

            if (SideA.Equals(SideB) && SideA.Equals(SideC))
                return true;
            return false;
        }

        /// <summary>
        /// Compare two triangles
        /// </summary>
        /// <param name="other">Second triangle</param>
        /// <returns>True, if triangles are similar</returns>
        public bool IsSimilar(Triangle other)
        {
            ChekRefOnNull(this);
            ChekRefOnNull(other);

            if ((SideA/other.SideA).Equals(SideB/other.SideB) && (SideA/other.SideA).Equals(SideC/other.SideC))
                return true;
            return false;
        }

        /// <summary>
        /// Define weather the triangle is equilateral
        /// </summary>
        /// <returns>True, if triangle is equilateral</returns>
        public bool IsEquilateral()
        {
            return SideA.Equals(SideB) && SideA.Equals(SideC) ? true : false;
        }

        /// <summary>
        /// Define weather the triangle is right
        /// </summary>
        /// <returns>True, if triangle is right</returns>
        public bool IsRight()
        {
            if (SideA.Equals(Math.Pow(SideB*SideB + SideC*SideC, 0.5)) ||
                SideB.Equals(Math.Pow(SideA*SideA + SideC*SideC, 0.5)) ||
                SideC.Equals(Math.Pow(SideB*SideB + SideA*SideA, 0.5)))
                return true;
            return false;
        }

        /// <summary>
        /// Define weather the triangle is isisceles
        /// </summary>
        /// <returns>True, if triangle is isisceles</returns>
        public bool IsIsosceles()
        {
            if (SideA.Equals(SideB) && !SideA.Equals(SideC) ||
                SideA.Equals(SideC) && !SideA.Equals(SideB) ||
                SideC.Equals(SideB) && !SideA.Equals(SideC))
                return true;
            return false;
        }

        #endregion

        #region Private  Methods
        /// <summary>
        /// Check the existence of triangle
        /// </summary>
        /// <param name="a">First side</param>
        /// <param name="b">Second side</param>
        /// <param name="c">Third side</param>
        /// <returns>True, if it's good triangle</returns>
        private bool IsExist(double a, double b, double c)
        {
            if (a + b < c && a + c < b && b + c < a)
                return true;
            return false;
        }
        #endregion
    }
}
