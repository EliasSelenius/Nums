using System;

namespace Nums {

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct ivec2 {

        #region constants
        public static readonly ivec2 zero = (0, 0);
        public static readonly ivec2 unitx = (1, 0);
        public static readonly ivec2 unity = (0, 1);
        public static readonly ivec2 one = (1, 1);
        #endregion

        public int x, y;
        public int sum => x + y;
        public int bytesize => sizeof(int) * 2;
        public int sqlength => dot(this);
        public int length => (int)Math.Sqrt(dot(this));
        public ivec2 normalized => this / length;

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
        #endregion

        #region conversion
        public static implicit operator ivec2((int, int) tuple) => new ivec2(tuple.Item1, tuple.Item2);
        #endregion
    }
}
