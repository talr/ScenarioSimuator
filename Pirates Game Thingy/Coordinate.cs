using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulatorNamespace
{
    class Coordinate
    {
        #region Properties
        double x;
        double y;
        #endregion
        #region Constructors
        public Coordinate()
        {
            x = 0;
            y = 0;
        }

        public Coordinate(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        #endregion
        #region GetSet
        public double GetX()
        {
            return x;
        }

        public double GetY()
        {
            return y;
        }
        #endregion
        #region Methods
        public double Distance(Coordinate Co2)
        {
            return Math.Sqrt(Math.Pow(x - Co2.GetX(), 2) + Math.Pow(y - Co2.GetY(), 2));
        }
        #endregion
    }
}
