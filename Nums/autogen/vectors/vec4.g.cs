using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 4 component vector of float
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct vec4 : vec {

        #region constants
        /// <summary>
        /// The zero vector: A vector where all components are equal to zero.
        /// </summary>
        public static readonly vec4 zero = (0, 0, 0, 0);
        /// <summary>
        /// A unit vector pointing in the positive x direction. →
        /// </summary>
        public static readonly vec4 unitx = (1, 0, 0, 0);
        /// <summary>
        /// A unit vector pointing in the positive y direction. ↑
        /// </summary>
        public static readonly vec4 unity = (0, 1, 0, 0);
        /// <summary>
        /// A unit vector pointing in the positive z direction. ↗
        /// </summary>
        public static readonly vec4 unitz = (0, 0, 1, 0);
        /// <summary>
        /// A unit vector pointing in the positive w direction. 
        /// </summary>
        public static readonly vec4 unitw = (0, 0, 0, 1);
        /// <summary>
        /// A vector where all components are equal to one.
        /// </summary>
        public static readonly vec4 one = (1, 1, 1, 1);
        #endregion

        /// <summary>
        /// The x component is the first index of the vector
        /// </summary>
        public float x;
        /// <summary>
        /// The y component is the second index of the vector
        /// </summary>
        public float y;
        /// <summary>
        /// The z component is the third index of the vector
        /// </summary>
        public float z;
        /// <summary>
        /// The w component is the fourth index of the vector
        /// </summary>
        public float w;
        /// <summary>
        /// The sum of the vectors components. x + y + z + w
        /// </summary>
        public readonly float sum => x + y + z + w;
        /// <summary>
        /// The number of bytes the vector type uses.
        /// </summary>
        public const int bytesize = sizeof(float) * 4;
        /// <summary>
        /// The magnitude of the vector
        /// </summary>
        public readonly float length => (float)Math.Sqrt(dot(this));
        /// <summary>
        /// The squared magnitude of the vector. sqlength is faster than length since a square-root operation is not needed.
        /// </summary>
        public readonly float sqlength => dot(this);
        /// <summary>
        /// The normalized version of this vector.
        /// </summary>
        public readonly vec4 normalized() => this / length;
        /// <summary>
        /// Normalizes this vector.
        /// </summary>
        public void normalize() => this /= length;

        public float this[int i] {
            readonly get => i switch {
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
        /// <summary>
        /// A vec2 containing the xx components of this vector
        /// </summary>
        public readonly vec2 xx => new vec2(x, x);
        /// <summary>
        /// A vec2 containing the yx components of this vector
        /// </summary>
        public vec2 yx {
            readonly get => new vec2(y, x);
            set {
                y = value.x;
                x = value.y;
            }
        }
        /// <summary>
        /// A vec2 containing the zx components of this vector
        /// </summary>
        public vec2 zx {
            readonly get => new vec2(z, x);
            set {
                z = value.x;
                x = value.y;
            }
        }
        /// <summary>
        /// A vec2 containing the wx components of this vector
        /// </summary>
        public vec2 wx {
            readonly get => new vec2(w, x);
            set {
                w = value.x;
                x = value.y;
            }
        }
        /// <summary>
        /// A vec2 containing the xy components of this vector
        /// </summary>
        public vec2 xy {
            readonly get => new vec2(x, y);
            set {
                x = value.x;
                y = value.y;
            }
        }
        /// <summary>
        /// A vec2 containing the yy components of this vector
        /// </summary>
        public readonly vec2 yy => new vec2(y, y);
        /// <summary>
        /// A vec2 containing the zy components of this vector
        /// </summary>
        public vec2 zy {
            readonly get => new vec2(z, y);
            set {
                z = value.x;
                y = value.y;
            }
        }
        /// <summary>
        /// A vec2 containing the wy components of this vector
        /// </summary>
        public vec2 wy {
            readonly get => new vec2(w, y);
            set {
                w = value.x;
                y = value.y;
            }
        }
        /// <summary>
        /// A vec2 containing the xz components of this vector
        /// </summary>
        public vec2 xz {
            readonly get => new vec2(x, z);
            set {
                x = value.x;
                z = value.y;
            }
        }
        /// <summary>
        /// A vec2 containing the yz components of this vector
        /// </summary>
        public vec2 yz {
            readonly get => new vec2(y, z);
            set {
                y = value.x;
                z = value.y;
            }
        }
        /// <summary>
        /// A vec2 containing the zz components of this vector
        /// </summary>
        public readonly vec2 zz => new vec2(z, z);
        /// <summary>
        /// A vec2 containing the wz components of this vector
        /// </summary>
        public vec2 wz {
            readonly get => new vec2(w, z);
            set {
                w = value.x;
                z = value.y;
            }
        }
        /// <summary>
        /// A vec2 containing the xw components of this vector
        /// </summary>
        public vec2 xw {
            readonly get => new vec2(x, w);
            set {
                x = value.x;
                w = value.y;
            }
        }
        /// <summary>
        /// A vec2 containing the yw components of this vector
        /// </summary>
        public vec2 yw {
            readonly get => new vec2(y, w);
            set {
                y = value.x;
                w = value.y;
            }
        }
        /// <summary>
        /// A vec2 containing the zw components of this vector
        /// </summary>
        public vec2 zw {
            readonly get => new vec2(z, w);
            set {
                z = value.x;
                w = value.y;
            }
        }
        /// <summary>
        /// A vec2 containing the ww components of this vector
        /// </summary>
        public readonly vec2 ww => new vec2(w, w);
        /// <summary>
        /// A vec3 containing the xxx components of this vector
        /// </summary>
        public readonly vec3 xxx => new vec3(x, x, x);
        /// <summary>
        /// A vec3 containing the yxx components of this vector
        /// </summary>
        public readonly vec3 yxx => new vec3(y, x, x);
        /// <summary>
        /// A vec3 containing the zxx components of this vector
        /// </summary>
        public readonly vec3 zxx => new vec3(z, x, x);
        /// <summary>
        /// A vec3 containing the wxx components of this vector
        /// </summary>
        public readonly vec3 wxx => new vec3(w, x, x);
        /// <summary>
        /// A vec3 containing the xyx components of this vector
        /// </summary>
        public readonly vec3 xyx => new vec3(x, y, x);
        /// <summary>
        /// A vec3 containing the yyx components of this vector
        /// </summary>
        public readonly vec3 yyx => new vec3(y, y, x);
        /// <summary>
        /// A vec3 containing the zyx components of this vector
        /// </summary>
        public vec3 zyx {
            readonly get => new vec3(z, y, x);
            set {
                z = value.x;
                y = value.y;
                x = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the wyx components of this vector
        /// </summary>
        public vec3 wyx {
            readonly get => new vec3(w, y, x);
            set {
                w = value.x;
                y = value.y;
                x = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the xzx components of this vector
        /// </summary>
        public readonly vec3 xzx => new vec3(x, z, x);
        /// <summary>
        /// A vec3 containing the yzx components of this vector
        /// </summary>
        public vec3 yzx {
            readonly get => new vec3(y, z, x);
            set {
                y = value.x;
                z = value.y;
                x = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the zzx components of this vector
        /// </summary>
        public readonly vec3 zzx => new vec3(z, z, x);
        /// <summary>
        /// A vec3 containing the wzx components of this vector
        /// </summary>
        public vec3 wzx {
            readonly get => new vec3(w, z, x);
            set {
                w = value.x;
                z = value.y;
                x = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the xwx components of this vector
        /// </summary>
        public readonly vec3 xwx => new vec3(x, w, x);
        /// <summary>
        /// A vec3 containing the ywx components of this vector
        /// </summary>
        public vec3 ywx {
            readonly get => new vec3(y, w, x);
            set {
                y = value.x;
                w = value.y;
                x = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the zwx components of this vector
        /// </summary>
        public vec3 zwx {
            readonly get => new vec3(z, w, x);
            set {
                z = value.x;
                w = value.y;
                x = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the wwx components of this vector
        /// </summary>
        public readonly vec3 wwx => new vec3(w, w, x);
        /// <summary>
        /// A vec3 containing the xxy components of this vector
        /// </summary>
        public readonly vec3 xxy => new vec3(x, x, y);
        /// <summary>
        /// A vec3 containing the yxy components of this vector
        /// </summary>
        public readonly vec3 yxy => new vec3(y, x, y);
        /// <summary>
        /// A vec3 containing the zxy components of this vector
        /// </summary>
        public vec3 zxy {
            readonly get => new vec3(z, x, y);
            set {
                z = value.x;
                x = value.y;
                y = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the wxy components of this vector
        /// </summary>
        public vec3 wxy {
            readonly get => new vec3(w, x, y);
            set {
                w = value.x;
                x = value.y;
                y = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the xyy components of this vector
        /// </summary>
        public readonly vec3 xyy => new vec3(x, y, y);
        /// <summary>
        /// A vec3 containing the yyy components of this vector
        /// </summary>
        public readonly vec3 yyy => new vec3(y, y, y);
        /// <summary>
        /// A vec3 containing the zyy components of this vector
        /// </summary>
        public readonly vec3 zyy => new vec3(z, y, y);
        /// <summary>
        /// A vec3 containing the wyy components of this vector
        /// </summary>
        public readonly vec3 wyy => new vec3(w, y, y);
        /// <summary>
        /// A vec3 containing the xzy components of this vector
        /// </summary>
        public vec3 xzy {
            readonly get => new vec3(x, z, y);
            set {
                x = value.x;
                z = value.y;
                y = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the yzy components of this vector
        /// </summary>
        public readonly vec3 yzy => new vec3(y, z, y);
        /// <summary>
        /// A vec3 containing the zzy components of this vector
        /// </summary>
        public readonly vec3 zzy => new vec3(z, z, y);
        /// <summary>
        /// A vec3 containing the wzy components of this vector
        /// </summary>
        public vec3 wzy {
            readonly get => new vec3(w, z, y);
            set {
                w = value.x;
                z = value.y;
                y = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the xwy components of this vector
        /// </summary>
        public vec3 xwy {
            readonly get => new vec3(x, w, y);
            set {
                x = value.x;
                w = value.y;
                y = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the ywy components of this vector
        /// </summary>
        public readonly vec3 ywy => new vec3(y, w, y);
        /// <summary>
        /// A vec3 containing the zwy components of this vector
        /// </summary>
        public vec3 zwy {
            readonly get => new vec3(z, w, y);
            set {
                z = value.x;
                w = value.y;
                y = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the wwy components of this vector
        /// </summary>
        public readonly vec3 wwy => new vec3(w, w, y);
        /// <summary>
        /// A vec3 containing the xxz components of this vector
        /// </summary>
        public readonly vec3 xxz => new vec3(x, x, z);
        /// <summary>
        /// A vec3 containing the yxz components of this vector
        /// </summary>
        public vec3 yxz {
            readonly get => new vec3(y, x, z);
            set {
                y = value.x;
                x = value.y;
                z = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the zxz components of this vector
        /// </summary>
        public readonly vec3 zxz => new vec3(z, x, z);
        /// <summary>
        /// A vec3 containing the wxz components of this vector
        /// </summary>
        public vec3 wxz {
            readonly get => new vec3(w, x, z);
            set {
                w = value.x;
                x = value.y;
                z = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the xyz components of this vector
        /// </summary>
        public vec3 xyz {
            readonly get => new vec3(x, y, z);
            set {
                x = value.x;
                y = value.y;
                z = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the yyz components of this vector
        /// </summary>
        public readonly vec3 yyz => new vec3(y, y, z);
        /// <summary>
        /// A vec3 containing the zyz components of this vector
        /// </summary>
        public readonly vec3 zyz => new vec3(z, y, z);
        /// <summary>
        /// A vec3 containing the wyz components of this vector
        /// </summary>
        public vec3 wyz {
            readonly get => new vec3(w, y, z);
            set {
                w = value.x;
                y = value.y;
                z = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the xzz components of this vector
        /// </summary>
        public readonly vec3 xzz => new vec3(x, z, z);
        /// <summary>
        /// A vec3 containing the yzz components of this vector
        /// </summary>
        public readonly vec3 yzz => new vec3(y, z, z);
        /// <summary>
        /// A vec3 containing the zzz components of this vector
        /// </summary>
        public readonly vec3 zzz => new vec3(z, z, z);
        /// <summary>
        /// A vec3 containing the wzz components of this vector
        /// </summary>
        public readonly vec3 wzz => new vec3(w, z, z);
        /// <summary>
        /// A vec3 containing the xwz components of this vector
        /// </summary>
        public vec3 xwz {
            readonly get => new vec3(x, w, z);
            set {
                x = value.x;
                w = value.y;
                z = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the ywz components of this vector
        /// </summary>
        public vec3 ywz {
            readonly get => new vec3(y, w, z);
            set {
                y = value.x;
                w = value.y;
                z = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the zwz components of this vector
        /// </summary>
        public readonly vec3 zwz => new vec3(z, w, z);
        /// <summary>
        /// A vec3 containing the wwz components of this vector
        /// </summary>
        public readonly vec3 wwz => new vec3(w, w, z);
        /// <summary>
        /// A vec3 containing the xxw components of this vector
        /// </summary>
        public readonly vec3 xxw => new vec3(x, x, w);
        /// <summary>
        /// A vec3 containing the yxw components of this vector
        /// </summary>
        public vec3 yxw {
            readonly get => new vec3(y, x, w);
            set {
                y = value.x;
                x = value.y;
                w = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the zxw components of this vector
        /// </summary>
        public vec3 zxw {
            readonly get => new vec3(z, x, w);
            set {
                z = value.x;
                x = value.y;
                w = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the wxw components of this vector
        /// </summary>
        public readonly vec3 wxw => new vec3(w, x, w);
        /// <summary>
        /// A vec3 containing the xyw components of this vector
        /// </summary>
        public vec3 xyw {
            readonly get => new vec3(x, y, w);
            set {
                x = value.x;
                y = value.y;
                w = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the yyw components of this vector
        /// </summary>
        public readonly vec3 yyw => new vec3(y, y, w);
        /// <summary>
        /// A vec3 containing the zyw components of this vector
        /// </summary>
        public vec3 zyw {
            readonly get => new vec3(z, y, w);
            set {
                z = value.x;
                y = value.y;
                w = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the wyw components of this vector
        /// </summary>
        public readonly vec3 wyw => new vec3(w, y, w);
        /// <summary>
        /// A vec3 containing the xzw components of this vector
        /// </summary>
        public vec3 xzw {
            readonly get => new vec3(x, z, w);
            set {
                x = value.x;
                z = value.y;
                w = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the yzw components of this vector
        /// </summary>
        public vec3 yzw {
            readonly get => new vec3(y, z, w);
            set {
                y = value.x;
                z = value.y;
                w = value.z;
            }
        }
        /// <summary>
        /// A vec3 containing the zzw components of this vector
        /// </summary>
        public readonly vec3 zzw => new vec3(z, z, w);
        /// <summary>
        /// A vec3 containing the wzw components of this vector
        /// </summary>
        public readonly vec3 wzw => new vec3(w, z, w);
        /// <summary>
        /// A vec3 containing the xww components of this vector
        /// </summary>
        public readonly vec3 xww => new vec3(x, w, w);
        /// <summary>
        /// A vec3 containing the yww components of this vector
        /// </summary>
        public readonly vec3 yww => new vec3(y, w, w);
        /// <summary>
        /// A vec3 containing the zww components of this vector
        /// </summary>
        public readonly vec3 zww => new vec3(z, w, w);
        /// <summary>
        /// A vec3 containing the www components of this vector
        /// </summary>
        public readonly vec3 www => new vec3(w, w, w);
        /// <summary>
        /// A vec4 containing the xxxx components of this vector
        /// </summary>
        public readonly vec4 xxxx => new vec4(x, x, x, x);
        /// <summary>
        /// A vec4 containing the yxxx components of this vector
        /// </summary>
        public readonly vec4 yxxx => new vec4(y, x, x, x);
        /// <summary>
        /// A vec4 containing the zxxx components of this vector
        /// </summary>
        public readonly vec4 zxxx => new vec4(z, x, x, x);
        /// <summary>
        /// A vec4 containing the wxxx components of this vector
        /// </summary>
        public readonly vec4 wxxx => new vec4(w, x, x, x);
        /// <summary>
        /// A vec4 containing the xyxx components of this vector
        /// </summary>
        public readonly vec4 xyxx => new vec4(x, y, x, x);
        /// <summary>
        /// A vec4 containing the yyxx components of this vector
        /// </summary>
        public readonly vec4 yyxx => new vec4(y, y, x, x);
        /// <summary>
        /// A vec4 containing the zyxx components of this vector
        /// </summary>
        public readonly vec4 zyxx => new vec4(z, y, x, x);
        /// <summary>
        /// A vec4 containing the wyxx components of this vector
        /// </summary>
        public readonly vec4 wyxx => new vec4(w, y, x, x);
        /// <summary>
        /// A vec4 containing the xzxx components of this vector
        /// </summary>
        public readonly vec4 xzxx => new vec4(x, z, x, x);
        /// <summary>
        /// A vec4 containing the yzxx components of this vector
        /// </summary>
        public readonly vec4 yzxx => new vec4(y, z, x, x);
        /// <summary>
        /// A vec4 containing the zzxx components of this vector
        /// </summary>
        public readonly vec4 zzxx => new vec4(z, z, x, x);
        /// <summary>
        /// A vec4 containing the wzxx components of this vector
        /// </summary>
        public readonly vec4 wzxx => new vec4(w, z, x, x);
        /// <summary>
        /// A vec4 containing the xwxx components of this vector
        /// </summary>
        public readonly vec4 xwxx => new vec4(x, w, x, x);
        /// <summary>
        /// A vec4 containing the ywxx components of this vector
        /// </summary>
        public readonly vec4 ywxx => new vec4(y, w, x, x);
        /// <summary>
        /// A vec4 containing the zwxx components of this vector
        /// </summary>
        public readonly vec4 zwxx => new vec4(z, w, x, x);
        /// <summary>
        /// A vec4 containing the wwxx components of this vector
        /// </summary>
        public readonly vec4 wwxx => new vec4(w, w, x, x);
        /// <summary>
        /// A vec4 containing the xxyx components of this vector
        /// </summary>
        public readonly vec4 xxyx => new vec4(x, x, y, x);
        /// <summary>
        /// A vec4 containing the yxyx components of this vector
        /// </summary>
        public readonly vec4 yxyx => new vec4(y, x, y, x);
        /// <summary>
        /// A vec4 containing the zxyx components of this vector
        /// </summary>
        public readonly vec4 zxyx => new vec4(z, x, y, x);
        /// <summary>
        /// A vec4 containing the wxyx components of this vector
        /// </summary>
        public readonly vec4 wxyx => new vec4(w, x, y, x);
        /// <summary>
        /// A vec4 containing the xyyx components of this vector
        /// </summary>
        public readonly vec4 xyyx => new vec4(x, y, y, x);
        /// <summary>
        /// A vec4 containing the yyyx components of this vector
        /// </summary>
        public readonly vec4 yyyx => new vec4(y, y, y, x);
        /// <summary>
        /// A vec4 containing the zyyx components of this vector
        /// </summary>
        public readonly vec4 zyyx => new vec4(z, y, y, x);
        /// <summary>
        /// A vec4 containing the wyyx components of this vector
        /// </summary>
        public readonly vec4 wyyx => new vec4(w, y, y, x);
        /// <summary>
        /// A vec4 containing the xzyx components of this vector
        /// </summary>
        public readonly vec4 xzyx => new vec4(x, z, y, x);
        /// <summary>
        /// A vec4 containing the yzyx components of this vector
        /// </summary>
        public readonly vec4 yzyx => new vec4(y, z, y, x);
        /// <summary>
        /// A vec4 containing the zzyx components of this vector
        /// </summary>
        public readonly vec4 zzyx => new vec4(z, z, y, x);
        /// <summary>
        /// A vec4 containing the wzyx components of this vector
        /// </summary>
        public vec4 wzyx {
            readonly get => new vec4(w, z, y, x);
            set {
                w = value.x;
                z = value.y;
                y = value.z;
                x = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the xwyx components of this vector
        /// </summary>
        public readonly vec4 xwyx => new vec4(x, w, y, x);
        /// <summary>
        /// A vec4 containing the ywyx components of this vector
        /// </summary>
        public readonly vec4 ywyx => new vec4(y, w, y, x);
        /// <summary>
        /// A vec4 containing the zwyx components of this vector
        /// </summary>
        public vec4 zwyx {
            readonly get => new vec4(z, w, y, x);
            set {
                z = value.x;
                w = value.y;
                y = value.z;
                x = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the wwyx components of this vector
        /// </summary>
        public readonly vec4 wwyx => new vec4(w, w, y, x);
        /// <summary>
        /// A vec4 containing the xxzx components of this vector
        /// </summary>
        public readonly vec4 xxzx => new vec4(x, x, z, x);
        /// <summary>
        /// A vec4 containing the yxzx components of this vector
        /// </summary>
        public readonly vec4 yxzx => new vec4(y, x, z, x);
        /// <summary>
        /// A vec4 containing the zxzx components of this vector
        /// </summary>
        public readonly vec4 zxzx => new vec4(z, x, z, x);
        /// <summary>
        /// A vec4 containing the wxzx components of this vector
        /// </summary>
        public readonly vec4 wxzx => new vec4(w, x, z, x);
        /// <summary>
        /// A vec4 containing the xyzx components of this vector
        /// </summary>
        public readonly vec4 xyzx => new vec4(x, y, z, x);
        /// <summary>
        /// A vec4 containing the yyzx components of this vector
        /// </summary>
        public readonly vec4 yyzx => new vec4(y, y, z, x);
        /// <summary>
        /// A vec4 containing the zyzx components of this vector
        /// </summary>
        public readonly vec4 zyzx => new vec4(z, y, z, x);
        /// <summary>
        /// A vec4 containing the wyzx components of this vector
        /// </summary>
        public vec4 wyzx {
            readonly get => new vec4(w, y, z, x);
            set {
                w = value.x;
                y = value.y;
                z = value.z;
                x = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the xzzx components of this vector
        /// </summary>
        public readonly vec4 xzzx => new vec4(x, z, z, x);
        /// <summary>
        /// A vec4 containing the yzzx components of this vector
        /// </summary>
        public readonly vec4 yzzx => new vec4(y, z, z, x);
        /// <summary>
        /// A vec4 containing the zzzx components of this vector
        /// </summary>
        public readonly vec4 zzzx => new vec4(z, z, z, x);
        /// <summary>
        /// A vec4 containing the wzzx components of this vector
        /// </summary>
        public readonly vec4 wzzx => new vec4(w, z, z, x);
        /// <summary>
        /// A vec4 containing the xwzx components of this vector
        /// </summary>
        public readonly vec4 xwzx => new vec4(x, w, z, x);
        /// <summary>
        /// A vec4 containing the ywzx components of this vector
        /// </summary>
        public vec4 ywzx {
            readonly get => new vec4(y, w, z, x);
            set {
                y = value.x;
                w = value.y;
                z = value.z;
                x = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the zwzx components of this vector
        /// </summary>
        public readonly vec4 zwzx => new vec4(z, w, z, x);
        /// <summary>
        /// A vec4 containing the wwzx components of this vector
        /// </summary>
        public readonly vec4 wwzx => new vec4(w, w, z, x);
        /// <summary>
        /// A vec4 containing the xxwx components of this vector
        /// </summary>
        public readonly vec4 xxwx => new vec4(x, x, w, x);
        /// <summary>
        /// A vec4 containing the yxwx components of this vector
        /// </summary>
        public readonly vec4 yxwx => new vec4(y, x, w, x);
        /// <summary>
        /// A vec4 containing the zxwx components of this vector
        /// </summary>
        public readonly vec4 zxwx => new vec4(z, x, w, x);
        /// <summary>
        /// A vec4 containing the wxwx components of this vector
        /// </summary>
        public readonly vec4 wxwx => new vec4(w, x, w, x);
        /// <summary>
        /// A vec4 containing the xywx components of this vector
        /// </summary>
        public readonly vec4 xywx => new vec4(x, y, w, x);
        /// <summary>
        /// A vec4 containing the yywx components of this vector
        /// </summary>
        public readonly vec4 yywx => new vec4(y, y, w, x);
        /// <summary>
        /// A vec4 containing the zywx components of this vector
        /// </summary>
        public vec4 zywx {
            readonly get => new vec4(z, y, w, x);
            set {
                z = value.x;
                y = value.y;
                w = value.z;
                x = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the wywx components of this vector
        /// </summary>
        public readonly vec4 wywx => new vec4(w, y, w, x);
        /// <summary>
        /// A vec4 containing the xzwx components of this vector
        /// </summary>
        public readonly vec4 xzwx => new vec4(x, z, w, x);
        /// <summary>
        /// A vec4 containing the yzwx components of this vector
        /// </summary>
        public vec4 yzwx {
            readonly get => new vec4(y, z, w, x);
            set {
                y = value.x;
                z = value.y;
                w = value.z;
                x = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the zzwx components of this vector
        /// </summary>
        public readonly vec4 zzwx => new vec4(z, z, w, x);
        /// <summary>
        /// A vec4 containing the wzwx components of this vector
        /// </summary>
        public readonly vec4 wzwx => new vec4(w, z, w, x);
        /// <summary>
        /// A vec4 containing the xwwx components of this vector
        /// </summary>
        public readonly vec4 xwwx => new vec4(x, w, w, x);
        /// <summary>
        /// A vec4 containing the ywwx components of this vector
        /// </summary>
        public readonly vec4 ywwx => new vec4(y, w, w, x);
        /// <summary>
        /// A vec4 containing the zwwx components of this vector
        /// </summary>
        public readonly vec4 zwwx => new vec4(z, w, w, x);
        /// <summary>
        /// A vec4 containing the wwwx components of this vector
        /// </summary>
        public readonly vec4 wwwx => new vec4(w, w, w, x);
        /// <summary>
        /// A vec4 containing the xxxy components of this vector
        /// </summary>
        public readonly vec4 xxxy => new vec4(x, x, x, y);
        /// <summary>
        /// A vec4 containing the yxxy components of this vector
        /// </summary>
        public readonly vec4 yxxy => new vec4(y, x, x, y);
        /// <summary>
        /// A vec4 containing the zxxy components of this vector
        /// </summary>
        public readonly vec4 zxxy => new vec4(z, x, x, y);
        /// <summary>
        /// A vec4 containing the wxxy components of this vector
        /// </summary>
        public readonly vec4 wxxy => new vec4(w, x, x, y);
        /// <summary>
        /// A vec4 containing the xyxy components of this vector
        /// </summary>
        public readonly vec4 xyxy => new vec4(x, y, x, y);
        /// <summary>
        /// A vec4 containing the yyxy components of this vector
        /// </summary>
        public readonly vec4 yyxy => new vec4(y, y, x, y);
        /// <summary>
        /// A vec4 containing the zyxy components of this vector
        /// </summary>
        public readonly vec4 zyxy => new vec4(z, y, x, y);
        /// <summary>
        /// A vec4 containing the wyxy components of this vector
        /// </summary>
        public readonly vec4 wyxy => new vec4(w, y, x, y);
        /// <summary>
        /// A vec4 containing the xzxy components of this vector
        /// </summary>
        public readonly vec4 xzxy => new vec4(x, z, x, y);
        /// <summary>
        /// A vec4 containing the yzxy components of this vector
        /// </summary>
        public readonly vec4 yzxy => new vec4(y, z, x, y);
        /// <summary>
        /// A vec4 containing the zzxy components of this vector
        /// </summary>
        public readonly vec4 zzxy => new vec4(z, z, x, y);
        /// <summary>
        /// A vec4 containing the wzxy components of this vector
        /// </summary>
        public vec4 wzxy {
            readonly get => new vec4(w, z, x, y);
            set {
                w = value.x;
                z = value.y;
                x = value.z;
                y = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the xwxy components of this vector
        /// </summary>
        public readonly vec4 xwxy => new vec4(x, w, x, y);
        /// <summary>
        /// A vec4 containing the ywxy components of this vector
        /// </summary>
        public readonly vec4 ywxy => new vec4(y, w, x, y);
        /// <summary>
        /// A vec4 containing the zwxy components of this vector
        /// </summary>
        public vec4 zwxy {
            readonly get => new vec4(z, w, x, y);
            set {
                z = value.x;
                w = value.y;
                x = value.z;
                y = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the wwxy components of this vector
        /// </summary>
        public readonly vec4 wwxy => new vec4(w, w, x, y);
        /// <summary>
        /// A vec4 containing the xxyy components of this vector
        /// </summary>
        public readonly vec4 xxyy => new vec4(x, x, y, y);
        /// <summary>
        /// A vec4 containing the yxyy components of this vector
        /// </summary>
        public readonly vec4 yxyy => new vec4(y, x, y, y);
        /// <summary>
        /// A vec4 containing the zxyy components of this vector
        /// </summary>
        public readonly vec4 zxyy => new vec4(z, x, y, y);
        /// <summary>
        /// A vec4 containing the wxyy components of this vector
        /// </summary>
        public readonly vec4 wxyy => new vec4(w, x, y, y);
        /// <summary>
        /// A vec4 containing the xyyy components of this vector
        /// </summary>
        public readonly vec4 xyyy => new vec4(x, y, y, y);
        /// <summary>
        /// A vec4 containing the yyyy components of this vector
        /// </summary>
        public readonly vec4 yyyy => new vec4(y, y, y, y);
        /// <summary>
        /// A vec4 containing the zyyy components of this vector
        /// </summary>
        public readonly vec4 zyyy => new vec4(z, y, y, y);
        /// <summary>
        /// A vec4 containing the wyyy components of this vector
        /// </summary>
        public readonly vec4 wyyy => new vec4(w, y, y, y);
        /// <summary>
        /// A vec4 containing the xzyy components of this vector
        /// </summary>
        public readonly vec4 xzyy => new vec4(x, z, y, y);
        /// <summary>
        /// A vec4 containing the yzyy components of this vector
        /// </summary>
        public readonly vec4 yzyy => new vec4(y, z, y, y);
        /// <summary>
        /// A vec4 containing the zzyy components of this vector
        /// </summary>
        public readonly vec4 zzyy => new vec4(z, z, y, y);
        /// <summary>
        /// A vec4 containing the wzyy components of this vector
        /// </summary>
        public readonly vec4 wzyy => new vec4(w, z, y, y);
        /// <summary>
        /// A vec4 containing the xwyy components of this vector
        /// </summary>
        public readonly vec4 xwyy => new vec4(x, w, y, y);
        /// <summary>
        /// A vec4 containing the ywyy components of this vector
        /// </summary>
        public readonly vec4 ywyy => new vec4(y, w, y, y);
        /// <summary>
        /// A vec4 containing the zwyy components of this vector
        /// </summary>
        public readonly vec4 zwyy => new vec4(z, w, y, y);
        /// <summary>
        /// A vec4 containing the wwyy components of this vector
        /// </summary>
        public readonly vec4 wwyy => new vec4(w, w, y, y);
        /// <summary>
        /// A vec4 containing the xxzy components of this vector
        /// </summary>
        public readonly vec4 xxzy => new vec4(x, x, z, y);
        /// <summary>
        /// A vec4 containing the yxzy components of this vector
        /// </summary>
        public readonly vec4 yxzy => new vec4(y, x, z, y);
        /// <summary>
        /// A vec4 containing the zxzy components of this vector
        /// </summary>
        public readonly vec4 zxzy => new vec4(z, x, z, y);
        /// <summary>
        /// A vec4 containing the wxzy components of this vector
        /// </summary>
        public vec4 wxzy {
            readonly get => new vec4(w, x, z, y);
            set {
                w = value.x;
                x = value.y;
                z = value.z;
                y = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the xyzy components of this vector
        /// </summary>
        public readonly vec4 xyzy => new vec4(x, y, z, y);
        /// <summary>
        /// A vec4 containing the yyzy components of this vector
        /// </summary>
        public readonly vec4 yyzy => new vec4(y, y, z, y);
        /// <summary>
        /// A vec4 containing the zyzy components of this vector
        /// </summary>
        public readonly vec4 zyzy => new vec4(z, y, z, y);
        /// <summary>
        /// A vec4 containing the wyzy components of this vector
        /// </summary>
        public readonly vec4 wyzy => new vec4(w, y, z, y);
        /// <summary>
        /// A vec4 containing the xzzy components of this vector
        /// </summary>
        public readonly vec4 xzzy => new vec4(x, z, z, y);
        /// <summary>
        /// A vec4 containing the yzzy components of this vector
        /// </summary>
        public readonly vec4 yzzy => new vec4(y, z, z, y);
        /// <summary>
        /// A vec4 containing the zzzy components of this vector
        /// </summary>
        public readonly vec4 zzzy => new vec4(z, z, z, y);
        /// <summary>
        /// A vec4 containing the wzzy components of this vector
        /// </summary>
        public readonly vec4 wzzy => new vec4(w, z, z, y);
        /// <summary>
        /// A vec4 containing the xwzy components of this vector
        /// </summary>
        public vec4 xwzy {
            readonly get => new vec4(x, w, z, y);
            set {
                x = value.x;
                w = value.y;
                z = value.z;
                y = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the ywzy components of this vector
        /// </summary>
        public readonly vec4 ywzy => new vec4(y, w, z, y);
        /// <summary>
        /// A vec4 containing the zwzy components of this vector
        /// </summary>
        public readonly vec4 zwzy => new vec4(z, w, z, y);
        /// <summary>
        /// A vec4 containing the wwzy components of this vector
        /// </summary>
        public readonly vec4 wwzy => new vec4(w, w, z, y);
        /// <summary>
        /// A vec4 containing the xxwy components of this vector
        /// </summary>
        public readonly vec4 xxwy => new vec4(x, x, w, y);
        /// <summary>
        /// A vec4 containing the yxwy components of this vector
        /// </summary>
        public readonly vec4 yxwy => new vec4(y, x, w, y);
        /// <summary>
        /// A vec4 containing the zxwy components of this vector
        /// </summary>
        public vec4 zxwy {
            readonly get => new vec4(z, x, w, y);
            set {
                z = value.x;
                x = value.y;
                w = value.z;
                y = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the wxwy components of this vector
        /// </summary>
        public readonly vec4 wxwy => new vec4(w, x, w, y);
        /// <summary>
        /// A vec4 containing the xywy components of this vector
        /// </summary>
        public readonly vec4 xywy => new vec4(x, y, w, y);
        /// <summary>
        /// A vec4 containing the yywy components of this vector
        /// </summary>
        public readonly vec4 yywy => new vec4(y, y, w, y);
        /// <summary>
        /// A vec4 containing the zywy components of this vector
        /// </summary>
        public readonly vec4 zywy => new vec4(z, y, w, y);
        /// <summary>
        /// A vec4 containing the wywy components of this vector
        /// </summary>
        public readonly vec4 wywy => new vec4(w, y, w, y);
        /// <summary>
        /// A vec4 containing the xzwy components of this vector
        /// </summary>
        public vec4 xzwy {
            readonly get => new vec4(x, z, w, y);
            set {
                x = value.x;
                z = value.y;
                w = value.z;
                y = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the yzwy components of this vector
        /// </summary>
        public readonly vec4 yzwy => new vec4(y, z, w, y);
        /// <summary>
        /// A vec4 containing the zzwy components of this vector
        /// </summary>
        public readonly vec4 zzwy => new vec4(z, z, w, y);
        /// <summary>
        /// A vec4 containing the wzwy components of this vector
        /// </summary>
        public readonly vec4 wzwy => new vec4(w, z, w, y);
        /// <summary>
        /// A vec4 containing the xwwy components of this vector
        /// </summary>
        public readonly vec4 xwwy => new vec4(x, w, w, y);
        /// <summary>
        /// A vec4 containing the ywwy components of this vector
        /// </summary>
        public readonly vec4 ywwy => new vec4(y, w, w, y);
        /// <summary>
        /// A vec4 containing the zwwy components of this vector
        /// </summary>
        public readonly vec4 zwwy => new vec4(z, w, w, y);
        /// <summary>
        /// A vec4 containing the wwwy components of this vector
        /// </summary>
        public readonly vec4 wwwy => new vec4(w, w, w, y);
        /// <summary>
        /// A vec4 containing the xxxz components of this vector
        /// </summary>
        public readonly vec4 xxxz => new vec4(x, x, x, z);
        /// <summary>
        /// A vec4 containing the yxxz components of this vector
        /// </summary>
        public readonly vec4 yxxz => new vec4(y, x, x, z);
        /// <summary>
        /// A vec4 containing the zxxz components of this vector
        /// </summary>
        public readonly vec4 zxxz => new vec4(z, x, x, z);
        /// <summary>
        /// A vec4 containing the wxxz components of this vector
        /// </summary>
        public readonly vec4 wxxz => new vec4(w, x, x, z);
        /// <summary>
        /// A vec4 containing the xyxz components of this vector
        /// </summary>
        public readonly vec4 xyxz => new vec4(x, y, x, z);
        /// <summary>
        /// A vec4 containing the yyxz components of this vector
        /// </summary>
        public readonly vec4 yyxz => new vec4(y, y, x, z);
        /// <summary>
        /// A vec4 containing the zyxz components of this vector
        /// </summary>
        public readonly vec4 zyxz => new vec4(z, y, x, z);
        /// <summary>
        /// A vec4 containing the wyxz components of this vector
        /// </summary>
        public vec4 wyxz {
            readonly get => new vec4(w, y, x, z);
            set {
                w = value.x;
                y = value.y;
                x = value.z;
                z = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the xzxz components of this vector
        /// </summary>
        public readonly vec4 xzxz => new vec4(x, z, x, z);
        /// <summary>
        /// A vec4 containing the yzxz components of this vector
        /// </summary>
        public readonly vec4 yzxz => new vec4(y, z, x, z);
        /// <summary>
        /// A vec4 containing the zzxz components of this vector
        /// </summary>
        public readonly vec4 zzxz => new vec4(z, z, x, z);
        /// <summary>
        /// A vec4 containing the wzxz components of this vector
        /// </summary>
        public readonly vec4 wzxz => new vec4(w, z, x, z);
        /// <summary>
        /// A vec4 containing the xwxz components of this vector
        /// </summary>
        public readonly vec4 xwxz => new vec4(x, w, x, z);
        /// <summary>
        /// A vec4 containing the ywxz components of this vector
        /// </summary>
        public vec4 ywxz {
            readonly get => new vec4(y, w, x, z);
            set {
                y = value.x;
                w = value.y;
                x = value.z;
                z = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the zwxz components of this vector
        /// </summary>
        public readonly vec4 zwxz => new vec4(z, w, x, z);
        /// <summary>
        /// A vec4 containing the wwxz components of this vector
        /// </summary>
        public readonly vec4 wwxz => new vec4(w, w, x, z);
        /// <summary>
        /// A vec4 containing the xxyz components of this vector
        /// </summary>
        public readonly vec4 xxyz => new vec4(x, x, y, z);
        /// <summary>
        /// A vec4 containing the yxyz components of this vector
        /// </summary>
        public readonly vec4 yxyz => new vec4(y, x, y, z);
        /// <summary>
        /// A vec4 containing the zxyz components of this vector
        /// </summary>
        public readonly vec4 zxyz => new vec4(z, x, y, z);
        /// <summary>
        /// A vec4 containing the wxyz components of this vector
        /// </summary>
        public vec4 wxyz {
            readonly get => new vec4(w, x, y, z);
            set {
                w = value.x;
                x = value.y;
                y = value.z;
                z = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the xyyz components of this vector
        /// </summary>
        public readonly vec4 xyyz => new vec4(x, y, y, z);
        /// <summary>
        /// A vec4 containing the yyyz components of this vector
        /// </summary>
        public readonly vec4 yyyz => new vec4(y, y, y, z);
        /// <summary>
        /// A vec4 containing the zyyz components of this vector
        /// </summary>
        public readonly vec4 zyyz => new vec4(z, y, y, z);
        /// <summary>
        /// A vec4 containing the wyyz components of this vector
        /// </summary>
        public readonly vec4 wyyz => new vec4(w, y, y, z);
        /// <summary>
        /// A vec4 containing the xzyz components of this vector
        /// </summary>
        public readonly vec4 xzyz => new vec4(x, z, y, z);
        /// <summary>
        /// A vec4 containing the yzyz components of this vector
        /// </summary>
        public readonly vec4 yzyz => new vec4(y, z, y, z);
        /// <summary>
        /// A vec4 containing the zzyz components of this vector
        /// </summary>
        public readonly vec4 zzyz => new vec4(z, z, y, z);
        /// <summary>
        /// A vec4 containing the wzyz components of this vector
        /// </summary>
        public readonly vec4 wzyz => new vec4(w, z, y, z);
        /// <summary>
        /// A vec4 containing the xwyz components of this vector
        /// </summary>
        public vec4 xwyz {
            readonly get => new vec4(x, w, y, z);
            set {
                x = value.x;
                w = value.y;
                y = value.z;
                z = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the ywyz components of this vector
        /// </summary>
        public readonly vec4 ywyz => new vec4(y, w, y, z);
        /// <summary>
        /// A vec4 containing the zwyz components of this vector
        /// </summary>
        public readonly vec4 zwyz => new vec4(z, w, y, z);
        /// <summary>
        /// A vec4 containing the wwyz components of this vector
        /// </summary>
        public readonly vec4 wwyz => new vec4(w, w, y, z);
        /// <summary>
        /// A vec4 containing the xxzz components of this vector
        /// </summary>
        public readonly vec4 xxzz => new vec4(x, x, z, z);
        /// <summary>
        /// A vec4 containing the yxzz components of this vector
        /// </summary>
        public readonly vec4 yxzz => new vec4(y, x, z, z);
        /// <summary>
        /// A vec4 containing the zxzz components of this vector
        /// </summary>
        public readonly vec4 zxzz => new vec4(z, x, z, z);
        /// <summary>
        /// A vec4 containing the wxzz components of this vector
        /// </summary>
        public readonly vec4 wxzz => new vec4(w, x, z, z);
        /// <summary>
        /// A vec4 containing the xyzz components of this vector
        /// </summary>
        public readonly vec4 xyzz => new vec4(x, y, z, z);
        /// <summary>
        /// A vec4 containing the yyzz components of this vector
        /// </summary>
        public readonly vec4 yyzz => new vec4(y, y, z, z);
        /// <summary>
        /// A vec4 containing the zyzz components of this vector
        /// </summary>
        public readonly vec4 zyzz => new vec4(z, y, z, z);
        /// <summary>
        /// A vec4 containing the wyzz components of this vector
        /// </summary>
        public readonly vec4 wyzz => new vec4(w, y, z, z);
        /// <summary>
        /// A vec4 containing the xzzz components of this vector
        /// </summary>
        public readonly vec4 xzzz => new vec4(x, z, z, z);
        /// <summary>
        /// A vec4 containing the yzzz components of this vector
        /// </summary>
        public readonly vec4 yzzz => new vec4(y, z, z, z);
        /// <summary>
        /// A vec4 containing the zzzz components of this vector
        /// </summary>
        public readonly vec4 zzzz => new vec4(z, z, z, z);
        /// <summary>
        /// A vec4 containing the wzzz components of this vector
        /// </summary>
        public readonly vec4 wzzz => new vec4(w, z, z, z);
        /// <summary>
        /// A vec4 containing the xwzz components of this vector
        /// </summary>
        public readonly vec4 xwzz => new vec4(x, w, z, z);
        /// <summary>
        /// A vec4 containing the ywzz components of this vector
        /// </summary>
        public readonly vec4 ywzz => new vec4(y, w, z, z);
        /// <summary>
        /// A vec4 containing the zwzz components of this vector
        /// </summary>
        public readonly vec4 zwzz => new vec4(z, w, z, z);
        /// <summary>
        /// A vec4 containing the wwzz components of this vector
        /// </summary>
        public readonly vec4 wwzz => new vec4(w, w, z, z);
        /// <summary>
        /// A vec4 containing the xxwz components of this vector
        /// </summary>
        public readonly vec4 xxwz => new vec4(x, x, w, z);
        /// <summary>
        /// A vec4 containing the yxwz components of this vector
        /// </summary>
        public vec4 yxwz {
            readonly get => new vec4(y, x, w, z);
            set {
                y = value.x;
                x = value.y;
                w = value.z;
                z = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the zxwz components of this vector
        /// </summary>
        public readonly vec4 zxwz => new vec4(z, x, w, z);
        /// <summary>
        /// A vec4 containing the wxwz components of this vector
        /// </summary>
        public readonly vec4 wxwz => new vec4(w, x, w, z);
        /// <summary>
        /// A vec4 containing the xywz components of this vector
        /// </summary>
        public vec4 xywz {
            readonly get => new vec4(x, y, w, z);
            set {
                x = value.x;
                y = value.y;
                w = value.z;
                z = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the yywz components of this vector
        /// </summary>
        public readonly vec4 yywz => new vec4(y, y, w, z);
        /// <summary>
        /// A vec4 containing the zywz components of this vector
        /// </summary>
        public readonly vec4 zywz => new vec4(z, y, w, z);
        /// <summary>
        /// A vec4 containing the wywz components of this vector
        /// </summary>
        public readonly vec4 wywz => new vec4(w, y, w, z);
        /// <summary>
        /// A vec4 containing the xzwz components of this vector
        /// </summary>
        public readonly vec4 xzwz => new vec4(x, z, w, z);
        /// <summary>
        /// A vec4 containing the yzwz components of this vector
        /// </summary>
        public readonly vec4 yzwz => new vec4(y, z, w, z);
        /// <summary>
        /// A vec4 containing the zzwz components of this vector
        /// </summary>
        public readonly vec4 zzwz => new vec4(z, z, w, z);
        /// <summary>
        /// A vec4 containing the wzwz components of this vector
        /// </summary>
        public readonly vec4 wzwz => new vec4(w, z, w, z);
        /// <summary>
        /// A vec4 containing the xwwz components of this vector
        /// </summary>
        public readonly vec4 xwwz => new vec4(x, w, w, z);
        /// <summary>
        /// A vec4 containing the ywwz components of this vector
        /// </summary>
        public readonly vec4 ywwz => new vec4(y, w, w, z);
        /// <summary>
        /// A vec4 containing the zwwz components of this vector
        /// </summary>
        public readonly vec4 zwwz => new vec4(z, w, w, z);
        /// <summary>
        /// A vec4 containing the wwwz components of this vector
        /// </summary>
        public readonly vec4 wwwz => new vec4(w, w, w, z);
        /// <summary>
        /// A vec4 containing the xxxw components of this vector
        /// </summary>
        public readonly vec4 xxxw => new vec4(x, x, x, w);
        /// <summary>
        /// A vec4 containing the yxxw components of this vector
        /// </summary>
        public readonly vec4 yxxw => new vec4(y, x, x, w);
        /// <summary>
        /// A vec4 containing the zxxw components of this vector
        /// </summary>
        public readonly vec4 zxxw => new vec4(z, x, x, w);
        /// <summary>
        /// A vec4 containing the wxxw components of this vector
        /// </summary>
        public readonly vec4 wxxw => new vec4(w, x, x, w);
        /// <summary>
        /// A vec4 containing the xyxw components of this vector
        /// </summary>
        public readonly vec4 xyxw => new vec4(x, y, x, w);
        /// <summary>
        /// A vec4 containing the yyxw components of this vector
        /// </summary>
        public readonly vec4 yyxw => new vec4(y, y, x, w);
        /// <summary>
        /// A vec4 containing the zyxw components of this vector
        /// </summary>
        public vec4 zyxw {
            readonly get => new vec4(z, y, x, w);
            set {
                z = value.x;
                y = value.y;
                x = value.z;
                w = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the wyxw components of this vector
        /// </summary>
        public readonly vec4 wyxw => new vec4(w, y, x, w);
        /// <summary>
        /// A vec4 containing the xzxw components of this vector
        /// </summary>
        public readonly vec4 xzxw => new vec4(x, z, x, w);
        /// <summary>
        /// A vec4 containing the yzxw components of this vector
        /// </summary>
        public vec4 yzxw {
            readonly get => new vec4(y, z, x, w);
            set {
                y = value.x;
                z = value.y;
                x = value.z;
                w = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the zzxw components of this vector
        /// </summary>
        public readonly vec4 zzxw => new vec4(z, z, x, w);
        /// <summary>
        /// A vec4 containing the wzxw components of this vector
        /// </summary>
        public readonly vec4 wzxw => new vec4(w, z, x, w);
        /// <summary>
        /// A vec4 containing the xwxw components of this vector
        /// </summary>
        public readonly vec4 xwxw => new vec4(x, w, x, w);
        /// <summary>
        /// A vec4 containing the ywxw components of this vector
        /// </summary>
        public readonly vec4 ywxw => new vec4(y, w, x, w);
        /// <summary>
        /// A vec4 containing the zwxw components of this vector
        /// </summary>
        public readonly vec4 zwxw => new vec4(z, w, x, w);
        /// <summary>
        /// A vec4 containing the wwxw components of this vector
        /// </summary>
        public readonly vec4 wwxw => new vec4(w, w, x, w);
        /// <summary>
        /// A vec4 containing the xxyw components of this vector
        /// </summary>
        public readonly vec4 xxyw => new vec4(x, x, y, w);
        /// <summary>
        /// A vec4 containing the yxyw components of this vector
        /// </summary>
        public readonly vec4 yxyw => new vec4(y, x, y, w);
        /// <summary>
        /// A vec4 containing the zxyw components of this vector
        /// </summary>
        public vec4 zxyw {
            readonly get => new vec4(z, x, y, w);
            set {
                z = value.x;
                x = value.y;
                y = value.z;
                w = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the wxyw components of this vector
        /// </summary>
        public readonly vec4 wxyw => new vec4(w, x, y, w);
        /// <summary>
        /// A vec4 containing the xyyw components of this vector
        /// </summary>
        public readonly vec4 xyyw => new vec4(x, y, y, w);
        /// <summary>
        /// A vec4 containing the yyyw components of this vector
        /// </summary>
        public readonly vec4 yyyw => new vec4(y, y, y, w);
        /// <summary>
        /// A vec4 containing the zyyw components of this vector
        /// </summary>
        public readonly vec4 zyyw => new vec4(z, y, y, w);
        /// <summary>
        /// A vec4 containing the wyyw components of this vector
        /// </summary>
        public readonly vec4 wyyw => new vec4(w, y, y, w);
        /// <summary>
        /// A vec4 containing the xzyw components of this vector
        /// </summary>
        public vec4 xzyw {
            readonly get => new vec4(x, z, y, w);
            set {
                x = value.x;
                z = value.y;
                y = value.z;
                w = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the yzyw components of this vector
        /// </summary>
        public readonly vec4 yzyw => new vec4(y, z, y, w);
        /// <summary>
        /// A vec4 containing the zzyw components of this vector
        /// </summary>
        public readonly vec4 zzyw => new vec4(z, z, y, w);
        /// <summary>
        /// A vec4 containing the wzyw components of this vector
        /// </summary>
        public readonly vec4 wzyw => new vec4(w, z, y, w);
        /// <summary>
        /// A vec4 containing the xwyw components of this vector
        /// </summary>
        public readonly vec4 xwyw => new vec4(x, w, y, w);
        /// <summary>
        /// A vec4 containing the ywyw components of this vector
        /// </summary>
        public readonly vec4 ywyw => new vec4(y, w, y, w);
        /// <summary>
        /// A vec4 containing the zwyw components of this vector
        /// </summary>
        public readonly vec4 zwyw => new vec4(z, w, y, w);
        /// <summary>
        /// A vec4 containing the wwyw components of this vector
        /// </summary>
        public readonly vec4 wwyw => new vec4(w, w, y, w);
        /// <summary>
        /// A vec4 containing the xxzw components of this vector
        /// </summary>
        public readonly vec4 xxzw => new vec4(x, x, z, w);
        /// <summary>
        /// A vec4 containing the yxzw components of this vector
        /// </summary>
        public vec4 yxzw {
            readonly get => new vec4(y, x, z, w);
            set {
                y = value.x;
                x = value.y;
                z = value.z;
                w = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the zxzw components of this vector
        /// </summary>
        public readonly vec4 zxzw => new vec4(z, x, z, w);
        /// <summary>
        /// A vec4 containing the wxzw components of this vector
        /// </summary>
        public readonly vec4 wxzw => new vec4(w, x, z, w);
        /// <summary>
        /// A vec4 containing the xyzw components of this vector
        /// </summary>
        public vec4 xyzw {
            readonly get => new vec4(x, y, z, w);
            set {
                x = value.x;
                y = value.y;
                z = value.z;
                w = value.w;
            }
        }
        /// <summary>
        /// A vec4 containing the yyzw components of this vector
        /// </summary>
        public readonly vec4 yyzw => new vec4(y, y, z, w);
        /// <summary>
        /// A vec4 containing the zyzw components of this vector
        /// </summary>
        public readonly vec4 zyzw => new vec4(z, y, z, w);
        /// <summary>
        /// A vec4 containing the wyzw components of this vector
        /// </summary>
        public readonly vec4 wyzw => new vec4(w, y, z, w);
        /// <summary>
        /// A vec4 containing the xzzw components of this vector
        /// </summary>
        public readonly vec4 xzzw => new vec4(x, z, z, w);
        /// <summary>
        /// A vec4 containing the yzzw components of this vector
        /// </summary>
        public readonly vec4 yzzw => new vec4(y, z, z, w);
        /// <summary>
        /// A vec4 containing the zzzw components of this vector
        /// </summary>
        public readonly vec4 zzzw => new vec4(z, z, z, w);
        /// <summary>
        /// A vec4 containing the wzzw components of this vector
        /// </summary>
        public readonly vec4 wzzw => new vec4(w, z, z, w);
        /// <summary>
        /// A vec4 containing the xwzw components of this vector
        /// </summary>
        public readonly vec4 xwzw => new vec4(x, w, z, w);
        /// <summary>
        /// A vec4 containing the ywzw components of this vector
        /// </summary>
        public readonly vec4 ywzw => new vec4(y, w, z, w);
        /// <summary>
        /// A vec4 containing the zwzw components of this vector
        /// </summary>
        public readonly vec4 zwzw => new vec4(z, w, z, w);
        /// <summary>
        /// A vec4 containing the wwzw components of this vector
        /// </summary>
        public readonly vec4 wwzw => new vec4(w, w, z, w);
        /// <summary>
        /// A vec4 containing the xxww components of this vector
        /// </summary>
        public readonly vec4 xxww => new vec4(x, x, w, w);
        /// <summary>
        /// A vec4 containing the yxww components of this vector
        /// </summary>
        public readonly vec4 yxww => new vec4(y, x, w, w);
        /// <summary>
        /// A vec4 containing the zxww components of this vector
        /// </summary>
        public readonly vec4 zxww => new vec4(z, x, w, w);
        /// <summary>
        /// A vec4 containing the wxww components of this vector
        /// </summary>
        public readonly vec4 wxww => new vec4(w, x, w, w);
        /// <summary>
        /// A vec4 containing the xyww components of this vector
        /// </summary>
        public readonly vec4 xyww => new vec4(x, y, w, w);
        /// <summary>
        /// A vec4 containing the yyww components of this vector
        /// </summary>
        public readonly vec4 yyww => new vec4(y, y, w, w);
        /// <summary>
        /// A vec4 containing the zyww components of this vector
        /// </summary>
        public readonly vec4 zyww => new vec4(z, y, w, w);
        /// <summary>
        /// A vec4 containing the wyww components of this vector
        /// </summary>
        public readonly vec4 wyww => new vec4(w, y, w, w);
        /// <summary>
        /// A vec4 containing the xzww components of this vector
        /// </summary>
        public readonly vec4 xzww => new vec4(x, z, w, w);
        /// <summary>
        /// A vec4 containing the yzww components of this vector
        /// </summary>
        public readonly vec4 yzww => new vec4(y, z, w, w);
        /// <summary>
        /// A vec4 containing the zzww components of this vector
        /// </summary>
        public readonly vec4 zzww => new vec4(z, z, w, w);
        /// <summary>
        /// A vec4 containing the wzww components of this vector
        /// </summary>
        public readonly vec4 wzww => new vec4(w, z, w, w);
        /// <summary>
        /// A vec4 containing the xwww components of this vector
        /// </summary>
        public readonly vec4 xwww => new vec4(x, w, w, w);
        /// <summary>
        /// A vec4 containing the ywww components of this vector
        /// </summary>
        public readonly vec4 ywww => new vec4(y, w, w, w);
        /// <summary>
        /// A vec4 containing the zwww components of this vector
        /// </summary>
        public readonly vec4 zwww => new vec4(z, w, w, w);
        /// <summary>
        /// A vec4 containing the wwww components of this vector
        /// </summary>
        public readonly vec4 wwww => new vec4(w, w, w, w);
        #endregion

        #region constructors
        public vec4(float x, float y, float z, float w) {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        public vec4(vec2 xy, vec2 zw) {
            this.x = xy.x;
            this.y = xy.y;
            this.z = zw.x;
            this.w = zw.y;
        }
        public vec4(vec2 xy, float z, float w) {
            this.x = xy.x;
            this.y = xy.y;
            this.z = z;
            this.w = w;
        }
        public vec4(float x, vec2 yz, float w) {
            this.x = x;
            this.y = yz.x;
            this.z = yz.y;
            this.w = w;
        }
        public vec4(float x, float y, vec2 zw) {
            this.x = x;
            this.y = y;
            this.z = zw.x;
            this.w = zw.y;
        }
        public vec4(vec3 xyz, float w) {
            this.x = xyz.x;
            this.y = xyz.y;
            this.z = xyz.z;
            this.w = w;
        }
        public vec4(float x, vec3 yzw) {
            this.x = x;
            this.y = yzw.x;
            this.z = yzw.y;
            this.w = yzw.z;
        }
        #endregion

        #region arithmetic
        public readonly float dot(vec4 v) => (this * v).sum;

        public static vec4 operator *(vec4 a, vec4 b) => new vec4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        public static vec4 operator /(vec4 a, vec4 b) => new vec4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
        public static vec4 operator +(vec4 a, vec4 b) => new vec4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        public static vec4 operator -(vec4 a, vec4 b) => new vec4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);

        public static vec4 operator *(vec4 a, float s) => new vec4(a.x * s, a.y * s, a.z * s, a.w * s);
        public static vec4 operator /(vec4 a, float s) => new vec4(a.x / s, a.y / s, a.z / s, a.w / s);

        public static vec4 operator -(vec4 v) => new vec4(-v.x, -v.y, -v.z, -v.w);
        #endregion

        #region math
        public readonly float distTo(vec4 o) => (o - this).length;
        public readonly float angleTo(vec4 o) => (float)Math.Acos(this.dot(o) / (this.length * o.length));
        public readonly vec4 reflect(vec4 normal) => this - (normal * 2 * (this.dot(normal) / normal.dot(normal)));
        #endregion

        #region conversion
        public static implicit operator vec4((float, float, float, float) tuple) => new vec4(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
        public static explicit operator ivec4(vec4 v) => new ivec4((int)v.x, (int)v.y, (int)v.z, (int)v.w);
        public static implicit operator dvec4(vec4 v) => new dvec4(v.x, v.y, v.z, v.w);
        public static implicit operator vec4(float n) => new vec4(n, n, n, n);
        #endregion

        #region other
        public override string ToString() => $"({x}, {y}, {z}, {w})";
        #endregion
    }
    public static partial class math {
        /// <summary>
        /// Takes the floor of each component in the given vec4.
        /// </summary>
        public static vec4 floor(in vec4 o) => new vec4(floor(o.x), floor(o.y), floor(o.z), floor(o.w));
        /// <summary>
        /// Takes the fract of each component in the given vec4.
        /// </summary>
        public static vec4 fract(in vec4 o) => new vec4(fract(o.x), fract(o.y), fract(o.z), fract(o.w));
        /// <summary>
        /// Takes the sqrt of each component in the given vec4.
        /// </summary>
        public static vec4 sqrt(in vec4 o) => new vec4(sqrt(o.x), sqrt(o.y), sqrt(o.z), sqrt(o.w));
        /// <summary>
        /// Takes the pow of each component in the given vec4.
        /// </summary>
        public static vec4 pow(in vec4 a, float b) => new vec4(pow(a.x, b), pow(a.y, b), pow(a.z, b), pow(a.w, b));
        /// <summary>
        /// Takes the sin of each component in the given vec4.
        /// </summary>
        public static vec4 sin(in vec4 o) => new vec4(sin(o.x), sin(o.y), sin(o.z), sin(o.w));
        /// <summary>
        /// Takes the cos of each component in the given vec4.
        /// </summary>
        public static vec4 cos(in vec4 o) => new vec4(cos(o.x), cos(o.y), cos(o.z), cos(o.w));
        /// <summary>
        /// Takes the tan of each component in the given vec4.
        /// </summary>
        public static vec4 tan(in vec4 o) => new vec4(tan(o.x), tan(o.y), tan(o.z), tan(o.w));
        /// <summary>
        /// Takes the abs of each component in the given vec4.
        /// </summary>
        public static vec4 abs(in vec4 o) => new vec4(abs(o.x), abs(o.y), abs(o.z), abs(o.w));
        /// <summary>
        /// Takes the min of each component in the given vec4.
        /// </summary>
        public static vec4 min(in vec4 a, in vec4 b) => new vec4(min(a.x, b.x), min(a.y, b.y), min(a.z, b.z), min(a.w, b.w));
        /// <summary>
        /// Takes the max of each component in the given vec4.
        /// </summary>
        public static vec4 max(in vec4 a, in vec4 b) => new vec4(max(a.x, b.x), max(a.y, b.y), max(a.z, b.z), max(a.w, b.w));
        /// <summary>
        /// Linear interpolation of two vec4 by t.
        /// </summary>
        public static vec4 lerp(in vec4 x, in vec4 y, float t) => x + (y - x) * t;
        /// <summary>
        /// Gets the vec4 at location t along a curve.
        /// </summary>
        public static vec4 bezier(in vec4 a, in vec4 b, in vec4 c, float t) => a + ((b - a)*2 + (c - 2*b + a)*t)*t;
    }
}
