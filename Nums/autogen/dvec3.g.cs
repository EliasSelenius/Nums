using System;

namespace Nums {

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct dvec3 {

        #region constants
        public static readonly dvec3 zero = (0, 0, 0);
        public static readonly dvec3 unitx = (1, 0, 0);
        public static readonly dvec3 unity = (0, 1, 0);
        public static readonly dvec3 unitz = (0, 0, 1);
        public static readonly dvec3 one = (1, 1, 1);
        #endregion

        public double x, y, z;
        public double sum => x + y + z;
        public int bytesize => sizeof(double) * 3;
        public double sqlength => dot(this);
        public double length => (double)Math.Sqrt(dot(this));
        public dvec3 normalized => this / length;

        public double this[int i] {
            get => i switch {
                0 => x,
                1 => y,
                2 => z,
                _ => throw new IndexOutOfRangeException("dvec3[" + i + "] is not a valid index")
            };
            set {
                switch (i) {
                    case 0: x = value; return;
                    case 1: y = value; return;
                    case 2: z = value; return;
                    default: throw new IndexOutOfRangeException("dvec3[" + i + "] is not a valid index");
                }
            }
        }

        #region swizzling properties
        public dvec2 xx => new dvec2(x, x);
        public dvec2 yx {
            get => new dvec2(y, x);
            set {
                y = value.x;
                x = value.y;
            }
        }
        public dvec2 zx {
            get => new dvec2(z, x);
            set {
                z = value.x;
                x = value.y;
            }
        }
        public dvec2 xy {
            get => new dvec2(x, y);
            set {
                x = value.x;
                y = value.y;
            }
        }
        public dvec2 yy => new dvec2(y, y);
        public dvec2 zy {
            get => new dvec2(z, y);
            set {
                z = value.x;
                y = value.y;
            }
        }
        public dvec2 xz {
            get => new dvec2(x, z);
            set {
                x = value.x;
                z = value.y;
            }
        }
        public dvec2 yz {
            get => new dvec2(y, z);
            set {
                y = value.x;
                z = value.y;
            }
        }
        public dvec2 zz => new dvec2(z, z);
        public dvec3 xxx => new dvec3(x, x, x);
        public dvec3 yxx => new dvec3(y, x, x);
        public dvec3 zxx => new dvec3(z, x, x);
        public dvec3 xyx => new dvec3(x, y, x);
        public dvec3 yyx => new dvec3(y, y, x);
        public dvec3 zyx {
            get => new dvec3(z, y, x);
            set {
                z = value.x;
                y = value.y;
                x = value.z;
            }
        }
        public dvec3 xzx => new dvec3(x, z, x);
        public dvec3 yzx {
            get => new dvec3(y, z, x);
            set {
                y = value.x;
                z = value.y;
                x = value.z;
            }
        }
        public dvec3 zzx => new dvec3(z, z, x);
        public dvec3 xxy => new dvec3(x, x, y);
        public dvec3 yxy => new dvec3(y, x, y);
        public dvec3 zxy {
            get => new dvec3(z, x, y);
            set {
                z = value.x;
                x = value.y;
                y = value.z;
            }
        }
        public dvec3 xyy => new dvec3(x, y, y);
        public dvec3 yyy => new dvec3(y, y, y);
        public dvec3 zyy => new dvec3(z, y, y);
        public dvec3 xzy {
            get => new dvec3(x, z, y);
            set {
                x = value.x;
                z = value.y;
                y = value.z;
            }
        }
        public dvec3 yzy => new dvec3(y, z, y);
        public dvec3 zzy => new dvec3(z, z, y);
        public dvec3 xxz => new dvec3(x, x, z);
        public dvec3 yxz {
            get => new dvec3(y, x, z);
            set {
                y = value.x;
                x = value.y;
                z = value.z;
            }
        }
        public dvec3 zxz => new dvec3(z, x, z);
        public dvec3 xyz {
            get => new dvec3(x, y, z);
            set {
                x = value.x;
                y = value.y;
                z = value.z;
            }
        }
        public dvec3 yyz => new dvec3(y, y, z);
        public dvec3 zyz => new dvec3(z, y, z);
        public dvec3 xzz => new dvec3(x, z, z);
        public dvec3 yzz => new dvec3(y, z, z);
        public dvec3 zzz => new dvec3(z, z, z);
        #endregion

        #region constructors
        public dvec3(double x, double y, double z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        #endregion

        #region arithmetic
        public double dot(dvec3 v) => (this * v).sum;

        public static dvec3 operator *(dvec3 a, dvec3 b) => new dvec3(a.x * b.x, a.y * b.y, a.z * b.z);
        public static dvec3 operator /(dvec3 a, dvec3 b) => new dvec3(a.x / b.x, a.y / b.y, a.z / b.z);
        public static dvec3 operator +(dvec3 a, dvec3 b) => new dvec3(a.x + b.x, a.y + b.y, a.z + b.z);
        public static dvec3 operator -(dvec3 a, dvec3 b) => new dvec3(a.x - b.x, a.y - b.y, a.z - b.z);

        public static dvec3 operator *(dvec3 a, double s) => new dvec3(a.x * s, a.y * s, a.z * s);
        public static dvec3 operator /(dvec3 a, double s) => new dvec3(a.x / s, a.y / s, a.z / s);

        public static dvec3 operator -(dvec3 v) => new dvec3(-v.x, -v.y, -v.z);
        #endregion

        #region math
        public double distTo(dvec3 o) => (o - this).length;
        public double angleTo(dvec3 o) => (double)Math.Acos(this.dot(o) / (this.length * o.length));
        public dvec3 lerp(dvec3 o, double t) => this + ((o - this) * t);
        #endregion

        #region conversion
        public static implicit operator dvec3((double, double, double) tuple) => new dvec3(tuple.Item1, tuple.Item2, tuple.Item3);
        #endregion
    }
}
