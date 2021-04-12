using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 3 component vector of double
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct dvec3 : dvec {

        #region constants
        /// <summary>
        /// The zero vector: A vector where all components are equal to zero.
        /// </summary>
        public static readonly dvec3 zero = (0, 0, 0);
        /// <summary>
        /// A unit vector pointing in the positive x direction. →
        /// </summary>
        public static readonly dvec3 unitx = (1, 0, 0);
        /// <summary>
        /// A unit vector pointing in the positive y direction. ↑
        /// </summary>
        public static readonly dvec3 unity = (0, 1, 0);
        /// <summary>
        /// A unit vector pointing in the positive z direction. ↗
        /// </summary>
        public static readonly dvec3 unitz = (0, 0, 1);
        /// <summary>
        /// A vector where all components are equal to one.
        /// </summary>
        public static readonly dvec3 one = (1, 1, 1);
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
        /// The sum of the vectors components. x + y + z
        /// </summary>
        public readonly double sum => x + y + z;
        /// <summary>
        /// The number of bytes the vector type uses.
        /// </summary>
        public const int bytesize = sizeof(double) * 3;
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
        public readonly dvec3 normalized() => this / length;
        /// <summary>
        /// Normalizes this vector.
        /// </summary>
        public void normalize() => this /= length;

        public double this[int i] {
            readonly get => i switch {
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
        #endregion

        #region constructors
        public dvec3(double x, double y, double z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public dvec3(dvec2 xy, double z) {
            this.x = xy.x;
            this.y = xy.y;
            this.z = z;
        }
        public dvec3(double x, dvec2 yz) {
            this.x = x;
            this.y = yz.x;
            this.z = yz.y;
        }
        #endregion

        #region arithmetic
        public readonly double dot(dvec3 v) => (this * v).sum;

        public static dvec3 operator *(dvec3 a, dvec3 b) => new dvec3(a.x * b.x, a.y * b.y, a.z * b.z);
        public static dvec3 operator /(dvec3 a, dvec3 b) => new dvec3(a.x / b.x, a.y / b.y, a.z / b.z);
        public static dvec3 operator +(dvec3 a, dvec3 b) => new dvec3(a.x + b.x, a.y + b.y, a.z + b.z);
        public static dvec3 operator -(dvec3 a, dvec3 b) => new dvec3(a.x - b.x, a.y - b.y, a.z - b.z);

        public static dvec3 operator *(dvec3 a, double s) => new dvec3(a.x * s, a.y * s, a.z * s);
        public static dvec3 operator /(dvec3 a, double s) => new dvec3(a.x / s, a.y / s, a.z / s);

        public static dvec3 operator -(dvec3 v) => new dvec3(-v.x, -v.y, -v.z);
        #endregion

        #region math
        public readonly double distTo(dvec3 o) => (o - this).length;
        public readonly double angleTo(dvec3 o) => (double)Math.Acos(this.dot(o) / (this.length * o.length));
        public readonly dvec3 reflect(dvec3 normal) => this - (normal * 2 * (this.dot(normal) / normal.dot(normal)));
        public dvec3 cross(dvec3 o) => new dvec3(y * o.z - z * o.y, z * o.x - x * o.z, x * o.y - y * o.x);
        #endregion

        #region conversion
        public static implicit operator dvec3((double, double, double) tuple) => new dvec3(tuple.Item1, tuple.Item2, tuple.Item3);
        public static explicit operator ivec3(dvec3 v) => new ivec3((int)v.x, (int)v.y, (int)v.z);
        public static explicit operator vec3(dvec3 v) => new vec3((float)v.x, (float)v.y, (float)v.z);
        public static implicit operator dvec3(double n) => new dvec3(n, n, n);
        #endregion

        #region other
        public override string ToString() => $"({x}, {y}, {z})";
        #endregion
    }
    public static partial class math {
        /// <summary>
        /// Takes the floor of each component in the given dvec3.
        /// </summary>
        public static dvec3 floor(in dvec3 o) => new dvec3(floor(o.x), floor(o.y), floor(o.z));
        /// <summary>
        /// Takes the fract of each component in the given dvec3.
        /// </summary>
        public static dvec3 fract(in dvec3 o) => new dvec3(fract(o.x), fract(o.y), fract(o.z));
        /// <summary>
        /// Takes the sqrt of each component in the given dvec3.
        /// </summary>
        public static dvec3 sqrt(in dvec3 o) => new dvec3(sqrt(o.x), sqrt(o.y), sqrt(o.z));
        /// <summary>
        /// Takes the sin of each component in the given dvec3.
        /// </summary>
        public static dvec3 sin(in dvec3 o) => new dvec3(sin(o.x), sin(o.y), sin(o.z));
        /// <summary>
        /// Takes the cos of each component in the given dvec3.
        /// </summary>
        public static dvec3 cos(in dvec3 o) => new dvec3(cos(o.x), cos(o.y), cos(o.z));
        /// <summary>
        /// Takes the tan of each component in the given dvec3.
        /// </summary>
        public static dvec3 tan(in dvec3 o) => new dvec3(tan(o.x), tan(o.y), tan(o.z));
        /// <summary>
        /// Takes the abs of each component in the given dvec3.
        /// </summary>
        public static dvec3 abs(in dvec3 o) => new dvec3(abs(o.x), abs(o.y), abs(o.z));
        /// <summary>
        /// Linear interpolation of two dvec3 by t.
        /// </summary>
        public static dvec3 lerp(in dvec3 x, in dvec3 y, double t) => x + (y - x) * t;
        /// <summary>
        /// Gets the dvec3 at location t along a curve.
        /// </summary>
        public static dvec3 bezier(in dvec3 a, in dvec3 b, in dvec3 c, double t) => a + ((b - a)*2 + (c - 2*b + a)*t)*t;
    }
}
