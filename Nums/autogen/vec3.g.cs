using System;

namespace Nums {

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct vec3 {

        #region constants
        public static readonly vec3 zero = (0, 0, 0);
        public static readonly vec3 unitx = (1, 0, 0);
        public static readonly vec3 unity = (0, 1, 0);
        public static readonly vec3 unitz = (0, 0, 1);
        public static readonly vec3 one = (1, 1, 1);
        #endregion

        public float x, y, z;
        public float sum => x + y + z;
        public int bytesize => sizeof(float) * 3;
        public float sqlength => dot(this);
        public float length => (float)Math.Sqrt(dot(this));
        public vec3 normalized => this / length;

        public float this[int i] {
            get => i switch {
                0 => x,
                1 => y,
                2 => z,
                _ => throw new IndexOutOfRangeException("vec3[" + i + "] is not a valid index")
            };
            set {
                switch (i) {
                    case 0: x = value; return;
                    case 1: y = value; return;
                    case 2: z = value; return;
                    default: throw new IndexOutOfRangeException("vec3[" + i + "] is not a valid index");
                }
            }
        }

        #region swizzling properties
        #endregion

        #region constructors
        public vec3(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        #endregion

        #region arithmetic
        public float dot(vec3 v) => (this * v).sum;

        public static vec3 operator *(vec3 a, vec3 b) => new vec3(a.x * b.x, a.y * b.y, a.z * b.z);
        public static vec3 operator /(vec3 a, vec3 b) => new vec3(a.x / b.x, a.y / b.y, a.z / b.z);
        public static vec3 operator +(vec3 a, vec3 b) => new vec3(a.x + b.x, a.y + b.y, a.z + b.z);
        public static vec3 operator -(vec3 a, vec3 b) => new vec3(a.x - b.x, a.y - b.y, a.z - b.z);

        public static vec3 operator *(vec3 a, float s) => new vec3(a.x * s, a.y * s, a.z * s);
        public static vec3 operator /(vec3 a, float s) => new vec3(a.x / s, a.y / s, a.z / s);

        public static vec3 operator -(vec3 v) => new vec3(-v.x, -v.y, -v.z);
        #endregion

        #region math
        public float distTo(vec3 o) => (o - this).length;
        public float angleTo(vec3 o) => (float)Math.Acos(this.dot(o) / (this.length * o.length));
        public vec3 lerp(vec3 o, float t) => this + ((o - this) * t);
        #endregion

        #region conversion
        public static implicit operator vec3((float, float, float) tuple) => new vec3(tuple.Item1, tuple.Item2, tuple.Item3);
        #endregion
    }
}
