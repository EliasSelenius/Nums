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
        public readonly int sum => x + y + z;
        /// <summary>
        /// The number of bytes the vector type uses.
        /// </summary>
        public const int bytesize = sizeof(int) * 3;
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
        public readonly ivec3 normalized() => this / length;
        /// <summary>
        /// Normalizes this vector.
        /// </summary>
        public void normalize() => this /= length;

        public int this[int i] {
            readonly get => i switch {
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
        #endregion

        #region constructors
        public ivec3(int x, int y, int z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public ivec3(ivec2 xy, int z) {
            this.x = xy.x;
            this.y = xy.y;
            this.z = z;
        }
        public ivec3(int x, ivec2 yz) {
            this.x = x;
            this.y = yz.x;
            this.z = yz.y;
        }
        #endregion

        #region arithmetic
        public readonly int dot(ivec3 v) => (this * v).sum;

        public static ivec3 operator *(ivec3 a, ivec3 b) => new ivec3(a.x * b.x, a.y * b.y, a.z * b.z);
        public static ivec3 operator /(ivec3 a, ivec3 b) => new ivec3(a.x / b.x, a.y / b.y, a.z / b.z);
        public static ivec3 operator +(ivec3 a, ivec3 b) => new ivec3(a.x + b.x, a.y + b.y, a.z + b.z);
        public static ivec3 operator -(ivec3 a, ivec3 b) => new ivec3(a.x - b.x, a.y - b.y, a.z - b.z);

        public static ivec3 operator *(ivec3 a, int s) => new ivec3(a.x * s, a.y * s, a.z * s);
        public static ivec3 operator /(ivec3 a, int s) => new ivec3(a.x / s, a.y / s, a.z / s);

        public static ivec3 operator -(ivec3 v) => new ivec3(-v.x, -v.y, -v.z);
        #endregion

        #region math
        public readonly int distTo(ivec3 o) => (o - this).length;
        public readonly int angleTo(ivec3 o) => (int)Math.Acos(this.dot(o) / (this.length * o.length));
        public readonly ivec3 reflect(ivec3 normal) => this - (normal * 2 * (this.dot(normal) / normal.dot(normal)));
        public ivec3 cross(ivec3 o) => new ivec3(y * o.z - z * o.y, z * o.x - x * o.z, x * o.y - y * o.x);
        #endregion

        #region conversion/deconstructors
        public static implicit operator ivec3((int, int, int) tuple) => new ivec3(tuple.Item1, tuple.Item2, tuple.Item3);
        public static implicit operator vec3(ivec3 v) => new vec3(v.x, v.y, v.z);
        public static implicit operator dvec3(ivec3 v) => new dvec3(v.x, v.y, v.z);
        public static implicit operator ivec3(int n) => new ivec3(n, n, n);
        public void Deconstruct(out int x, out int y, out int z) => (x, y, z) = (this.x, this.y, this.z);
        #endregion

        #region other
        public override string ToString() => $"({x}, {y}, {z})";
        #endregion
    }
    public static partial class math {
        /// <summary>
        /// Takes the abs of each component in the given ivec3.
        /// </summary>
        public static ivec3 abs(in ivec3 o) => new ivec3(abs(o.x), abs(o.y), abs(o.z));
        /// <summary>
        /// Takes the min of each component in the given ivec3.
        /// </summary>
        public static ivec3 min(in ivec3 a, in ivec3 b) => new ivec3(min(a.x, b.x), min(a.y, b.y), min(a.z, b.z));
        /// <summary>
        /// Takes the max of each component in the given ivec3.
        /// </summary>
        public static ivec3 max(in ivec3 a, in ivec3 b) => new ivec3(max(a.x, b.x), max(a.y, b.y), max(a.z, b.z));
        /// <summary>
        /// Linear interpolation of two ivec3 by t.
        /// </summary>
        public static ivec3 lerp(in ivec3 x, in ivec3 y, int t) => x + (y - x) * t;
        /// <summary>
        /// Gets the ivec3 at location t along a curve.
        /// </summary>
        public static ivec3 bezier(in ivec3 a, in ivec3 b, in ivec3 c, int t) => a + ((b - a)*2 + (c - 2*b + a)*t)*t;
    }
}
