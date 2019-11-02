
using static System.Math;
using System.Runtime.InteropServices;

namespace Nums.Vectors {
    /*public class Vec4 {
        public float x, y, z, w;

        public const int ByteSize = sizeof(float) * 4;

        public Vec4() { x = y = z = w = 0; }
        public Vec4(float xyzw) => x = y = z = w = xyzw;
        public Vec4(float X, float Y, float Z, float W) {
            x = X; y = Y; z = Z; w = W;
        }

        public Vec3 xyz { get { return new Vec3(x, y, z); } set { x = value.x; y = value.y; z = value.z; } }

        public static readonly Vec4 Zero = new Vec4(0);
        public static readonly Vec4 One = new Vec4(1);
        public static readonly Vec4 UnitX = new Vec4(1, 0, 0, 0);
        public static readonly Vec4 UnitY = new Vec4(0, 1, 0, 0);
        public static readonly Vec4 UnitZ = new Vec4(0, 0, 1, 0);
        public static readonly Vec4 UnitW = new Vec4(0, 0, 0, 1);

        public override string ToString() => $"({x}, {y}, {z}, {w})";
    }*/

    /// <summary>
    /// Represents a four component vector
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec4 : IVec {
        /// <summary>
        /// A vector component
        /// </summary>
        public float x, y, z, w;

        /// <summary>
        /// The first three components of this vector 
        /// </summary>
        public Vec3 xyz {
            get => new Vec3(x, y, z);
            set {
                x = value.x;
                y = value.y;
                z = value.z;
            }
        }

        /// <summary>
        /// The number of bytes this vector type uses
        /// </summary>
        public const int ByteSize = sizeof(float) * 4;

        /// <summary>
        /// The sum of all vector components
        /// </summary>
        public float Sum => x + y + z + w;


        #region Const Vectors

        /// <summary>
        /// The [0, 0, 0, 0] vector
        /// </summary>
        public static readonly Vec4 Zero = new Vec4(0);
        /// <summary>
        /// The [1, 1, 1, 1] vector
        /// </summary>
        public static readonly Vec4 One = new Vec4(1);
        /// <summary>
        /// The [1, 0, 0, 0] vector
        /// </summary>
        public static readonly Vec4 UnitX = new Vec4(1, 0, 0, 0);
        /// <summary>
        /// The [0, 1, 0, 0] vector
        /// </summary>
        public static readonly Vec4 UnitY = new Vec4(0, 1, 0, 0);
        /// <summary>
        /// The [0, 0, 1, 0] vector
        /// </summary>
        public static readonly Vec4 UnitZ = new Vec4(0, 0, 1, 0);
        /// <summary>
        /// The [0, 0, 0, 1] vector
        /// </summary>
        public static readonly Vec4 UnitW = new Vec4(0, 0, 0, 1);

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a vector from given components
        /// </summary>
        /// <param name="_x">The vectors x component</param>
        /// <param name="_y">The vectors y component</param>
        /// <param name="_z">The vectors z component</param>
        /// <param name="_w">The vectors w component</param>
        public Vec4(float _x, float _y, float _z, float _w) {
            x = _x; y = _y; z = _z; w = _w;
        }


        /// <summary>
        /// Creates a vector where all components are equal to the given param
        /// </summary>
        /// <param name="xyzw">The value of all the vector components</param>
        public Vec4(float xyzw) => x = y = z = w = xyzw;

        #endregion

        #region SetOperations

        public void Set(float xyzw) => x = y = z = w = xyzw;
        
        public void Set(float _x, float _y, float _z, float _w) {
            x = _x; y = _y; z = _z; w = _w;
        }

        public void Set(Vec3 _xyz, float _w) {
            xyz = _xyz; w = _w;
        }

        #endregion

        #region Operators 

        /// <summary>
        /// Fetch this vectors component by its index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public float this[int index] {
            get =>
                index == 0 ? x :
                index == 1 ? y :
                index == 2 ? z :
                index == 3 ? w :
                throw new System.IndexOutOfRangeException(index + " is not a valid vector index");
            set {
                if (index == 0) x = value;
                else if (index == 1) y = value;
                else if (index == 2) z = value;
                else if (index == 3) w = value;
                else throw new System.IndexOutOfRangeException(index + " is not a valid vector index");
            }
        }


        /// <summary>
        /// Multiplies each component of a vector with each component of another vector
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vec4 operator *(Vec4 a, Vec4 b) => new Vec4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);



        #endregion

        #region Magnitudes

        public float SqMagnitude => this.Dot(this);

        public float Magnitude => (float)Sqrt(SqMagnitude);

        #endregion

        #region Dot product

        /// <summary>
        /// Gets the dot product of the two vectors
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static float Dot(Vec4 left, Vec4 right) => (left * right).Sum;
        /// <summary>
        /// Gets the dot product with another vector
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public float Dot(Vec4 other) => (this * other).Sum;



        #endregion

        /// <summary>
        /// Is obj equal to this object?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) => (obj is Vec4 o) ? o.x == x && o.y == y && o.z == z && o.w == w : false;

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode() ^ w.GetHashCode();

        /// <summary>
        /// Returns a string that represents the current vector.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"({x}, {y}, {z}, {w})";

    }
}
