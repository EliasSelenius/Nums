using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 2 component vector of float
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct vec2 {

        #region constants
        /// <summary>
        /// The zero vector: A vector where all components are equal to zero.
        /// </summary>
        public static readonly vec2 zero = (0, 0);
        /// <summary>
        /// A unit vector pointing in the positive x direction.
        /// </summary>
        public static readonly vec2 unitx = (1, 0);
        /// <summary>
        /// A unit vector pointing in the positive y direction.
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
        public float sum => x + y;
        /// <summary>
        /// The number of bytes the vector type uses.
        /// </summary>
        public int bytesize => sizeof(float) * 2;
        /// <summary>
        /// The magnitude of the vector
        /// </summary>
        public float length => (float)Math.Sqrt(dot(this));
        /// <summary>
        /// The squared magnitude of the vector. sqlength is faster than length since a square-root operation is not needed.
        /// </summary>
        public float sqlength => dot(this);
        /// <summary>
        /// The normalized version of this vector.
        /// </summary>
        public vec2 normalized => this / length;

        public float this[int i] {
            get => i switch {
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
        public vec2 xx => new vec2(x, x);
        public vec2 yx {
            get => new vec2(y, x);
            set {
                y = value.x;
                x = value.y;
            }
        }
        public vec2 xy {
            get => new vec2(x, y);
            set {
                x = value.x;
                y = value.y;
            }
        }
        public vec2 yy => new vec2(y, y);
        #endregion

        #region constructors
        public vec2(float x, float y) {
            this.x = x;
            this.y = y;
        }
        #endregion

        #region arithmetic
        public float dot(vec2 v) => (this * v).sum;

        public static vec2 operator *(vec2 a, vec2 b) => new vec2(a.x * b.x, a.y * b.y);
        public static vec2 operator /(vec2 a, vec2 b) => new vec2(a.x / b.x, a.y / b.y);
        public static vec2 operator +(vec2 a, vec2 b) => new vec2(a.x + b.x, a.y + b.y);
        public static vec2 operator -(vec2 a, vec2 b) => new vec2(a.x - b.x, a.y - b.y);

        public static vec2 operator *(vec2 a, float s) => new vec2(a.x * s, a.y * s);
        public static vec2 operator /(vec2 a, float s) => new vec2(a.x / s, a.y / s);

        public static vec2 operator -(vec2 v) => new vec2(-v.x, -v.y);
        #endregion

        #region math
        public float distTo(vec2 o) => (o - this).length;
        public float angleTo(vec2 o) => (float)Math.Acos(this.dot(o) / (this.length * o.length));
        public vec2 lerp(vec2 o, float t) => this + ((o - this) * t);
        public vec2 reflect(vec2 normal) => this - (normal * 2 * (this.dot(normal) / normal.dot(normal)));
        #endregion

        #region conversion
        public static implicit operator vec2((float, float) tuple) => new vec2(tuple.Item1, tuple.Item2);
        #endregion

        #region other
        public override string ToString() => $"({x}, {y})";
        #endregion
    }
}
