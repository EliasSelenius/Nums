using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Nums.old {
    [StructLayout(LayoutKind.Sequential)]
    public struct vec4 : IVector<vec4> {

        #region constants
        public static readonly vec4 zero = (0, 0, 0, 0);
        public static readonly vec4 unitX = (1, 0, 0, 0);
        public static readonly vec4 unitY = (0, 1, 0, 0);
        public static readonly vec4 unitZ = (0, 0, 1, 0);
        public static readonly vec4 unitW = (0, 0, 0, 1);
        public static readonly vec4 one = (1, 1, 1, 1);
        #endregion

        public float x, y, z, w;

        public float sum => x + y + z + w;

        public float this[int i] {
            get => i switch
            {
                0 => x,
                1 => y,
                2 => z,
                3 => w,
                _ => throw new IndexOutOfRangeException(i + " is not a valid index for vec4")
            };
            set {
                switch (i) {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    case 3: w = value; break;
                    default: throw new IndexOutOfRangeException(i + " is not a valid index for vec4");
                }
            }
        }

        public int NumberOfElements => 4;
        public int ByteSize => sizeof(float) * NumberOfElements;


        public vec4(float x, float y, float z, float w) {
            this.x = x; this.y = y; this.z = z; this.w = w;
        }


        #region Operators

        #region arithmetic
        public vec4 add(vec4 v) => new vec4(x + v.x, y + v.y, z + v.z, w + v.w);
        public static vec4 operator +(vec4 a, vec4 b) => a.add(b);

        public vec4 divide(vec4 v) => new vec4(x / v.x, y / v.y, z / v.z, w / v.w);
        public static vec4 operator /(vec4 a, vec4 b) => a.divide(b);

        public vec4 divide(float f) => new vec4(x / f, y / f, z / f, w / f);
        public static vec4 operator /(vec4 a, float f) => a.divide(f);

        public vec4 multiply(vec4 v) => new vec4(x * v.x, y * v.y, z * v.z, w * v.w);
        public static vec4 operator *(vec4 a, vec4 b) => a.multiply(b);

        public vec4 multiply(float f) => new vec4(x * f, y * f, z * f, w * f);
        public static vec4 operator *(vec4 a, float f) => a.multiply(f);

        public vec4 subtract(vec4 v) => new vec4(x - v.x, y - v.y, z - v.z, w - v.w);
        public static vec4 operator -(vec4 a, vec4 b) => a.subtract(b);

        public vec4 negate() => new vec4(-x, -y, -z, -w);
        public static vec4 operator -(vec4 a) => a.negate();
        #endregion

        #region boolean
        public bool Equals(vec4 other) => x == other.x && y == other.y && z == other.z && w == other.w;

        #endregion

        #region conversion
        public static implicit operator vec4((float, float, float, float) tuple) => new vec4(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
        #endregion

        #endregion
    }
}
