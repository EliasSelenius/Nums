using System;

namespace Nums {

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct dvec2 {

        #region constants
        public static readonly dvec2 zero = (0, 0);
        public static readonly dvec2 unitx = (1, 0);
        public static readonly dvec2 unity = (0, 1);
        public static readonly dvec2 one = (1, 1);
        #endregion

        public double x, y;
        public double sum => x + y;
        public int bytesize => sizeof(double) * 2;
        public double sqlength => dot(this);
        public double length => (double)Math.Sqrt(dot(this));
        public dvec2 normalized => this / length;

        public double this[int i] {
            get => i switch {
                0 => x,
                1 => y,
                _ => throw new IndexOutOfRangeException("dvec2[" + i + "] is not a valid index")
            };
            set {
                switch (i) {
                    case 0: x = value; return;
                    case 1: y = value; return;
                    default: throw new IndexOutOfRangeException("dvec2[" + i + "] is not a valid index");
                }
            }
        }

        #region swizzling properties
        public dvec2 xx => new dvec2(x, x);
        public dvec2 yx {
            get => new dvec2(y, x);
            set {
                y = value.x;
                x = value.y;
            }
        }
        public dvec2 xy {
            get => new dvec2(x, y);
            set {
                x = value.x;
                y = value.y;
            }
        }
        public dvec2 yy => new dvec2(y, y);
        #endregion

        #region constructors
        public dvec2(double x, double y) {
            this.x = x;
            this.y = y;
        }
        #endregion

        #region arithmetic
        public double dot(dvec2 v) => (this * v).sum;

        public static dvec2 operator *(dvec2 a, dvec2 b) => new dvec2(a.x * b.x, a.y * b.y);
        public static dvec2 operator /(dvec2 a, dvec2 b) => new dvec2(a.x / b.x, a.y / b.y);
        public static dvec2 operator +(dvec2 a, dvec2 b) => new dvec2(a.x + b.x, a.y + b.y);
        public static dvec2 operator -(dvec2 a, dvec2 b) => new dvec2(a.x - b.x, a.y - b.y);

        public static dvec2 operator *(dvec2 a, double s) => new dvec2(a.x * s, a.y * s);
        public static dvec2 operator /(dvec2 a, double s) => new dvec2(a.x / s, a.y / s);

        public static dvec2 operator -(dvec2 v) => new dvec2(-v.x, -v.y);
        #endregion

        #region math
        public double distTo(dvec2 o) => (o - this).length;
        public double angleTo(dvec2 o) => (double)Math.Acos(this.dot(o) / (this.length * o.length));
        public dvec2 lerp(dvec2 o, double t) => this + ((o - this) * t);
        #endregion

        #region conversion
        public static implicit operator dvec2((double, double) tuple) => new dvec2(tuple.Item1, tuple.Item2);
        #endregion
    }
}
