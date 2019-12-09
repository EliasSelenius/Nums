using System;

namespace Nums {

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct ivec3 {

        #region constants
        public static readonly ivec3 zero = (0, 0, 0);
        public static readonly ivec3 unitx = (1, 0, 0);
        public static readonly ivec3 unity = (0, 1, 0);
        public static readonly ivec3 unitz = (0, 0, 1);
        public static readonly ivec3 one = (1, 1, 1);
        #endregion

        public int x, y, z;
        public int sum => x + y + z;
        public int bytesize => sizeof(int) * 3;
        public int sqlength => dot(this);
        public int length => (int)Math.Sqrt(dot(this));
        public ivec3 normalized => this / length;

        public int this[int i] {
            get => i switch {
                0 => x,
                1 => y,
                2 => z,
                _ => throw new IndexOutOfRangeException("ivec3[" + i + "] is not a valid index")
            };
            set {
                switch (i) {
                    case 0: x = value; return;
                    case 1: y = value; return;
                    case 2: z = value; return;
                    default: throw new IndexOutOfRangeException("ivec3[" + i + "] is not a valid index");
                }
            }
        }

        #region swizzling properties
        public ivec3 xxx => new ivec3(x, x, x);
        public ivec3 yxx => new ivec3(y, x, x);
        public ivec3 zxx => new ivec3(z, x, x);
        public ivec3 xyx => new ivec3(x, y, x);
        public ivec3 yyx => new ivec3(y, y, x);
        public ivec3 zyx {
            get => new ivec3(z, y, x);
            set {
                z = value.x;
                y = value.y;
                x = value.z;
            }
        }
        public ivec3 xzx => new ivec3(x, z, x);
        public ivec3 yzx {
            get => new ivec3(y, z, x);
            set {
                y = value.x;
                z = value.y;
                x = value.z;
            }
        }
        public ivec3 zzx => new ivec3(z, z, x);
        public ivec3 xxy => new ivec3(x, x, y);
        public ivec3 yxy => new ivec3(y, x, y);
        public ivec3 zxy {
            get => new ivec3(z, x, y);
            set {
                z = value.x;
                x = value.y;
                y = value.z;
            }
        }
        public ivec3 xyy => new ivec3(x, y, y);
        public ivec3 yyy => new ivec3(y, y, y);
        public ivec3 zyy => new ivec3(z, y, y);
        public ivec3 xzy {
            get => new ivec3(x, z, y);
            set {
                x = value.x;
                z = value.y;
                y = value.z;
            }
        }
        public ivec3 yzy => new ivec3(y, z, y);
        public ivec3 zzy => new ivec3(z, z, y);
        public ivec3 xxz => new ivec3(x, x, z);
        public ivec3 yxz {
            get => new ivec3(y, x, z);
            set {
                y = value.x;
                x = value.y;
                z = value.z;
            }
        }
        public ivec3 zxz => new ivec3(z, x, z);
        public ivec3 xyz {
            get => new ivec3(x, y, z);
            set {
                x = value.x;
                y = value.y;
                z = value.z;
            }
        }
        public ivec3 yyz => new ivec3(y, y, z);
        public ivec3 zyz => new ivec3(z, y, z);
        public ivec3 xzz => new ivec3(x, z, z);
        public ivec3 yzz => new ivec3(y, z, z);
        public ivec3 zzz => new ivec3(z, z, z);
        #endregion

        #region constructors
        public ivec3(int x, int y, int z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        #endregion

        #region arithmetic
        public int dot(ivec3 v) => (this * v).sum;

        public static ivec3 operator *(ivec3 a, ivec3 b) => new ivec3(a.x * b.x, a.y * b.y, a.z * b.z);
        public static ivec3 operator /(ivec3 a, ivec3 b) => new ivec3(a.x / b.x, a.y / b.y, a.z / b.z);
        public static ivec3 operator +(ivec3 a, ivec3 b) => new ivec3(a.x + b.x, a.y + b.y, a.z + b.z);
        public static ivec3 operator -(ivec3 a, ivec3 b) => new ivec3(a.x - b.x, a.y - b.y, a.z - b.z);

        public static ivec3 operator *(ivec3 a, int s) => new ivec3(a.x * s, a.y * s, a.z * s);
        public static ivec3 operator /(ivec3 a, int s) => new ivec3(a.x / s, a.y / s, a.z / s);

        public static ivec3 operator -(ivec3 v) => new ivec3(-v.x, -v.y, -v.z);
        #endregion

        #region math
        public int distTo(ivec3 o) => (o - this).length;
        public int angleTo(ivec3 o) => (int)Math.Acos(this.dot(o) / (this.length * o.length));
        public ivec3 lerp(ivec3 o, int t) => this + ((o - this) * t);
        #endregion

        #region conversion
        public static implicit operator ivec3((int, int, int) tuple) => new ivec3(tuple.Item1, tuple.Item2, tuple.Item3);
        #endregion
    }
}
