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
        public vec3 xxx => new vec3(x, x, x);
        public vec3 yxx => new vec3(y, x, x);
        public vec3 zxx => new vec3(z, x, x);
        public vec3 xyx => new vec3(x, y, x);
        public vec3 yyx => new vec3(y, y, x);
        public vec3 zyx {
            get => new vec3(z, y, x);
            set {
                z = value.x;
                y = value.y;
                x = value.z;
            }
        }
        public vec3 xzx => new vec3(x, z, x);
        public vec3 yzx {
            get => new vec3(y, z, x);
            set {
                y = value.x;
                z = value.y;
                x = value.z;
            }
        }
        public vec3 zzx => new vec3(z, z, x);
        public vec3 xxy => new vec3(x, x, y);
        public vec3 yxy => new vec3(y, x, y);
        public vec3 zxy {
            get => new vec3(z, x, y);
            set {
                z = value.x;
                x = value.y;
                y = value.z;
            }
        }
        public vec3 xyy => new vec3(x, y, y);
        public vec3 yyy => new vec3(y, y, y);
        public vec3 zyy => new vec3(z, y, y);
        public vec3 xzy {
            get => new vec3(x, z, y);
            set {
                x = value.x;
                z = value.y;
                y = value.z;
            }
        }
        public vec3 yzy => new vec3(y, z, y);
        public vec3 zzy => new vec3(z, z, y);
        public vec3 xxz => new vec3(x, x, z);
        public vec3 yxz {
            get => new vec3(y, x, z);
            set {
                y = value.x;
                x = value.y;
                z = value.z;
            }
        }
        public vec3 zxz => new vec3(z, x, z);
        public vec3 xyz {
            get => new vec3(x, y, z);
            set {
                x = value.x;
                y = value.y;
                z = value.z;
            }
        }
        public vec3 yyz => new vec3(y, y, z);
        public vec3 zyz => new vec3(z, y, z);
        public vec3 xzz => new vec3(x, z, z);
        public vec3 yzz => new vec3(y, z, z);
        public vec3 zzz => new vec3(z, z, z);
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
