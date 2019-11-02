using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Nums {
    [StructLayout(LayoutKind.Sequential)]
    public struct vec2 : IVector<vec2> {

        #region constants
        public static readonly vec2 zero = (0, 0);
        public static readonly vec2 unitX = (1, 0);
        public static readonly vec2 unitY = (0, 1);
        public static readonly vec2 one = (1, 1);
        #endregion

        public float x, y;
        public float sum => x + y;

        public vec2(float x, float y) {
            this.x = x; this.y = y;
        }

        #region Operators

        #region arithmetic
        public vec2 add(vec2 v) => new vec2(x + v.x, y + v.y);
        public static vec2 operator +(vec2 a, vec2 b) => a.add(b);

        public vec2 divide(vec2 v) => new vec2(x / v.x, y / v.y);
        public static vec2 operator /(vec2 a, vec2 b) => a.divide(b);

        public vec2 divide(float f) => new vec2(x / f, y / f);
        public static vec2 operator /(vec2 a, float f) => a.divide(f);

        public vec2 multiply(vec2 v) => new vec2(x * v.x, y * v.y);
        public static vec2 operator *(vec2 a, vec2 b) => a.multiply(b);

        public vec2 multiply(float f) => new vec2(x * f, y * f);
        public static vec2 operator *(vec2 a, float f) => a.multiply(f);

        public vec2 subtract(vec2 v) => new vec2(x - v.x, y - v.y);
        public static vec2 operator -(vec2 a, vec2 b) => a.subtract(b);

        public vec2 negate() => new vec2(-x, -y);
        public static vec2 operator -(vec2 a) => a.negate();
        #endregion

        #region boolean
        public bool Equals(vec2 other) => x == other.x && y == other.y;
        //public static bool operator ==(vec2 a, vec2 b) => a.Equals(b);
        //public static bool operator !=(vec2 a, vec2 b) => !a.Equals(b);
        #endregion

        #region conversion
        public static implicit operator vec2((float, float) tuple) => new vec2(tuple.Item1, tuple.Item2);
        #endregion

        #endregion
    }
}
