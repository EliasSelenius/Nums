using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 4 component vector of double
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct dvec4 : dvec {

        #region constants
        /// <summary>
        /// The zero vector: A vector where all components are equal to zero.
        /// </summary>
        public static readonly dvec4 zero = (0, 0, 0, 0);
        /// <summary>
        /// A unit vector pointing in the positive x direction. →
        /// </summary>
        public static readonly dvec4 unitx = (1, 0, 0, 0);
        /// <summary>
        /// A unit vector pointing in the positive y direction. ↑
        /// </summary>
        public static readonly dvec4 unity = (0, 1, 0, 0);
        /// <summary>
        /// A unit vector pointing in the positive z direction. ↗
        /// </summary>
        public static readonly dvec4 unitz = (0, 0, 1, 0);
        /// <summary>
        /// A unit vector pointing in the positive w direction. 
        /// </summary>
        public static readonly dvec4 unitw = (0, 0, 0, 1);
        /// <summary>
        /// A vector where all components are equal to one.
        /// </summary>
        public static readonly dvec4 one = (1, 1, 1, 1);
        #endregion

        /// <summary>
        /// The x component is the first index of the vector
        /// </summary>
        public double x;
        /// <summary>
        /// The y component is the second index of the vector
        /// </summary>
        public double y;
        /// <summary>
        /// The z component is the third index of the vector
        /// </summary>
        public double z;
        /// <summary>
        /// The w component is the fourth index of the vector
        /// </summary>
        public double w;
        /// <summary>
        /// The sum of the vectors components. x + y + z + w
        /// </summary>
        public double sum => x + y + z + w;
        /// <summary>
        /// The number of bytes the vector type uses.
        /// </summary>
        public const int bytesize = sizeof(double) * 4;
        /// <summary>
        /// The magnitude of the vector
        /// </summary>
        public double length => (double)Math.Sqrt(dot(this));
        /// <summary>
        /// The squared magnitude of the vector. sqlength is faster than length since a square-root operation is not needed.
        /// </summary>
        public double sqlength => dot(this);
        /// <summary>
        /// The normalized version of this vector.
        /// </summary>
        public dvec4 normalized() => this / length;
        /// <summary>
        /// Normalizes this vector.
        /// </summary>
        public void normalize() => this /= length;

        public double this[int i] {
            get => i switch {
                0 => x,
                1 => y,
                2 => z,
                3 => w,
                _ => throw new IndexOutOfRangeException("dvec4[" + i + "] is not a valid index")
            };
            set {
                switch (i) {
                    case 0: x = value; return;
                    case 1: y = value; return;
                    case 2: z = value; return;
                    case 3: w = value; return;
                    default: throw new IndexOutOfRangeException("dvec4[" + i + "] is not a valid index");
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
        public dvec2 wx {
            get => new dvec2(w, x);
            set {
                w = value.x;
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
        public dvec2 wy {
            get => new dvec2(w, y);
            set {
                w = value.x;
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
        public dvec2 wz {
            get => new dvec2(w, z);
            set {
                w = value.x;
                z = value.y;
            }
        }
        public dvec2 xw {
            get => new dvec2(x, w);
            set {
                x = value.x;
                w = value.y;
            }
        }
        public dvec2 yw {
            get => new dvec2(y, w);
            set {
                y = value.x;
                w = value.y;
            }
        }
        public dvec2 zw {
            get => new dvec2(z, w);
            set {
                z = value.x;
                w = value.y;
            }
        }
        public dvec2 ww => new dvec2(w, w);
        public dvec3 xxx => new dvec3(x, x, x);
        public dvec3 yxx => new dvec3(y, x, x);
        public dvec3 zxx => new dvec3(z, x, x);
        public dvec3 wxx => new dvec3(w, x, x);
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
        public dvec3 wyx {
            get => new dvec3(w, y, x);
            set {
                w = value.x;
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
        public dvec3 wzx {
            get => new dvec3(w, z, x);
            set {
                w = value.x;
                z = value.y;
                x = value.z;
            }
        }
        public dvec3 xwx => new dvec3(x, w, x);
        public dvec3 ywx {
            get => new dvec3(y, w, x);
            set {
                y = value.x;
                w = value.y;
                x = value.z;
            }
        }
        public dvec3 zwx {
            get => new dvec3(z, w, x);
            set {
                z = value.x;
                w = value.y;
                x = value.z;
            }
        }
        public dvec3 wwx => new dvec3(w, w, x);
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
        public dvec3 wxy {
            get => new dvec3(w, x, y);
            set {
                w = value.x;
                x = value.y;
                y = value.z;
            }
        }
        public dvec3 xyy => new dvec3(x, y, y);
        public dvec3 yyy => new dvec3(y, y, y);
        public dvec3 zyy => new dvec3(z, y, y);
        public dvec3 wyy => new dvec3(w, y, y);
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
        public dvec3 wzy {
            get => new dvec3(w, z, y);
            set {
                w = value.x;
                z = value.y;
                y = value.z;
            }
        }
        public dvec3 xwy {
            get => new dvec3(x, w, y);
            set {
                x = value.x;
                w = value.y;
                y = value.z;
            }
        }
        public dvec3 ywy => new dvec3(y, w, y);
        public dvec3 zwy {
            get => new dvec3(z, w, y);
            set {
                z = value.x;
                w = value.y;
                y = value.z;
            }
        }
        public dvec3 wwy => new dvec3(w, w, y);
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
        public dvec3 wxz {
            get => new dvec3(w, x, z);
            set {
                w = value.x;
                x = value.y;
                z = value.z;
            }
        }
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
        public dvec3 wyz {
            get => new dvec3(w, y, z);
            set {
                w = value.x;
                y = value.y;
                z = value.z;
            }
        }
        public dvec3 xzz => new dvec3(x, z, z);
        public dvec3 yzz => new dvec3(y, z, z);
        public dvec3 zzz => new dvec3(z, z, z);
        public dvec3 wzz => new dvec3(w, z, z);
        public dvec3 xwz {
            get => new dvec3(x, w, z);
            set {
                x = value.x;
                w = value.y;
                z = value.z;
            }
        }
        public dvec3 ywz {
            get => new dvec3(y, w, z);
            set {
                y = value.x;
                w = value.y;
                z = value.z;
            }
        }
        public dvec3 zwz => new dvec3(z, w, z);
        public dvec3 wwz => new dvec3(w, w, z);
        public dvec3 xxw => new dvec3(x, x, w);
        public dvec3 yxw {
            get => new dvec3(y, x, w);
            set {
                y = value.x;
                x = value.y;
                w = value.z;
            }
        }
        public dvec3 zxw {
            get => new dvec3(z, x, w);
            set {
                z = value.x;
                x = value.y;
                w = value.z;
            }
        }
        public dvec3 wxw => new dvec3(w, x, w);
        public dvec3 xyw {
            get => new dvec3(x, y, w);
            set {
                x = value.x;
                y = value.y;
                w = value.z;
            }
        }
        public dvec3 yyw => new dvec3(y, y, w);
        public dvec3 zyw {
            get => new dvec3(z, y, w);
            set {
                z = value.x;
                y = value.y;
                w = value.z;
            }
        }
        public dvec3 wyw => new dvec3(w, y, w);
        public dvec3 xzw {
            get => new dvec3(x, z, w);
            set {
                x = value.x;
                z = value.y;
                w = value.z;
            }
        }
        public dvec3 yzw {
            get => new dvec3(y, z, w);
            set {
                y = value.x;
                z = value.y;
                w = value.z;
            }
        }
        public dvec3 zzw => new dvec3(z, z, w);
        public dvec3 wzw => new dvec3(w, z, w);
        public dvec3 xww => new dvec3(x, w, w);
        public dvec3 yww => new dvec3(y, w, w);
        public dvec3 zww => new dvec3(z, w, w);
        public dvec3 www => new dvec3(w, w, w);
        public dvec4 xxxx => new dvec4(x, x, x, x);
        public dvec4 yxxx => new dvec4(y, x, x, x);
        public dvec4 zxxx => new dvec4(z, x, x, x);
        public dvec4 wxxx => new dvec4(w, x, x, x);
        public dvec4 xyxx => new dvec4(x, y, x, x);
        public dvec4 yyxx => new dvec4(y, y, x, x);
        public dvec4 zyxx => new dvec4(z, y, x, x);
        public dvec4 wyxx => new dvec4(w, y, x, x);
        public dvec4 xzxx => new dvec4(x, z, x, x);
        public dvec4 yzxx => new dvec4(y, z, x, x);
        public dvec4 zzxx => new dvec4(z, z, x, x);
        public dvec4 wzxx => new dvec4(w, z, x, x);
        public dvec4 xwxx => new dvec4(x, w, x, x);
        public dvec4 ywxx => new dvec4(y, w, x, x);
        public dvec4 zwxx => new dvec4(z, w, x, x);
        public dvec4 wwxx => new dvec4(w, w, x, x);
        public dvec4 xxyx => new dvec4(x, x, y, x);
        public dvec4 yxyx => new dvec4(y, x, y, x);
        public dvec4 zxyx => new dvec4(z, x, y, x);
        public dvec4 wxyx => new dvec4(w, x, y, x);
        public dvec4 xyyx => new dvec4(x, y, y, x);
        public dvec4 yyyx => new dvec4(y, y, y, x);
        public dvec4 zyyx => new dvec4(z, y, y, x);
        public dvec4 wyyx => new dvec4(w, y, y, x);
        public dvec4 xzyx => new dvec4(x, z, y, x);
        public dvec4 yzyx => new dvec4(y, z, y, x);
        public dvec4 zzyx => new dvec4(z, z, y, x);
        public dvec4 wzyx {
            get => new dvec4(w, z, y, x);
            set {
                w = value.x;
                z = value.y;
                y = value.z;
                x = value.w;
            }
        }
        public dvec4 xwyx => new dvec4(x, w, y, x);
        public dvec4 ywyx => new dvec4(y, w, y, x);
        public dvec4 zwyx {
            get => new dvec4(z, w, y, x);
            set {
                z = value.x;
                w = value.y;
                y = value.z;
                x = value.w;
            }
        }
        public dvec4 wwyx => new dvec4(w, w, y, x);
        public dvec4 xxzx => new dvec4(x, x, z, x);
        public dvec4 yxzx => new dvec4(y, x, z, x);
        public dvec4 zxzx => new dvec4(z, x, z, x);
        public dvec4 wxzx => new dvec4(w, x, z, x);
        public dvec4 xyzx => new dvec4(x, y, z, x);
        public dvec4 yyzx => new dvec4(y, y, z, x);
        public dvec4 zyzx => new dvec4(z, y, z, x);
        public dvec4 wyzx {
            get => new dvec4(w, y, z, x);
            set {
                w = value.x;
                y = value.y;
                z = value.z;
                x = value.w;
            }
        }
        public dvec4 xzzx => new dvec4(x, z, z, x);
        public dvec4 yzzx => new dvec4(y, z, z, x);
        public dvec4 zzzx => new dvec4(z, z, z, x);
        public dvec4 wzzx => new dvec4(w, z, z, x);
        public dvec4 xwzx => new dvec4(x, w, z, x);
        public dvec4 ywzx {
            get => new dvec4(y, w, z, x);
            set {
                y = value.x;
                w = value.y;
                z = value.z;
                x = value.w;
            }
        }
        public dvec4 zwzx => new dvec4(z, w, z, x);
        public dvec4 wwzx => new dvec4(w, w, z, x);
        public dvec4 xxwx => new dvec4(x, x, w, x);
        public dvec4 yxwx => new dvec4(y, x, w, x);
        public dvec4 zxwx => new dvec4(z, x, w, x);
        public dvec4 wxwx => new dvec4(w, x, w, x);
        public dvec4 xywx => new dvec4(x, y, w, x);
        public dvec4 yywx => new dvec4(y, y, w, x);
        public dvec4 zywx {
            get => new dvec4(z, y, w, x);
            set {
                z = value.x;
                y = value.y;
                w = value.z;
                x = value.w;
            }
        }
        public dvec4 wywx => new dvec4(w, y, w, x);
        public dvec4 xzwx => new dvec4(x, z, w, x);
        public dvec4 yzwx {
            get => new dvec4(y, z, w, x);
            set {
                y = value.x;
                z = value.y;
                w = value.z;
                x = value.w;
            }
        }
        public dvec4 zzwx => new dvec4(z, z, w, x);
        public dvec4 wzwx => new dvec4(w, z, w, x);
        public dvec4 xwwx => new dvec4(x, w, w, x);
        public dvec4 ywwx => new dvec4(y, w, w, x);
        public dvec4 zwwx => new dvec4(z, w, w, x);
        public dvec4 wwwx => new dvec4(w, w, w, x);
        public dvec4 xxxy => new dvec4(x, x, x, y);
        public dvec4 yxxy => new dvec4(y, x, x, y);
        public dvec4 zxxy => new dvec4(z, x, x, y);
        public dvec4 wxxy => new dvec4(w, x, x, y);
        public dvec4 xyxy => new dvec4(x, y, x, y);
        public dvec4 yyxy => new dvec4(y, y, x, y);
        public dvec4 zyxy => new dvec4(z, y, x, y);
        public dvec4 wyxy => new dvec4(w, y, x, y);
        public dvec4 xzxy => new dvec4(x, z, x, y);
        public dvec4 yzxy => new dvec4(y, z, x, y);
        public dvec4 zzxy => new dvec4(z, z, x, y);
        public dvec4 wzxy {
            get => new dvec4(w, z, x, y);
            set {
                w = value.x;
                z = value.y;
                x = value.z;
                y = value.w;
            }
        }
        public dvec4 xwxy => new dvec4(x, w, x, y);
        public dvec4 ywxy => new dvec4(y, w, x, y);
        public dvec4 zwxy {
            get => new dvec4(z, w, x, y);
            set {
                z = value.x;
                w = value.y;
                x = value.z;
                y = value.w;
            }
        }
        public dvec4 wwxy => new dvec4(w, w, x, y);
        public dvec4 xxyy => new dvec4(x, x, y, y);
        public dvec4 yxyy => new dvec4(y, x, y, y);
        public dvec4 zxyy => new dvec4(z, x, y, y);
        public dvec4 wxyy => new dvec4(w, x, y, y);
        public dvec4 xyyy => new dvec4(x, y, y, y);
        public dvec4 yyyy => new dvec4(y, y, y, y);
        public dvec4 zyyy => new dvec4(z, y, y, y);
        public dvec4 wyyy => new dvec4(w, y, y, y);
        public dvec4 xzyy => new dvec4(x, z, y, y);
        public dvec4 yzyy => new dvec4(y, z, y, y);
        public dvec4 zzyy => new dvec4(z, z, y, y);
        public dvec4 wzyy => new dvec4(w, z, y, y);
        public dvec4 xwyy => new dvec4(x, w, y, y);
        public dvec4 ywyy => new dvec4(y, w, y, y);
        public dvec4 zwyy => new dvec4(z, w, y, y);
        public dvec4 wwyy => new dvec4(w, w, y, y);
        public dvec4 xxzy => new dvec4(x, x, z, y);
        public dvec4 yxzy => new dvec4(y, x, z, y);
        public dvec4 zxzy => new dvec4(z, x, z, y);
        public dvec4 wxzy {
            get => new dvec4(w, x, z, y);
            set {
                w = value.x;
                x = value.y;
                z = value.z;
                y = value.w;
            }
        }
        public dvec4 xyzy => new dvec4(x, y, z, y);
        public dvec4 yyzy => new dvec4(y, y, z, y);
        public dvec4 zyzy => new dvec4(z, y, z, y);
        public dvec4 wyzy => new dvec4(w, y, z, y);
        public dvec4 xzzy => new dvec4(x, z, z, y);
        public dvec4 yzzy => new dvec4(y, z, z, y);
        public dvec4 zzzy => new dvec4(z, z, z, y);
        public dvec4 wzzy => new dvec4(w, z, z, y);
        public dvec4 xwzy {
            get => new dvec4(x, w, z, y);
            set {
                x = value.x;
                w = value.y;
                z = value.z;
                y = value.w;
            }
        }
        public dvec4 ywzy => new dvec4(y, w, z, y);
        public dvec4 zwzy => new dvec4(z, w, z, y);
        public dvec4 wwzy => new dvec4(w, w, z, y);
        public dvec4 xxwy => new dvec4(x, x, w, y);
        public dvec4 yxwy => new dvec4(y, x, w, y);
        public dvec4 zxwy {
            get => new dvec4(z, x, w, y);
            set {
                z = value.x;
                x = value.y;
                w = value.z;
                y = value.w;
            }
        }
        public dvec4 wxwy => new dvec4(w, x, w, y);
        public dvec4 xywy => new dvec4(x, y, w, y);
        public dvec4 yywy => new dvec4(y, y, w, y);
        public dvec4 zywy => new dvec4(z, y, w, y);
        public dvec4 wywy => new dvec4(w, y, w, y);
        public dvec4 xzwy {
            get => new dvec4(x, z, w, y);
            set {
                x = value.x;
                z = value.y;
                w = value.z;
                y = value.w;
            }
        }
        public dvec4 yzwy => new dvec4(y, z, w, y);
        public dvec4 zzwy => new dvec4(z, z, w, y);
        public dvec4 wzwy => new dvec4(w, z, w, y);
        public dvec4 xwwy => new dvec4(x, w, w, y);
        public dvec4 ywwy => new dvec4(y, w, w, y);
        public dvec4 zwwy => new dvec4(z, w, w, y);
        public dvec4 wwwy => new dvec4(w, w, w, y);
        public dvec4 xxxz => new dvec4(x, x, x, z);
        public dvec4 yxxz => new dvec4(y, x, x, z);
        public dvec4 zxxz => new dvec4(z, x, x, z);
        public dvec4 wxxz => new dvec4(w, x, x, z);
        public dvec4 xyxz => new dvec4(x, y, x, z);
        public dvec4 yyxz => new dvec4(y, y, x, z);
        public dvec4 zyxz => new dvec4(z, y, x, z);
        public dvec4 wyxz {
            get => new dvec4(w, y, x, z);
            set {
                w = value.x;
                y = value.y;
                x = value.z;
                z = value.w;
            }
        }
        public dvec4 xzxz => new dvec4(x, z, x, z);
        public dvec4 yzxz => new dvec4(y, z, x, z);
        public dvec4 zzxz => new dvec4(z, z, x, z);
        public dvec4 wzxz => new dvec4(w, z, x, z);
        public dvec4 xwxz => new dvec4(x, w, x, z);
        public dvec4 ywxz {
            get => new dvec4(y, w, x, z);
            set {
                y = value.x;
                w = value.y;
                x = value.z;
                z = value.w;
            }
        }
        public dvec4 zwxz => new dvec4(z, w, x, z);
        public dvec4 wwxz => new dvec4(w, w, x, z);
        public dvec4 xxyz => new dvec4(x, x, y, z);
        public dvec4 yxyz => new dvec4(y, x, y, z);
        public dvec4 zxyz => new dvec4(z, x, y, z);
        public dvec4 wxyz {
            get => new dvec4(w, x, y, z);
            set {
                w = value.x;
                x = value.y;
                y = value.z;
                z = value.w;
            }
        }
        public dvec4 xyyz => new dvec4(x, y, y, z);
        public dvec4 yyyz => new dvec4(y, y, y, z);
        public dvec4 zyyz => new dvec4(z, y, y, z);
        public dvec4 wyyz => new dvec4(w, y, y, z);
        public dvec4 xzyz => new dvec4(x, z, y, z);
        public dvec4 yzyz => new dvec4(y, z, y, z);
        public dvec4 zzyz => new dvec4(z, z, y, z);
        public dvec4 wzyz => new dvec4(w, z, y, z);
        public dvec4 xwyz {
            get => new dvec4(x, w, y, z);
            set {
                x = value.x;
                w = value.y;
                y = value.z;
                z = value.w;
            }
        }
        public dvec4 ywyz => new dvec4(y, w, y, z);
        public dvec4 zwyz => new dvec4(z, w, y, z);
        public dvec4 wwyz => new dvec4(w, w, y, z);
        public dvec4 xxzz => new dvec4(x, x, z, z);
        public dvec4 yxzz => new dvec4(y, x, z, z);
        public dvec4 zxzz => new dvec4(z, x, z, z);
        public dvec4 wxzz => new dvec4(w, x, z, z);
        public dvec4 xyzz => new dvec4(x, y, z, z);
        public dvec4 yyzz => new dvec4(y, y, z, z);
        public dvec4 zyzz => new dvec4(z, y, z, z);
        public dvec4 wyzz => new dvec4(w, y, z, z);
        public dvec4 xzzz => new dvec4(x, z, z, z);
        public dvec4 yzzz => new dvec4(y, z, z, z);
        public dvec4 zzzz => new dvec4(z, z, z, z);
        public dvec4 wzzz => new dvec4(w, z, z, z);
        public dvec4 xwzz => new dvec4(x, w, z, z);
        public dvec4 ywzz => new dvec4(y, w, z, z);
        public dvec4 zwzz => new dvec4(z, w, z, z);
        public dvec4 wwzz => new dvec4(w, w, z, z);
        public dvec4 xxwz => new dvec4(x, x, w, z);
        public dvec4 yxwz {
            get => new dvec4(y, x, w, z);
            set {
                y = value.x;
                x = value.y;
                w = value.z;
                z = value.w;
            }
        }
        public dvec4 zxwz => new dvec4(z, x, w, z);
        public dvec4 wxwz => new dvec4(w, x, w, z);
        public dvec4 xywz {
            get => new dvec4(x, y, w, z);
            set {
                x = value.x;
                y = value.y;
                w = value.z;
                z = value.w;
            }
        }
        public dvec4 yywz => new dvec4(y, y, w, z);
        public dvec4 zywz => new dvec4(z, y, w, z);
        public dvec4 wywz => new dvec4(w, y, w, z);
        public dvec4 xzwz => new dvec4(x, z, w, z);
        public dvec4 yzwz => new dvec4(y, z, w, z);
        public dvec4 zzwz => new dvec4(z, z, w, z);
        public dvec4 wzwz => new dvec4(w, z, w, z);
        public dvec4 xwwz => new dvec4(x, w, w, z);
        public dvec4 ywwz => new dvec4(y, w, w, z);
        public dvec4 zwwz => new dvec4(z, w, w, z);
        public dvec4 wwwz => new dvec4(w, w, w, z);
        public dvec4 xxxw => new dvec4(x, x, x, w);
        public dvec4 yxxw => new dvec4(y, x, x, w);
        public dvec4 zxxw => new dvec4(z, x, x, w);
        public dvec4 wxxw => new dvec4(w, x, x, w);
        public dvec4 xyxw => new dvec4(x, y, x, w);
        public dvec4 yyxw => new dvec4(y, y, x, w);
        public dvec4 zyxw {
            get => new dvec4(z, y, x, w);
            set {
                z = value.x;
                y = value.y;
                x = value.z;
                w = value.w;
            }
        }
        public dvec4 wyxw => new dvec4(w, y, x, w);
        public dvec4 xzxw => new dvec4(x, z, x, w);
        public dvec4 yzxw {
            get => new dvec4(y, z, x, w);
            set {
                y = value.x;
                z = value.y;
                x = value.z;
                w = value.w;
            }
        }
        public dvec4 zzxw => new dvec4(z, z, x, w);
        public dvec4 wzxw => new dvec4(w, z, x, w);
        public dvec4 xwxw => new dvec4(x, w, x, w);
        public dvec4 ywxw => new dvec4(y, w, x, w);
        public dvec4 zwxw => new dvec4(z, w, x, w);
        public dvec4 wwxw => new dvec4(w, w, x, w);
        public dvec4 xxyw => new dvec4(x, x, y, w);
        public dvec4 yxyw => new dvec4(y, x, y, w);
        public dvec4 zxyw {
            get => new dvec4(z, x, y, w);
            set {
                z = value.x;
                x = value.y;
                y = value.z;
                w = value.w;
            }
        }
        public dvec4 wxyw => new dvec4(w, x, y, w);
        public dvec4 xyyw => new dvec4(x, y, y, w);
        public dvec4 yyyw => new dvec4(y, y, y, w);
        public dvec4 zyyw => new dvec4(z, y, y, w);
        public dvec4 wyyw => new dvec4(w, y, y, w);
        public dvec4 xzyw {
            get => new dvec4(x, z, y, w);
            set {
                x = value.x;
                z = value.y;
                y = value.z;
                w = value.w;
            }
        }
        public dvec4 yzyw => new dvec4(y, z, y, w);
        public dvec4 zzyw => new dvec4(z, z, y, w);
        public dvec4 wzyw => new dvec4(w, z, y, w);
        public dvec4 xwyw => new dvec4(x, w, y, w);
        public dvec4 ywyw => new dvec4(y, w, y, w);
        public dvec4 zwyw => new dvec4(z, w, y, w);
        public dvec4 wwyw => new dvec4(w, w, y, w);
        public dvec4 xxzw => new dvec4(x, x, z, w);
        public dvec4 yxzw {
            get => new dvec4(y, x, z, w);
            set {
                y = value.x;
                x = value.y;
                z = value.z;
                w = value.w;
            }
        }
        public dvec4 zxzw => new dvec4(z, x, z, w);
        public dvec4 wxzw => new dvec4(w, x, z, w);
        public dvec4 xyzw {
            get => new dvec4(x, y, z, w);
            set {
                x = value.x;
                y = value.y;
                z = value.z;
                w = value.w;
            }
        }
        public dvec4 yyzw => new dvec4(y, y, z, w);
        public dvec4 zyzw => new dvec4(z, y, z, w);
        public dvec4 wyzw => new dvec4(w, y, z, w);
        public dvec4 xzzw => new dvec4(x, z, z, w);
        public dvec4 yzzw => new dvec4(y, z, z, w);
        public dvec4 zzzw => new dvec4(z, z, z, w);
        public dvec4 wzzw => new dvec4(w, z, z, w);
        public dvec4 xwzw => new dvec4(x, w, z, w);
        public dvec4 ywzw => new dvec4(y, w, z, w);
        public dvec4 zwzw => new dvec4(z, w, z, w);
        public dvec4 wwzw => new dvec4(w, w, z, w);
        public dvec4 xxww => new dvec4(x, x, w, w);
        public dvec4 yxww => new dvec4(y, x, w, w);
        public dvec4 zxww => new dvec4(z, x, w, w);
        public dvec4 wxww => new dvec4(w, x, w, w);
        public dvec4 xyww => new dvec4(x, y, w, w);
        public dvec4 yyww => new dvec4(y, y, w, w);
        public dvec4 zyww => new dvec4(z, y, w, w);
        public dvec4 wyww => new dvec4(w, y, w, w);
        public dvec4 xzww => new dvec4(x, z, w, w);
        public dvec4 yzww => new dvec4(y, z, w, w);
        public dvec4 zzww => new dvec4(z, z, w, w);
        public dvec4 wzww => new dvec4(w, z, w, w);
        public dvec4 xwww => new dvec4(x, w, w, w);
        public dvec4 ywww => new dvec4(y, w, w, w);
        public dvec4 zwww => new dvec4(z, w, w, w);
        public dvec4 wwww => new dvec4(w, w, w, w);
        #endregion

        #region constructors
        public dvec4(double x, double y, double z, double w) {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        #endregion

        #region arithmetic
        public double dot(dvec4 v) => (this * v).sum;

        public static dvec4 operator *(dvec4 a, dvec4 b) => new dvec4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        public static dvec4 operator /(dvec4 a, dvec4 b) => new dvec4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
        public static dvec4 operator +(dvec4 a, dvec4 b) => new dvec4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        public static dvec4 operator -(dvec4 a, dvec4 b) => new dvec4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);

        public static dvec4 operator *(dvec4 a, double s) => new dvec4(a.x * s, a.y * s, a.z * s, a.w * s);
        public static dvec4 operator /(dvec4 a, double s) => new dvec4(a.x / s, a.y / s, a.z / s, a.w / s);

        public static dvec4 operator -(dvec4 v) => new dvec4(-v.x, -v.y, -v.z, -v.w);
        #endregion

        #region math
        public double distTo(dvec4 o) => (o - this).length;
        public double angleTo(dvec4 o) => (double)Math.Acos(this.dot(o) / (this.length * o.length));
        public dvec4 lerp(dvec4 o, double t) => this + ((o - this) * t);
        public dvec4 reflect(dvec4 normal) => this - (normal * 2 * (this.dot(normal) / normal.dot(normal)));
        #endregion

        #region conversion
        public static implicit operator dvec4((double, double, double, double) tuple) => new dvec4(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
        public static explicit operator ivec4(dvec4 v) => new ivec4((int)v.x, (int)v.y, (int)v.z, (int)v.w);
        public static explicit operator vec4(dvec4 v) => new vec4((float)v.x, (float)v.y, (float)v.z, (float)v.w);
        public static implicit operator dvec4(double n) => new dvec4(n, n, n, n);
        #endregion

        #region other
        public override string ToString() => $"({x}, {y}, {z}, {w})";
        #endregion
    }
    public static partial class math {
        public static dvec4 floor(dvec4 o) => new dvec4(floor(o.x), floor(o.y), floor(o.z), floor(o.w));
        public static dvec4 fract(dvec4 o) => new dvec4(fract(o.x), fract(o.y), fract(o.z), fract(o.w));
        public static dvec4 abs(dvec4 o) => new dvec4(abs(o.x), abs(o.y), abs(o.z), abs(o.w));
        public static dvec4 sqrt(dvec4 o) => new dvec4(sqrt(o.x), sqrt(o.y), sqrt(o.z), sqrt(o.w));
        public static dvec4 sin(dvec4 o) => new dvec4(sin(o.x), sin(o.y), sin(o.z), sin(o.w));
        public static dvec4 cos(dvec4 o) => new dvec4(cos(o.x), cos(o.y), cos(o.z), cos(o.w));
        public static dvec4 tan(dvec4 o) => new dvec4(tan(o.x), tan(o.y), tan(o.z), tan(o.w));
    }
}
