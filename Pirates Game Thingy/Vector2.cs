using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulatorNamespace
{
    class Vector2
    {
        #region Properties
        public double x { get; set; }
        public double y { get; set; }
        #endregion
        #region Constructors
        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public Vector2()
        {
            x = 0;
            y = 0;
        }
        #endregion
        #region Methods
        public double Length()
        {
            return Math.Sqrt(x * x + y * y);
        }
        public double Distance(Vector2 Vec)
        {
            return Math.Sqrt(Math.Pow(x - Vec.x, 2) + Math.Pow(y - Vec.y, 2));
        }
        public Vector2 Round()
        {
            return new Vector2(Math.Round(x), Math.Round(y));
        }
        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
        #endregion
        #region Operators
        public static Vector2 operator +(Vector2 v, Vector2 u)
        {
            return new Vector2(v.x + u.x, v.y + u.y);
        }
        public static Vector2 operator -(Vector2 v, Vector2 u)
        {
            return new Vector2(v.x - u.x, v.y - u.y);
        }
        public static Vector2 operator *(double s, Vector2 v)
        {
            return new Vector2(s * v.x, s * v.y);
        }
        public static Vector2 operator *(Vector2 v, double s)
        {
            return new Vector2(s * v.x, s * v.y);
        }
        public static Vector2 operator /(Vector2 v, double s)
        {
            return new Vector2(v.x / s, v.y / s);
        }
        public static double operator *(Vector2 v, Vector2 u)
        {
            return ((v.x * u.x) + (v.y * u.y));
        }
        public static bool operator ==(Vector2 v, Vector2 u)
        {
            return (v.x == u.x) && (v.y == u.y);
        }
        public static bool operator !=(Vector2 v, Vector2 u)
        {
            return (v.x != u.x) || (v.y != u.y);
        }
        
        #endregion
    }
}
