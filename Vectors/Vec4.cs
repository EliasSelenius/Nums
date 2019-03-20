
namespace Nums.Vectors {
    public class Vec4 {
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
    }
}
