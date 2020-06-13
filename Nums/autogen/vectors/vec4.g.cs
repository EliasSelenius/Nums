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
        public float sum => x + y + z + w;
        /// <summary>
        /// The number of bytes the vector type uses.
        /// </summary>
        public static int bytesize => sizeof(float) * 4;
        /// <summary>
        /// The magnitude of the vector
        /// </summary>
        public float length => (float)Math.Sqrt(dot(this));
        /// <summary>
        /// The squared magnitude of the vector. sqlength is faster than length since a square-root operation is not needed.
        /// </summary>
        public float sqlength => dot(this);
        /// <summary>
        /// The normalized version of this vector.
        /// </summary>
        public vec4 normalized() => this / length;
        /// <summary>
        /// Normalizes this vector.
        /// </summary>
        public void normalize() => this /= length;

        public float this[int i] {
            get => i switch {
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
        public vec2 xx => new vec2(x, x);
        public vec2 yx {
            get => new vec2(y, x);
            set {
                y = value.x;
                x = value.y;
            }
        }
        public vec2 zx {
            get => new vec2(z, x);
            set {
                z = value.x;
                x = value.y;
            }
        }
        public vec2 wx {
            get => new vec2(w, x);
            set {
                w = value.x;
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
        public vec2 zy {
            get => new vec2(z, y);
            set {
                z = value.x;
                y = value.y;
            }
        }
        public vec2 wy {
            get => new vec2(w, y);
            set {
                w = value.x;
                y = value.y;
            }
        }
        public vec2 xz {
            get => new vec2(x, z);
            set {
                x = value.x;
                z = value.y;
            }
        }
        public vec2 yz {
            get => new vec2(y, z);
            set {
                y = value.x;
                z = value.y;
            }
        }
        public vec2 zz => new vec2(z, z);
        public vec2 wz {
            get => new vec2(w, z);
            set {
                w = value.x;
                z = value.y;
            }
        }
        public vec2 xw {
            get => new vec2(x, w);
            set {
                x = value.x;
                w = value.y;
            }
        }
        public vec2 yw {
            get => new vec2(y, w);
            set {
                y = value.x;
                w = value.y;
            }
        }
        public vec2 zw {
            get => new vec2(z, w);
            set {
                z = value.x;
                w = value.y;
            }
        }
        public vec2 ww => new vec2(w, w);
        public vec3 xxx => new vec3(x, x, x);
        public vec3 yxx => new vec3(y, x, x);
        public vec3 zxx => new vec3(z, x, x);
        public vec3 wxx => new vec3(w, x, x);
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
        public vec3 wyx {
            get => new vec3(w, y, x);
            set {
                w = value.x;
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
        public vec3 wzx {
            get => new vec3(w, z, x);
            set {
                w = value.x;
                z = value.y;
                x = value.z;
            }
        }
        public vec3 xwx => new vec3(x, w, x);
        public vec3 ywx {
            get => new vec3(y, w, x);
            set {
                y = value.x;
                w = value.y;
                x = value.z;
            }
        }
        public vec3 zwx {
            get => new vec3(z, w, x);
            set {
                z = value.x;
                w = value.y;
                x = value.z;
            }
        }
        public vec3 wwx => new vec3(w, w, x);
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
        public vec3 wxy {
            get => new vec3(w, x, y);
            set {
                w = value.x;
                x = value.y;
                y = value.z;
            }
        }
        public vec3 xyy => new vec3(x, y, y);
        public vec3 yyy => new vec3(y, y, y);
        public vec3 zyy => new vec3(z, y, y);
        public vec3 wyy => new vec3(w, y, y);
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
        public vec3 wzy {
            get => new vec3(w, z, y);
            set {
                w = value.x;
                z = value.y;
                y = value.z;
            }
        }
        public vec3 xwy {
            get => new vec3(x, w, y);
            set {
                x = value.x;
                w = value.y;
                y = value.z;
            }
        }
        public vec3 ywy => new vec3(y, w, y);
        public vec3 zwy {
            get => new vec3(z, w, y);
            set {
                z = value.x;
                w = value.y;
                y = value.z;
            }
        }
        public vec3 wwy => new vec3(w, w, y);
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
        public vec3 wxz {
            get => new vec3(w, x, z);
            set {
                w = value.x;
                x = value.y;
                z = value.z;
            }
        }
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
        public vec3 wyz {
            get => new vec3(w, y, z);
            set {
                w = value.x;
                y = value.y;
                z = value.z;
            }
        }
        public vec3 xzz => new vec3(x, z, z);
        public vec3 yzz => new vec3(y, z, z);
        public vec3 zzz => new vec3(z, z, z);
        public vec3 wzz => new vec3(w, z, z);
        public vec3 xwz {
            get => new vec3(x, w, z);
            set {
                x = value.x;
                w = value.y;
                z = value.z;
            }
        }
        public vec3 ywz {
            get => new vec3(y, w, z);
            set {
                y = value.x;
                w = value.y;
                z = value.z;
            }
        }
        public vec3 zwz => new vec3(z, w, z);
        public vec3 wwz => new vec3(w, w, z);
        public vec3 xxw => new vec3(x, x, w);
        public vec3 yxw {
            get => new vec3(y, x, w);
            set {
                y = value.x;
                x = value.y;
                w = value.z;
            }
        }
        public vec3 zxw {
            get => new vec3(z, x, w);
            set {
                z = value.x;
                x = value.y;
                w = value.z;
            }
        }
        public vec3 wxw => new vec3(w, x, w);
        public vec3 xyw {
            get => new vec3(x, y, w);
            set {
                x = value.x;
                y = value.y;
                w = value.z;
            }
        }
        public vec3 yyw => new vec3(y, y, w);
        public vec3 zyw {
            get => new vec3(z, y, w);
            set {
                z = value.x;
                y = value.y;
                w = value.z;
            }
        }
        public vec3 wyw => new vec3(w, y, w);
        public vec3 xzw {
            get => new vec3(x, z, w);
            set {
                x = value.x;
                z = value.y;
                w = value.z;
            }
        }
        public vec3 yzw {
            get => new vec3(y, z, w);
            set {
                y = value.x;
                z = value.y;
                w = value.z;
            }
        }
        public vec3 zzw => new vec3(z, z, w);
        public vec3 wzw => new vec3(w, z, w);
        public vec3 xww => new vec3(x, w, w);
        public vec3 yww => new vec3(y, w, w);
        public vec3 zww => new vec3(z, w, w);
        public vec3 www => new vec3(w, w, w);
        public vec4 xxxx => new vec4(x, x, x, x);
        public vec4 yxxx => new vec4(y, x, x, x);
        public vec4 zxxx => new vec4(z, x, x, x);
        public vec4 wxxx => new vec4(w, x, x, x);
        public vec4 xyxx => new vec4(x, y, x, x);
        public vec4 yyxx => new vec4(y, y, x, x);
        public vec4 zyxx => new vec4(z, y, x, x);
        public vec4 wyxx => new vec4(w, y, x, x);
        public vec4 xzxx => new vec4(x, z, x, x);
        public vec4 yzxx => new vec4(y, z, x, x);
        public vec4 zzxx => new vec4(z, z, x, x);
        public vec4 wzxx => new vec4(w, z, x, x);
        public vec4 xwxx => new vec4(x, w, x, x);
        public vec4 ywxx => new vec4(y, w, x, x);
        public vec4 zwxx => new vec4(z, w, x, x);
        public vec4 wwxx => new vec4(w, w, x, x);
        public vec4 xxyx => new vec4(x, x, y, x);
        public vec4 yxyx => new vec4(y, x, y, x);
        public vec4 zxyx => new vec4(z, x, y, x);
        public vec4 wxyx => new vec4(w, x, y, x);
        public vec4 xyyx => new vec4(x, y, y, x);
        public vec4 yyyx => new vec4(y, y, y, x);
        public vec4 zyyx => new vec4(z, y, y, x);
        public vec4 wyyx => new vec4(w, y, y, x);
        public vec4 xzyx => new vec4(x, z, y, x);
        public vec4 yzyx => new vec4(y, z, y, x);
        public vec4 zzyx => new vec4(z, z, y, x);
        public vec4 wzyx {
            get => new vec4(w, z, y, x);
            set {
                w = value.x;
                z = value.y;
                y = value.z;
                x = value.w;
            }
        }
        public vec4 xwyx => new vec4(x, w, y, x);
        public vec4 ywyx => new vec4(y, w, y, x);
        public vec4 zwyx {
            get => new vec4(z, w, y, x);
            set {
                z = value.x;
                w = value.y;
                y = value.z;
                x = value.w;
            }
        }
        public vec4 wwyx => new vec4(w, w, y, x);
        public vec4 xxzx => new vec4(x, x, z, x);
        public vec4 yxzx => new vec4(y, x, z, x);
        public vec4 zxzx => new vec4(z, x, z, x);
        public vec4 wxzx => new vec4(w, x, z, x);
        public vec4 xyzx => new vec4(x, y, z, x);
        public vec4 yyzx => new vec4(y, y, z, x);
        public vec4 zyzx => new vec4(z, y, z, x);
        public vec4 wyzx {
            get => new vec4(w, y, z, x);
            set {
                w = value.x;
                y = value.y;
                z = value.z;
                x = value.w;
            }
        }
        public vec4 xzzx => new vec4(x, z, z, x);
        public vec4 yzzx => new vec4(y, z, z, x);
        public vec4 zzzx => new vec4(z, z, z, x);
        public vec4 wzzx => new vec4(w, z, z, x);
        public vec4 xwzx => new vec4(x, w, z, x);
        public vec4 ywzx {
            get => new vec4(y, w, z, x);
            set {
                y = value.x;
                w = value.y;
                z = value.z;
                x = value.w;
            }
        }
        public vec4 zwzx => new vec4(z, w, z, x);
        public vec4 wwzx => new vec4(w, w, z, x);
        public vec4 xxwx => new vec4(x, x, w, x);
        public vec4 yxwx => new vec4(y, x, w, x);
        public vec4 zxwx => new vec4(z, x, w, x);
        public vec4 wxwx => new vec4(w, x, w, x);
        public vec4 xywx => new vec4(x, y, w, x);
        public vec4 yywx => new vec4(y, y, w, x);
        public vec4 zywx {
            get => new vec4(z, y, w, x);
            set {
                z = value.x;
                y = value.y;
                w = value.z;
                x = value.w;
            }
        }
        public vec4 wywx => new vec4(w, y, w, x);
        public vec4 xzwx => new vec4(x, z, w, x);
        public vec4 yzwx {
            get => new vec4(y, z, w, x);
            set {
                y = value.x;
                z = value.y;
                w = value.z;
                x = value.w;
            }
        }
        public vec4 zzwx => new vec4(z, z, w, x);
        public vec4 wzwx => new vec4(w, z, w, x);
        public vec4 xwwx => new vec4(x, w, w, x);
        public vec4 ywwx => new vec4(y, w, w, x);
        public vec4 zwwx => new vec4(z, w, w, x);
        public vec4 wwwx => new vec4(w, w, w, x);
        public vec4 xxxy => new vec4(x, x, x, y);
        public vec4 yxxy => new vec4(y, x, x, y);
        public vec4 zxxy => new vec4(z, x, x, y);
        public vec4 wxxy => new vec4(w, x, x, y);
        public vec4 xyxy => new vec4(x, y, x, y);
        public vec4 yyxy => new vec4(y, y, x, y);
        public vec4 zyxy => new vec4(z, y, x, y);
        public vec4 wyxy => new vec4(w, y, x, y);
        public vec4 xzxy => new vec4(x, z, x, y);
        public vec4 yzxy => new vec4(y, z, x, y);
        public vec4 zzxy => new vec4(z, z, x, y);
        public vec4 wzxy {
            get => new vec4(w, z, x, y);
            set {
                w = value.x;
                z = value.y;
                x = value.z;
                y = value.w;
            }
        }
        public vec4 xwxy => new vec4(x, w, x, y);
        public vec4 ywxy => new vec4(y, w, x, y);
        public vec4 zwxy {
            get => new vec4(z, w, x, y);
            set {
                z = value.x;
                w = value.y;
                x = value.z;
                y = value.w;
            }
        }
        public vec4 wwxy => new vec4(w, w, x, y);
        public vec4 xxyy => new vec4(x, x, y, y);
        public vec4 yxyy => new vec4(y, x, y, y);
        public vec4 zxyy => new vec4(z, x, y, y);
        public vec4 wxyy => new vec4(w, x, y, y);
        public vec4 xyyy => new vec4(x, y, y, y);
        public vec4 yyyy => new vec4(y, y, y, y);
        public vec4 zyyy => new vec4(z, y, y, y);
        public vec4 wyyy => new vec4(w, y, y, y);
        public vec4 xzyy => new vec4(x, z, y, y);
        public vec4 yzyy => new vec4(y, z, y, y);
        public vec4 zzyy => new vec4(z, z, y, y);
        public vec4 wzyy => new vec4(w, z, y, y);
        public vec4 xwyy => new vec4(x, w, y, y);
        public vec4 ywyy => new vec4(y, w, y, y);
        public vec4 zwyy => new vec4(z, w, y, y);
        public vec4 wwyy => new vec4(w, w, y, y);
        public vec4 xxzy => new vec4(x, x, z, y);
        public vec4 yxzy => new vec4(y, x, z, y);
        public vec4 zxzy => new vec4(z, x, z, y);
        public vec4 wxzy {
            get => new vec4(w, x, z, y);
            set {
                w = value.x;
                x = value.y;
                z = value.z;
                y = value.w;
            }
        }
        public vec4 xyzy => new vec4(x, y, z, y);
        public vec4 yyzy => new vec4(y, y, z, y);
        public vec4 zyzy => new vec4(z, y, z, y);
        public vec4 wyzy => new vec4(w, y, z, y);
        public vec4 xzzy => new vec4(x, z, z, y);
        public vec4 yzzy => new vec4(y, z, z, y);
        public vec4 zzzy => new vec4(z, z, z, y);
        public vec4 wzzy => new vec4(w, z, z, y);
        public vec4 xwzy {
            get => new vec4(x, w, z, y);
            set {
                x = value.x;
                w = value.y;
                z = value.z;
                y = value.w;
            }
        }
        public vec4 ywzy => new vec4(y, w, z, y);
        public vec4 zwzy => new vec4(z, w, z, y);
        public vec4 wwzy => new vec4(w, w, z, y);
        public vec4 xxwy => new vec4(x, x, w, y);
        public vec4 yxwy => new vec4(y, x, w, y);
        public vec4 zxwy {
            get => new vec4(z, x, w, y);
            set {
                z = value.x;
                x = value.y;
                w = value.z;
                y = value.w;
            }
        }
        public vec4 wxwy => new vec4(w, x, w, y);
        public vec4 xywy => new vec4(x, y, w, y);
        public vec4 yywy => new vec4(y, y, w, y);
        public vec4 zywy => new vec4(z, y, w, y);
        public vec4 wywy => new vec4(w, y, w, y);
        public vec4 xzwy {
            get => new vec4(x, z, w, y);
            set {
                x = value.x;
                z = value.y;
                w = value.z;
                y = value.w;
            }
        }
        public vec4 yzwy => new vec4(y, z, w, y);
        public vec4 zzwy => new vec4(z, z, w, y);
        public vec4 wzwy => new vec4(w, z, w, y);
        public vec4 xwwy => new vec4(x, w, w, y);
        public vec4 ywwy => new vec4(y, w, w, y);
        public vec4 zwwy => new vec4(z, w, w, y);
        public vec4 wwwy => new vec4(w, w, w, y);
        public vec4 xxxz => new vec4(x, x, x, z);
        public vec4 yxxz => new vec4(y, x, x, z);
        public vec4 zxxz => new vec4(z, x, x, z);
        public vec4 wxxz => new vec4(w, x, x, z);
        public vec4 xyxz => new vec4(x, y, x, z);
        public vec4 yyxz => new vec4(y, y, x, z);
        public vec4 zyxz => new vec4(z, y, x, z);
        public vec4 wyxz {
            get => new vec4(w, y, x, z);
            set {
                w = value.x;
                y = value.y;
                x = value.z;
                z = value.w;
            }
        }
        public vec4 xzxz => new vec4(x, z, x, z);
        public vec4 yzxz => new vec4(y, z, x, z);
        public vec4 zzxz => new vec4(z, z, x, z);
        public vec4 wzxz => new vec4(w, z, x, z);
        public vec4 xwxz => new vec4(x, w, x, z);
        public vec4 ywxz {
            get => new vec4(y, w, x, z);
            set {
                y = value.x;
                w = value.y;
                x = value.z;
                z = value.w;
            }
        }
        public vec4 zwxz => new vec4(z, w, x, z);
        public vec4 wwxz => new vec4(w, w, x, z);
        public vec4 xxyz => new vec4(x, x, y, z);
        public vec4 yxyz => new vec4(y, x, y, z);
        public vec4 zxyz => new vec4(z, x, y, z);
        public vec4 wxyz {
            get => new vec4(w, x, y, z);
            set {
                w = value.x;
                x = value.y;
                y = value.z;
                z = value.w;
            }
        }
        public vec4 xyyz => new vec4(x, y, y, z);
        public vec4 yyyz => new vec4(y, y, y, z);
        public vec4 zyyz => new vec4(z, y, y, z);
        public vec4 wyyz => new vec4(w, y, y, z);
        public vec4 xzyz => new vec4(x, z, y, z);
        public vec4 yzyz => new vec4(y, z, y, z);
        public vec4 zzyz => new vec4(z, z, y, z);
        public vec4 wzyz => new vec4(w, z, y, z);
        public vec4 xwyz {
            get => new vec4(x, w, y, z);
            set {
                x = value.x;
                w = value.y;
                y = value.z;
                z = value.w;
            }
        }
        public vec4 ywyz => new vec4(y, w, y, z);
        public vec4 zwyz => new vec4(z, w, y, z);
        public vec4 wwyz => new vec4(w, w, y, z);
        public vec4 xxzz => new vec4(x, x, z, z);
        public vec4 yxzz => new vec4(y, x, z, z);
        public vec4 zxzz => new vec4(z, x, z, z);
        public vec4 wxzz => new vec4(w, x, z, z);
        public vec4 xyzz => new vec4(x, y, z, z);
        public vec4 yyzz => new vec4(y, y, z, z);
        public vec4 zyzz => new vec4(z, y, z, z);
        public vec4 wyzz => new vec4(w, y, z, z);
        public vec4 xzzz => new vec4(x, z, z, z);
        public vec4 yzzz => new vec4(y, z, z, z);
        public vec4 zzzz => new vec4(z, z, z, z);
        public vec4 wzzz => new vec4(w, z, z, z);
        public vec4 xwzz => new vec4(x, w, z, z);
        public vec4 ywzz => new vec4(y, w, z, z);
        public vec4 zwzz => new vec4(z, w, z, z);
        public vec4 wwzz => new vec4(w, w, z, z);
        public vec4 xxwz => new vec4(x, x, w, z);
        public vec4 yxwz {
            get => new vec4(y, x, w, z);
            set {
                y = value.x;
                x = value.y;
                w = value.z;
                z = value.w;
            }
        }
        public vec4 zxwz => new vec4(z, x, w, z);
        public vec4 wxwz => new vec4(w, x, w, z);
        public vec4 xywz {
            get => new vec4(x, y, w, z);
            set {
                x = value.x;
                y = value.y;
                w = value.z;
                z = value.w;
            }
        }
        public vec4 yywz => new vec4(y, y, w, z);
        public vec4 zywz => new vec4(z, y, w, z);
        public vec4 wywz => new vec4(w, y, w, z);
        public vec4 xzwz => new vec4(x, z, w, z);
        public vec4 yzwz => new vec4(y, z, w, z);
        public vec4 zzwz => new vec4(z, z, w, z);
        public vec4 wzwz => new vec4(w, z, w, z);
        public vec4 xwwz => new vec4(x, w, w, z);
        public vec4 ywwz => new vec4(y, w, w, z);
        public vec4 zwwz => new vec4(z, w, w, z);
        public vec4 wwwz => new vec4(w, w, w, z);
        public vec4 xxxw => new vec4(x, x, x, w);
        public vec4 yxxw => new vec4(y, x, x, w);
        public vec4 zxxw => new vec4(z, x, x, w);
        public vec4 wxxw => new vec4(w, x, x, w);
        public vec4 xyxw => new vec4(x, y, x, w);
        public vec4 yyxw => new vec4(y, y, x, w);
        public vec4 zyxw {
            get => new vec4(z, y, x, w);
            set {
                z = value.x;
                y = value.y;
                x = value.z;
                w = value.w;
            }
        }
        public vec4 wyxw => new vec4(w, y, x, w);
        public vec4 xzxw => new vec4(x, z, x, w);
        public vec4 yzxw {
            get => new vec4(y, z, x, w);
            set {
                y = value.x;
                z = value.y;
                x = value.z;
                w = value.w;
            }
        }
        public vec4 zzxw => new vec4(z, z, x, w);
        public vec4 wzxw => new vec4(w, z, x, w);
        public vec4 xwxw => new vec4(x, w, x, w);
        public vec4 ywxw => new vec4(y, w, x, w);
        public vec4 zwxw => new vec4(z, w, x, w);
        public vec4 wwxw => new vec4(w, w, x, w);
        public vec4 xxyw => new vec4(x, x, y, w);
        public vec4 yxyw => new vec4(y, x, y, w);
        public vec4 zxyw {
            get => new vec4(z, x, y, w);
            set {
                z = value.x;
                x = value.y;
                y = value.z;
                w = value.w;
            }
        }
        public vec4 wxyw => new vec4(w, x, y, w);
        public vec4 xyyw => new vec4(x, y, y, w);
        public vec4 yyyw => new vec4(y, y, y, w);
        public vec4 zyyw => new vec4(z, y, y, w);
        public vec4 wyyw => new vec4(w, y, y, w);
        public vec4 xzyw {
            get => new vec4(x, z, y, w);
            set {
                x = value.x;
                z = value.y;
                y = value.z;
                w = value.w;
            }
        }
        public vec4 yzyw => new vec4(y, z, y, w);
        public vec4 zzyw => new vec4(z, z, y, w);
        public vec4 wzyw => new vec4(w, z, y, w);
        public vec4 xwyw => new vec4(x, w, y, w);
        public vec4 ywyw => new vec4(y, w, y, w);
        public vec4 zwyw => new vec4(z, w, y, w);
        public vec4 wwyw => new vec4(w, w, y, w);
        public vec4 xxzw => new vec4(x, x, z, w);
        public vec4 yxzw {
            get => new vec4(y, x, z, w);
            set {
                y = value.x;
                x = value.y;
                z = value.z;
                w = value.w;
            }
        }
        public vec4 zxzw => new vec4(z, x, z, w);
        public vec4 wxzw => new vec4(w, x, z, w);
        public vec4 xyzw {
            get => new vec4(x, y, z, w);
            set {
                x = value.x;
                y = value.y;
                z = value.z;
                w = value.w;
            }
        }
        public vec4 yyzw => new vec4(y, y, z, w);
        public vec4 zyzw => new vec4(z, y, z, w);
        public vec4 wyzw => new vec4(w, y, z, w);
        public vec4 xzzw => new vec4(x, z, z, w);
        public vec4 yzzw => new vec4(y, z, z, w);
        public vec4 zzzw => new vec4(z, z, z, w);
        public vec4 wzzw => new vec4(w, z, z, w);
        public vec4 xwzw => new vec4(x, w, z, w);
        public vec4 ywzw => new vec4(y, w, z, w);
        public vec4 zwzw => new vec4(z, w, z, w);
        public vec4 wwzw => new vec4(w, w, z, w);
        public vec4 xxww => new vec4(x, x, w, w);
        public vec4 yxww => new vec4(y, x, w, w);
        public vec4 zxww => new vec4(z, x, w, w);
        public vec4 wxww => new vec4(w, x, w, w);
        public vec4 xyww => new vec4(x, y, w, w);
        public vec4 yyww => new vec4(y, y, w, w);
        public vec4 zyww => new vec4(z, y, w, w);
        public vec4 wyww => new vec4(w, y, w, w);
        public vec4 xzww => new vec4(x, z, w, w);
        public vec4 yzww => new vec4(y, z, w, w);
        public vec4 zzww => new vec4(z, z, w, w);
        public vec4 wzww => new vec4(w, z, w, w);
        public vec4 xwww => new vec4(x, w, w, w);
        public vec4 ywww => new vec4(y, w, w, w);
        public vec4 zwww => new vec4(z, w, w, w);
        public vec4 wwww => new vec4(w, w, w, w);
        #endregion

        #region constructors
        public vec4(float x, float y, float z, float w) {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        #endregion

        #region arithmetic
        public float dot(vec4 v) => (this * v).sum;

        public static vec4 operator *(vec4 a, vec4 b) => new vec4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        public static vec4 operator /(vec4 a, vec4 b) => new vec4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
        public static vec4 operator +(vec4 a, vec4 b) => new vec4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        public static vec4 operator -(vec4 a, vec4 b) => new vec4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);

        public static vec4 operator *(vec4 a, float s) => new vec4(a.x * s, a.y * s, a.z * s, a.w * s);
        public static vec4 operator /(vec4 a, float s) => new vec4(a.x / s, a.y / s, a.z / s, a.w / s);

        public static vec4 operator -(vec4 v) => new vec4(-v.x, -v.y, -v.z, -v.w);
        #endregion

        #region math
        public float distTo(vec4 o) => (o - this).length;
        public float angleTo(vec4 o) => (float)Math.Acos(this.dot(o) / (this.length * o.length));
        public vec4 lerp(vec4 o, float t) => this + ((o - this) * t);
        public vec4 reflect(vec4 normal) => this - (normal * 2 * (this.dot(normal) / normal.dot(normal)));
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
        public static vec4 floor(vec4 o) => new vec4(floor(o.x), floor(o.y), floor(o.z), floor(o.w));
        public static vec4 fract(vec4 o) => new vec4(fract(o.x), fract(o.y), fract(o.z), fract(o.w));
        public static vec4 abs(vec4 o) => new vec4(abs(o.x), abs(o.y), abs(o.z), abs(o.w));
        public static vec4 sqrt(vec4 o) => new vec4(sqrt(o.x), sqrt(o.y), sqrt(o.z), sqrt(o.w));
        public static vec4 sin(vec4 o) => new vec4(sin(o.x), sin(o.y), sin(o.z), sin(o.w));
        public static vec4 cos(vec4 o) => new vec4(cos(o.x), cos(o.y), cos(o.z), cos(o.w));
        public static vec4 tan(vec4 o) => new vec4(tan(o.x), tan(o.y), tan(o.z), tan(o.w));
    }
}
