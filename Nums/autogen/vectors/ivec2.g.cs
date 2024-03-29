using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 2 component vector of int
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ivec2 : ivec {

        #region constants
        /// <summary>
        /// The zero vector: A vector where all components are equal to zero.
        /// </summary>
        public static readonly ivec2 zero = (0, 0);
        /// <summary>
        /// A unit vector pointing in the positive x direction. →
        /// </summary>
        public static readonly ivec2 unitx = (1, 0);
        /// <summary>
        /// A unit vector pointing in the positive y direction. ↑
        /// </summary>
        public static readonly ivec2 unity = (0, 1);
        /// <summary>
        /// A vector where all components are equal to one.
        /// </summary>
        public static readonly ivec2 one = (1, 1);
        #endregion

        /// <summary>
        /// The x component is the first index of the vector
        /// </summary>
        public int x;
        /// <summary>
        /// The y component is the second index of the vector
        /// </summary>
        public int y;
        /// <summary>
        /// The sum of the vectors components. x + y
        /// </summary>
        public readonly int sum => x + y;
        /// <summary>
        /// The number of bytes the vector type uses.
        /// </summary>
        public const int bytesize = sizeof(int) * 2;
        /// <summary>
        /// The magnitude of the vector
        /// </summary>
        public readonly int length => (int)Math.Sqrt(dot(this));
        /// <summary>
        /// The squared magnitude of the vector. sqlength is faster than length since a square-root operation is not needed.
        /// </summary>
        public readonly int sqlength => dot(this);
        /// <summary>
        /// The normalized version of this vector.
        /// </summary>
        public readonly ivec2 normalized() => this / length;
        /// <summary>
        /// Normalizes this vector.
        /// </summary>
        public void normalize() => this /= length;

        public int this[int i] {
            readonly get => i switch {
                0 => x,
                1 => y,
                _ => throw new IndexOutOfRangeException("ivec2[" + i + "] is not a valid index")
            };
            set {
                switch (i) {
                    case 0: x = value; return;
                    case 1: y = value; return;
                    default: throw new IndexOutOfRangeException("ivec2[" + i + "] is not a valid index");
                }
            }
        }

        #region swizzling properties
        /// <summary>
        /// A ivec2 containing the xx components of this vector
        /// </summary>
        public readonly ivec2 xx => new ivec2(x, x);
        /// <summary>
        /// A ivec2 containing the yx components of this vector
        /// </summary>
        public ivec2 yx {
            readonly get => new ivec2(y, x);
            set {
                y = value.x;
                x = value.y;
            }
        }
        /// <summary>
        /// A ivec2 containing the xy components of this vector
        /// </summary>
        public ivec2 xy {
            readonly get => new ivec2(x, y);
            set {
                x = value.x;
                y = value.y;
            }
        }
        /// <summary>
        /// A ivec2 containing the yy components of this vector
        /// </summary>
        public readonly ivec2 yy => new ivec2(y, y);
        #endregion

        #region constructors
        public ivec2(int x, int y) {
            this.x = x;
            this.y = y;
        }
        #endregion

        #region arithmetic
        public readonly int dot(ivec2 v) => (this * v).sum;

        public static ivec2 operator *(ivec2 a, ivec2 b) => new ivec2(a.x * b.x, a.y * b.y);
        public static ivec2 operator /(ivec2 a, ivec2 b) => new ivec2(a.x / b.x, a.y / b.y);
        public static ivec2 operator +(ivec2 a, ivec2 b) => new ivec2(a.x + b.x, a.y + b.y);
        public static ivec2 operator -(ivec2 a, ivec2 b) => new ivec2(a.x - b.x, a.y - b.y);

        public static ivec2 operator *(ivec2 a, int s) => new ivec2(a.x * s, a.y * s);
        public static ivec2 operator /(ivec2 a, int s) => new ivec2(a.x / s, a.y / s);

        public static ivec2 operator -(ivec2 v) => new ivec2(-v.x, -v.y);
        #endregion

        #region math
        public readonly int distTo(ivec2 o) => (o - this).length;
        public readonly int angleTo(ivec2 o) => (int)Math.Acos(this.dot(o) / (this.length * o.length));
        public readonly ivec2 reflect(ivec2 normal) => this - (normal * 2 * (this.dot(normal) / normal.dot(normal)));
        #endregion

        #region conversion/deconstructors
        public static implicit operator ivec2((int, int) tuple) => new ivec2(tuple.Item1, tuple.Item2);
        public static implicit operator vec2(ivec2 v) => new vec2(v.x, v.y);
        public static implicit operator dvec2(ivec2 v) => new dvec2(v.x, v.y);
        public static implicit operator ivec2(int n) => new ivec2(n, n);
        public void Deconstruct(out int x, out int y) => (x, y) = (this.x, this.y);
        #endregion

        #region other
        public override string ToString() => $"({x}, {y})";
        #endregion
    }
    public static partial class math {
        /// <summary>
        /// Takes the abs of each component in the given ivec2.
        /// </summary>
        public static ivec2 abs(in ivec2 o) => new ivec2(abs(o.x), abs(o.y));
        /// <summary>
        /// Takes the min of each component in the given ivec2.
        /// </summary>
        public static ivec2 min(in ivec2 a, in ivec2 b) => new ivec2(min(a.x, b.x), min(a.y, b.y));
        /// <summary>
        /// Takes the max of each component in the given ivec2.
        /// </summary>
        public static ivec2 max(in ivec2 a, in ivec2 b) => new ivec2(max(a.x, b.x), max(a.y, b.y));
        /// <summary>
        /// Linear interpolation of two ivec2 by t.
        /// </summary>
        public static ivec2 lerp(in ivec2 x, in ivec2 y, int t) => x + (y - x) * t;
        /// <summary>
        /// Gets the ivec2 at location t along a curve.
        /// </summary>
        public static ivec2 bezier(in ivec2 a, in ivec2 b, in ivec2 c, int t) => a + ((b - a)*2 + (c - 2*b + a)*t)*t;
    }
}
