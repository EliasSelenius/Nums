using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Nums.Vectors
{


    /// <summary>
    /// Represents a three component vector
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3 : IVec {
        /// <summary>
        /// A vector component
        /// </summary>
        public float x, y, z;

        /// <summary>
        /// The number of bytes this vector type uses
        /// </summary>
        public const int ByteSize = sizeof(float) * 3;

        /// <summary>
        /// The sum of all vector components
        /// </summary>
        public float Sum => x + y + z;


        #region Const Vectors

        /// <summary>
        /// The [0, 0, 0] vector
        /// </summary>
        public static readonly Vec3 Zero = new Vec3(0);
        /// <summary>
        /// The [1, 1, 1] vector
        /// </summary>
        public static readonly Vec3 One = new Vec3(1);
        /// <summary>
        /// The [1, 0, 0] vector
        /// </summary>
        public static readonly Vec3 UnitX = new Vec3(1, 0, 0);
        /// <summary>
        /// The [0, 1, 0] vector
        /// </summary>
        public static readonly Vec3 UnitY = new Vec3(0, 1, 0);
        /// <summary>
        /// The [0, 0, 1] vector
        /// </summary>
        public static readonly Vec3 UnitZ = new Vec3(0, 0, 1);

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a vector from given components
        /// </summary>
        /// <param name="_x">The vectors x component</param>
        /// <param name="_y">The vectors y component</param>
        /// <param name="_z">The vectors z component</param>
        public Vec3(float _x, float _y, float _z) {
            x = _x; y = _y; z = _z;
        }

        /// <summary>
        /// Creates a vector from given components
        /// </summary>
        /// <param name="_x">The vectors x component</param>
        /// <param name="_y">The vectors y component</param>
        public Vec3(float _x, float _y) {
            x = _x; y = _y; z = 0;
        }

        /// <summary>
        /// Creates a vector where all components are equal to the given param
        /// </summary>
        /// <param name="xyz">The value of all the vector components</param>
        public Vec3(float xyz) {
            x = y = z = xyz;
        }

        #endregion

        #region Operators

        /*
        public static implicit operator Vec3(float[] array) {
            //return new Vec3(array[0], array[1], array[2]);
            return null;
        }*/

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
                throw new IndexOutOfRangeException(index + " is not a valid vector index");
            set {
                if (index == 0) x = value;
                else if (index == 1) y = value;
                else if (index == 2) z = value;
                else throw new IndexOutOfRangeException(index + " is not a valid vector index");
            }
        }
            


        /// <summary>
        /// Multiplies each component of a vector with a float
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vec3 operator *(Vec3 a, float b) => new Vec3(a.x * b, a.y * b, a.z * b);
        /// <summary>
        /// Devides each component of a vector with a float
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vec3 operator /(Vec3 a, float b) => new Vec3(a.x / b, a.y / b, a.z / b);
        /// <summary>
        /// Multiplies each component of a vector with each component of another vector
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vec3 operator *(Vec3 a, Vec3 b) => new Vec3(a.x * b.x, a.y * b.y, a.z * b.z);
        /// <summary>
        /// Devides each component of a vector with each component of another vector
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vec3 operator /(Vec3 a, Vec3 b) => new Vec3(a.x / b.x, a.y / b.y, a.z / b.z);
        /// <summary>
        /// Adds each component of a vector with each component of another vector
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vec3 operator +(Vec3 a, Vec3 b) => new Vec3(a.x + b.x, a.y + b.y, a.z + b.z);
        /// <summary>
        /// Subtracts each component of a vector with each component of another vector
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vec3 operator -(Vec3 a, Vec3 b) => new Vec3(a.x - b.x, a.y - b.y, a.z - b.z);
        /// <summary>
        /// Negates each component of a vector
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Vec3 operator -(Vec3 a) => new Vec3(-a.x, -a.y, -a.z);

        #endregion

        #region Math operands

        #region Dot product
        /// <summary>
        /// Calculates two vectors dot product
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>The dot product</returns>
        public static float Dot(Vec3 a, Vec3 b) => (a * b).Sum;
        /// <summary>
        /// Calculates two vectors dot product
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <returns>The dot product</returns>
        public static float Dot(float x1, float y1, float z1, float x2, float y2, float z2) =>
            (x1 * x2) + (y1 * y2) + (z1 * z2);
        /// <summary>
        /// Calculates the vectors dot product with another vector
        /// </summary>
        /// <param name="a"></param>
        /// <returns>The dot product</returns>
        public float Dot(Vec3 a) => Dot(this, a);
        /// <summary>
        /// Calculates the vectors dot product with another vector
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="_z"></param>
        /// <returns>The dot product</returns>
        public float Dot(float _x, float _y, float _z) => Dot(this, new Vec3(_x, _y, _z));

        #endregion

        #region Cross product

        /// <summary>
        /// Calculates two vectors cross product
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>The cross product vector</returns>
        public static Vec3 Cross(Vec3 a, Vec3 b) =>
            new Vec3(
                a.y * b.z - a.z * b.y,
                a.z * b.x - a.x * b.z,
                a.x * b.y - a.y * b.x);

        /// <summary>
        /// Calculates the vectors cross product with another vector
        /// </summary>
        /// <param name="a"></param>
        /// <returns>The cross product vector</returns>
        public Vec3 Cross(Vec3 a) => Cross(this, a);
        /// <summary>
        /// Calculates the vectors cross product with another vector
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="_z"></param>
        /// <returns></returns>
        public Vec3 Cross(float _x, float _y, float _z) => Cross(this, new Vec3(_x, _y, _z));

        #endregion

        #region Magnitudes
        /// <summary>
        /// Finds the square magnitude of a vector
        /// </summary>
        /// <param name="a"></param>
        /// <returns>The square magnitude</returns>
        public static float SqMagnitudeOf(Vec3 a) => a.Dot(a);
        /// <summary>
        /// Finds the square magnitude of a vector
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="_z"></param>
        /// <returns>The square magnitude</returns>
        public static float SqMagnitudeOf(float _x, float _y, float _z) => (_x * _x) + (_y * _y) + (_z * _z);
        /// <summary>
        /// Finds the magnitude of a vector
        /// </summary>
        /// <param name="a"></param>
        /// <returns>The magnitude</returns>
        public static float MagnitudeOf(Vec3 a) => (float)Math.Sqrt(SqMagnitudeOf(a));
        /// <summary>
        /// Finds the magnitude of a vector
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="_z"></param>
        /// <returns>The magnitude</returns>
        public static float MagnitudeOf(float _x, float _y, float _z) => (float)Math.Sqrt(SqMagnitudeOf(_x, _y, _z));

        /// <summary>
        /// This vectors square magnitude
        /// </summary>
        public float SqMagnitude => SqMagnitudeOf(this);
        /// <summary>
        /// This vectors magnitude
        /// </summary>
        public float Magnitude => MagnitudeOf(this);

        #endregion

        #region Normalize 

        /// <summary>
        /// Gets the normalized version of the vector
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Vec3 UnitVecOf(Vec3 a) => a / a.Magnitude;
        /// <summary>
        /// Gets the normalized version of the vector
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="_z"></param>
        /// <returns></returns>
        public static Vec3 UnitVecOf(float _x, float _y, float _z) {
            var mag = Vec3.MagnitudeOf(_x, _y, _z);
            return new Vec3(_x / mag, _y / mag, _z / mag);
        }
        /// <summary>
        /// Normalize this vector
        /// </summary>
        public void Normalize() {
            this = Normalized;
        }
        /// <summary>
        /// Normalized version of this vector
        /// </summary>
        public Vec3 Normalized => UnitVecOf(this);

        #endregion

        #region Distances

        /// <summary>
        /// Calculates the distance between two vectors
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float DistBetween(Vec3 a, Vec3 b) => (a - b).Magnitude;
        /// <summary>
        /// Calculates the distance between two vectors
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <returns></returns>
        public static float DistBetween(float x1, float y1, float z1, float x2, float y2, float z2) => Vec3.MagnitudeOf(x1 - x2, y1 - y2, z1 - z2);
        /// <summary>
        /// Calculates the distance to another vector
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public float DistTo(Vec3 a) => Vec3.DistBetween(this, a);
        /// <summary>
        /// Calculates the distance to another vector
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="_z"></param>
        /// <returns></returns>
        public float DistTo(float _x, float _y, float _z) => Vec3.DistBetween(x, y, z, _x, _y, _z);

        #endregion

        #region Angles

        /// <summary>
        /// Calculates the angle between two vectors
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float AngleBetween(Vec3 a, Vec3 b) => (float)Math.Acos(Vec3.Dot(a, b) / (a.Magnitude * b.Magnitude));
        /// <summary>
        /// Calculates the angle between two vectors
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <returns></returns>
        public static float AngleBetween(float x1, float y1, float z1, float x2, float y2, float z2) =>
            (float)Math.Acos(Vec3.Dot(x1, y1, z1, x2, y2, z2) / (Vec3.MagnitudeOf(x1, y1, z1) * Vec3.MagnitudeOf(x2, y2, z2)));

        /// <summary>
        /// Calculates the angle to another vector
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public float AngleTo(Vec3 a) => Vec3.AngleBetween(this, a);
        /// <summary>
        /// Calculates the angle to another vector
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="_z"></param>
        /// <returns></returns>
        public float AngleTo(float _x, float _y, float _z) => Vec3.AngleBetween(x, y, z, _x, _y, _z);

        #endregion

        #region Lerp

        /// <summary>
        /// linearly interpolate between two vectors. Where time = 0 is vector a, and time = 1 is vector b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static Vec3 Lerp(Vec3 a, Vec3 b, float time) => a + ((b - a) * time);
        /// <summary>
        /// linearly interpolate between two vectors. Where time = 0 is the first vector, and time = 1 is the last vector
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static Vec3 Lerp(float x1, float y1, float z1, float x2, float y2, float z2, float time) => 
            Vec3.Lerp(new Vec3(x1, y1, z1), new Vec3(x2, y2, z2), time);

        /// <summary>
        /// linearly interpolates to another vector. Where time = 0 is this vector, and time = 1 is the other vector
        /// </summary>
        /// <param name="a"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public Vec3 Lerp(Vec3 a, float time) => Vec3.Lerp(this, a, time);
        /// <summary>
        /// linearly interpolates to another vector. Where time = 0 is this vector, and time = 1 is the other vector
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="_z"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public Vec3 Lerp(float _x, float _y, float _z, float time) => this.Lerp(new Vec3(_x, _y, _z), time);



        #endregion

        #endregion

        /// <summary>
        /// Is obj equal to this object?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) => (obj is Vec3 o) ? o.x == x && o.y == y && o.z == z : false;
        
        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode();

        /// <summary>
        /// Returns a string that represents the current vector.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"({x}, {y}, {z})";

    }
}
