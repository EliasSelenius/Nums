using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 2 component vector of double
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct dvec2 : dvec {

        #region constants
        /// <summary>
        /// The zero vector: A vector where all components are equal to zero.
        /// </summary>
        public static readonly dvec2 zero = (0, 0);
        /// <summary>
        /// A unit vector pointing in the positive x direction. →
        /// </summary>
        public static readonly dvec2 unitx = (1, 0);
        /// <summary>
        /// A unit vector pointing in the positive y direction. ↑
        /// </summary>
        public static readonly dvec2 unity = (0, 1);
        /// <summary>
        /// A vector where all components are equal to one.
        /// </summary>
        public static readonly dvec2 one = (1, 1);
        #endregion

        /// <summary>
        /// The x component is the first index of the vector
        /// </summary>
        public double x;
        /// <summary>
        /// The y component is the second index of the vector
        /// </summary>
        public double y;
        /// <summary>
        /// The sum of the vectors components. x + y
        /// </summary>
        public readonly double sum => x + y;
        /// <summary>
        /// The number of bytes the vector type uses.
        /// </summary>
        public const int bytesize = sizeof(double) * 2;
        /// <summary>
        /// The magnitude of the vector
        /// </summary>
        public readonly double length => (double)Math.Sqrt(dot(this));
        /// <summary>
        /// The squared magnitude of the vector. sqlength is faster than length since a square-root operation is not needed.
        /// </summary>
        public readonly double sqlength => dot(this);
        /// <summary>
        /// The normalized version of this vector.
        /// </summary>
        public readonly dvec2 normalized() => this / length;
        /// <summary>
        /// Normalizes this vector.
        /// </summary>
        public void normalize() => this /= length;

        public double this[int i] {
            readonly get => i switch {
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
        /// <summary>
        /// A dvec2 containing the xx components of this vector
        /// </summary>
        public readonly dvec2 xx => new dvec2(x, x);
        /// <summary>
        /// A dvec2 containing the yx components of this vector
        /// </summary>
        public dvec2 yx {
            readonly get => new dvec2(y, x);
            set {
                y = value.x;
                x = value.y;
            }
        }
        /// <summary>
        /// A dvec2 containing the xy components of this vector
        /// </summary>
        public dvec2 xy {
            readonly get => new dvec2(x, y);
            set {
                x = value.x;
                y = value.y;
            }
        }
        /// <summary>
        /// A dvec2 containing the yy components of this vector
        /// </summary>
        public readonly dvec2 yy => new dvec2(y, y);
        #endregion

        #region constructors
        public dvec2(double x, double y) {
            this.x = x;
            this.y = y;
        }
        #endregion

        #region arithmetic
        public readonly double dot(dvec2 v) => (this * v).sum;

        public static dvec2 operator *(dvec2 a, dvec2 b) => new dvec2(a.x * b.x, a.y * b.y);
        public static dvec2 operator /(dvec2 a, dvec2 b) => new dvec2(a.x / b.x, a.y / b.y);
        public static dvec2 operator +(dvec2 a, dvec2 b) => new dvec2(a.x + b.x, a.y + b.y);
        public static dvec2 operator -(dvec2 a, dvec2 b) => new dvec2(a.x - b.x, a.y - b.y);

        public static dvec2 operator *(dvec2 a, double s) => new dvec2(a.x * s, a.y * s);
        public static dvec2 operator /(dvec2 a, double s) => new dvec2(a.x / s, a.y / s);

        public static dvec2 operator -(dvec2 v) => new dvec2(-v.x, -v.y);
        #endregion

        #region math
        public readonly double distTo(dvec2 o) => (o - this).length;
        public readonly double angleTo(dvec2 o) => (double)Math.Acos(this.dot(o) / (this.length * o.length));
        public readonly dvec2 reflect(dvec2 normal) => this - (normal * 2 * (this.dot(normal) / normal.dot(normal)));
        #endregion

        #region conversion
        public static implicit operator dvec2((double, double) tuple) => new dvec2(tuple.Item1, tuple.Item2);
        public static explicit operator ivec2(dvec2 v) => new ivec2((int)v.x, (int)v.y);
        public static explicit operator vec2(dvec2 v) => new vec2((float)v.x, (float)v.y);
        public static implicit operator dvec2(double n) => new dvec2(n, n);
        #endregion

        #region other
        public override string ToString() => $"({x}, {y})";
        #endregion
    }
    public static partial class math {
        /// <summary>
        /// Takes the floor of each component in the given dvec2.
        /// </summary>
        public static dvec2 floor(in dvec2 o) => new dvec2(floor(o.x), floor(o.y));
        /// <summary>
        /// Takes the fract of each component in the given dvec2.
        /// </summary>
        public static dvec2 fract(in dvec2 o) => new dvec2(fract(o.x), fract(o.y));
        /// <summary>
        /// Takes the sqrt of each component in the given dvec2.
        /// </summary>
        public static dvec2 sqrt(in dvec2 o) => new dvec2(sqrt(o.x), sqrt(o.y));
        /// <summary>
        /// Takes the sin of each component in the given dvec2.
        /// </summary>
        public static dvec2 sin(in dvec2 o) => new dvec2(sin(o.x), sin(o.y));
        /// <summary>
        /// Takes the cos of each component in the given dvec2.
        /// </summary>
        public static dvec2 cos(in dvec2 o) => new dvec2(cos(o.x), cos(o.y));
        /// <summary>
        /// Takes the tan of each component in the given dvec2.
        /// </summary>
        public static dvec2 tan(in dvec2 o) => new dvec2(tan(o.x), tan(o.y));
        /// <summary>
        /// Takes the abs of each component in the given dvec2.
        /// </summary>
        public static dvec2 abs(in dvec2 o) => new dvec2(abs(o.x), abs(o.y));
        /// <summary>
        /// Linear interpolation of two dvec2 by t.
        /// </summary>
        public static dvec2 lerp(in dvec2 x, in dvec2 y, double t) => x + (y - x) * t;
        /// <summary>
        /// Gets the dvec2 at location t along a curve.
        /// </summary>
        public static dvec2 bezier(in dvec2 a, in dvec2 b, in dvec2 c, double t) => a + ((b - a)*2 + (c - a)*t)*t;
    }
}
