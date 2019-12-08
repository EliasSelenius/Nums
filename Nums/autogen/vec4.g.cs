using System;

namespace Nums {

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct vec4 {

        #region constants
        #endregion

        public float x, y, z, w;
        public float sum => x + y + z + w;
        public int bytesize => sizeof(float) * 4;
        public float sqlength => dot(this);
        public float length => (float)Math.Sqrt(dot(this));
        public vec4 normalized => this / length;

        #region swizzling properties
        #endregion

        #region constructors
        public vec4(float x, float y, float z, float w) {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        #endregion

        #region arithmetic
        public float dot(vec4 v) => (this * v).sum;

        public static vec4 operator *(vec4 a, vec4 b) => new vec4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        public static vec4 operator /(vec4 a, vec4 b) => new vec4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
        public static vec4 operator +(vec4 a, vec4 b) => new vec4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        public static vec4 operator -(vec4 a, vec4 b) => new vec4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);

        public static vec4 operator *(vec4 a, float s) => new vec4(a.x * s, a.y * s, a.z * s, a.w * s);
        public static vec4 operator /(vec4 a, float s) => new vec4(a.x / s, a.y / s, a.z / s, a.w / s);
        #endregion

        #region math
        #endregion

        #region conversion
        #endregion
    }
}
