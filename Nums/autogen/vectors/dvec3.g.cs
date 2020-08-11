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
        public double sum => x + y + z;
        /// <summary>
        /// The number of bytes the vector type uses.
        /// </summary>
        public const int bytesize = sizeof(double) * 3;
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
        public dvec3 normalized() => this / length;
        /// <summary>
        /// Normalizes this vector.
        /// </summary>
        public void normalize() => this /= length;

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
        public dvec3 reflect(dvec3 normal) => this - (normal * 2 * (this.dot(normal) / normal.dot(normal)));
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
        public static dvec3 floor(dvec3 o) => new dvec3(floor(o.x), floor(o.y), floor(o.z));
        public static dvec3 fract(dvec3 o) => new dvec3(fract(o.x), fract(o.y), fract(o.z));
        public static dvec3 abs(dvec3 o) => new dvec3(abs(o.x), abs(o.y), abs(o.z));
        public static dvec3 sqrt(dvec3 o) => new dvec3(sqrt(o.x), sqrt(o.y), sqrt(o.z));
        public static dvec3 sin(dvec3 o) => new dvec3(sin(o.x), sin(o.y), sin(o.z));
        public static dvec3 cos(dvec3 o) => new dvec3(cos(o.x), cos(o.y), cos(o.z));
        public static dvec3 tan(dvec3 o) => new dvec3(tan(o.x), tan(o.y), tan(o.z));
    }
}
