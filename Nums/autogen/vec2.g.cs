using System;

namespace Nums {

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct vec2 {

        #region constants
        public static readonly vec2 zero = (0, 0);
        public static readonly vec2 unitx = (1, 0);
        public static readonly vec2 unity = (0, 1);
        public static readonly vec2 one = (1, 1);
        #endregion

        public float x, y;
        public float sum => x + y;
        public int bytesize => sizeof(float) * 2;
        public float sqlength => dot(this);
        public float length => (float)Math.Sqrt(dot(this));
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
        #endregion

        #region conversion
        public static implicit operator vec2((float, float) tuple) => new vec2(tuple.Item1, tuple.Item2);
        #endregion
    }
}
