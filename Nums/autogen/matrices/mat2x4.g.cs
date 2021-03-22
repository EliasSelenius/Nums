using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 2 by 4 matrix
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mat2x4 {

        #region rows and columns
        /// <summary>
        /// The first row in the matrix.
        /// </summary>
        public vec4 row1;
        /// <summary>
        /// The second row in the matrix.
        /// </summary>
        public vec4 row2;

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
        /// <summary>
        /// The fourth column in the matrix.
        /// </summary>
        public vec2 col4 {
            readonly get => new vec2(row1.w, row2.w);
            set {
                row1.w = value.x;
                row2.w = value.y;
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
        /// Gets the value at the first row in the fourth column
        /// </summary>
        public float m14 {
            readonly get => row1.w;
            set => row1.w = value;
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
        /// <summary>
        /// Gets the value at the second row in the fourth column
        /// </summary>
        public float m24 {
            readonly get => row2.w;
            set => row2.w = value;
        }
        #endregion

        /// <summary>
        /// Gets the transpose of this matrix
        /// </summary>
        public readonly mat4x2 transpose => new mat4x2(col1, col2, col3, col4);
        /// <summary>
        /// The number of bytes the matrix type uses.
        /// </summary>
        public const int bytesize = sizeof(float) * 8;
        /// <summary>
        /// Gets or sets the element at row r and column c.
        /// </summary>
        public float this[int r, int c] {
            readonly get => r switch {
                0 => row1[c],
                1 => row2[c],
                _ => throw new IndexOutOfRangeException(r + " is not a valid row index for mat2x4")
            };
            set {
                switch(r) {
                    case 0: row1[c] = value; return;
                    case 1: row2[c] = value; return;
                    default: throw new IndexOutOfRangeException(r + " is not a valid row index for mat2x4");
                }
            }
        }

        public mat2x4(vec4 row1, vec4 row2) {
            this.row1 = row1;
            this.row2 = row2;
        }
        public mat2x4(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24) {
            row1.x = m11;
            row1.y = m12;
            row1.z = m13;
            row1.w = m14;
            row2.x = m21;
            row2.y = m22;
            row2.z = m23;
            row2.w = m24;
        }

        #region operators
        /// <summary>
        /// Multiplies a mat2x4 with a vec4.
        /// </summary>
        public static vec2 operator *(mat2x4 m, vec4 v) => new vec2(m.row1.dot(v), m.row2.dot(v));
        /// <summary>
        /// Multiplies a vec2 with a mat2x4.
        /// </summary>
        public static vec4 operator *(vec2 v, mat2x4 m ) => new vec4(m.col1.dot(v), m.col2.dot(v), m.col3.dot(v), m.col4.dot(v));
        /// <summary>
        /// Multiplies a mat2x4 with a mat4x2.
        /// </summary>
        public static mat2 operator *(mat2x4 m1, mat4x2 m2) => new mat2(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2));
        /// <summary>
        /// Multiplies a mat2x4 with a mat4x3.
        /// </summary>
        public static mat2x3 operator *(mat2x4 m1, mat4x3 m2) => new mat2x3(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3));
        /// <summary>
        /// Multiplies a mat2x4 with a mat4.
        /// </summary>
        public static mat2x4 operator *(mat2x4 m1, mat4 m2) => new mat2x4(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row1.dot(m2.col4), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3), m1.row2.dot(m2.col4));
        /// <summary>
        /// Multiplies all elements of a matrix with a scalar.
        /// </summary>
        public static mat2x4 operator *(mat2x4 m, float s) => new mat2x4(m.row1 * s, m.row2 * s);
        #endregion
    }
}
