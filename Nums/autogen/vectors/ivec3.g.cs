using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 3 component vector of int
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ivec3 : ivec {

        #region constants
        /// <summary>
        /// The zero vector: A vector where all components are equal to zero.
        /// </summary>
        public static readonly ivec3 zero = (0, 0, 0);
        /// <summary>
        /// A unit vector pointing in the positive x direction. →
        /// </summary>
        public static readonly ivec3 unitx = (1, 0, 0);
        /// <summary>
        /// A unit vector pointing in the positive y direction. ↑
        /// </summary>
        public static readonly ivec3 unity = (0, 1, 0);
        /// <summary>
        /// A unit vector pointing in the positive z direction. ↗
        /// </summary>
        public static readonly ivec3 unitz = (0, 0, 1);
        /// <summary>
        /// A vector where all components are equal to one.
        /// </summary>
        public static readonly ivec3 one = (1, 1, 1);
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
        /// The sum of the vectors components. x + y + z
        /// </summary>
        public int sum => x + y + z;
        /// <summary>
        /// The number of bytes the vector type uses.
        /// </summary>
        public static int bytesize => sizeof(int) * 3;
        /// <summary>
        /// The magnitude of the vector
        /// </summary>
        public int length => (int)Math.Sqrt(dot(this));
        /// <summary>
        /// The squared magnitude of the vector. sqlength is faster than length since a square-root operation is not needed.
        /// </summary>
        public int sqlength => dot(this);
        /// <summary>
        /// The normalized version of this vector.
        /// </summary>
        public ivec3 normalized() => this / length;
        /// <summary>
        /// Normalizes this vector.
        /// </summary>
        public void normalize() => this /= length;

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
        public ivec2 xx => new ivec2(x, x);
        public ivec2 yx {
            get => new ivec2(y, x);
            set {
                y = value.x;
                x = value.y;
            }
        }
        public ivec2 zx {
            get => new ivec2(z, x);
            set {
                z = value.x;
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
        public ivec2 zy {
            get => new ivec2(z, y);
            set {
                z = value.x;
                y = value.y;
            }
        }
        public ivec2 xz {
            get => new ivec2(x, z);
            set {
                x = value.x;
                z = value.y;
            }
        }
        public ivec2 yz {
            get => new ivec2(y, z);
            set {
                y = value.x;
                z = value.y;
            }
        }
        public ivec2 zz => new ivec2(z, z);
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
        public ivec3 reflect(ivec3 normal) => this - (normal * 2 * (this.dot(normal) / normal.dot(normal)));
        public ivec3 cross(ivec3 o) => new ivec3(y * o.z - z * o.y, z * o.x - x * o.z, x * o.y - y * o.x);
        #endregion

        #region conversion
        public static implicit operator ivec3((int, int, int) tuple) => new ivec3(tuple.Item1, tuple.Item2, tuple.Item3);
        public static implicit operator vec3(ivec3 v) => new vec3(v.x, v.y, v.z);
        public static implicit operator dvec3(ivec3 v) => new dvec3(v.x, v.y, v.z);
        public static implicit operator ivec3(int n) => new ivec3(n, n, n);
        #endregion

        #region other
        public override string ToString() => $"({x}, {y}, {z})";
        #endregion
    }
    public static partial class math {
    }
}
