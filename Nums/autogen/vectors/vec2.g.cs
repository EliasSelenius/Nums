using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 2 component vector of float
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct vec2 : vec {

        #region constants
        /// <summary>
        /// The zero vector: A vector where all components are equal to zero.
        /// </summary>
        public static readonly vec2 zero = (0, 0);
        /// <summary>
        /// A unit vector pointing in the positive x direction. →
        /// </summary>
        public static readonly vec2 unitx = (1, 0);
        /// <summary>
        /// A unit vector pointing in the positive y direction. ↑
        /// </summary>
        public static readonly vec2 unity = (0, 1);
        /// <summary>
        /// A vector where all components are equal to one.
        /// </summary>
        public static readonly vec2 one = (1, 1);
        #endregion

        /// <summary>
        /// The x component is the first index of the vector
        /// </summary>
        public float x;
        /// <summary>
        /// The y component is the second index of the vector
        /// </summary>
        public float y;
        /// <summary>
        /// The sum of the vectors components. x + y
        /// </summary>
        public readonly float sum => x + y;
        /// <summary>
        /// The number of bytes the vector type uses.
        /// </summary>
        public const int bytesize = sizeof(float) * 2;
        /// <summary>
        /// The magnitude of the vector
        /// </summary>
        public readonly float length => (float)Math.Sqrt(dot(this));
        /// <summary>
        /// The squared magnitude of the vector. sqlength is faster than length since a square-root operation is not needed.
        /// </summary>
        public readonly float sqlength => dot(this);
        /// <summary>
        /// The normalized version of this vector.
        /// </summary>
        public readonly vec2 normalized() => this / length;
        /// <summary>
        /// Normalizes this vector.
        /// </summary>
        public void normalize() => this /= length;

        public float this[int i] {
            readonly get => i switch {
                0 => x,
                1 => y,
                _ => throw new IndexOutOfRangeException("vec2[" + i + "] is not a valid index")
            };
            set {
                switch (i) {
                    case 0: x = value; return;
                    case 1: y = value; return;
                    default: throw new IndexOutOfRangeException("vec2[" + i + "] is not a valid index");
                }
            }
        }

        #region swizzling properties
        /// <summary>
        /// A vec2 containing the xx components of this vector
        /// </summary>
        public readonly vec2 xx => new vec2(x, x);
        /// <summary>
        /// A vec2 containing the yx components of this vector
        /// </summary>
        public vec2 yx {
            readonly get => new vec2(y, x);
            set {
                y = value.x;
                x = value.y;
            }
        }
        /// <summary>
        /// A vec2 containing the xy components of this vector
        /// </summary>
        public vec2 xy {
            readonly get => new vec2(x, y);
            set {
                x = value.x;
                y = value.y;
            }
        }
        /// <summary>
        /// A vec2 containing the yy components of this vector
        /// </summary>
        public readonly vec2 yy => new vec2(y, y);
        #endregion

        #region constructors
        public vec2(float x, float y) {
            this.x = x;
            this.y = y;
        }
        #endregion

        #region arithmetic
        public readonly float dot(vec2 v) => (this * v).sum;

        public static vec2 operator *(vec2 a, vec2 b) => new vec2(a.x * b.x, a.y * b.y);
        public static vec2 operator /(vec2 a, vec2 b) => new vec2(a.x / b.x, a.y / b.y);
        public static vec2 operator +(vec2 a, vec2 b) => new vec2(a.x + b.x, a.y + b.y);
        public static vec2 operator -(vec2 a, vec2 b) => new vec2(a.x - b.x, a.y - b.y);

        public static vec2 operator *(vec2 a, float s) => new vec2(a.x * s, a.y * s);
        public static vec2 operator /(vec2 a, float s) => new vec2(a.x / s, a.y / s);

        public static vec2 operator -(vec2 v) => new vec2(-v.x, -v.y);
        #endregion

        #region math
        public readonly float distTo(vec2 o) => (o - this).length;
        public readonly float angleTo(vec2 o) => (float)Math.Acos(this.dot(o) / (this.length * o.length));
        public readonly vec2 reflect(vec2 normal) => this - (normal * 2 * (this.dot(normal) / normal.dot(normal)));
        #endregion

        #region conversion
        public static implicit operator vec2((float, float) tuple) => new vec2(tuple.Item1, tuple.Item2);
        public static explicit operator ivec2(vec2 v) => new ivec2((int)v.x, (int)v.y);
        public static implicit operator dvec2(vec2 v) => new dvec2(v.x, v.y);
        public static implicit operator vec2(float n) => new vec2(n, n);
        #endregion

        #region other
        public override string ToString() => $"({x}, {y})";
        #endregion
    }
    public static partial class math {
        /// <summary>
        /// Takes the floor of each component in the given vec2.
        /// </summary>
        public static vec2 floor(in vec2 o) => new vec2(floor(o.x), floor(o.y));
        /// <summary>
        /// Takes the fract of each component in the given vec2.
        /// </summary>
        public static vec2 fract(in vec2 o) => new vec2(fract(o.x), fract(o.y));
        /// <summary>
        /// Takes the sqrt of each component in the given vec2.
        /// </summary>
        public static vec2 sqrt(in vec2 o) => new vec2(sqrt(o.x), sqrt(o.y));
        /// <summary>
        /// Takes the sin of each component in the given vec2.
        /// </summary>
        public static vec2 sin(in vec2 o) => new vec2(sin(o.x), sin(o.y));
        /// <summary>
        /// Takes the cos of each component in the given vec2.
        /// </summary>
        public static vec2 cos(in vec2 o) => new vec2(cos(o.x), cos(o.y));
        /// <summary>
        /// Takes the tan of each component in the given vec2.
        /// </summary>
        public static vec2 tan(in vec2 o) => new vec2(tan(o.x), tan(o.y));
        /// <summary>
        /// Takes the abs of each component in the given vec2.
        /// </summary>
        public static vec2 abs(in vec2 o) => new vec2(abs(o.x), abs(o.y));
        /// <summary>
        /// Linear interpolation of two vec2 by t.
        /// </summary>
        public static vec2 lerp(in vec2 x, in vec2 y, float t) => x + (y - x) * t;
        /// <summary>
        /// Gets the vec2 at location t along a curve.
        /// </summary>
        public static vec2 bezier(in vec2 a, in vec2 b, in vec2 c, float t) => a + ((b - a)*2 + (c - a)*t)*t;
    }
}
