using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 3 component vector of float
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct vec3 : vec {

        #region constants
        /// <summary>
        /// The zero vector: A vector where all components are equal to zero.
        /// </summary>
        public static readonly vec3 zero = (0, 0, 0);
        /// <summary>
        /// A unit vector pointing in the positive x direction. →
        /// </summary>
        public static readonly vec3 unitx = (1, 0, 0);
        /// <summary>
        /// A unit vector pointing in the positive y direction. ↑
        /// </summary>
        public static readonly vec3 unity = (0, 1, 0);
        /// <summary>
        /// A unit vector pointing in the positive z direction. ↗
        /// </summary>
        public static readonly vec3 unitz = (0, 0, 1);
        /// <summary>
        /// A vector where all components are equal to one.
        /// </summary>
        public static readonly vec3 one = (1, 1, 1);
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
        /// The sum of the vectors components. x + y + z
        /// </summary>
        public readonly float sum => x + y + z;
        /// <summary>
        /// The number of bytes the vector type uses.
        /// </summary>
        public const int bytesize = sizeof(float) * 3;
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
        public readonly vec3 normalized() => this / length;
        /// <summary>
        /// Normalizes this vector.
        /// </summary>
        public void normalize() => this /= length;

        public float this[int i] {
            readonly get => i switch {
                0 => x,
                1 => y,
                2 => z,
                _ => throw new IndexOutOfRangeException("vec3[" + i + "] is not a valid index")
            };
            set {
                switch (i) {
                    case 0: x = value; return;
                    case 1: y = value; return;
                    case 2: z = value; return;
                    default: throw new IndexOutOfRangeException("vec3[" + i + "] is not a valid index");
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
        #endregion

        #region constructors
        public vec3(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public vec3(vec2 xy, float z) {
            this.x = xy.x;
            this.y = xy.y;
            this.z = z;
        }
        public vec3(float x, vec2 yz) {
            this.x = x;
            this.y = yz.x;
            this.z = yz.y;
        }
        #endregion

        #region arithmetic
        public readonly float dot(vec3 v) => (this * v).sum;

        public static vec3 operator *(vec3 a, vec3 b) => new vec3(a.x * b.x, a.y * b.y, a.z * b.z);
        public static vec3 operator /(vec3 a, vec3 b) => new vec3(a.x / b.x, a.y / b.y, a.z / b.z);
        public static vec3 operator +(vec3 a, vec3 b) => new vec3(a.x + b.x, a.y + b.y, a.z + b.z);
        public static vec3 operator -(vec3 a, vec3 b) => new vec3(a.x - b.x, a.y - b.y, a.z - b.z);

        public static vec3 operator *(vec3 a, float s) => new vec3(a.x * s, a.y * s, a.z * s);
        public static vec3 operator /(vec3 a, float s) => new vec3(a.x / s, a.y / s, a.z / s);

        public static vec3 operator -(vec3 v) => new vec3(-v.x, -v.y, -v.z);
        #endregion

        #region math
        public readonly float distTo(vec3 o) => (o - this).length;
        public readonly float angleTo(vec3 o) => (float)Math.Acos(this.dot(o) / (this.length * o.length));
        public readonly vec3 reflect(vec3 normal) => this - (normal * 2 * (this.dot(normal) / normal.dot(normal)));
        public vec3 cross(vec3 o) => new vec3(y * o.z - z * o.y, z * o.x - x * o.z, x * o.y - y * o.x);
        #endregion

        #region conversion/deconstructors
        public static implicit operator vec3((float, float, float) tuple) => new vec3(tuple.Item1, tuple.Item2, tuple.Item3);
        public static explicit operator ivec3(vec3 v) => new ivec3((int)v.x, (int)v.y, (int)v.z);
        public static implicit operator dvec3(vec3 v) => new dvec3(v.x, v.y, v.z);
        public static implicit operator vec3(float n) => new vec3(n, n, n);
        public void Deconstruct(out float x, out float y, out float z) => (x, y, z) = (this.x, this.y, this.z);
        #endregion

        #region other
        public override string ToString() => $"({x}, {y}, {z})";
        #endregion
    }
    public static partial class math {
        /// <summary>
        /// Takes the floor of each component in the given vec3.
        /// </summary>
        public static vec3 floor(in vec3 o) => new vec3(floor(o.x), floor(o.y), floor(o.z));
        /// <summary>
        /// Takes the fract of each component in the given vec3.
        /// </summary>
        public static vec3 fract(in vec3 o) => new vec3(fract(o.x), fract(o.y), fract(o.z));
        /// <summary>
        /// Takes the sqrt of each component in the given vec3.
        /// </summary>
        public static vec3 sqrt(in vec3 o) => new vec3(sqrt(o.x), sqrt(o.y), sqrt(o.z));
        /// <summary>
        /// Takes the pow of each component in the given vec3.
        /// </summary>
        public static vec3 pow(in vec3 a, float b) => new vec3(pow(a.x, b), pow(a.y, b), pow(a.z, b));
        /// <summary>
        /// Takes the sin of each component in the given vec3.
        /// </summary>
        public static vec3 sin(in vec3 o) => new vec3(sin(o.x), sin(o.y), sin(o.z));
        /// <summary>
        /// Takes the cos of each component in the given vec3.
        /// </summary>
        public static vec3 cos(in vec3 o) => new vec3(cos(o.x), cos(o.y), cos(o.z));
        /// <summary>
        /// Takes the tan of each component in the given vec3.
        /// </summary>
        public static vec3 tan(in vec3 o) => new vec3(tan(o.x), tan(o.y), tan(o.z));
        /// <summary>
        /// Takes the abs of each component in the given vec3.
        /// </summary>
        public static vec3 abs(in vec3 o) => new vec3(abs(o.x), abs(o.y), abs(o.z));
        /// <summary>
        /// Takes the min of each component in the given vec3.
        /// </summary>
        public static vec3 min(in vec3 a, in vec3 b) => new vec3(min(a.x, b.x), min(a.y, b.y), min(a.z, b.z));
        /// <summary>
        /// Takes the max of each component in the given vec3.
        /// </summary>
        public static vec3 max(in vec3 a, in vec3 b) => new vec3(max(a.x, b.x), max(a.y, b.y), max(a.z, b.z));
        /// <summary>
        /// Linear interpolation of two vec3 by t.
        /// </summary>
        public static vec3 lerp(in vec3 x, in vec3 y, float t) => x + (y - x) * t;
        /// <summary>
        /// Gets the vec3 at location t along a curve.
        /// </summary>
        public static vec3 bezier(in vec3 a, in vec3 b, in vec3 c, float t) => a + ((b - a)*2 + (c - 2*b + a)*t)*t;
    }
}
