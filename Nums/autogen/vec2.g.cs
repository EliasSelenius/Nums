using System;

namespace Nums {

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct vec2 {

        #region constants
        #endregion

        public float x, y;
        public float sum => x + y;
        public int bytesize => sizeof(float) * 2;
        public float sqlength => dot(this);
        public float length => (float)Math.Sqrt(dot(this));
        public vec2 normalized => this / length;

        #region swizzling properties
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
        #endregion

        #region math
        #endregion

        #region conversion
        #endregion
    }
}
