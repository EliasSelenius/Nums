using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 2 by 2 matrix
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mat2 {
        /// <summary>
        /// The identity matrix
        /// </summary>
        public static readonly mat2 identity = new mat2(1, 0, 0, 1);

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
        #endregion

        /// <summary>
        /// Gets the transpose of this matrix
        /// </summary>
        public readonly mat2 transpose => new mat2(col1, col2);
        /// <summary>
        /// The number of bytes the matrix type uses.
        /// </summary>
        public const int bytesize = sizeof(float) * 4;
        /// <summary>
        /// Gets or sets the diagonal of the matrix.
        /// </summary>
        public vec2 diagonal {
            readonly get => new vec2(row1.x, row2.y);
            set => (row1.x, row2.y) = (value.x, value.y);
        }
        /// <summary>
        /// Gets the sum of the diagonal.
        /// </summary>
        public readonly float trace => row1.x + row2.y;
        /// <summary>
        /// Gets or sets the element at row r and column c.
        /// </summary>
        public float this[int r, int c] {
            readonly get => r switch {
                0 => row1[c],
                1 => row2[c],
                _ => throw new IndexOutOfRangeException(r + " is not a valid row index for mat2")
            };
            set {
                switch(r) {
                    case 0: row1[c] = value; return;
                    case 1: row2[c] = value; return;
                    default: throw new IndexOutOfRangeException(r + " is not a valid row index for mat2");
                }
            }
        }

        public mat2(vec2 row1, vec2 row2) {
            this.row1 = row1;
            this.row2 = row2;
        }
        public mat2(float m11, float m12, float m21, float m22) {
            row1.x = m11;
            row1.y = m12;
            row2.x = m21;
            row2.y = m22;
        }
        /// <summary>
        /// creates a mat2 from the given mat3
        /// </summary>
        public mat2(mat3 m) {
            row1.x = m.row1.x;
            row1.y = m.row1.y;
            row2.x = m.row2.x;
            row2.y = m.row2.y;
        }
        /// <summary>
        /// creates a mat2 from the given mat4
        /// </summary>
        public mat2(mat4 m) {
            row1.x = m.row1.x;
            row1.y = m.row1.y;
            row2.x = m.row2.x;
            row2.y = m.row2.y;
        }

        #region operators
        /// <summary>
        /// Multiplies a mat2 with a vec2.
        /// </summary>
        public static vec2 operator *(mat2 m, vec2 v) => new vec2(m.row1.dot(v), m.row2.dot(v));
        /// <summary>
        /// Multiplies a vec2 with a mat2.
        /// </summary>
        public static vec2 operator *(vec2 v, mat2 m ) => new vec2(m.col1.dot(v), m.col2.dot(v));
        /// <summary>
        /// Multiplies a mat2 with a mat2.
        /// </summary>
        public static mat2 operator *(mat2 m1, mat2 m2) => new mat2(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2));
        /// <summary>
        /// Multiplies a mat2 with a mat2x3.
        /// </summary>
        public static mat2x3 operator *(mat2 m1, mat2x3 m2) => new mat2x3(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3));
        /// <summary>
        /// Multiplies a mat2 with a mat2x4.
        /// </summary>
        public static mat2x4 operator *(mat2 m1, mat2x4 m2) => new mat2x4(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row1.dot(m2.col4), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3), m1.row2.dot(m2.col4));
        /// <summary>
        /// Multiplies all elements of a matrix with a scalar.
        /// </summary>
        public static mat2 operator *(mat2 m, float s) => new mat2(m.row1 * s, m.row2 * s);
        #endregion
    }
}
