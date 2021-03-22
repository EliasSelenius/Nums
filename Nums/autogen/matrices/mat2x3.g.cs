using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 2 by 3 matrix
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mat2x3 {

        #region rows and columns
        /// <summary>
        /// The first row in the matrix.
        /// </summary>
        public vec3 row1;
        /// <summary>
        /// The second row in the matrix.
        /// </summary>
        public vec3 row2;

        /// <summary>
        /// The first column in the matrix.
        /// </summary>
        public vec2 col1 {
            readonly get => new vec2(row1.x, row2.x);
            set {
                row1.x = value.x;
                row2.x = value.y;
            }
        }
        /// <summary>
        /// The second column in the matrix.
        /// </summary>
        public vec2 col2 {
            readonly get => new vec2(row1.y, row2.y);
            set {
                row1.y = value.x;
                row2.y = value.y;
            }
        }
        /// <summary>
        /// The third column in the matrix.
        /// </summary>
        public vec2 col3 {
            readonly get => new vec2(row1.z, row2.z);
            set {
                row1.z = value.x;
                row2.z = value.y;
            }
        }
        #endregion


        #region indexed properties
        /// <summary>
        /// Gets the value at the first row in the first column
        /// </summary>
        public float m11 {
            readonly get => row1.x;
            set => row1.x = value;
        }
        /// <summary>
        /// Gets the value at the first row in the second column
        /// </summary>
        public float m12 {
            readonly get => row1.y;
            set => row1.y = value;
        }
        /// <summary>
        /// Gets the value at the first row in the third column
        /// </summary>
        public float m13 {
            readonly get => row1.z;
            set => row1.z = value;
        }
        /// <summary>
        /// Gets the value at the second row in the first column
        /// </summary>
        public float m21 {
            readonly get => row2.x;
            set => row2.x = value;
        }
        /// <summary>
        /// Gets the value at the second row in the second column
        /// </summary>
        public float m22 {
            readonly get => row2.y;
            set => row2.y = value;
        }
        /// <summary>
        /// Gets the value at the second row in the third column
        /// </summary>
        public float m23 {
            readonly get => row2.z;
            set => row2.z = value;
        }
        #endregion

        /// <summary>
        /// Gets the transpose of this matrix
        /// </summary>
        public readonly mat3x2 transpose => new mat3x2(col1, col2, col3);
        /// <summary>
        /// The number of bytes the matrix type uses.
        /// </summary>
        public const int bytesize = sizeof(float) * 6;
        /// <summary>
        /// Gets or sets the element at row r and column c.
        /// </summary>
        public float this[int r, int c] {
            readonly get => r switch {
                0 => row1[c],
                1 => row2[c],
                _ => throw new IndexOutOfRangeException(r + " is not a valid row index for mat2x3")
            };
            set {
                switch(r) {
                    case 0: row1[c] = value; return;
                    case 1: row2[c] = value; return;
                    default: throw new IndexOutOfRangeException(r + " is not a valid row index for mat2x3");
                }
            }
        }

        public mat2x3(vec3 row1, vec3 row2) {
            this.row1 = row1;
            this.row2 = row2;
        }
        public mat2x3(float m11, float m12, float m13, float m21, float m22, float m23) {
            row1.x = m11;
            row1.y = m12;
            row1.z = m13;
            row2.x = m21;
            row2.y = m22;
            row2.z = m23;
        }

        #region operators
        /// <summary>
        /// Multiplies a mat2x3 with a vec3.
        /// </summary>
        public static vec2 operator *(mat2x3 m, vec3 v) => new vec2(m.row1.dot(v), m.row2.dot(v));
        /// <summary>
        /// Multiplies a vec2 with a mat2x3.
        /// </summary>
        public static vec3 operator *(vec2 v, mat2x3 m ) => new vec3(m.col1.dot(v), m.col2.dot(v), m.col3.dot(v));
        /// <summary>
        /// Multiplies a mat2x3 with a mat3x2.
        /// </summary>
        public static mat2 operator *(mat2x3 m1, mat3x2 m2) => new mat2(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2));
        /// <summary>
        /// Multiplies a mat2x3 with a mat3.
        /// </summary>
        public static mat2x3 operator *(mat2x3 m1, mat3 m2) => new mat2x3(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3));
        /// <summary>
        /// Multiplies a mat2x3 with a mat3x4.
        /// </summary>
        public static mat2x4 operator *(mat2x3 m1, mat3x4 m2) => new mat2x4(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row1.dot(m2.col4), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3), m1.row2.dot(m2.col4));
        /// <summary>
        /// Multiplies all elements of a matrix with a scalar.
        /// </summary>
        public static mat2x3 operator *(mat2x3 m, float s) => new mat2x3(m.row1 * s, m.row2 * s);
        #endregion
    }
}
