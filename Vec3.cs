using System;

namespace Nums
{
    public struct Vec3 {
        public float x, y, z;

        public const int ByteSize = sizeof(float) * 3;


        public Vec3(float xyz) => x = y = z = xyz;
        public Vec3(float X, float Y, float Z) {
            x = X; y = Y; z = Z;
        }
        public Vec3(Vec3 copy) => this = copy;

        public void Set(float xyz) => x = y = z = xyz;
        public void Set(float X, float Y, float Z) { x = X; y = Y; z = Z; }

        public static Vec3 operator *(Vec3 a, float b) => new Vec3(a.x * b, a.y * b, a.z * b);
        public static Vec3 operator /(Vec3 a, float b) => new Vec3(a.x / b, a.y / b, a.z / b);
        public static Vec3 operator *(Vec3 a, Vec3 b) => new Vec3(a.x * b.x, a.y * b.y, a.z * b.z);
        public static Vec3 operator /(Vec3 a, Vec3 b) => new Vec3(a.x / b.x, a.y / b.y, a.z / b.z);
        public static Vec3 operator +(Vec3 a, Vec3 b) => new Vec3(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Vec3 operator -(Vec3 a, Vec3 b) => new Vec3(a.x - b.x, a.y - b.y, a.z - b.z);
        public static Vec3 operator -(Vec3 a) => new Vec3(-a.x, -a.y, -a.z);


        public static readonly Vec3 Zero = new Vec3(0);
        public static readonly Vec3 One = new Vec3(1);
        public static readonly Vec3 UnitX = new Vec3(1, 0, 0);
        public static readonly Vec3 UnitY = new Vec3(0, 1, 0);
        public static readonly Vec3 UnitZ = new Vec3(0, 0, 1);


        public Vec3 Cross(Vec3 v) => new Vec3(y * v.z - z * v.y,
                       z * v.x - x * v.z,
                       x * v.y - y * v.x);
        public static Vec3 Cross(Vec3 a, Vec3 b) => a.Cross(b);

        public float Dot(Vec3 v) => Dot(v.x, v.y, v.z);
        public float Dot(float X, float Y, float Z) => x * X + y * Y + z * Z;

        public float Magnitude => (float)Math.Sqrt(Dot(this));
        public float SqMagnitude => Dot(this);

        public Vec3 Normalize() => this /= Magnitude;
        public Vec3 Normalized {
            get {
                Vec3 v = new Vec3(x, y, z);
                return v /= Magnitude;
            }
        }

        public float DistanceTo(Vec3 v) => (this - v).Magnitude;
        public static float DistanceBetween(Vec3 a, Vec3 b) => a.DistanceTo(b);

        public float AngleTo(Vec3 v) => (float)Math.Acos(Dot(v) / (Magnitude * v.Magnitude));
        public static float AngleBetween(Vec3 a, Vec3 b) => a.AngleTo(b);

        public override string ToString() => $"({x}, {y}, {z})";
    }
}
