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
        public int sum => x + y;
        /// <summary>
        /// The number of bytes the vector type uses.
        /// </summary>
        public const int bytesize = sizeof(int) * 2;
        /// <summary>
        /// The magnitude of the vector
        /// </summary>
        public int length => (int)Math.Sqrt(dot(this));
        /// <summary>
        /// The squared magnitude of the vector. sqlength is faster than length since a square-root operation is not needed.
        /// </summary>
        public int sqlength => dot(this);
        /// <summary>
        /// The normalized version of this vector.
        /// </summary>
        public ivec2 normalized() => this / length;
        /// <summary>
        /// Normalizes this vector.
        /// </summary>
        public void normalize() => this /= length;

        public int this[int i] {
            get => i switch {
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
        public ivec2 xx => new ivec2(x, x);
        public ivec2 yx {
            get => new ivec2(y, x);
            set {
                y = value.x;
                x = value.y;
            }
        }
        public ivec2 xy {
            get => new ivec2(x, y);
            set {
                x = value.x;
                y = value.y;
            }
        }
        public ivec2 yy => new ivec2(y, y);
        #endregion

        #region constructors
        public ivec2(int x, int y) {
            this.x = x;
            this.y = y;
        }
        #endregion

        #region arithmetic
        public int dot(ivec2 v) => (this * v).sum;

        public static ivec2 operator *(ivec2 a, ivec2 b) => new ivec2(a.x * b.x, a.y * b.y);
        public static ivec2 operator /(ivec2 a, ivec2 b) => new ivec2(a.x / b.x, a.y / b.y);
        public static ivec2 operator +(ivec2 a, ivec2 b) => new ivec2(a.x + b.x, a.y + b.y);
        public static ivec2 operator -(ivec2 a, ivec2 b) => new ivec2(a.x - b.x, a.y - b.y);

        public static ivec2 operator *(ivec2 a, int s) => new ivec2(a.x * s, a.y * s);
        public static ivec2 operator /(ivec2 a, int s) => new ivec2(a.x / s, a.y / s);

        public static ivec2 operator -(ivec2 v) => new ivec2(-v.x, -v.y);
        #endregion

        #region math
        public int distTo(ivec2 o) => (o - this).length;
        public int angleTo(ivec2 o) => (int)Math.Acos(this.dot(o) / (this.length * o.length));
        public ivec2 lerp(ivec2 o, int t) => this + ((o - this) * t);
        public ivec2 reflect(ivec2 normal) => this - (normal * 2 * (this.dot(normal) / normal.dot(normal)));
        #endregion

        #region conversion
        public static implicit operator ivec2((int, int) tuple) => new ivec2(tuple.Item1, tuple.Item2);
        public static implicit operator vec2(ivec2 v) => new vec2(v.x, v.y);
        public static implicit operator dvec2(ivec2 v) => new dvec2(v.x, v.y);
        public static implicit operator ivec2(int n) => new ivec2(n, n);
        #endregion

        #region other
        public override string ToString() => $"({x}, {y})";
        #endregion
    }
    public static partial class math {
    }
}
