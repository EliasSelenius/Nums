﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Nums {
    [StructLayout(LayoutKind.Sequential)]
    public struct vec3 : IVector<vec3> {

        #region constants
        public static readonly vec3 zero = (0, 0, 0);
        public static readonly vec3 unitX = (1, 0, 0);
        public static readonly vec3 unitY = (0, 1, 0);
        public static readonly vec3 unitZ = (0, 0, 1);
        public static readonly vec3 one = (1, 1, 1);
        #endregion

        public float x, y, z;

        public float sum => x + y + z;

        public vec3(float x, float y, float z) {
            this.x = x; this.y = y; this.z = z;
        }

        #region Operators

        #region arithmetic
        public vec3 add(vec3 v) => new vec3(x + v.x, y + v.y, z + v.z);
        public static vec3 operator +(vec3 a, vec3 b) => a.add(b);

        public vec3 divide(vec3 v) => new vec3(x / v.x, y / v.y, z / v.z);
        public static vec3 operator /(vec3 a, vec3 b) => a.divide(b);

        public vec3 divide(float f) => new vec3(x / f, y / f, z / f);
        public static vec3 operator /(vec3 a, float f) => a.divide(f);

        public vec3 multiply(vec3 v) => new vec3(x * v.x, y * v.y, z * v.z);
        public static vec3 operator *(vec3 a, vec3 b) => a.multiply(b);

        public vec3 multiply(float f) => new vec3(x * f, y * f, z * f);
        public static vec3 operator *(vec3 a, float f) => a.multiply(f);

        public vec3 subtract(vec3 v) => new vec3(x - v.x, y - v.y, z - v.z);
        public static vec3 operator -(vec3 a, vec3 b) => a.subtract(b);

        public vec3 negate() => new vec3(-x, -y, -z);
        public static vec3 operator -(vec3 a) => a.negate();
        #endregion

        #region boolean
        public bool Equals(vec3 other) => x == other.x && y == other.y && z == other.z;

        #endregion

        #region conversion
        public static implicit operator vec3((float, float, float) tuple) => new vec3(tuple.Item1, tuple.Item2, tuple.Item3);
        #endregion

        #endregion
    }
}