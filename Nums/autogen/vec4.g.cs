using System;

namespace Nums {

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct vec4 {

        #region constants
        public static readonly vec4 zero = (0, 0, 0, 0);
        public static readonly vec4 unitx = (1, 0, 0, 0);
        public static readonly vec4 unity = (0, 1, 0, 0);
        public static readonly vec4 unitz = (0, 0, 1, 0);
        public static readonly vec4 unitw = (0, 0, 0, 1);
        public static readonly vec4 one = (1, 1, 1, 1);
        #endregion

        public float x, y, z, w;
        public float sum => x + y + z + w;
        public int bytesize => sizeof(float) * 4;
        public float sqlength => dot(this);
        public float length => (float)Math.Sqrt(dot(this));
        public vec4 normalized => this / length;

        public float this[int i] {
            get => i switch {
                0 => x,
                1 => y,
                2 => z,
                3 => w,
                _ => throw new IndexOutOfRangeException("vec4[" + i + "] is not a valid index")
            };
            set {
                switch (i) {
                    case 0: x = value; return;
                    case 1: y = value; return;
                    case 2: z = value; return;
                    case 3: w = value; return;
                    default: throw new IndexOutOfRangeException("vec4[" + i + "] is not a valid index");
                }
            }
        }

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

        public static vec4 operator -(vec4 v) => new vec4(-v.x, -v.y, -v.z, -v.w);
        #endregion

        #region math
        public float distTo(vec4 o) => (o - this).length;
        public float angleTo(vec4 o) => (float)Math.Acos(this.dot(o) / (this.length * o.length));
        public vec4 lerp(vec4 o, float t) => this + ((o - this) * t);
        #endregion

        #region conversion
        public static implicit operator vec4((float, float, float, float) tuple) => new vec4(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
        #endregion
    }
}
