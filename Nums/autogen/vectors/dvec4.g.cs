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
        public readonly double sum => x + y + z + w;
        /// <summary>
        /// The number of bytes the vector type uses.
        /// </summary>
        public const int bytesize = sizeof(double) * 4;
        /// <summary>
        /// The magnitude of the vector
        /// </summary>
        public readonly double length => (double)Math.Sqrt(dot(this));
        /// <summary>
        /// The squared magnitude of the vector. sqlength is faster than length since a square-root operation is not needed.
        /// </summary>
        public readonly double sqlength => dot(this);
        /// <summary>
        /// The normalized version of this vector.
        /// </summary>
        public readonly dvec4 normalized() => this / length;
        /// <summary>
        /// Normalizes this vector.
        /// </summary>
        public void normalize() => this /= length;

        public double this[int i] {
            readonly get => i switch {
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
        /// <summary>
        /// A dvec2 containing the xx components of this vector
        /// </summary>
        public readonly dvec2 xx => new dvec2(x, x);
        /// <summary>
        /// A dvec2 containing the yx components of this vector
        /// </summary>
        public dvec2 yx {
            readonly get => new dvec2(y, x);
            set {
                y = value.x;
                x = value.y;
            }
        }
        /// <summary>
        /// A dvec2 containing the zx components of this vector
        /// </summary>
        public dvec2 zx {
            readonly get => new dvec2(z, x);
            set {
                z = value.x;
                x = value.y;
            }
        }
        /// <summary>
        /// A dvec2 containing the wx components of this vector
        /// </summary>
        public dvec2 wx {
            readonly get => new dvec2(w, x);
            set {
                w = value.x;
                x = value.y;
            }
        }
        /// <summary>
        /// A dvec2 containing the xy components of this vector
        /// </summary>
        public dvec2 xy {
            readonly get => new dvec2(x, y);
            set {
                x = value.x;
                y = value.y;
            }
        }
        /// <summary>
        /// A dvec2 containing the yy components of this vector
        /// </summary>
        public readonly dvec2 yy => new dvec2(y, y);
        /// <summary>
        /// A dvec2 containing the zy components of this vector
        /// </summary>
        public dvec2 zy {
            readonly get => new dvec2(z, y);
            set {
                z = value.x;
                y = value.y;
            }
        }
        /// <summary>
        /// A dvec2 containing the wy components of this vector
        /// </summary>
        public dvec2 wy {
            readonly get => new dvec2(w, y);
            set {
                w = value.x;
                y = value.y;
            }
        }
        /// <summary>
        /// A dvec2 containing the xz components of this vector
        /// </summary>
        public dvec2 xz {
            readonly get => new dvec2(x, z);
            set {
                x = value.x;
                z = value.y;
            }
        }
        /// <summary>
        /// A dvec2 containing the yz components of this vector
        /// </summary>
        public dvec2 yz {
            readonly get => new dvec2(y, z);
            set {
                y = value.x;
                z = value.y;
            }
        }
        /// <summary>
        /// A dvec2 containing the zz components of this vector
        /// </summary>
        public readonly dvec2 zz => new dvec2(z, z);
        /// <summary>
        /// A dvec2 containing the wz components of this vector
        /// </summary>
        public dvec2 wz {
            readonly get => new dvec2(w, z);
            set {
                w = value.x;
                z = value.y;
            }
        }
        /// <summary>
        /// A dvec2 containing the xw components of this vector
        /// </summary>
        public dvec2 xw {
            readonly get => new dvec2(x, w);
            set {
                x = value.x;
                w = value.y;
            }
        }
        /// <summary>
        /// A dvec2 containing the yw components of this vector
        /// </summary>
        public dvec2 yw {
            readonly get => new dvec2(y, w);
            set {
                y = value.x;
                w = value.y;
            }
        }
        /// <summary>
        /// A dvec2 containing the zw components of this vector
        /// </summary>
        public dvec2 zw {
            readonly get => new dvec2(z, w);
            set {
                z = value.x;
                w = value.y;
            }
        }
        /// <summary>
        /// A dvec2 containing the ww components of this vector
        /// </summary>
        public readonly dvec2 ww => new dvec2(w, w);
        /// <summary>
        /// A dvec3 containing the xxx components of this vector
        /// </summary>
        public readonly dvec3 xxx => new dvec3(x, x, x);
        /// <summary>
        /// A dvec3 containing the yxx components of this vector
        /// </summary>
        public readonly dvec3 yxx => new dvec3(y, x, x);
        /// <summary>
        /// A dvec3 containing the zxx components of this vector
        /// </summary>
        public readonly dvec3 zxx => new dvec3(z, x, x);
        /// <summary>
        /// A dvec3 containing the wxx components of this vector
        /// </summary>
        public readonly dvec3 wxx => new dvec3(w, x, x);
        /// <summary>
        /// A dvec3 containing the xyx components of this vector
        /// </summary>
        public readonly dvec3 xyx => new dvec3(x, y, x);
        /// <summary>
        /// A dvec3 containing the yyx components of this vector
        /// </summary>
        public readonly dvec3 yyx => new dvec3(y, y, x);
        /// <summary>
        /// A dvec3 containing the zyx components of this vector
        /// </summary>
        public dvec3 zyx {
            readonly get => new dvec3(z, y, x);
            set {
                z = value.x;
                y = value.y;
                x = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the wyx components of this vector
        /// </summary>
        public dvec3 wyx {
            readonly get => new dvec3(w, y, x);
            set {
                w = value.x;
                y = value.y;
                x = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the xzx components of this vector
        /// </summary>
        public readonly dvec3 xzx => new dvec3(x, z, x);
        /// <summary>
        /// A dvec3 containing the yzx components of this vector
        /// </summary>
        public dvec3 yzx {
            readonly get => new dvec3(y, z, x);
            set {
                y = value.x;
                z = value.y;
                x = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the zzx components of this vector
        /// </summary>
        public readonly dvec3 zzx => new dvec3(z, z, x);
        /// <summary>
        /// A dvec3 containing the wzx components of this vector
        /// </summary>
        public dvec3 wzx {
            readonly get => new dvec3(w, z, x);
            set {
                w = value.x;
                z = value.y;
                x = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the xwx components of this vector
        /// </summary>
        public readonly dvec3 xwx => new dvec3(x, w, x);
        /// <summary>
        /// A dvec3 containing the ywx components of this vector
        /// </summary>
        public dvec3 ywx {
            readonly get => new dvec3(y, w, x);
            set {
                y = value.x;
                w = value.y;
                x = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the zwx components of this vector
        /// </summary>
        public dvec3 zwx {
            readonly get => new dvec3(z, w, x);
            set {
                z = value.x;
                w = value.y;
                x = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the wwx components of this vector
        /// </summary>
        public readonly dvec3 wwx => new dvec3(w, w, x);
        /// <summary>
        /// A dvec3 containing the xxy components of this vector
        /// </summary>
        public readonly dvec3 xxy => new dvec3(x, x, y);
        /// <summary>
        /// A dvec3 containing the yxy components of this vector
        /// </summary>
        public readonly dvec3 yxy => new dvec3(y, x, y);
        /// <summary>
        /// A dvec3 containing the zxy components of this vector
        /// </summary>
        public dvec3 zxy {
            readonly get => new dvec3(z, x, y);
            set {
                z = value.x;
                x = value.y;
                y = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the wxy components of this vector
        /// </summary>
        public dvec3 wxy {
            readonly get => new dvec3(w, x, y);
            set {
                w = value.x;
                x = value.y;
                y = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the xyy components of this vector
        /// </summary>
        public readonly dvec3 xyy => new dvec3(x, y, y);
        /// <summary>
        /// A dvec3 containing the yyy components of this vector
        /// </summary>
        public readonly dvec3 yyy => new dvec3(y, y, y);
        /// <summary>
        /// A dvec3 containing the zyy components of this vector
        /// </summary>
        public readonly dvec3 zyy => new dvec3(z, y, y);
        /// <summary>
        /// A dvec3 containing the wyy components of this vector
        /// </summary>
        public readonly dvec3 wyy => new dvec3(w, y, y);
        /// <summary>
        /// A dvec3 containing the xzy components of this vector
        /// </summary>
        public dvec3 xzy {
            readonly get => new dvec3(x, z, y);
            set {
                x = value.x;
                z = value.y;
                y = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the yzy components of this vector
        /// </summary>
        public readonly dvec3 yzy => new dvec3(y, z, y);
        /// <summary>
        /// A dvec3 containing the zzy components of this vector
        /// </summary>
        public readonly dvec3 zzy => new dvec3(z, z, y);
        /// <summary>
        /// A dvec3 containing the wzy components of this vector
        /// </summary>
        public dvec3 wzy {
            readonly get => new dvec3(w, z, y);
            set {
                w = value.x;
                z = value.y;
                y = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the xwy components of this vector
        /// </summary>
        public dvec3 xwy {
            readonly get => new dvec3(x, w, y);
            set {
                x = value.x;
                w = value.y;
                y = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the ywy components of this vector
        /// </summary>
        public readonly dvec3 ywy => new dvec3(y, w, y);
        /// <summary>
        /// A dvec3 containing the zwy components of this vector
        /// </summary>
        public dvec3 zwy {
            readonly get => new dvec3(z, w, y);
            set {
                z = value.x;
                w = value.y;
                y = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the wwy components of this vector
        /// </summary>
        public readonly dvec3 wwy => new dvec3(w, w, y);
        /// <summary>
        /// A dvec3 containing the xxz components of this vector
        /// </summary>
        public readonly dvec3 xxz => new dvec3(x, x, z);
        /// <summary>
        /// A dvec3 containing the yxz components of this vector
        /// </summary>
        public dvec3 yxz {
            readonly get => new dvec3(y, x, z);
            set {
                y = value.x;
                x = value.y;
                z = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the zxz components of this vector
        /// </summary>
        public readonly dvec3 zxz => new dvec3(z, x, z);
        /// <summary>
        /// A dvec3 containing the wxz components of this vector
        /// </summary>
        public dvec3 wxz {
            readonly get => new dvec3(w, x, z);
            set {
                w = value.x;
                x = value.y;
                z = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the xyz components of this vector
        /// </summary>
        public dvec3 xyz {
            readonly get => new dvec3(x, y, z);
            set {
                x = value.x;
                y = value.y;
                z = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the yyz components of this vector
        /// </summary>
        public readonly dvec3 yyz => new dvec3(y, y, z);
        /// <summary>
        /// A dvec3 containing the zyz components of this vector
        /// </summary>
        public readonly dvec3 zyz => new dvec3(z, y, z);
        /// <summary>
        /// A dvec3 containing the wyz components of this vector
        /// </summary>
        public dvec3 wyz {
            readonly get => new dvec3(w, y, z);
            set {
                w = value.x;
                y = value.y;
                z = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the xzz components of this vector
        /// </summary>
        public readonly dvec3 xzz => new dvec3(x, z, z);
        /// <summary>
        /// A dvec3 containing the yzz components of this vector
        /// </summary>
        public readonly dvec3 yzz => new dvec3(y, z, z);
        /// <summary>
        /// A dvec3 containing the zzz components of this vector
        /// </summary>
        public readonly dvec3 zzz => new dvec3(z, z, z);
        /// <summary>
        /// A dvec3 containing the wzz components of this vector
        /// </summary>
        public readonly dvec3 wzz => new dvec3(w, z, z);
        /// <summary>
        /// A dvec3 containing the xwz components of this vector
        /// </summary>
        public dvec3 xwz {
            readonly get => new dvec3(x, w, z);
            set {
                x = value.x;
                w = value.y;
                z = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the ywz components of this vector
        /// </summary>
        public dvec3 ywz {
            readonly get => new dvec3(y, w, z);
            set {
                y = value.x;
                w = value.y;
                z = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the zwz components of this vector
        /// </summary>
        public readonly dvec3 zwz => new dvec3(z, w, z);
        /// <summary>
        /// A dvec3 containing the wwz components of this vector
        /// </summary>
        public readonly dvec3 wwz => new dvec3(w, w, z);
        /// <summary>
        /// A dvec3 containing the xxw components of this vector
        /// </summary>
        public readonly dvec3 xxw => new dvec3(x, x, w);
        /// <summary>
        /// A dvec3 containing the yxw components of this vector
        /// </summary>
        public dvec3 yxw {
            readonly get => new dvec3(y, x, w);
            set {
                y = value.x;
                x = value.y;
                w = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the zxw components of this vector
        /// </summary>
        public dvec3 zxw {
            readonly get => new dvec3(z, x, w);
            set {
                z = value.x;
                x = value.y;
                w = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the wxw components of this vector
        /// </summary>
        public readonly dvec3 wxw => new dvec3(w, x, w);
        /// <summary>
        /// A dvec3 containing the xyw components of this vector
        /// </summary>
        public dvec3 xyw {
            readonly get => new dvec3(x, y, w);
            set {
                x = value.x;
                y = value.y;
                w = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the yyw components of this vector
        /// </summary>
        public readonly dvec3 yyw => new dvec3(y, y, w);
        /// <summary>
        /// A dvec3 containing the zyw components of this vector
        /// </summary>
        public dvec3 zyw {
            readonly get => new dvec3(z, y, w);
            set {
                z = value.x;
                y = value.y;
                w = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the wyw components of this vector
        /// </summary>
        public readonly dvec3 wyw => new dvec3(w, y, w);
        /// <summary>
        /// A dvec3 containing the xzw components of this vector
        /// </summary>
        public dvec3 xzw {
            readonly get => new dvec3(x, z, w);
            set {
                x = value.x;
                z = value.y;
                w = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the yzw components of this vector
        /// </summary>
        public dvec3 yzw {
            readonly get => new dvec3(y, z, w);
            set {
                y = value.x;
                z = value.y;
                w = value.z;
            }
        }
        /// <summary>
        /// A dvec3 containing the zzw components of this vector
        /// </summary>
        public readonly dvec3 zzw => new dvec3(z, z, w);
        /// <summary>
        /// A dvec3 containing the wzw components of this vector
        /// </summary>
        public readonly dvec3 wzw => new dvec3(w, z, w);
        /// <summary>
        /// A dvec3 containing the xww components of this vector
        /// </summary>
        public readonly dvec3 xww => new dvec3(x, w, w);
        /// <summary>
        /// A dvec3 containing the yww components of this vector
        /// </summary>
        public readonly dvec3 yww => new dvec3(y, w, w);
        /// <summary>
        /// A dvec3 containing the zww components of this vector
        /// </summary>
        public readonly dvec3 zww => new dvec3(z, w, w);
        /// <summary>
        /// A dvec3 containing the www components of this vector
        /// </summary>
        public readonly dvec3 www => new dvec3(w, w, w);
        /// <summary>
        /// A dvec4 containing the xxxx components of this vector
        /// </summary>
        public readonly dvec4 xxxx => new dvec4(x, x, x, x);
        /// <summary>
        /// A dvec4 containing the yxxx components of this vector
        /// </summary>
        public readonly dvec4 yxxx => new dvec4(y, x, x, x);
        /// <summary>
        /// A dvec4 containing the zxxx components of this vector
        /// </summary>
        public readonly dvec4 zxxx => new dvec4(z, x, x, x);
        /// <summary>
        /// A dvec4 containing the wxxx components of this vector
        /// </summary>
        public readonly dvec4 wxxx => new dvec4(w, x, x, x);
        /// <summary>
        /// A dvec4 containing the xyxx components of this vector
        /// </summary>
        public readonly dvec4 xyxx => new dvec4(x, y, x, x);
        /// <summary>
        /// A dvec4 containing the yyxx components of this vector
        /// </summary>
        public readonly dvec4 yyxx => new dvec4(y, y, x, x);
        /// <summary>
        /// A dvec4 containing the zyxx components of this vector
        /// </summary>
        public readonly dvec4 zyxx => new dvec4(z, y, x, x);
        /// <summary>
        /// A dvec4 containing the wyxx components of this vector
        /// </summary>
        public readonly dvec4 wyxx => new dvec4(w, y, x, x);
        /// <summary>
        /// A dvec4 containing the xzxx components of this vector
        /// </summary>
        public readonly dvec4 xzxx => new dvec4(x, z, x, x);
        /// <summary>
        /// A dvec4 containing the yzxx components of this vector
        /// </summary>
        public readonly dvec4 yzxx => new dvec4(y, z, x, x);
        /// <summary>
        /// A dvec4 containing the zzxx components of this vector
        /// </summary>
        public readonly dvec4 zzxx => new dvec4(z, z, x, x);
        /// <summary>
        /// A dvec4 containing the wzxx components of this vector
        /// </summary>
        public readonly dvec4 wzxx => new dvec4(w, z, x, x);
        /// <summary>
        /// A dvec4 containing the xwxx components of this vector
        /// </summary>
        public readonly dvec4 xwxx => new dvec4(x, w, x, x);
        /// <summary>
        /// A dvec4 containing the ywxx components of this vector
        /// </summary>
        public readonly dvec4 ywxx => new dvec4(y, w, x, x);
        /// <summary>
        /// A dvec4 containing the zwxx components of this vector
        /// </summary>
        public readonly dvec4 zwxx => new dvec4(z, w, x, x);
        /// <summary>
        /// A dvec4 containing the wwxx components of this vector
        /// </summary>
        public readonly dvec4 wwxx => new dvec4(w, w, x, x);
        /// <summary>
        /// A dvec4 containing the xxyx components of this vector
        /// </summary>
        public readonly dvec4 xxyx => new dvec4(x, x, y, x);
        /// <summary>
        /// A dvec4 containing the yxyx components of this vector
        /// </summary>
        public readonly dvec4 yxyx => new dvec4(y, x, y, x);
        /// <summary>
        /// A dvec4 containing the zxyx components of this vector
        /// </summary>
        public readonly dvec4 zxyx => new dvec4(z, x, y, x);
        /// <summary>
        /// A dvec4 containing the wxyx components of this vector
        /// </summary>
        public readonly dvec4 wxyx => new dvec4(w, x, y, x);
        /// <summary>
        /// A dvec4 containing the xyyx components of this vector
        /// </summary>
        public readonly dvec4 xyyx => new dvec4(x, y, y, x);
        /// <summary>
        /// A dvec4 containing the yyyx components of this vector
        /// </summary>
        public readonly dvec4 yyyx => new dvec4(y, y, y, x);
        /// <summary>
        /// A dvec4 containing the zyyx components of this vector
        /// </summary>
        public readonly dvec4 zyyx => new dvec4(z, y, y, x);
        /// <summary>
        /// A dvec4 containing the wyyx components of this vector
        /// </summary>
        public readonly dvec4 wyyx => new dvec4(w, y, y, x);
        /// <summary>
        /// A dvec4 containing the xzyx components of this vector
        /// </summary>
        public readonly dvec4 xzyx => new dvec4(x, z, y, x);
        /// <summary>
        /// A dvec4 containing the yzyx components of this vector
        /// </summary>
        public readonly dvec4 yzyx => new dvec4(y, z, y, x);
        /// <summary>
        /// A dvec4 containing the zzyx components of this vector
        /// </summary>
        public readonly dvec4 zzyx => new dvec4(z, z, y, x);
        /// <summary>
        /// A dvec4 containing the wzyx components of this vector
        /// </summary>
        public dvec4 wzyx {
            readonly get => new dvec4(w, z, y, x);
            set {
                w = value.x;
                z = value.y;
                y = value.z;
                x = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the xwyx components of this vector
        /// </summary>
        public readonly dvec4 xwyx => new dvec4(x, w, y, x);
        /// <summary>
        /// A dvec4 containing the ywyx components of this vector
        /// </summary>
        public readonly dvec4 ywyx => new dvec4(y, w, y, x);
        /// <summary>
        /// A dvec4 containing the zwyx components of this vector
        /// </summary>
        public dvec4 zwyx {
            readonly get => new dvec4(z, w, y, x);
            set {
                z = value.x;
                w = value.y;
                y = value.z;
                x = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the wwyx components of this vector
        /// </summary>
        public readonly dvec4 wwyx => new dvec4(w, w, y, x);
        /// <summary>
        /// A dvec4 containing the xxzx components of this vector
        /// </summary>
        public readonly dvec4 xxzx => new dvec4(x, x, z, x);
        /// <summary>
        /// A dvec4 containing the yxzx components of this vector
        /// </summary>
        public readonly dvec4 yxzx => new dvec4(y, x, z, x);
        /// <summary>
        /// A dvec4 containing the zxzx components of this vector
        /// </summary>
        public readonly dvec4 zxzx => new dvec4(z, x, z, x);
        /// <summary>
        /// A dvec4 containing the wxzx components of this vector
        /// </summary>
        public readonly dvec4 wxzx => new dvec4(w, x, z, x);
        /// <summary>
        /// A dvec4 containing the xyzx components of this vector
        /// </summary>
        public readonly dvec4 xyzx => new dvec4(x, y, z, x);
        /// <summary>
        /// A dvec4 containing the yyzx components of this vector
        /// </summary>
        public readonly dvec4 yyzx => new dvec4(y, y, z, x);
        /// <summary>
        /// A dvec4 containing the zyzx components of this vector
        /// </summary>
        public readonly dvec4 zyzx => new dvec4(z, y, z, x);
        /// <summary>
        /// A dvec4 containing the wyzx components of this vector
        /// </summary>
        public dvec4 wyzx {
            readonly get => new dvec4(w, y, z, x);
            set {
                w = value.x;
                y = value.y;
                z = value.z;
                x = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the xzzx components of this vector
        /// </summary>
        public readonly dvec4 xzzx => new dvec4(x, z, z, x);
        /// <summary>
        /// A dvec4 containing the yzzx components of this vector
        /// </summary>
        public readonly dvec4 yzzx => new dvec4(y, z, z, x);
        /// <summary>
        /// A dvec4 containing the zzzx components of this vector
        /// </summary>
        public readonly dvec4 zzzx => new dvec4(z, z, z, x);
        /// <summary>
        /// A dvec4 containing the wzzx components of this vector
        /// </summary>
        public readonly dvec4 wzzx => new dvec4(w, z, z, x);
        /// <summary>
        /// A dvec4 containing the xwzx components of this vector
        /// </summary>
        public readonly dvec4 xwzx => new dvec4(x, w, z, x);
        /// <summary>
        /// A dvec4 containing the ywzx components of this vector
        /// </summary>
        public dvec4 ywzx {
            readonly get => new dvec4(y, w, z, x);
            set {
                y = value.x;
                w = value.y;
                z = value.z;
                x = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the zwzx components of this vector
        /// </summary>
        public readonly dvec4 zwzx => new dvec4(z, w, z, x);
        /// <summary>
        /// A dvec4 containing the wwzx components of this vector
        /// </summary>
        public readonly dvec4 wwzx => new dvec4(w, w, z, x);
        /// <summary>
        /// A dvec4 containing the xxwx components of this vector
        /// </summary>
        public readonly dvec4 xxwx => new dvec4(x, x, w, x);
        /// <summary>
        /// A dvec4 containing the yxwx components of this vector
        /// </summary>
        public readonly dvec4 yxwx => new dvec4(y, x, w, x);
        /// <summary>
        /// A dvec4 containing the zxwx components of this vector
        /// </summary>
        public readonly dvec4 zxwx => new dvec4(z, x, w, x);
        /// <summary>
        /// A dvec4 containing the wxwx components of this vector
        /// </summary>
        public readonly dvec4 wxwx => new dvec4(w, x, w, x);
        /// <summary>
        /// A dvec4 containing the xywx components of this vector
        /// </summary>
        public readonly dvec4 xywx => new dvec4(x, y, w, x);
        /// <summary>
        /// A dvec4 containing the yywx components of this vector
        /// </summary>
        public readonly dvec4 yywx => new dvec4(y, y, w, x);
        /// <summary>
        /// A dvec4 containing the zywx components of this vector
        /// </summary>
        public dvec4 zywx {
            readonly get => new dvec4(z, y, w, x);
            set {
                z = value.x;
                y = value.y;
                w = value.z;
                x = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the wywx components of this vector
        /// </summary>
        public readonly dvec4 wywx => new dvec4(w, y, w, x);
        /// <summary>
        /// A dvec4 containing the xzwx components of this vector
        /// </summary>
        public readonly dvec4 xzwx => new dvec4(x, z, w, x);
        /// <summary>
        /// A dvec4 containing the yzwx components of this vector
        /// </summary>
        public dvec4 yzwx {
            readonly get => new dvec4(y, z, w, x);
            set {
                y = value.x;
                z = value.y;
                w = value.z;
                x = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the zzwx components of this vector
        /// </summary>
        public readonly dvec4 zzwx => new dvec4(z, z, w, x);
        /// <summary>
        /// A dvec4 containing the wzwx components of this vector
        /// </summary>
        public readonly dvec4 wzwx => new dvec4(w, z, w, x);
        /// <summary>
        /// A dvec4 containing the xwwx components of this vector
        /// </summary>
        public readonly dvec4 xwwx => new dvec4(x, w, w, x);
        /// <summary>
        /// A dvec4 containing the ywwx components of this vector
        /// </summary>
        public readonly dvec4 ywwx => new dvec4(y, w, w, x);
        /// <summary>
        /// A dvec4 containing the zwwx components of this vector
        /// </summary>
        public readonly dvec4 zwwx => new dvec4(z, w, w, x);
        /// <summary>
        /// A dvec4 containing the wwwx components of this vector
        /// </summary>
        public readonly dvec4 wwwx => new dvec4(w, w, w, x);
        /// <summary>
        /// A dvec4 containing the xxxy components of this vector
        /// </summary>
        public readonly dvec4 xxxy => new dvec4(x, x, x, y);
        /// <summary>
        /// A dvec4 containing the yxxy components of this vector
        /// </summary>
        public readonly dvec4 yxxy => new dvec4(y, x, x, y);
        /// <summary>
        /// A dvec4 containing the zxxy components of this vector
        /// </summary>
        public readonly dvec4 zxxy => new dvec4(z, x, x, y);
        /// <summary>
        /// A dvec4 containing the wxxy components of this vector
        /// </summary>
        public readonly dvec4 wxxy => new dvec4(w, x, x, y);
        /// <summary>
        /// A dvec4 containing the xyxy components of this vector
        /// </summary>
        public readonly dvec4 xyxy => new dvec4(x, y, x, y);
        /// <summary>
        /// A dvec4 containing the yyxy components of this vector
        /// </summary>
        public readonly dvec4 yyxy => new dvec4(y, y, x, y);
        /// <summary>
        /// A dvec4 containing the zyxy components of this vector
        /// </summary>
        public readonly dvec4 zyxy => new dvec4(z, y, x, y);
        /// <summary>
        /// A dvec4 containing the wyxy components of this vector
        /// </summary>
        public readonly dvec4 wyxy => new dvec4(w, y, x, y);
        /// <summary>
        /// A dvec4 containing the xzxy components of this vector
        /// </summary>
        public readonly dvec4 xzxy => new dvec4(x, z, x, y);
        /// <summary>
        /// A dvec4 containing the yzxy components of this vector
        /// </summary>
        public readonly dvec4 yzxy => new dvec4(y, z, x, y);
        /// <summary>
        /// A dvec4 containing the zzxy components of this vector
        /// </summary>
        public readonly dvec4 zzxy => new dvec4(z, z, x, y);
        /// <summary>
        /// A dvec4 containing the wzxy components of this vector
        /// </summary>
        public dvec4 wzxy {
            readonly get => new dvec4(w, z, x, y);
            set {
                w = value.x;
                z = value.y;
                x = value.z;
                y = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the xwxy components of this vector
        /// </summary>
        public readonly dvec4 xwxy => new dvec4(x, w, x, y);
        /// <summary>
        /// A dvec4 containing the ywxy components of this vector
        /// </summary>
        public readonly dvec4 ywxy => new dvec4(y, w, x, y);
        /// <summary>
        /// A dvec4 containing the zwxy components of this vector
        /// </summary>
        public dvec4 zwxy {
            readonly get => new dvec4(z, w, x, y);
            set {
                z = value.x;
                w = value.y;
                x = value.z;
                y = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the wwxy components of this vector
        /// </summary>
        public readonly dvec4 wwxy => new dvec4(w, w, x, y);
        /// <summary>
        /// A dvec4 containing the xxyy components of this vector
        /// </summary>
        public readonly dvec4 xxyy => new dvec4(x, x, y, y);
        /// <summary>
        /// A dvec4 containing the yxyy components of this vector
        /// </summary>
        public readonly dvec4 yxyy => new dvec4(y, x, y, y);
        /// <summary>
        /// A dvec4 containing the zxyy components of this vector
        /// </summary>
        public readonly dvec4 zxyy => new dvec4(z, x, y, y);
        /// <summary>
        /// A dvec4 containing the wxyy components of this vector
        /// </summary>
        public readonly dvec4 wxyy => new dvec4(w, x, y, y);
        /// <summary>
        /// A dvec4 containing the xyyy components of this vector
        /// </summary>
        public readonly dvec4 xyyy => new dvec4(x, y, y, y);
        /// <summary>
        /// A dvec4 containing the yyyy components of this vector
        /// </summary>
        public readonly dvec4 yyyy => new dvec4(y, y, y, y);
        /// <summary>
        /// A dvec4 containing the zyyy components of this vector
        /// </summary>
        public readonly dvec4 zyyy => new dvec4(z, y, y, y);
        /// <summary>
        /// A dvec4 containing the wyyy components of this vector
        /// </summary>
        public readonly dvec4 wyyy => new dvec4(w, y, y, y);
        /// <summary>
        /// A dvec4 containing the xzyy components of this vector
        /// </summary>
        public readonly dvec4 xzyy => new dvec4(x, z, y, y);
        /// <summary>
        /// A dvec4 containing the yzyy components of this vector
        /// </summary>
        public readonly dvec4 yzyy => new dvec4(y, z, y, y);
        /// <summary>
        /// A dvec4 containing the zzyy components of this vector
        /// </summary>
        public readonly dvec4 zzyy => new dvec4(z, z, y, y);
        /// <summary>
        /// A dvec4 containing the wzyy components of this vector
        /// </summary>
        public readonly dvec4 wzyy => new dvec4(w, z, y, y);
        /// <summary>
        /// A dvec4 containing the xwyy components of this vector
        /// </summary>
        public readonly dvec4 xwyy => new dvec4(x, w, y, y);
        /// <summary>
        /// A dvec4 containing the ywyy components of this vector
        /// </summary>
        public readonly dvec4 ywyy => new dvec4(y, w, y, y);
        /// <summary>
        /// A dvec4 containing the zwyy components of this vector
        /// </summary>
        public readonly dvec4 zwyy => new dvec4(z, w, y, y);
        /// <summary>
        /// A dvec4 containing the wwyy components of this vector
        /// </summary>
        public readonly dvec4 wwyy => new dvec4(w, w, y, y);
        /// <summary>
        /// A dvec4 containing the xxzy components of this vector
        /// </summary>
        public readonly dvec4 xxzy => new dvec4(x, x, z, y);
        /// <summary>
        /// A dvec4 containing the yxzy components of this vector
        /// </summary>
        public readonly dvec4 yxzy => new dvec4(y, x, z, y);
        /// <summary>
        /// A dvec4 containing the zxzy components of this vector
        /// </summary>
        public readonly dvec4 zxzy => new dvec4(z, x, z, y);
        /// <summary>
        /// A dvec4 containing the wxzy components of this vector
        /// </summary>
        public dvec4 wxzy {
            readonly get => new dvec4(w, x, z, y);
            set {
                w = value.x;
                x = value.y;
                z = value.z;
                y = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the xyzy components of this vector
        /// </summary>
        public readonly dvec4 xyzy => new dvec4(x, y, z, y);
        /// <summary>
        /// A dvec4 containing the yyzy components of this vector
        /// </summary>
        public readonly dvec4 yyzy => new dvec4(y, y, z, y);
        /// <summary>
        /// A dvec4 containing the zyzy components of this vector
        /// </summary>
        public readonly dvec4 zyzy => new dvec4(z, y, z, y);
        /// <summary>
        /// A dvec4 containing the wyzy components of this vector
        /// </summary>
        public readonly dvec4 wyzy => new dvec4(w, y, z, y);
        /// <summary>
        /// A dvec4 containing the xzzy components of this vector
        /// </summary>
        public readonly dvec4 xzzy => new dvec4(x, z, z, y);
        /// <summary>
        /// A dvec4 containing the yzzy components of this vector
        /// </summary>
        public readonly dvec4 yzzy => new dvec4(y, z, z, y);
        /// <summary>
        /// A dvec4 containing the zzzy components of this vector
        /// </summary>
        public readonly dvec4 zzzy => new dvec4(z, z, z, y);
        /// <summary>
        /// A dvec4 containing the wzzy components of this vector
        /// </summary>
        public readonly dvec4 wzzy => new dvec4(w, z, z, y);
        /// <summary>
        /// A dvec4 containing the xwzy components of this vector
        /// </summary>
        public dvec4 xwzy {
            readonly get => new dvec4(x, w, z, y);
            set {
                x = value.x;
                w = value.y;
                z = value.z;
                y = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the ywzy components of this vector
        /// </summary>
        public readonly dvec4 ywzy => new dvec4(y, w, z, y);
        /// <summary>
        /// A dvec4 containing the zwzy components of this vector
        /// </summary>
        public readonly dvec4 zwzy => new dvec4(z, w, z, y);
        /// <summary>
        /// A dvec4 containing the wwzy components of this vector
        /// </summary>
        public readonly dvec4 wwzy => new dvec4(w, w, z, y);
        /// <summary>
        /// A dvec4 containing the xxwy components of this vector
        /// </summary>
        public readonly dvec4 xxwy => new dvec4(x, x, w, y);
        /// <summary>
        /// A dvec4 containing the yxwy components of this vector
        /// </summary>
        public readonly dvec4 yxwy => new dvec4(y, x, w, y);
        /// <summary>
        /// A dvec4 containing the zxwy components of this vector
        /// </summary>
        public dvec4 zxwy {
            readonly get => new dvec4(z, x, w, y);
            set {
                z = value.x;
                x = value.y;
                w = value.z;
                y = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the wxwy components of this vector
        /// </summary>
        public readonly dvec4 wxwy => new dvec4(w, x, w, y);
        /// <summary>
        /// A dvec4 containing the xywy components of this vector
        /// </summary>
        public readonly dvec4 xywy => new dvec4(x, y, w, y);
        /// <summary>
        /// A dvec4 containing the yywy components of this vector
        /// </summary>
        public readonly dvec4 yywy => new dvec4(y, y, w, y);
        /// <summary>
        /// A dvec4 containing the zywy components of this vector
        /// </summary>
        public readonly dvec4 zywy => new dvec4(z, y, w, y);
        /// <summary>
        /// A dvec4 containing the wywy components of this vector
        /// </summary>
        public readonly dvec4 wywy => new dvec4(w, y, w, y);
        /// <summary>
        /// A dvec4 containing the xzwy components of this vector
        /// </summary>
        public dvec4 xzwy {
            readonly get => new dvec4(x, z, w, y);
            set {
                x = value.x;
                z = value.y;
                w = value.z;
                y = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the yzwy components of this vector
        /// </summary>
        public readonly dvec4 yzwy => new dvec4(y, z, w, y);
        /// <summary>
        /// A dvec4 containing the zzwy components of this vector
        /// </summary>
        public readonly dvec4 zzwy => new dvec4(z, z, w, y);
        /// <summary>
        /// A dvec4 containing the wzwy components of this vector
        /// </summary>
        public readonly dvec4 wzwy => new dvec4(w, z, w, y);
        /// <summary>
        /// A dvec4 containing the xwwy components of this vector
        /// </summary>
        public readonly dvec4 xwwy => new dvec4(x, w, w, y);
        /// <summary>
        /// A dvec4 containing the ywwy components of this vector
        /// </summary>
        public readonly dvec4 ywwy => new dvec4(y, w, w, y);
        /// <summary>
        /// A dvec4 containing the zwwy components of this vector
        /// </summary>
        public readonly dvec4 zwwy => new dvec4(z, w, w, y);
        /// <summary>
        /// A dvec4 containing the wwwy components of this vector
        /// </summary>
        public readonly dvec4 wwwy => new dvec4(w, w, w, y);
        /// <summary>
        /// A dvec4 containing the xxxz components of this vector
        /// </summary>
        public readonly dvec4 xxxz => new dvec4(x, x, x, z);
        /// <summary>
        /// A dvec4 containing the yxxz components of this vector
        /// </summary>
        public readonly dvec4 yxxz => new dvec4(y, x, x, z);
        /// <summary>
        /// A dvec4 containing the zxxz components of this vector
        /// </summary>
        public readonly dvec4 zxxz => new dvec4(z, x, x, z);
        /// <summary>
        /// A dvec4 containing the wxxz components of this vector
        /// </summary>
        public readonly dvec4 wxxz => new dvec4(w, x, x, z);
        /// <summary>
        /// A dvec4 containing the xyxz components of this vector
        /// </summary>
        public readonly dvec4 xyxz => new dvec4(x, y, x, z);
        /// <summary>
        /// A dvec4 containing the yyxz components of this vector
        /// </summary>
        public readonly dvec4 yyxz => new dvec4(y, y, x, z);
        /// <summary>
        /// A dvec4 containing the zyxz components of this vector
        /// </summary>
        public readonly dvec4 zyxz => new dvec4(z, y, x, z);
        /// <summary>
        /// A dvec4 containing the wyxz components of this vector
        /// </summary>
        public dvec4 wyxz {
            readonly get => new dvec4(w, y, x, z);
            set {
                w = value.x;
                y = value.y;
                x = value.z;
                z = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the xzxz components of this vector
        /// </summary>
        public readonly dvec4 xzxz => new dvec4(x, z, x, z);
        /// <summary>
        /// A dvec4 containing the yzxz components of this vector
        /// </summary>
        public readonly dvec4 yzxz => new dvec4(y, z, x, z);
        /// <summary>
        /// A dvec4 containing the zzxz components of this vector
        /// </summary>
        public readonly dvec4 zzxz => new dvec4(z, z, x, z);
        /// <summary>
        /// A dvec4 containing the wzxz components of this vector
        /// </summary>
        public readonly dvec4 wzxz => new dvec4(w, z, x, z);
        /// <summary>
        /// A dvec4 containing the xwxz components of this vector
        /// </summary>
        public readonly dvec4 xwxz => new dvec4(x, w, x, z);
        /// <summary>
        /// A dvec4 containing the ywxz components of this vector
        /// </summary>
        public dvec4 ywxz {
            readonly get => new dvec4(y, w, x, z);
            set {
                y = value.x;
                w = value.y;
                x = value.z;
                z = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the zwxz components of this vector
        /// </summary>
        public readonly dvec4 zwxz => new dvec4(z, w, x, z);
        /// <summary>
        /// A dvec4 containing the wwxz components of this vector
        /// </summary>
        public readonly dvec4 wwxz => new dvec4(w, w, x, z);
        /// <summary>
        /// A dvec4 containing the xxyz components of this vector
        /// </summary>
        public readonly dvec4 xxyz => new dvec4(x, x, y, z);
        /// <summary>
        /// A dvec4 containing the yxyz components of this vector
        /// </summary>
        public readonly dvec4 yxyz => new dvec4(y, x, y, z);
        /// <summary>
        /// A dvec4 containing the zxyz components of this vector
        /// </summary>
        public readonly dvec4 zxyz => new dvec4(z, x, y, z);
        /// <summary>
        /// A dvec4 containing the wxyz components of this vector
        /// </summary>
        public dvec4 wxyz {
            readonly get => new dvec4(w, x, y, z);
            set {
                w = value.x;
                x = value.y;
                y = value.z;
                z = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the xyyz components of this vector
        /// </summary>
        public readonly dvec4 xyyz => new dvec4(x, y, y, z);
        /// <summary>
        /// A dvec4 containing the yyyz components of this vector
        /// </summary>
        public readonly dvec4 yyyz => new dvec4(y, y, y, z);
        /// <summary>
        /// A dvec4 containing the zyyz components of this vector
        /// </summary>
        public readonly dvec4 zyyz => new dvec4(z, y, y, z);
        /// <summary>
        /// A dvec4 containing the wyyz components of this vector
        /// </summary>
        public readonly dvec4 wyyz => new dvec4(w, y, y, z);
        /// <summary>
        /// A dvec4 containing the xzyz components of this vector
        /// </summary>
        public readonly dvec4 xzyz => new dvec4(x, z, y, z);
        /// <summary>
        /// A dvec4 containing the yzyz components of this vector
        /// </summary>
        public readonly dvec4 yzyz => new dvec4(y, z, y, z);
        /// <summary>
        /// A dvec4 containing the zzyz components of this vector
        /// </summary>
        public readonly dvec4 zzyz => new dvec4(z, z, y, z);
        /// <summary>
        /// A dvec4 containing the wzyz components of this vector
        /// </summary>
        public readonly dvec4 wzyz => new dvec4(w, z, y, z);
        /// <summary>
        /// A dvec4 containing the xwyz components of this vector
        /// </summary>
        public dvec4 xwyz {
            readonly get => new dvec4(x, w, y, z);
            set {
                x = value.x;
                w = value.y;
                y = value.z;
                z = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the ywyz components of this vector
        /// </summary>
        public readonly dvec4 ywyz => new dvec4(y, w, y, z);
        /// <summary>
        /// A dvec4 containing the zwyz components of this vector
        /// </summary>
        public readonly dvec4 zwyz => new dvec4(z, w, y, z);
        /// <summary>
        /// A dvec4 containing the wwyz components of this vector
        /// </summary>
        public readonly dvec4 wwyz => new dvec4(w, w, y, z);
        /// <summary>
        /// A dvec4 containing the xxzz components of this vector
        /// </summary>
        public readonly dvec4 xxzz => new dvec4(x, x, z, z);
        /// <summary>
        /// A dvec4 containing the yxzz components of this vector
        /// </summary>
        public readonly dvec4 yxzz => new dvec4(y, x, z, z);
        /// <summary>
        /// A dvec4 containing the zxzz components of this vector
        /// </summary>
        public readonly dvec4 zxzz => new dvec4(z, x, z, z);
        /// <summary>
        /// A dvec4 containing the wxzz components of this vector
        /// </summary>
        public readonly dvec4 wxzz => new dvec4(w, x, z, z);
        /// <summary>
        /// A dvec4 containing the xyzz components of this vector
        /// </summary>
        public readonly dvec4 xyzz => new dvec4(x, y, z, z);
        /// <summary>
        /// A dvec4 containing the yyzz components of this vector
        /// </summary>
        public readonly dvec4 yyzz => new dvec4(y, y, z, z);
        /// <summary>
        /// A dvec4 containing the zyzz components of this vector
        /// </summary>
        public readonly dvec4 zyzz => new dvec4(z, y, z, z);
        /// <summary>
        /// A dvec4 containing the wyzz components of this vector
        /// </summary>
        public readonly dvec4 wyzz => new dvec4(w, y, z, z);
        /// <summary>
        /// A dvec4 containing the xzzz components of this vector
        /// </summary>
        public readonly dvec4 xzzz => new dvec4(x, z, z, z);
        /// <summary>
        /// A dvec4 containing the yzzz components of this vector
        /// </summary>
        public readonly dvec4 yzzz => new dvec4(y, z, z, z);
        /// <summary>
        /// A dvec4 containing the zzzz components of this vector
        /// </summary>
        public readonly dvec4 zzzz => new dvec4(z, z, z, z);
        /// <summary>
        /// A dvec4 containing the wzzz components of this vector
        /// </summary>
        public readonly dvec4 wzzz => new dvec4(w, z, z, z);
        /// <summary>
        /// A dvec4 containing the xwzz components of this vector
        /// </summary>
        public readonly dvec4 xwzz => new dvec4(x, w, z, z);
        /// <summary>
        /// A dvec4 containing the ywzz components of this vector
        /// </summary>
        public readonly dvec4 ywzz => new dvec4(y, w, z, z);
        /// <summary>
        /// A dvec4 containing the zwzz components of this vector
        /// </summary>
        public readonly dvec4 zwzz => new dvec4(z, w, z, z);
        /// <summary>
        /// A dvec4 containing the wwzz components of this vector
        /// </summary>
        public readonly dvec4 wwzz => new dvec4(w, w, z, z);
        /// <summary>
        /// A dvec4 containing the xxwz components of this vector
        /// </summary>
        public readonly dvec4 xxwz => new dvec4(x, x, w, z);
        /// <summary>
        /// A dvec4 containing the yxwz components of this vector
        /// </summary>
        public dvec4 yxwz {
            readonly get => new dvec4(y, x, w, z);
            set {
                y = value.x;
                x = value.y;
                w = value.z;
                z = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the zxwz components of this vector
        /// </summary>
        public readonly dvec4 zxwz => new dvec4(z, x, w, z);
        /// <summary>
        /// A dvec4 containing the wxwz components of this vector
        /// </summary>
        public readonly dvec4 wxwz => new dvec4(w, x, w, z);
        /// <summary>
        /// A dvec4 containing the xywz components of this vector
        /// </summary>
        public dvec4 xywz {
            readonly get => new dvec4(x, y, w, z);
            set {
                x = value.x;
                y = value.y;
                w = value.z;
                z = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the yywz components of this vector
        /// </summary>
        public readonly dvec4 yywz => new dvec4(y, y, w, z);
        /// <summary>
        /// A dvec4 containing the zywz components of this vector
        /// </summary>
        public readonly dvec4 zywz => new dvec4(z, y, w, z);
        /// <summary>
        /// A dvec4 containing the wywz components of this vector
        /// </summary>
        public readonly dvec4 wywz => new dvec4(w, y, w, z);
        /// <summary>
        /// A dvec4 containing the xzwz components of this vector
        /// </summary>
        public readonly dvec4 xzwz => new dvec4(x, z, w, z);
        /// <summary>
        /// A dvec4 containing the yzwz components of this vector
        /// </summary>
        public readonly dvec4 yzwz => new dvec4(y, z, w, z);
        /// <summary>
        /// A dvec4 containing the zzwz components of this vector
        /// </summary>
        public readonly dvec4 zzwz => new dvec4(z, z, w, z);
        /// <summary>
        /// A dvec4 containing the wzwz components of this vector
        /// </summary>
        public readonly dvec4 wzwz => new dvec4(w, z, w, z);
        /// <summary>
        /// A dvec4 containing the xwwz components of this vector
        /// </summary>
        public readonly dvec4 xwwz => new dvec4(x, w, w, z);
        /// <summary>
        /// A dvec4 containing the ywwz components of this vector
        /// </summary>
        public readonly dvec4 ywwz => new dvec4(y, w, w, z);
        /// <summary>
        /// A dvec4 containing the zwwz components of this vector
        /// </summary>
        public readonly dvec4 zwwz => new dvec4(z, w, w, z);
        /// <summary>
        /// A dvec4 containing the wwwz components of this vector
        /// </summary>
        public readonly dvec4 wwwz => new dvec4(w, w, w, z);
        /// <summary>
        /// A dvec4 containing the xxxw components of this vector
        /// </summary>
        public readonly dvec4 xxxw => new dvec4(x, x, x, w);
        /// <summary>
        /// A dvec4 containing the yxxw components of this vector
        /// </summary>
        public readonly dvec4 yxxw => new dvec4(y, x, x, w);
        /// <summary>
        /// A dvec4 containing the zxxw components of this vector
        /// </summary>
        public readonly dvec4 zxxw => new dvec4(z, x, x, w);
        /// <summary>
        /// A dvec4 containing the wxxw components of this vector
        /// </summary>
        public readonly dvec4 wxxw => new dvec4(w, x, x, w);
        /// <summary>
        /// A dvec4 containing the xyxw components of this vector
        /// </summary>
        public readonly dvec4 xyxw => new dvec4(x, y, x, w);
        /// <summary>
        /// A dvec4 containing the yyxw components of this vector
        /// </summary>
        public readonly dvec4 yyxw => new dvec4(y, y, x, w);
        /// <summary>
        /// A dvec4 containing the zyxw components of this vector
        /// </summary>
        public dvec4 zyxw {
            readonly get => new dvec4(z, y, x, w);
            set {
                z = value.x;
                y = value.y;
                x = value.z;
                w = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the wyxw components of this vector
        /// </summary>
        public readonly dvec4 wyxw => new dvec4(w, y, x, w);
        /// <summary>
        /// A dvec4 containing the xzxw components of this vector
        /// </summary>
        public readonly dvec4 xzxw => new dvec4(x, z, x, w);
        /// <summary>
        /// A dvec4 containing the yzxw components of this vector
        /// </summary>
        public dvec4 yzxw {
            readonly get => new dvec4(y, z, x, w);
            set {
                y = value.x;
                z = value.y;
                x = value.z;
                w = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the zzxw components of this vector
        /// </summary>
        public readonly dvec4 zzxw => new dvec4(z, z, x, w);
        /// <summary>
        /// A dvec4 containing the wzxw components of this vector
        /// </summary>
        public readonly dvec4 wzxw => new dvec4(w, z, x, w);
        /// <summary>
        /// A dvec4 containing the xwxw components of this vector
        /// </summary>
        public readonly dvec4 xwxw => new dvec4(x, w, x, w);
        /// <summary>
        /// A dvec4 containing the ywxw components of this vector
        /// </summary>
        public readonly dvec4 ywxw => new dvec4(y, w, x, w);
        /// <summary>
        /// A dvec4 containing the zwxw components of this vector
        /// </summary>
        public readonly dvec4 zwxw => new dvec4(z, w, x, w);
        /// <summary>
        /// A dvec4 containing the wwxw components of this vector
        /// </summary>
        public readonly dvec4 wwxw => new dvec4(w, w, x, w);
        /// <summary>
        /// A dvec4 containing the xxyw components of this vector
        /// </summary>
        public readonly dvec4 xxyw => new dvec4(x, x, y, w);
        /// <summary>
        /// A dvec4 containing the yxyw components of this vector
        /// </summary>
        public readonly dvec4 yxyw => new dvec4(y, x, y, w);
        /// <summary>
        /// A dvec4 containing the zxyw components of this vector
        /// </summary>
        public dvec4 zxyw {
            readonly get => new dvec4(z, x, y, w);
            set {
                z = value.x;
                x = value.y;
                y = value.z;
                w = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the wxyw components of this vector
        /// </summary>
        public readonly dvec4 wxyw => new dvec4(w, x, y, w);
        /// <summary>
        /// A dvec4 containing the xyyw components of this vector
        /// </summary>
        public readonly dvec4 xyyw => new dvec4(x, y, y, w);
        /// <summary>
        /// A dvec4 containing the yyyw components of this vector
        /// </summary>
        public readonly dvec4 yyyw => new dvec4(y, y, y, w);
        /// <summary>
        /// A dvec4 containing the zyyw components of this vector
        /// </summary>
        public readonly dvec4 zyyw => new dvec4(z, y, y, w);
        /// <summary>
        /// A dvec4 containing the wyyw components of this vector
        /// </summary>
        public readonly dvec4 wyyw => new dvec4(w, y, y, w);
        /// <summary>
        /// A dvec4 containing the xzyw components of this vector
        /// </summary>
        public dvec4 xzyw {
            readonly get => new dvec4(x, z, y, w);
            set {
                x = value.x;
                z = value.y;
                y = value.z;
                w = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the yzyw components of this vector
        /// </summary>
        public readonly dvec4 yzyw => new dvec4(y, z, y, w);
        /// <summary>
        /// A dvec4 containing the zzyw components of this vector
        /// </summary>
        public readonly dvec4 zzyw => new dvec4(z, z, y, w);
        /// <summary>
        /// A dvec4 containing the wzyw components of this vector
        /// </summary>
        public readonly dvec4 wzyw => new dvec4(w, z, y, w);
        /// <summary>
        /// A dvec4 containing the xwyw components of this vector
        /// </summary>
        public readonly dvec4 xwyw => new dvec4(x, w, y, w);
        /// <summary>
        /// A dvec4 containing the ywyw components of this vector
        /// </summary>
        public readonly dvec4 ywyw => new dvec4(y, w, y, w);
        /// <summary>
        /// A dvec4 containing the zwyw components of this vector
        /// </summary>
        public readonly dvec4 zwyw => new dvec4(z, w, y, w);
        /// <summary>
        /// A dvec4 containing the wwyw components of this vector
        /// </summary>
        public readonly dvec4 wwyw => new dvec4(w, w, y, w);
        /// <summary>
        /// A dvec4 containing the xxzw components of this vector
        /// </summary>
        public readonly dvec4 xxzw => new dvec4(x, x, z, w);
        /// <summary>
        /// A dvec4 containing the yxzw components of this vector
        /// </summary>
        public dvec4 yxzw {
            readonly get => new dvec4(y, x, z, w);
            set {
                y = value.x;
                x = value.y;
                z = value.z;
                w = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the zxzw components of this vector
        /// </summary>
        public readonly dvec4 zxzw => new dvec4(z, x, z, w);
        /// <summary>
        /// A dvec4 containing the wxzw components of this vector
        /// </summary>
        public readonly dvec4 wxzw => new dvec4(w, x, z, w);
        /// <summary>
        /// A dvec4 containing the xyzw components of this vector
        /// </summary>
        public dvec4 xyzw {
            readonly get => new dvec4(x, y, z, w);
            set {
                x = value.x;
                y = value.y;
                z = value.z;
                w = value.w;
            }
        }
        /// <summary>
        /// A dvec4 containing the yyzw components of this vector
        /// </summary>
        public readonly dvec4 yyzw => new dvec4(y, y, z, w);
        /// <summary>
        /// A dvec4 containing the zyzw components of this vector
        /// </summary>
        public readonly dvec4 zyzw => new dvec4(z, y, z, w);
        /// <summary>
        /// A dvec4 containing the wyzw components of this vector
        /// </summary>
        public readonly dvec4 wyzw => new dvec4(w, y, z, w);
        /// <summary>
        /// A dvec4 containing the xzzw components of this vector
        /// </summary>
        public readonly dvec4 xzzw => new dvec4(x, z, z, w);
        /// <summary>
        /// A dvec4 containing the yzzw components of this vector
        /// </summary>
        public readonly dvec4 yzzw => new dvec4(y, z, z, w);
        /// <summary>
        /// A dvec4 containing the zzzw components of this vector
        /// </summary>
        public readonly dvec4 zzzw => new dvec4(z, z, z, w);
        /// <summary>
        /// A dvec4 containing the wzzw components of this vector
        /// </summary>
        public readonly dvec4 wzzw => new dvec4(w, z, z, w);
        /// <summary>
        /// A dvec4 containing the xwzw components of this vector
        /// </summary>
        public readonly dvec4 xwzw => new dvec4(x, w, z, w);
        /// <summary>
        /// A dvec4 containing the ywzw components of this vector
        /// </summary>
        public readonly dvec4 ywzw => new dvec4(y, w, z, w);
        /// <summary>
        /// A dvec4 containing the zwzw components of this vector
        /// </summary>
        public readonly dvec4 zwzw => new dvec4(z, w, z, w);
        /// <summary>
        /// A dvec4 containing the wwzw components of this vector
        /// </summary>
        public readonly dvec4 wwzw => new dvec4(w, w, z, w);
        /// <summary>
        /// A dvec4 containing the xxww components of this vector
        /// </summary>
        public readonly dvec4 xxww => new dvec4(x, x, w, w);
        /// <summary>
        /// A dvec4 containing the yxww components of this vector
        /// </summary>
        public readonly dvec4 yxww => new dvec4(y, x, w, w);
        /// <summary>
        /// A dvec4 containing the zxww components of this vector
        /// </summary>
        public readonly dvec4 zxww => new dvec4(z, x, w, w);
        /// <summary>
        /// A dvec4 containing the wxww components of this vector
        /// </summary>
        public readonly dvec4 wxww => new dvec4(w, x, w, w);
        /// <summary>
        /// A dvec4 containing the xyww components of this vector
        /// </summary>
        public readonly dvec4 xyww => new dvec4(x, y, w, w);
        /// <summary>
        /// A dvec4 containing the yyww components of this vector
        /// </summary>
        public readonly dvec4 yyww => new dvec4(y, y, w, w);
        /// <summary>
        /// A dvec4 containing the zyww components of this vector
        /// </summary>
        public readonly dvec4 zyww => new dvec4(z, y, w, w);
        /// <summary>
        /// A dvec4 containing the wyww components of this vector
        /// </summary>
        public readonly dvec4 wyww => new dvec4(w, y, w, w);
        /// <summary>
        /// A dvec4 containing the xzww components of this vector
        /// </summary>
        public readonly dvec4 xzww => new dvec4(x, z, w, w);
        /// <summary>
        /// A dvec4 containing the yzww components of this vector
        /// </summary>
        public readonly dvec4 yzww => new dvec4(y, z, w, w);
        /// <summary>
        /// A dvec4 containing the zzww components of this vector
        /// </summary>
        public readonly dvec4 zzww => new dvec4(z, z, w, w);
        /// <summary>
        /// A dvec4 containing the wzww components of this vector
        /// </summary>
        public readonly dvec4 wzww => new dvec4(w, z, w, w);
        /// <summary>
        /// A dvec4 containing the xwww components of this vector
        /// </summary>
        public readonly dvec4 xwww => new dvec4(x, w, w, w);
        /// <summary>
        /// A dvec4 containing the ywww components of this vector
        /// </summary>
        public readonly dvec4 ywww => new dvec4(y, w, w, w);
        /// <summary>
        /// A dvec4 containing the zwww components of this vector
        /// </summary>
        public readonly dvec4 zwww => new dvec4(z, w, w, w);
        /// <summary>
        /// A dvec4 containing the wwww components of this vector
        /// </summary>
        public readonly dvec4 wwww => new dvec4(w, w, w, w);
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
        public readonly double dot(dvec4 v) => (this * v).sum;

        public static dvec4 operator *(dvec4 a, dvec4 b) => new dvec4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        public static dvec4 operator /(dvec4 a, dvec4 b) => new dvec4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
        public static dvec4 operator +(dvec4 a, dvec4 b) => new dvec4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        public static dvec4 operator -(dvec4 a, dvec4 b) => new dvec4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);

        public static dvec4 operator *(dvec4 a, double s) => new dvec4(a.x * s, a.y * s, a.z * s, a.w * s);
        public static dvec4 operator /(dvec4 a, double s) => new dvec4(a.x / s, a.y / s, a.z / s, a.w / s);

        public static dvec4 operator -(dvec4 v) => new dvec4(-v.x, -v.y, -v.z, -v.w);
        #endregion

        #region math
        public readonly double distTo(dvec4 o) => (o - this).length;
        public readonly double angleTo(dvec4 o) => (double)Math.Acos(this.dot(o) / (this.length * o.length));
        public readonly dvec4 lerp(dvec4 o, double t) => this + ((o - this) * t);
        public readonly dvec4 reflect(dvec4 normal) => this - (normal * 2 * (this.dot(normal) / normal.dot(normal)));
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
