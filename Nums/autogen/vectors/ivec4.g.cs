using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 4 component vector of int
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ivec4 : ivec {

        #region constants
        /// <summary>
        /// The zero vector: A vector where all components are equal to zero.
        /// </summary>
        public static readonly ivec4 zero = (0, 0, 0, 0);
        /// <summary>
        /// A unit vector pointing in the positive x direction. →
        /// </summary>
        public static readonly ivec4 unitx = (1, 0, 0, 0);
        /// <summary>
        /// A unit vector pointing in the positive y direction. ↑
        /// </summary>
        public static readonly ivec4 unity = (0, 1, 0, 0);
        /// <summary>
        /// A unit vector pointing in the positive z direction. ↗
        /// </summary>
        public static readonly ivec4 unitz = (0, 0, 1, 0);
        /// <summary>
        /// A unit vector pointing in the positive w direction. 
        /// </summary>
        public static readonly ivec4 unitw = (0, 0, 0, 1);
        /// <summary>
        /// A vector where all components are equal to one.
        /// </summary>
        public static readonly ivec4 one = (1, 1, 1, 1);
        #endregion

        /// <summary>
        /// The x component is the first index of the vector
        /// </summary>
        public int x;
        /// <summary>
        /// The y component is the second index of the vector
        /// </summary>
        public int y;
        /// <summary>
        /// The z component is the third index of the vector
        /// </summary>
        public int z;
        /// <summary>
        /// The w component is the fourth index of the vector
        /// </summary>
        public int w;
        /// <summary>
        /// The sum of the vectors components. x + y + z + w
        /// </summary>
        public readonly int sum => x + y + z + w;
        /// <summary>
        /// The number of bytes the vector type uses.
        /// </summary>
        public const int bytesize = sizeof(int) * 4;
        /// <summary>
        /// The magnitude of the vector
        /// </summary>
        public readonly int length => (int)Math.Sqrt(dot(this));
        /// <summary>
        /// The squared magnitude of the vector. sqlength is faster than length since a square-root operation is not needed.
        /// </summary>
        public readonly int sqlength => dot(this);
        /// <summary>
        /// The normalized version of this vector.
        /// </summary>
        public readonly ivec4 normalized() => this / length;
        /// <summary>
        /// Normalizes this vector.
        /// </summary>
        public void normalize() => this /= length;

        public int this[int i] {
            readonly get => i switch {
                0 => x,
                1 => y,
                2 => z,
                3 => w,
                _ => throw new IndexOutOfRangeException("ivec4[" + i + "] is not a valid index")
            };
            set {
                switch (i) {
                    case 0: x = value; return;
                    case 1: y = value; return;
                    case 2: z = value; return;
                    case 3: w = value; return;
                    default: throw new IndexOutOfRangeException("ivec4[" + i + "] is not a valid index");
                }
            }
        }

        #region swizzling properties
        /// <summary>
        /// A ivec2 containing the xx components of this vector
        /// </summary>
        public readonly ivec2 xx => new ivec2(x, x);
        /// <summary>
        /// A ivec2 containing the yx components of this vector
        /// </summary>
        public ivec2 yx {
            readonly get => new ivec2(y, x);
            set {
                y = value.x;
                x = value.y;
            }
        }
        /// <summary>
        /// A ivec2 containing the zx components of this vector
        /// </summary>
        public ivec2 zx {
            readonly get => new ivec2(z, x);
            set {
                z = value.x;
                x = value.y;
            }
        }
        /// <summary>
        /// A ivec2 containing the wx components of this vector
        /// </summary>
        public ivec2 wx {
            readonly get => new ivec2(w, x);
            set {
                w = value.x;
                x = value.y;
            }
        }
        /// <summary>
        /// A ivec2 containing the xy components of this vector
        /// </summary>
        public ivec2 xy {
            readonly get => new ivec2(x, y);
            set {
                x = value.x;
                y = value.y;
            }
        }
        /// <summary>
        /// A ivec2 containing the yy components of this vector
        /// </summary>
        public readonly ivec2 yy => new ivec2(y, y);
        /// <summary>
        /// A ivec2 containing the zy components of this vector
        /// </summary>
        public ivec2 zy {
            readonly get => new ivec2(z, y);
            set {
                z = value.x;
                y = value.y;
            }
        }
        /// <summary>
        /// A ivec2 containing the wy components of this vector
        /// </summary>
        public ivec2 wy {
            readonly get => new ivec2(w, y);
            set {
                w = value.x;
                y = value.y;
            }
        }
        /// <summary>
        /// A ivec2 containing the xz components of this vector
        /// </summary>
        public ivec2 xz {
            readonly get => new ivec2(x, z);
            set {
                x = value.x;
                z = value.y;
            }
        }
        /// <summary>
        /// A ivec2 containing the yz components of this vector
        /// </summary>
        public ivec2 yz {
            readonly get => new ivec2(y, z);
            set {
                y = value.x;
                z = value.y;
            }
        }
        /// <summary>
        /// A ivec2 containing the zz components of this vector
        /// </summary>
        public readonly ivec2 zz => new ivec2(z, z);
        /// <summary>
        /// A ivec2 containing the wz components of this vector
        /// </summary>
        public ivec2 wz {
            readonly get => new ivec2(w, z);
            set {
                w = value.x;
                z = value.y;
            }
        }
        /// <summary>
        /// A ivec2 containing the xw components of this vector
        /// </summary>
        public ivec2 xw {
            readonly get => new ivec2(x, w);
            set {
                x = value.x;
                w = value.y;
            }
        }
        /// <summary>
        /// A ivec2 containing the yw components of this vector
        /// </summary>
        public ivec2 yw {
            readonly get => new ivec2(y, w);
            set {
                y = value.x;
                w = value.y;
            }
        }
        /// <summary>
        /// A ivec2 containing the zw components of this vector
        /// </summary>
        public ivec2 zw {
            readonly get => new ivec2(z, w);
            set {
                z = value.x;
                w = value.y;
            }
        }
        /// <summary>
        /// A ivec2 containing the ww components of this vector
        /// </summary>
        public readonly ivec2 ww => new ivec2(w, w);
        /// <summary>
        /// A ivec3 containing the xxx components of this vector
        /// </summary>
        public readonly ivec3 xxx => new ivec3(x, x, x);
        /// <summary>
        /// A ivec3 containing the yxx components of this vector
        /// </summary>
        public readonly ivec3 yxx => new ivec3(y, x, x);
        /// <summary>
        /// A ivec3 containing the zxx components of this vector
        /// </summary>
        public readonly ivec3 zxx => new ivec3(z, x, x);
        /// <summary>
        /// A ivec3 containing the wxx components of this vector
        /// </summary>
        public readonly ivec3 wxx => new ivec3(w, x, x);
        /// <summary>
        /// A ivec3 containing the xyx components of this vector
        /// </summary>
        public readonly ivec3 xyx => new ivec3(x, y, x);
        /// <summary>
        /// A ivec3 containing the yyx components of this vector
        /// </summary>
        public readonly ivec3 yyx => new ivec3(y, y, x);
        /// <summary>
        /// A ivec3 containing the zyx components of this vector
        /// </summary>
        public ivec3 zyx {
            readonly get => new ivec3(z, y, x);
            set {
                z = value.x;
                y = value.y;
                x = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the wyx components of this vector
        /// </summary>
        public ivec3 wyx {
            readonly get => new ivec3(w, y, x);
            set {
                w = value.x;
                y = value.y;
                x = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the xzx components of this vector
        /// </summary>
        public readonly ivec3 xzx => new ivec3(x, z, x);
        /// <summary>
        /// A ivec3 containing the yzx components of this vector
        /// </summary>
        public ivec3 yzx {
            readonly get => new ivec3(y, z, x);
            set {
                y = value.x;
                z = value.y;
                x = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the zzx components of this vector
        /// </summary>
        public readonly ivec3 zzx => new ivec3(z, z, x);
        /// <summary>
        /// A ivec3 containing the wzx components of this vector
        /// </summary>
        public ivec3 wzx {
            readonly get => new ivec3(w, z, x);
            set {
                w = value.x;
                z = value.y;
                x = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the xwx components of this vector
        /// </summary>
        public readonly ivec3 xwx => new ivec3(x, w, x);
        /// <summary>
        /// A ivec3 containing the ywx components of this vector
        /// </summary>
        public ivec3 ywx {
            readonly get => new ivec3(y, w, x);
            set {
                y = value.x;
                w = value.y;
                x = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the zwx components of this vector
        /// </summary>
        public ivec3 zwx {
            readonly get => new ivec3(z, w, x);
            set {
                z = value.x;
                w = value.y;
                x = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the wwx components of this vector
        /// </summary>
        public readonly ivec3 wwx => new ivec3(w, w, x);
        /// <summary>
        /// A ivec3 containing the xxy components of this vector
        /// </summary>
        public readonly ivec3 xxy => new ivec3(x, x, y);
        /// <summary>
        /// A ivec3 containing the yxy components of this vector
        /// </summary>
        public readonly ivec3 yxy => new ivec3(y, x, y);
        /// <summary>
        /// A ivec3 containing the zxy components of this vector
        /// </summary>
        public ivec3 zxy {
            readonly get => new ivec3(z, x, y);
            set {
                z = value.x;
                x = value.y;
                y = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the wxy components of this vector
        /// </summary>
        public ivec3 wxy {
            readonly get => new ivec3(w, x, y);
            set {
                w = value.x;
                x = value.y;
                y = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the xyy components of this vector
        /// </summary>
        public readonly ivec3 xyy => new ivec3(x, y, y);
        /// <summary>
        /// A ivec3 containing the yyy components of this vector
        /// </summary>
        public readonly ivec3 yyy => new ivec3(y, y, y);
        /// <summary>
        /// A ivec3 containing the zyy components of this vector
        /// </summary>
        public readonly ivec3 zyy => new ivec3(z, y, y);
        /// <summary>
        /// A ivec3 containing the wyy components of this vector
        /// </summary>
        public readonly ivec3 wyy => new ivec3(w, y, y);
        /// <summary>
        /// A ivec3 containing the xzy components of this vector
        /// </summary>
        public ivec3 xzy {
            readonly get => new ivec3(x, z, y);
            set {
                x = value.x;
                z = value.y;
                y = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the yzy components of this vector
        /// </summary>
        public readonly ivec3 yzy => new ivec3(y, z, y);
        /// <summary>
        /// A ivec3 containing the zzy components of this vector
        /// </summary>
        public readonly ivec3 zzy => new ivec3(z, z, y);
        /// <summary>
        /// A ivec3 containing the wzy components of this vector
        /// </summary>
        public ivec3 wzy {
            readonly get => new ivec3(w, z, y);
            set {
                w = value.x;
                z = value.y;
                y = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the xwy components of this vector
        /// </summary>
        public ivec3 xwy {
            readonly get => new ivec3(x, w, y);
            set {
                x = value.x;
                w = value.y;
                y = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the ywy components of this vector
        /// </summary>
        public readonly ivec3 ywy => new ivec3(y, w, y);
        /// <summary>
        /// A ivec3 containing the zwy components of this vector
        /// </summary>
        public ivec3 zwy {
            readonly get => new ivec3(z, w, y);
            set {
                z = value.x;
                w = value.y;
                y = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the wwy components of this vector
        /// </summary>
        public readonly ivec3 wwy => new ivec3(w, w, y);
        /// <summary>
        /// A ivec3 containing the xxz components of this vector
        /// </summary>
        public readonly ivec3 xxz => new ivec3(x, x, z);
        /// <summary>
        /// A ivec3 containing the yxz components of this vector
        /// </summary>
        public ivec3 yxz {
            readonly get => new ivec3(y, x, z);
            set {
                y = value.x;
                x = value.y;
                z = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the zxz components of this vector
        /// </summary>
        public readonly ivec3 zxz => new ivec3(z, x, z);
        /// <summary>
        /// A ivec3 containing the wxz components of this vector
        /// </summary>
        public ivec3 wxz {
            readonly get => new ivec3(w, x, z);
            set {
                w = value.x;
                x = value.y;
                z = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the xyz components of this vector
        /// </summary>
        public ivec3 xyz {
            readonly get => new ivec3(x, y, z);
            set {
                x = value.x;
                y = value.y;
                z = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the yyz components of this vector
        /// </summary>
        public readonly ivec3 yyz => new ivec3(y, y, z);
        /// <summary>
        /// A ivec3 containing the zyz components of this vector
        /// </summary>
        public readonly ivec3 zyz => new ivec3(z, y, z);
        /// <summary>
        /// A ivec3 containing the wyz components of this vector
        /// </summary>
        public ivec3 wyz {
            readonly get => new ivec3(w, y, z);
            set {
                w = value.x;
                y = value.y;
                z = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the xzz components of this vector
        /// </summary>
        public readonly ivec3 xzz => new ivec3(x, z, z);
        /// <summary>
        /// A ivec3 containing the yzz components of this vector
        /// </summary>
        public readonly ivec3 yzz => new ivec3(y, z, z);
        /// <summary>
        /// A ivec3 containing the zzz components of this vector
        /// </summary>
        public readonly ivec3 zzz => new ivec3(z, z, z);
        /// <summary>
        /// A ivec3 containing the wzz components of this vector
        /// </summary>
        public readonly ivec3 wzz => new ivec3(w, z, z);
        /// <summary>
        /// A ivec3 containing the xwz components of this vector
        /// </summary>
        public ivec3 xwz {
            readonly get => new ivec3(x, w, z);
            set {
                x = value.x;
                w = value.y;
                z = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the ywz components of this vector
        /// </summary>
        public ivec3 ywz {
            readonly get => new ivec3(y, w, z);
            set {
                y = value.x;
                w = value.y;
                z = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the zwz components of this vector
        /// </summary>
        public readonly ivec3 zwz => new ivec3(z, w, z);
        /// <summary>
        /// A ivec3 containing the wwz components of this vector
        /// </summary>
        public readonly ivec3 wwz => new ivec3(w, w, z);
        /// <summary>
        /// A ivec3 containing the xxw components of this vector
        /// </summary>
        public readonly ivec3 xxw => new ivec3(x, x, w);
        /// <summary>
        /// A ivec3 containing the yxw components of this vector
        /// </summary>
        public ivec3 yxw {
            readonly get => new ivec3(y, x, w);
            set {
                y = value.x;
                x = value.y;
                w = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the zxw components of this vector
        /// </summary>
        public ivec3 zxw {
            readonly get => new ivec3(z, x, w);
            set {
                z = value.x;
                x = value.y;
                w = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the wxw components of this vector
        /// </summary>
        public readonly ivec3 wxw => new ivec3(w, x, w);
        /// <summary>
        /// A ivec3 containing the xyw components of this vector
        /// </summary>
        public ivec3 xyw {
            readonly get => new ivec3(x, y, w);
            set {
                x = value.x;
                y = value.y;
                w = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the yyw components of this vector
        /// </summary>
        public readonly ivec3 yyw => new ivec3(y, y, w);
        /// <summary>
        /// A ivec3 containing the zyw components of this vector
        /// </summary>
        public ivec3 zyw {
            readonly get => new ivec3(z, y, w);
            set {
                z = value.x;
                y = value.y;
                w = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the wyw components of this vector
        /// </summary>
        public readonly ivec3 wyw => new ivec3(w, y, w);
        /// <summary>
        /// A ivec3 containing the xzw components of this vector
        /// </summary>
        public ivec3 xzw {
            readonly get => new ivec3(x, z, w);
            set {
                x = value.x;
                z = value.y;
                w = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the yzw components of this vector
        /// </summary>
        public ivec3 yzw {
            readonly get => new ivec3(y, z, w);
            set {
                y = value.x;
                z = value.y;
                w = value.z;
            }
        }
        /// <summary>
        /// A ivec3 containing the zzw components of this vector
        /// </summary>
        public readonly ivec3 zzw => new ivec3(z, z, w);
        /// <summary>
        /// A ivec3 containing the wzw components of this vector
        /// </summary>
        public readonly ivec3 wzw => new ivec3(w, z, w);
        /// <summary>
        /// A ivec3 containing the xww components of this vector
        /// </summary>
        public readonly ivec3 xww => new ivec3(x, w, w);
        /// <summary>
        /// A ivec3 containing the yww components of this vector
        /// </summary>
        public readonly ivec3 yww => new ivec3(y, w, w);
        /// <summary>
        /// A ivec3 containing the zww components of this vector
        /// </summary>
        public readonly ivec3 zww => new ivec3(z, w, w);
        /// <summary>
        /// A ivec3 containing the www components of this vector
        /// </summary>
        public readonly ivec3 www => new ivec3(w, w, w);
        /// <summary>
        /// A ivec4 containing the xxxx components of this vector
        /// </summary>
        public readonly ivec4 xxxx => new ivec4(x, x, x, x);
        /// <summary>
        /// A ivec4 containing the yxxx components of this vector
        /// </summary>
        public readonly ivec4 yxxx => new ivec4(y, x, x, x);
        /// <summary>
        /// A ivec4 containing the zxxx components of this vector
        /// </summary>
        public readonly ivec4 zxxx => new ivec4(z, x, x, x);
        /// <summary>
        /// A ivec4 containing the wxxx components of this vector
        /// </summary>
        public readonly ivec4 wxxx => new ivec4(w, x, x, x);
        /// <summary>
        /// A ivec4 containing the xyxx components of this vector
        /// </summary>
        public readonly ivec4 xyxx => new ivec4(x, y, x, x);
        /// <summary>
        /// A ivec4 containing the yyxx components of this vector
        /// </summary>
        public readonly ivec4 yyxx => new ivec4(y, y, x, x);
        /// <summary>
        /// A ivec4 containing the zyxx components of this vector
        /// </summary>
        public readonly ivec4 zyxx => new ivec4(z, y, x, x);
        /// <summary>
        /// A ivec4 containing the wyxx components of this vector
        /// </summary>
        public readonly ivec4 wyxx => new ivec4(w, y, x, x);
        /// <summary>
        /// A ivec4 containing the xzxx components of this vector
        /// </summary>
        public readonly ivec4 xzxx => new ivec4(x, z, x, x);
        /// <summary>
        /// A ivec4 containing the yzxx components of this vector
        /// </summary>
        public readonly ivec4 yzxx => new ivec4(y, z, x, x);
        /// <summary>
        /// A ivec4 containing the zzxx components of this vector
        /// </summary>
        public readonly ivec4 zzxx => new ivec4(z, z, x, x);
        /// <summary>
        /// A ivec4 containing the wzxx components of this vector
        /// </summary>
        public readonly ivec4 wzxx => new ivec4(w, z, x, x);
        /// <summary>
        /// A ivec4 containing the xwxx components of this vector
        /// </summary>
        public readonly ivec4 xwxx => new ivec4(x, w, x, x);
        /// <summary>
        /// A ivec4 containing the ywxx components of this vector
        /// </summary>
        public readonly ivec4 ywxx => new ivec4(y, w, x, x);
        /// <summary>
        /// A ivec4 containing the zwxx components of this vector
        /// </summary>
        public readonly ivec4 zwxx => new ivec4(z, w, x, x);
        /// <summary>
        /// A ivec4 containing the wwxx components of this vector
        /// </summary>
        public readonly ivec4 wwxx => new ivec4(w, w, x, x);
        /// <summary>
        /// A ivec4 containing the xxyx components of this vector
        /// </summary>
        public readonly ivec4 xxyx => new ivec4(x, x, y, x);
        /// <summary>
        /// A ivec4 containing the yxyx components of this vector
        /// </summary>
        public readonly ivec4 yxyx => new ivec4(y, x, y, x);
        /// <summary>
        /// A ivec4 containing the zxyx components of this vector
        /// </summary>
        public readonly ivec4 zxyx => new ivec4(z, x, y, x);
        /// <summary>
        /// A ivec4 containing the wxyx components of this vector
        /// </summary>
        public readonly ivec4 wxyx => new ivec4(w, x, y, x);
        /// <summary>
        /// A ivec4 containing the xyyx components of this vector
        /// </summary>
        public readonly ivec4 xyyx => new ivec4(x, y, y, x);
        /// <summary>
        /// A ivec4 containing the yyyx components of this vector
        /// </summary>
        public readonly ivec4 yyyx => new ivec4(y, y, y, x);
        /// <summary>
        /// A ivec4 containing the zyyx components of this vector
        /// </summary>
        public readonly ivec4 zyyx => new ivec4(z, y, y, x);
        /// <summary>
        /// A ivec4 containing the wyyx components of this vector
        /// </summary>
        public readonly ivec4 wyyx => new ivec4(w, y, y, x);
        /// <summary>
        /// A ivec4 containing the xzyx components of this vector
        /// </summary>
        public readonly ivec4 xzyx => new ivec4(x, z, y, x);
        /// <summary>
        /// A ivec4 containing the yzyx components of this vector
        /// </summary>
        public readonly ivec4 yzyx => new ivec4(y, z, y, x);
        /// <summary>
        /// A ivec4 containing the zzyx components of this vector
        /// </summary>
        public readonly ivec4 zzyx => new ivec4(z, z, y, x);
        /// <summary>
        /// A ivec4 containing the wzyx components of this vector
        /// </summary>
        public ivec4 wzyx {
            readonly get => new ivec4(w, z, y, x);
            set {
                w = value.x;
                z = value.y;
                y = value.z;
                x = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the xwyx components of this vector
        /// </summary>
        public readonly ivec4 xwyx => new ivec4(x, w, y, x);
        /// <summary>
        /// A ivec4 containing the ywyx components of this vector
        /// </summary>
        public readonly ivec4 ywyx => new ivec4(y, w, y, x);
        /// <summary>
        /// A ivec4 containing the zwyx components of this vector
        /// </summary>
        public ivec4 zwyx {
            readonly get => new ivec4(z, w, y, x);
            set {
                z = value.x;
                w = value.y;
                y = value.z;
                x = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the wwyx components of this vector
        /// </summary>
        public readonly ivec4 wwyx => new ivec4(w, w, y, x);
        /// <summary>
        /// A ivec4 containing the xxzx components of this vector
        /// </summary>
        public readonly ivec4 xxzx => new ivec4(x, x, z, x);
        /// <summary>
        /// A ivec4 containing the yxzx components of this vector
        /// </summary>
        public readonly ivec4 yxzx => new ivec4(y, x, z, x);
        /// <summary>
        /// A ivec4 containing the zxzx components of this vector
        /// </summary>
        public readonly ivec4 zxzx => new ivec4(z, x, z, x);
        /// <summary>
        /// A ivec4 containing the wxzx components of this vector
        /// </summary>
        public readonly ivec4 wxzx => new ivec4(w, x, z, x);
        /// <summary>
        /// A ivec4 containing the xyzx components of this vector
        /// </summary>
        public readonly ivec4 xyzx => new ivec4(x, y, z, x);
        /// <summary>
        /// A ivec4 containing the yyzx components of this vector
        /// </summary>
        public readonly ivec4 yyzx => new ivec4(y, y, z, x);
        /// <summary>
        /// A ivec4 containing the zyzx components of this vector
        /// </summary>
        public readonly ivec4 zyzx => new ivec4(z, y, z, x);
        /// <summary>
        /// A ivec4 containing the wyzx components of this vector
        /// </summary>
        public ivec4 wyzx {
            readonly get => new ivec4(w, y, z, x);
            set {
                w = value.x;
                y = value.y;
                z = value.z;
                x = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the xzzx components of this vector
        /// </summary>
        public readonly ivec4 xzzx => new ivec4(x, z, z, x);
        /// <summary>
        /// A ivec4 containing the yzzx components of this vector
        /// </summary>
        public readonly ivec4 yzzx => new ivec4(y, z, z, x);
        /// <summary>
        /// A ivec4 containing the zzzx components of this vector
        /// </summary>
        public readonly ivec4 zzzx => new ivec4(z, z, z, x);
        /// <summary>
        /// A ivec4 containing the wzzx components of this vector
        /// </summary>
        public readonly ivec4 wzzx => new ivec4(w, z, z, x);
        /// <summary>
        /// A ivec4 containing the xwzx components of this vector
        /// </summary>
        public readonly ivec4 xwzx => new ivec4(x, w, z, x);
        /// <summary>
        /// A ivec4 containing the ywzx components of this vector
        /// </summary>
        public ivec4 ywzx {
            readonly get => new ivec4(y, w, z, x);
            set {
                y = value.x;
                w = value.y;
                z = value.z;
                x = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the zwzx components of this vector
        /// </summary>
        public readonly ivec4 zwzx => new ivec4(z, w, z, x);
        /// <summary>
        /// A ivec4 containing the wwzx components of this vector
        /// </summary>
        public readonly ivec4 wwzx => new ivec4(w, w, z, x);
        /// <summary>
        /// A ivec4 containing the xxwx components of this vector
        /// </summary>
        public readonly ivec4 xxwx => new ivec4(x, x, w, x);
        /// <summary>
        /// A ivec4 containing the yxwx components of this vector
        /// </summary>
        public readonly ivec4 yxwx => new ivec4(y, x, w, x);
        /// <summary>
        /// A ivec4 containing the zxwx components of this vector
        /// </summary>
        public readonly ivec4 zxwx => new ivec4(z, x, w, x);
        /// <summary>
        /// A ivec4 containing the wxwx components of this vector
        /// </summary>
        public readonly ivec4 wxwx => new ivec4(w, x, w, x);
        /// <summary>
        /// A ivec4 containing the xywx components of this vector
        /// </summary>
        public readonly ivec4 xywx => new ivec4(x, y, w, x);
        /// <summary>
        /// A ivec4 containing the yywx components of this vector
        /// </summary>
        public readonly ivec4 yywx => new ivec4(y, y, w, x);
        /// <summary>
        /// A ivec4 containing the zywx components of this vector
        /// </summary>
        public ivec4 zywx {
            readonly get => new ivec4(z, y, w, x);
            set {
                z = value.x;
                y = value.y;
                w = value.z;
                x = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the wywx components of this vector
        /// </summary>
        public readonly ivec4 wywx => new ivec4(w, y, w, x);
        /// <summary>
        /// A ivec4 containing the xzwx components of this vector
        /// </summary>
        public readonly ivec4 xzwx => new ivec4(x, z, w, x);
        /// <summary>
        /// A ivec4 containing the yzwx components of this vector
        /// </summary>
        public ivec4 yzwx {
            readonly get => new ivec4(y, z, w, x);
            set {
                y = value.x;
                z = value.y;
                w = value.z;
                x = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the zzwx components of this vector
        /// </summary>
        public readonly ivec4 zzwx => new ivec4(z, z, w, x);
        /// <summary>
        /// A ivec4 containing the wzwx components of this vector
        /// </summary>
        public readonly ivec4 wzwx => new ivec4(w, z, w, x);
        /// <summary>
        /// A ivec4 containing the xwwx components of this vector
        /// </summary>
        public readonly ivec4 xwwx => new ivec4(x, w, w, x);
        /// <summary>
        /// A ivec4 containing the ywwx components of this vector
        /// </summary>
        public readonly ivec4 ywwx => new ivec4(y, w, w, x);
        /// <summary>
        /// A ivec4 containing the zwwx components of this vector
        /// </summary>
        public readonly ivec4 zwwx => new ivec4(z, w, w, x);
        /// <summary>
        /// A ivec4 containing the wwwx components of this vector
        /// </summary>
        public readonly ivec4 wwwx => new ivec4(w, w, w, x);
        /// <summary>
        /// A ivec4 containing the xxxy components of this vector
        /// </summary>
        public readonly ivec4 xxxy => new ivec4(x, x, x, y);
        /// <summary>
        /// A ivec4 containing the yxxy components of this vector
        /// </summary>
        public readonly ivec4 yxxy => new ivec4(y, x, x, y);
        /// <summary>
        /// A ivec4 containing the zxxy components of this vector
        /// </summary>
        public readonly ivec4 zxxy => new ivec4(z, x, x, y);
        /// <summary>
        /// A ivec4 containing the wxxy components of this vector
        /// </summary>
        public readonly ivec4 wxxy => new ivec4(w, x, x, y);
        /// <summary>
        /// A ivec4 containing the xyxy components of this vector
        /// </summary>
        public readonly ivec4 xyxy => new ivec4(x, y, x, y);
        /// <summary>
        /// A ivec4 containing the yyxy components of this vector
        /// </summary>
        public readonly ivec4 yyxy => new ivec4(y, y, x, y);
        /// <summary>
        /// A ivec4 containing the zyxy components of this vector
        /// </summary>
        public readonly ivec4 zyxy => new ivec4(z, y, x, y);
        /// <summary>
        /// A ivec4 containing the wyxy components of this vector
        /// </summary>
        public readonly ivec4 wyxy => new ivec4(w, y, x, y);
        /// <summary>
        /// A ivec4 containing the xzxy components of this vector
        /// </summary>
        public readonly ivec4 xzxy => new ivec4(x, z, x, y);
        /// <summary>
        /// A ivec4 containing the yzxy components of this vector
        /// </summary>
        public readonly ivec4 yzxy => new ivec4(y, z, x, y);
        /// <summary>
        /// A ivec4 containing the zzxy components of this vector
        /// </summary>
        public readonly ivec4 zzxy => new ivec4(z, z, x, y);
        /// <summary>
        /// A ivec4 containing the wzxy components of this vector
        /// </summary>
        public ivec4 wzxy {
            readonly get => new ivec4(w, z, x, y);
            set {
                w = value.x;
                z = value.y;
                x = value.z;
                y = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the xwxy components of this vector
        /// </summary>
        public readonly ivec4 xwxy => new ivec4(x, w, x, y);
        /// <summary>
        /// A ivec4 containing the ywxy components of this vector
        /// </summary>
        public readonly ivec4 ywxy => new ivec4(y, w, x, y);
        /// <summary>
        /// A ivec4 containing the zwxy components of this vector
        /// </summary>
        public ivec4 zwxy {
            readonly get => new ivec4(z, w, x, y);
            set {
                z = value.x;
                w = value.y;
                x = value.z;
                y = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the wwxy components of this vector
        /// </summary>
        public readonly ivec4 wwxy => new ivec4(w, w, x, y);
        /// <summary>
        /// A ivec4 containing the xxyy components of this vector
        /// </summary>
        public readonly ivec4 xxyy => new ivec4(x, x, y, y);
        /// <summary>
        /// A ivec4 containing the yxyy components of this vector
        /// </summary>
        public readonly ivec4 yxyy => new ivec4(y, x, y, y);
        /// <summary>
        /// A ivec4 containing the zxyy components of this vector
        /// </summary>
        public readonly ivec4 zxyy => new ivec4(z, x, y, y);
        /// <summary>
        /// A ivec4 containing the wxyy components of this vector
        /// </summary>
        public readonly ivec4 wxyy => new ivec4(w, x, y, y);
        /// <summary>
        /// A ivec4 containing the xyyy components of this vector
        /// </summary>
        public readonly ivec4 xyyy => new ivec4(x, y, y, y);
        /// <summary>
        /// A ivec4 containing the yyyy components of this vector
        /// </summary>
        public readonly ivec4 yyyy => new ivec4(y, y, y, y);
        /// <summary>
        /// A ivec4 containing the zyyy components of this vector
        /// </summary>
        public readonly ivec4 zyyy => new ivec4(z, y, y, y);
        /// <summary>
        /// A ivec4 containing the wyyy components of this vector
        /// </summary>
        public readonly ivec4 wyyy => new ivec4(w, y, y, y);
        /// <summary>
        /// A ivec4 containing the xzyy components of this vector
        /// </summary>
        public readonly ivec4 xzyy => new ivec4(x, z, y, y);
        /// <summary>
        /// A ivec4 containing the yzyy components of this vector
        /// </summary>
        public readonly ivec4 yzyy => new ivec4(y, z, y, y);
        /// <summary>
        /// A ivec4 containing the zzyy components of this vector
        /// </summary>
        public readonly ivec4 zzyy => new ivec4(z, z, y, y);
        /// <summary>
        /// A ivec4 containing the wzyy components of this vector
        /// </summary>
        public readonly ivec4 wzyy => new ivec4(w, z, y, y);
        /// <summary>
        /// A ivec4 containing the xwyy components of this vector
        /// </summary>
        public readonly ivec4 xwyy => new ivec4(x, w, y, y);
        /// <summary>
        /// A ivec4 containing the ywyy components of this vector
        /// </summary>
        public readonly ivec4 ywyy => new ivec4(y, w, y, y);
        /// <summary>
        /// A ivec4 containing the zwyy components of this vector
        /// </summary>
        public readonly ivec4 zwyy => new ivec4(z, w, y, y);
        /// <summary>
        /// A ivec4 containing the wwyy components of this vector
        /// </summary>
        public readonly ivec4 wwyy => new ivec4(w, w, y, y);
        /// <summary>
        /// A ivec4 containing the xxzy components of this vector
        /// </summary>
        public readonly ivec4 xxzy => new ivec4(x, x, z, y);
        /// <summary>
        /// A ivec4 containing the yxzy components of this vector
        /// </summary>
        public readonly ivec4 yxzy => new ivec4(y, x, z, y);
        /// <summary>
        /// A ivec4 containing the zxzy components of this vector
        /// </summary>
        public readonly ivec4 zxzy => new ivec4(z, x, z, y);
        /// <summary>
        /// A ivec4 containing the wxzy components of this vector
        /// </summary>
        public ivec4 wxzy {
            readonly get => new ivec4(w, x, z, y);
            set {
                w = value.x;
                x = value.y;
                z = value.z;
                y = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the xyzy components of this vector
        /// </summary>
        public readonly ivec4 xyzy => new ivec4(x, y, z, y);
        /// <summary>
        /// A ivec4 containing the yyzy components of this vector
        /// </summary>
        public readonly ivec4 yyzy => new ivec4(y, y, z, y);
        /// <summary>
        /// A ivec4 containing the zyzy components of this vector
        /// </summary>
        public readonly ivec4 zyzy => new ivec4(z, y, z, y);
        /// <summary>
        /// A ivec4 containing the wyzy components of this vector
        /// </summary>
        public readonly ivec4 wyzy => new ivec4(w, y, z, y);
        /// <summary>
        /// A ivec4 containing the xzzy components of this vector
        /// </summary>
        public readonly ivec4 xzzy => new ivec4(x, z, z, y);
        /// <summary>
        /// A ivec4 containing the yzzy components of this vector
        /// </summary>
        public readonly ivec4 yzzy => new ivec4(y, z, z, y);
        /// <summary>
        /// A ivec4 containing the zzzy components of this vector
        /// </summary>
        public readonly ivec4 zzzy => new ivec4(z, z, z, y);
        /// <summary>
        /// A ivec4 containing the wzzy components of this vector
        /// </summary>
        public readonly ivec4 wzzy => new ivec4(w, z, z, y);
        /// <summary>
        /// A ivec4 containing the xwzy components of this vector
        /// </summary>
        public ivec4 xwzy {
            readonly get => new ivec4(x, w, z, y);
            set {
                x = value.x;
                w = value.y;
                z = value.z;
                y = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the ywzy components of this vector
        /// </summary>
        public readonly ivec4 ywzy => new ivec4(y, w, z, y);
        /// <summary>
        /// A ivec4 containing the zwzy components of this vector
        /// </summary>
        public readonly ivec4 zwzy => new ivec4(z, w, z, y);
        /// <summary>
        /// A ivec4 containing the wwzy components of this vector
        /// </summary>
        public readonly ivec4 wwzy => new ivec4(w, w, z, y);
        /// <summary>
        /// A ivec4 containing the xxwy components of this vector
        /// </summary>
        public readonly ivec4 xxwy => new ivec4(x, x, w, y);
        /// <summary>
        /// A ivec4 containing the yxwy components of this vector
        /// </summary>
        public readonly ivec4 yxwy => new ivec4(y, x, w, y);
        /// <summary>
        /// A ivec4 containing the zxwy components of this vector
        /// </summary>
        public ivec4 zxwy {
            readonly get => new ivec4(z, x, w, y);
            set {
                z = value.x;
                x = value.y;
                w = value.z;
                y = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the wxwy components of this vector
        /// </summary>
        public readonly ivec4 wxwy => new ivec4(w, x, w, y);
        /// <summary>
        /// A ivec4 containing the xywy components of this vector
        /// </summary>
        public readonly ivec4 xywy => new ivec4(x, y, w, y);
        /// <summary>
        /// A ivec4 containing the yywy components of this vector
        /// </summary>
        public readonly ivec4 yywy => new ivec4(y, y, w, y);
        /// <summary>
        /// A ivec4 containing the zywy components of this vector
        /// </summary>
        public readonly ivec4 zywy => new ivec4(z, y, w, y);
        /// <summary>
        /// A ivec4 containing the wywy components of this vector
        /// </summary>
        public readonly ivec4 wywy => new ivec4(w, y, w, y);
        /// <summary>
        /// A ivec4 containing the xzwy components of this vector
        /// </summary>
        public ivec4 xzwy {
            readonly get => new ivec4(x, z, w, y);
            set {
                x = value.x;
                z = value.y;
                w = value.z;
                y = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the yzwy components of this vector
        /// </summary>
        public readonly ivec4 yzwy => new ivec4(y, z, w, y);
        /// <summary>
        /// A ivec4 containing the zzwy components of this vector
        /// </summary>
        public readonly ivec4 zzwy => new ivec4(z, z, w, y);
        /// <summary>
        /// A ivec4 containing the wzwy components of this vector
        /// </summary>
        public readonly ivec4 wzwy => new ivec4(w, z, w, y);
        /// <summary>
        /// A ivec4 containing the xwwy components of this vector
        /// </summary>
        public readonly ivec4 xwwy => new ivec4(x, w, w, y);
        /// <summary>
        /// A ivec4 containing the ywwy components of this vector
        /// </summary>
        public readonly ivec4 ywwy => new ivec4(y, w, w, y);
        /// <summary>
        /// A ivec4 containing the zwwy components of this vector
        /// </summary>
        public readonly ivec4 zwwy => new ivec4(z, w, w, y);
        /// <summary>
        /// A ivec4 containing the wwwy components of this vector
        /// </summary>
        public readonly ivec4 wwwy => new ivec4(w, w, w, y);
        /// <summary>
        /// A ivec4 containing the xxxz components of this vector
        /// </summary>
        public readonly ivec4 xxxz => new ivec4(x, x, x, z);
        /// <summary>
        /// A ivec4 containing the yxxz components of this vector
        /// </summary>
        public readonly ivec4 yxxz => new ivec4(y, x, x, z);
        /// <summary>
        /// A ivec4 containing the zxxz components of this vector
        /// </summary>
        public readonly ivec4 zxxz => new ivec4(z, x, x, z);
        /// <summary>
        /// A ivec4 containing the wxxz components of this vector
        /// </summary>
        public readonly ivec4 wxxz => new ivec4(w, x, x, z);
        /// <summary>
        /// A ivec4 containing the xyxz components of this vector
        /// </summary>
        public readonly ivec4 xyxz => new ivec4(x, y, x, z);
        /// <summary>
        /// A ivec4 containing the yyxz components of this vector
        /// </summary>
        public readonly ivec4 yyxz => new ivec4(y, y, x, z);
        /// <summary>
        /// A ivec4 containing the zyxz components of this vector
        /// </summary>
        public readonly ivec4 zyxz => new ivec4(z, y, x, z);
        /// <summary>
        /// A ivec4 containing the wyxz components of this vector
        /// </summary>
        public ivec4 wyxz {
            readonly get => new ivec4(w, y, x, z);
            set {
                w = value.x;
                y = value.y;
                x = value.z;
                z = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the xzxz components of this vector
        /// </summary>
        public readonly ivec4 xzxz => new ivec4(x, z, x, z);
        /// <summary>
        /// A ivec4 containing the yzxz components of this vector
        /// </summary>
        public readonly ivec4 yzxz => new ivec4(y, z, x, z);
        /// <summary>
        /// A ivec4 containing the zzxz components of this vector
        /// </summary>
        public readonly ivec4 zzxz => new ivec4(z, z, x, z);
        /// <summary>
        /// A ivec4 containing the wzxz components of this vector
        /// </summary>
        public readonly ivec4 wzxz => new ivec4(w, z, x, z);
        /// <summary>
        /// A ivec4 containing the xwxz components of this vector
        /// </summary>
        public readonly ivec4 xwxz => new ivec4(x, w, x, z);
        /// <summary>
        /// A ivec4 containing the ywxz components of this vector
        /// </summary>
        public ivec4 ywxz {
            readonly get => new ivec4(y, w, x, z);
            set {
                y = value.x;
                w = value.y;
                x = value.z;
                z = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the zwxz components of this vector
        /// </summary>
        public readonly ivec4 zwxz => new ivec4(z, w, x, z);
        /// <summary>
        /// A ivec4 containing the wwxz components of this vector
        /// </summary>
        public readonly ivec4 wwxz => new ivec4(w, w, x, z);
        /// <summary>
        /// A ivec4 containing the xxyz components of this vector
        /// </summary>
        public readonly ivec4 xxyz => new ivec4(x, x, y, z);
        /// <summary>
        /// A ivec4 containing the yxyz components of this vector
        /// </summary>
        public readonly ivec4 yxyz => new ivec4(y, x, y, z);
        /// <summary>
        /// A ivec4 containing the zxyz components of this vector
        /// </summary>
        public readonly ivec4 zxyz => new ivec4(z, x, y, z);
        /// <summary>
        /// A ivec4 containing the wxyz components of this vector
        /// </summary>
        public ivec4 wxyz {
            readonly get => new ivec4(w, x, y, z);
            set {
                w = value.x;
                x = value.y;
                y = value.z;
                z = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the xyyz components of this vector
        /// </summary>
        public readonly ivec4 xyyz => new ivec4(x, y, y, z);
        /// <summary>
        /// A ivec4 containing the yyyz components of this vector
        /// </summary>
        public readonly ivec4 yyyz => new ivec4(y, y, y, z);
        /// <summary>
        /// A ivec4 containing the zyyz components of this vector
        /// </summary>
        public readonly ivec4 zyyz => new ivec4(z, y, y, z);
        /// <summary>
        /// A ivec4 containing the wyyz components of this vector
        /// </summary>
        public readonly ivec4 wyyz => new ivec4(w, y, y, z);
        /// <summary>
        /// A ivec4 containing the xzyz components of this vector
        /// </summary>
        public readonly ivec4 xzyz => new ivec4(x, z, y, z);
        /// <summary>
        /// A ivec4 containing the yzyz components of this vector
        /// </summary>
        public readonly ivec4 yzyz => new ivec4(y, z, y, z);
        /// <summary>
        /// A ivec4 containing the zzyz components of this vector
        /// </summary>
        public readonly ivec4 zzyz => new ivec4(z, z, y, z);
        /// <summary>
        /// A ivec4 containing the wzyz components of this vector
        /// </summary>
        public readonly ivec4 wzyz => new ivec4(w, z, y, z);
        /// <summary>
        /// A ivec4 containing the xwyz components of this vector
        /// </summary>
        public ivec4 xwyz {
            readonly get => new ivec4(x, w, y, z);
            set {
                x = value.x;
                w = value.y;
                y = value.z;
                z = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the ywyz components of this vector
        /// </summary>
        public readonly ivec4 ywyz => new ivec4(y, w, y, z);
        /// <summary>
        /// A ivec4 containing the zwyz components of this vector
        /// </summary>
        public readonly ivec4 zwyz => new ivec4(z, w, y, z);
        /// <summary>
        /// A ivec4 containing the wwyz components of this vector
        /// </summary>
        public readonly ivec4 wwyz => new ivec4(w, w, y, z);
        /// <summary>
        /// A ivec4 containing the xxzz components of this vector
        /// </summary>
        public readonly ivec4 xxzz => new ivec4(x, x, z, z);
        /// <summary>
        /// A ivec4 containing the yxzz components of this vector
        /// </summary>
        public readonly ivec4 yxzz => new ivec4(y, x, z, z);
        /// <summary>
        /// A ivec4 containing the zxzz components of this vector
        /// </summary>
        public readonly ivec4 zxzz => new ivec4(z, x, z, z);
        /// <summary>
        /// A ivec4 containing the wxzz components of this vector
        /// </summary>
        public readonly ivec4 wxzz => new ivec4(w, x, z, z);
        /// <summary>
        /// A ivec4 containing the xyzz components of this vector
        /// </summary>
        public readonly ivec4 xyzz => new ivec4(x, y, z, z);
        /// <summary>
        /// A ivec4 containing the yyzz components of this vector
        /// </summary>
        public readonly ivec4 yyzz => new ivec4(y, y, z, z);
        /// <summary>
        /// A ivec4 containing the zyzz components of this vector
        /// </summary>
        public readonly ivec4 zyzz => new ivec4(z, y, z, z);
        /// <summary>
        /// A ivec4 containing the wyzz components of this vector
        /// </summary>
        public readonly ivec4 wyzz => new ivec4(w, y, z, z);
        /// <summary>
        /// A ivec4 containing the xzzz components of this vector
        /// </summary>
        public readonly ivec4 xzzz => new ivec4(x, z, z, z);
        /// <summary>
        /// A ivec4 containing the yzzz components of this vector
        /// </summary>
        public readonly ivec4 yzzz => new ivec4(y, z, z, z);
        /// <summary>
        /// A ivec4 containing the zzzz components of this vector
        /// </summary>
        public readonly ivec4 zzzz => new ivec4(z, z, z, z);
        /// <summary>
        /// A ivec4 containing the wzzz components of this vector
        /// </summary>
        public readonly ivec4 wzzz => new ivec4(w, z, z, z);
        /// <summary>
        /// A ivec4 containing the xwzz components of this vector
        /// </summary>
        public readonly ivec4 xwzz => new ivec4(x, w, z, z);
        /// <summary>
        /// A ivec4 containing the ywzz components of this vector
        /// </summary>
        public readonly ivec4 ywzz => new ivec4(y, w, z, z);
        /// <summary>
        /// A ivec4 containing the zwzz components of this vector
        /// </summary>
        public readonly ivec4 zwzz => new ivec4(z, w, z, z);
        /// <summary>
        /// A ivec4 containing the wwzz components of this vector
        /// </summary>
        public readonly ivec4 wwzz => new ivec4(w, w, z, z);
        /// <summary>
        /// A ivec4 containing the xxwz components of this vector
        /// </summary>
        public readonly ivec4 xxwz => new ivec4(x, x, w, z);
        /// <summary>
        /// A ivec4 containing the yxwz components of this vector
        /// </summary>
        public ivec4 yxwz {
            readonly get => new ivec4(y, x, w, z);
            set {
                y = value.x;
                x = value.y;
                w = value.z;
                z = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the zxwz components of this vector
        /// </summary>
        public readonly ivec4 zxwz => new ivec4(z, x, w, z);
        /// <summary>
        /// A ivec4 containing the wxwz components of this vector
        /// </summary>
        public readonly ivec4 wxwz => new ivec4(w, x, w, z);
        /// <summary>
        /// A ivec4 containing the xywz components of this vector
        /// </summary>
        public ivec4 xywz {
            readonly get => new ivec4(x, y, w, z);
            set {
                x = value.x;
                y = value.y;
                w = value.z;
                z = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the yywz components of this vector
        /// </summary>
        public readonly ivec4 yywz => new ivec4(y, y, w, z);
        /// <summary>
        /// A ivec4 containing the zywz components of this vector
        /// </summary>
        public readonly ivec4 zywz => new ivec4(z, y, w, z);
        /// <summary>
        /// A ivec4 containing the wywz components of this vector
        /// </summary>
        public readonly ivec4 wywz => new ivec4(w, y, w, z);
        /// <summary>
        /// A ivec4 containing the xzwz components of this vector
        /// </summary>
        public readonly ivec4 xzwz => new ivec4(x, z, w, z);
        /// <summary>
        /// A ivec4 containing the yzwz components of this vector
        /// </summary>
        public readonly ivec4 yzwz => new ivec4(y, z, w, z);
        /// <summary>
        /// A ivec4 containing the zzwz components of this vector
        /// </summary>
        public readonly ivec4 zzwz => new ivec4(z, z, w, z);
        /// <summary>
        /// A ivec4 containing the wzwz components of this vector
        /// </summary>
        public readonly ivec4 wzwz => new ivec4(w, z, w, z);
        /// <summary>
        /// A ivec4 containing the xwwz components of this vector
        /// </summary>
        public readonly ivec4 xwwz => new ivec4(x, w, w, z);
        /// <summary>
        /// A ivec4 containing the ywwz components of this vector
        /// </summary>
        public readonly ivec4 ywwz => new ivec4(y, w, w, z);
        /// <summary>
        /// A ivec4 containing the zwwz components of this vector
        /// </summary>
        public readonly ivec4 zwwz => new ivec4(z, w, w, z);
        /// <summary>
        /// A ivec4 containing the wwwz components of this vector
        /// </summary>
        public readonly ivec4 wwwz => new ivec4(w, w, w, z);
        /// <summary>
        /// A ivec4 containing the xxxw components of this vector
        /// </summary>
        public readonly ivec4 xxxw => new ivec4(x, x, x, w);
        /// <summary>
        /// A ivec4 containing the yxxw components of this vector
        /// </summary>
        public readonly ivec4 yxxw => new ivec4(y, x, x, w);
        /// <summary>
        /// A ivec4 containing the zxxw components of this vector
        /// </summary>
        public readonly ivec4 zxxw => new ivec4(z, x, x, w);
        /// <summary>
        /// A ivec4 containing the wxxw components of this vector
        /// </summary>
        public readonly ivec4 wxxw => new ivec4(w, x, x, w);
        /// <summary>
        /// A ivec4 containing the xyxw components of this vector
        /// </summary>
        public readonly ivec4 xyxw => new ivec4(x, y, x, w);
        /// <summary>
        /// A ivec4 containing the yyxw components of this vector
        /// </summary>
        public readonly ivec4 yyxw => new ivec4(y, y, x, w);
        /// <summary>
        /// A ivec4 containing the zyxw components of this vector
        /// </summary>
        public ivec4 zyxw {
            readonly get => new ivec4(z, y, x, w);
            set {
                z = value.x;
                y = value.y;
                x = value.z;
                w = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the wyxw components of this vector
        /// </summary>
        public readonly ivec4 wyxw => new ivec4(w, y, x, w);
        /// <summary>
        /// A ivec4 containing the xzxw components of this vector
        /// </summary>
        public readonly ivec4 xzxw => new ivec4(x, z, x, w);
        /// <summary>
        /// A ivec4 containing the yzxw components of this vector
        /// </summary>
        public ivec4 yzxw {
            readonly get => new ivec4(y, z, x, w);
            set {
                y = value.x;
                z = value.y;
                x = value.z;
                w = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the zzxw components of this vector
        /// </summary>
        public readonly ivec4 zzxw => new ivec4(z, z, x, w);
        /// <summary>
        /// A ivec4 containing the wzxw components of this vector
        /// </summary>
        public readonly ivec4 wzxw => new ivec4(w, z, x, w);
        /// <summary>
        /// A ivec4 containing the xwxw components of this vector
        /// </summary>
        public readonly ivec4 xwxw => new ivec4(x, w, x, w);
        /// <summary>
        /// A ivec4 containing the ywxw components of this vector
        /// </summary>
        public readonly ivec4 ywxw => new ivec4(y, w, x, w);
        /// <summary>
        /// A ivec4 containing the zwxw components of this vector
        /// </summary>
        public readonly ivec4 zwxw => new ivec4(z, w, x, w);
        /// <summary>
        /// A ivec4 containing the wwxw components of this vector
        /// </summary>
        public readonly ivec4 wwxw => new ivec4(w, w, x, w);
        /// <summary>
        /// A ivec4 containing the xxyw components of this vector
        /// </summary>
        public readonly ivec4 xxyw => new ivec4(x, x, y, w);
        /// <summary>
        /// A ivec4 containing the yxyw components of this vector
        /// </summary>
        public readonly ivec4 yxyw => new ivec4(y, x, y, w);
        /// <summary>
        /// A ivec4 containing the zxyw components of this vector
        /// </summary>
        public ivec4 zxyw {
            readonly get => new ivec4(z, x, y, w);
            set {
                z = value.x;
                x = value.y;
                y = value.z;
                w = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the wxyw components of this vector
        /// </summary>
        public readonly ivec4 wxyw => new ivec4(w, x, y, w);
        /// <summary>
        /// A ivec4 containing the xyyw components of this vector
        /// </summary>
        public readonly ivec4 xyyw => new ivec4(x, y, y, w);
        /// <summary>
        /// A ivec4 containing the yyyw components of this vector
        /// </summary>
        public readonly ivec4 yyyw => new ivec4(y, y, y, w);
        /// <summary>
        /// A ivec4 containing the zyyw components of this vector
        /// </summary>
        public readonly ivec4 zyyw => new ivec4(z, y, y, w);
        /// <summary>
        /// A ivec4 containing the wyyw components of this vector
        /// </summary>
        public readonly ivec4 wyyw => new ivec4(w, y, y, w);
        /// <summary>
        /// A ivec4 containing the xzyw components of this vector
        /// </summary>
        public ivec4 xzyw {
            readonly get => new ivec4(x, z, y, w);
            set {
                x = value.x;
                z = value.y;
                y = value.z;
                w = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the yzyw components of this vector
        /// </summary>
        public readonly ivec4 yzyw => new ivec4(y, z, y, w);
        /// <summary>
        /// A ivec4 containing the zzyw components of this vector
        /// </summary>
        public readonly ivec4 zzyw => new ivec4(z, z, y, w);
        /// <summary>
        /// A ivec4 containing the wzyw components of this vector
        /// </summary>
        public readonly ivec4 wzyw => new ivec4(w, z, y, w);
        /// <summary>
        /// A ivec4 containing the xwyw components of this vector
        /// </summary>
        public readonly ivec4 xwyw => new ivec4(x, w, y, w);
        /// <summary>
        /// A ivec4 containing the ywyw components of this vector
        /// </summary>
        public readonly ivec4 ywyw => new ivec4(y, w, y, w);
        /// <summary>
        /// A ivec4 containing the zwyw components of this vector
        /// </summary>
        public readonly ivec4 zwyw => new ivec4(z, w, y, w);
        /// <summary>
        /// A ivec4 containing the wwyw components of this vector
        /// </summary>
        public readonly ivec4 wwyw => new ivec4(w, w, y, w);
        /// <summary>
        /// A ivec4 containing the xxzw components of this vector
        /// </summary>
        public readonly ivec4 xxzw => new ivec4(x, x, z, w);
        /// <summary>
        /// A ivec4 containing the yxzw components of this vector
        /// </summary>
        public ivec4 yxzw {
            readonly get => new ivec4(y, x, z, w);
            set {
                y = value.x;
                x = value.y;
                z = value.z;
                w = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the zxzw components of this vector
        /// </summary>
        public readonly ivec4 zxzw => new ivec4(z, x, z, w);
        /// <summary>
        /// A ivec4 containing the wxzw components of this vector
        /// </summary>
        public readonly ivec4 wxzw => new ivec4(w, x, z, w);
        /// <summary>
        /// A ivec4 containing the xyzw components of this vector
        /// </summary>
        public ivec4 xyzw {
            readonly get => new ivec4(x, y, z, w);
            set {
                x = value.x;
                y = value.y;
                z = value.z;
                w = value.w;
            }
        }
        /// <summary>
        /// A ivec4 containing the yyzw components of this vector
        /// </summary>
        public readonly ivec4 yyzw => new ivec4(y, y, z, w);
        /// <summary>
        /// A ivec4 containing the zyzw components of this vector
        /// </summary>
        public readonly ivec4 zyzw => new ivec4(z, y, z, w);
        /// <summary>
        /// A ivec4 containing the wyzw components of this vector
        /// </summary>
        public readonly ivec4 wyzw => new ivec4(w, y, z, w);
        /// <summary>
        /// A ivec4 containing the xzzw components of this vector
        /// </summary>
        public readonly ivec4 xzzw => new ivec4(x, z, z, w);
        /// <summary>
        /// A ivec4 containing the yzzw components of this vector
        /// </summary>
        public readonly ivec4 yzzw => new ivec4(y, z, z, w);
        /// <summary>
        /// A ivec4 containing the zzzw components of this vector
        /// </summary>
        public readonly ivec4 zzzw => new ivec4(z, z, z, w);
        /// <summary>
        /// A ivec4 containing the wzzw components of this vector
        /// </summary>
        public readonly ivec4 wzzw => new ivec4(w, z, z, w);
        /// <summary>
        /// A ivec4 containing the xwzw components of this vector
        /// </summary>
        public readonly ivec4 xwzw => new ivec4(x, w, z, w);
        /// <summary>
        /// A ivec4 containing the ywzw components of this vector
        /// </summary>
        public readonly ivec4 ywzw => new ivec4(y, w, z, w);
        /// <summary>
        /// A ivec4 containing the zwzw components of this vector
        /// </summary>
        public readonly ivec4 zwzw => new ivec4(z, w, z, w);
        /// <summary>
        /// A ivec4 containing the wwzw components of this vector
        /// </summary>
        public readonly ivec4 wwzw => new ivec4(w, w, z, w);
        /// <summary>
        /// A ivec4 containing the xxww components of this vector
        /// </summary>
        public readonly ivec4 xxww => new ivec4(x, x, w, w);
        /// <summary>
        /// A ivec4 containing the yxww components of this vector
        /// </summary>
        public readonly ivec4 yxww => new ivec4(y, x, w, w);
        /// <summary>
        /// A ivec4 containing the zxww components of this vector
        /// </summary>
        public readonly ivec4 zxww => new ivec4(z, x, w, w);
        /// <summary>
        /// A ivec4 containing the wxww components of this vector
        /// </summary>
        public readonly ivec4 wxww => new ivec4(w, x, w, w);
        /// <summary>
        /// A ivec4 containing the xyww components of this vector
        /// </summary>
        public readonly ivec4 xyww => new ivec4(x, y, w, w);
        /// <summary>
        /// A ivec4 containing the yyww components of this vector
        /// </summary>
        public readonly ivec4 yyww => new ivec4(y, y, w, w);
        /// <summary>
        /// A ivec4 containing the zyww components of this vector
        /// </summary>
        public readonly ivec4 zyww => new ivec4(z, y, w, w);
        /// <summary>
        /// A ivec4 containing the wyww components of this vector
        /// </summary>
        public readonly ivec4 wyww => new ivec4(w, y, w, w);
        /// <summary>
        /// A ivec4 containing the xzww components of this vector
        /// </summary>
        public readonly ivec4 xzww => new ivec4(x, z, w, w);
        /// <summary>
        /// A ivec4 containing the yzww components of this vector
        /// </summary>
        public readonly ivec4 yzww => new ivec4(y, z, w, w);
        /// <summary>
        /// A ivec4 containing the zzww components of this vector
        /// </summary>
        public readonly ivec4 zzww => new ivec4(z, z, w, w);
        /// <summary>
        /// A ivec4 containing the wzww components of this vector
        /// </summary>
        public readonly ivec4 wzww => new ivec4(w, z, w, w);
        /// <summary>
        /// A ivec4 containing the xwww components of this vector
        /// </summary>
        public readonly ivec4 xwww => new ivec4(x, w, w, w);
        /// <summary>
        /// A ivec4 containing the ywww components of this vector
        /// </summary>
        public readonly ivec4 ywww => new ivec4(y, w, w, w);
        /// <summary>
        /// A ivec4 containing the zwww components of this vector
        /// </summary>
        public readonly ivec4 zwww => new ivec4(z, w, w, w);
        /// <summary>
        /// A ivec4 containing the wwww components of this vector
        /// </summary>
        public readonly ivec4 wwww => new ivec4(w, w, w, w);
        #endregion

        #region constructors
        public ivec4(int x, int y, int z, int w) {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        public ivec4(ivec2 xy, ivec2 zw) {
            this.x = xy.x;
            this.y = xy.y;
            this.z = zw.x;
            this.w = zw.y;
        }
        public ivec4(ivec2 xy, int z, int w) {
            this.x = xy.x;
            this.y = xy.y;
            this.z = z;
            this.w = w;
        }
        public ivec4(int x, ivec2 yz, int w) {
            this.x = x;
            this.y = yz.x;
            this.z = yz.y;
            this.w = w;
        }
        public ivec4(int x, int y, ivec2 zw) {
            this.x = x;
            this.y = y;
            this.z = zw.x;
            this.w = zw.y;
        }
        public ivec4(ivec3 xyz, int w) {
            this.x = xyz.x;
            this.y = xyz.y;
            this.z = xyz.z;
            this.w = w;
        }
        public ivec4(int x, ivec3 yzw) {
            this.x = x;
            this.y = yzw.x;
            this.z = yzw.y;
            this.w = yzw.z;
        }
        #endregion

        #region arithmetic
        public readonly int dot(ivec4 v) => (this * v).sum;

        public static ivec4 operator *(ivec4 a, ivec4 b) => new ivec4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        public static ivec4 operator /(ivec4 a, ivec4 b) => new ivec4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
        public static ivec4 operator +(ivec4 a, ivec4 b) => new ivec4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        public static ivec4 operator -(ivec4 a, ivec4 b) => new ivec4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);

        public static ivec4 operator *(ivec4 a, int s) => new ivec4(a.x * s, a.y * s, a.z * s, a.w * s);
        public static ivec4 operator /(ivec4 a, int s) => new ivec4(a.x / s, a.y / s, a.z / s, a.w / s);

        public static ivec4 operator -(ivec4 v) => new ivec4(-v.x, -v.y, -v.z, -v.w);
        #endregion

        #region math
        public readonly int distTo(ivec4 o) => (o - this).length;
        public readonly int angleTo(ivec4 o) => (int)Math.Acos(this.dot(o) / (this.length * o.length));
        public readonly ivec4 reflect(ivec4 normal) => this - (normal * 2 * (this.dot(normal) / normal.dot(normal)));
        #endregion

        #region conversion/deconstructors
        public static implicit operator ivec4((int, int, int, int) tuple) => new ivec4(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
        public static implicit operator vec4(ivec4 v) => new vec4(v.x, v.y, v.z, v.w);
        public static implicit operator dvec4(ivec4 v) => new dvec4(v.x, v.y, v.z, v.w);
        public static implicit operator ivec4(int n) => new ivec4(n, n, n, n);
        public void Deconstruct(out int x, out int y, out int z, out int w) => (x, y, z, w) = (this.x, this.y, this.z, this.w);
        #endregion

        #region other
        public override string ToString() => $"({x}, {y}, {z}, {w})";
        #endregion
    }
    public static partial class math {
        /// <summary>
        /// Takes the abs of each component in the given ivec4.
        /// </summary>
        public static ivec4 abs(in ivec4 o) => new ivec4(abs(o.x), abs(o.y), abs(o.z), abs(o.w));
        /// <summary>
        /// Takes the min of each component in the given ivec4.
        /// </summary>
        public static ivec4 min(in ivec4 a, in ivec4 b) => new ivec4(min(a.x, b.x), min(a.y, b.y), min(a.z, b.z), min(a.w, b.w));
        /// <summary>
        /// Takes the max of each component in the given ivec4.
        /// </summary>
        public static ivec4 max(in ivec4 a, in ivec4 b) => new ivec4(max(a.x, b.x), max(a.y, b.y), max(a.z, b.z), max(a.w, b.w));
        /// <summary>
        /// Linear interpolation of two ivec4 by t.
        /// </summary>
        public static ivec4 lerp(in ivec4 x, in ivec4 y, int t) => x + (y - x) * t;
        /// <summary>
        /// Gets the ivec4 at location t along a curve.
        /// </summary>
        public static ivec4 bezier(in ivec4 a, in ivec4 b, in ivec4 c, int t) => a + ((b - a)*2 + (c - 2*b + a)*t)*t;
    }
}
