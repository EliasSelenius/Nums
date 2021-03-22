using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 4 by 2 matrix
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mat4x2 {

        #region rows and columns
        /// <summary>
        /// The first row in the matrix.
        /// </summary>
        public vec2 row1;
        /// <summary>
        /// The second row in the matrix.
        /// </summary>
        public vec2 row2;
        /// <summary>
        /// The third row in the matrix.
        /// </summary>
        public vec2 row3;
        /// <summary>
        /// The fourth row in the matrix.
        /// </summary>
        public vec2 row4;

        /// <summary>
        /// The first column in the matrix.
        /// </summary>
        public vec4 col1 {
            readonly get => new vec4(row1.x, row2.x, row3.x, row4.x);
            set {
                row1.x = value.x;
                row2.x = value.y;
                row3.x = value.z;
                row4.x = value.w;
            }
        }
        /// <summary>
        /// The second column in the matrix.
        /// </summary>
        public vec4 col2 {
            readonly get => new vec4(row1.y, row2.y, row3.y, row4.y);
            set {
                row1.y = value.x;
                row2.y = value.y;
                row3.y = value.z;
                row4.y = value.w;
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
        /// Gets the value at the third row in the first column
        /// </summary>
        public float m31 {
            readonly get => row3.x;
            set => row3.x = value;
        }
        /// <summary>
        /// Gets the value at the third row in the second column
        /// </summary>
        public float m32 {
            readonly get => row3.y;
            set => row3.y = value;
        }
        /// <summary>
        /// Gets the value at the fourth row in the first column
        /// </summary>
        public float m41 {
            readonly get => row4.x;
            set => row4.x = value;
        }
        /// <summary>
        /// Gets the value at the fourth row in the second column
        /// </summary>
        public float m42 {
            readonly get => row4.y;
            set => row4.y = value;
        }
        #endregion

        /// <summary>
        /// Gets the transpose of this matrix
        /// </summary>
        public readonly mat2x4 transpose => new mat2x4(col1, col2);
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
                2 => row3[c],
                3 => row4[c],
                _ => throw new IndexOutOfRangeException(r + " is not a valid row index for mat4x2")
            };
            set {
                switch(r) {
                    case 0: row1[c] = value; return;
                    case 1: row2[c] = value; return;
                    case 2: row3[c] = value; return;
                    case 3: row4[c] = value; return;
                    default: throw new IndexOutOfRangeException(r + " is not a valid row index for mat4x2");
                }
            }
        }

        public mat4x2(vec2 row1, vec2 row2, vec2 row3, vec2 row4) {
            this.row1 = row1;
            this.row2 = row2;
            this.row3 = row3;
            this.row4 = row4;
        }
        public mat4x2(float m11, float m12, float m21, float m22, float m31, float m32, float m41, float m42) {
            row1.x = m11;
            row1.y = m12;
            row2.x = m21;
            row2.y = m22;
            row3.x = m31;
            row3.y = m32;
            row4.x = m41;
            row4.y = m42;
        }

        #region operators
        /// <summary>
        /// Multiplies a mat4x2 with a vec2.
        /// </summary>
        public static vec4 operator *(mat4x2 m, vec2 v) => new vec4(m.row1.dot(v), m.row2.dot(v), m.row3.dot(v), m.row4.dot(v));
        /// <summary>
        /// Multiplies a vec4 with a mat4x2.
        /// </summary>
        public static vec2 operator *(vec4 v, mat4x2 m ) => new vec2(m.col1.dot(v), m.col2.dot(v));
        /// <summary>
        /// Multiplies a mat4x2 with a mat2.
        /// </summary>
        public static mat4x2 operator *(mat4x2 m1, mat2 m2) => new mat4x2(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row3.dot(m2.col1), m1.row3.dot(m2.col2), m1.row4.dot(m2.col1), m1.row4.dot(m2.col2));
        /// <summary>
        /// Multiplies a mat4x2 with a mat2x3.
        /// </summary>
        public static mat4x3 operator *(mat4x2 m1, mat2x3 m2) => new mat4x3(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3), m1.row3.dot(m2.col1), m1.row3.dot(m2.col2), m1.row3.dot(m2.col3), m1.row4.dot(m2.col1), m1.row4.dot(m2.col2), m1.row4.dot(m2.col3));
        /// <summary>
        /// Multiplies a mat4x2 with a mat2x4.
        /// </summary>
        public static mat4 operator *(mat4x2 m1, mat2x4 m2) => new mat4(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row1.dot(m2.col4), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3), m1.row2.dot(m2.col4), m1.row3.dot(m2.col1), m1.row3.dot(m2.col2), m1.row3.dot(m2.col3), m1.row3.dot(m2.col4), m1.row4.dot(m2.col1), m1.row4.dot(m2.col2), m1.row4.dot(m2.col3), m1.row4.dot(m2.col4));
        /// <summary>
        /// Multiplies all elements of a matrix with a scalar.
        /// </summary>
        public static mat4x2 operator *(mat4x2 m, float s) => new mat4x2(m.row1 * s, m.row2 * s, m.row3 * s, m.row4 * s);
        #endregion
    }
}
