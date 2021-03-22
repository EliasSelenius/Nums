using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 3 by 3 matrix
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mat3 {
        /// <summary>
        /// The identity matrix
        /// </summary>
        public static readonly mat3 identity = new mat3(1, 0, 0, 0, 1, 0, 0, 0, 1);

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
        /// The third row in the matrix.
        /// </summary>
        public vec3 row3;

        /// <summary>
        /// The first column in the matrix.
        /// </summary>
        public vec3 col1 {
            readonly get => new vec3(row1.x, row2.x, row3.x);
            set {
                row1.x = value.x;
                row2.x = value.y;
                row3.x = value.z;
            }
        }
        /// <summary>
        /// The second column in the matrix.
        /// </summary>
        public vec3 col2 {
            readonly get => new vec3(row1.y, row2.y, row3.y);
            set {
                row1.y = value.x;
                row2.y = value.y;
                row3.y = value.z;
            }
        }
        /// <summary>
        /// The third column in the matrix.
        /// </summary>
        public vec3 col3 {
            readonly get => new vec3(row1.z, row2.z, row3.z);
            set {
                row1.z = value.x;
                row2.z = value.y;
                row3.z = value.z;
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
        /// Gets the value at the third row in the third column
        /// </summary>
        public float m33 {
            readonly get => row3.z;
            set => row3.z = value;
        }
        #endregion

        /// <summary>
        /// Gets the transpose of this matrix
        /// </summary>
        public readonly mat3 transpose => new mat3(col1, col2, col3);
        /// <summary>
        /// The number of bytes the matrix type uses.
        /// </summary>
        public const int bytesize = sizeof(float) * 9;
        /// <summary>
        /// Gets or sets the diagonal of the matrix.
        /// </summary>
        public vec3 diagonal {
            readonly get => new vec3(row1.x, row2.y, row3.z);
            set => (row1.x, row2.y, row3.z) = (value.x, value.y, value.z);
        }
        /// <summary>
        /// Gets the sum of the diagonal.
        /// </summary>
        public readonly float trace => row1.x + row2.y + row3.z;
        /// <summary>
        /// Gets or sets the element at row r and column c.
        /// </summary>
        public float this[int r, int c] {
            readonly get => r switch {
                0 => row1[c],
                1 => row2[c],
                2 => row3[c],
                _ => throw new IndexOutOfRangeException(r + " is not a valid row index for mat3")
            };
            set {
                switch(r) {
                    case 0: row1[c] = value; return;
                    case 1: row2[c] = value; return;
                    case 2: row3[c] = value; return;
                    default: throw new IndexOutOfRangeException(r + " is not a valid row index for mat3");
                }
            }
        }

        public mat3(vec3 row1, vec3 row2, vec3 row3) {
            this.row1 = row1;
            this.row2 = row2;
            this.row3 = row3;
        }
        public mat3(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33) {
            row1.x = m11;
            row1.y = m12;
            row1.z = m13;
            row2.x = m21;
            row2.y = m22;
            row2.z = m23;
            row3.x = m31;
            row3.y = m32;
            row3.z = m33;
        }
        /// <summary>
        /// creates a mat3 from the given mat2
        /// </summary>
        public mat3(mat2 m) {
            row1.x = m.row1.x;
            row1.y = m.row1.y;
            row1.z = 0;
            row2.x = m.row2.x;
            row2.y = m.row2.y;
            row2.z = 0;
            row3.x = 0;
            row3.y = 0;
            row3.z = 1;
        }
        /// <summary>
        /// creates a mat3 from the given mat4
        /// </summary>
        public mat3(mat4 m) {
            row1.x = m.row1.x;
            row1.y = m.row1.y;
            row1.z = m.row1.z;
            row2.x = m.row2.x;
            row2.y = m.row2.y;
            row2.z = m.row2.z;
            row3.x = m.row3.x;
            row3.y = m.row3.y;
            row3.z = m.row3.z;
        }

        #region operators
        /// <summary>
        /// Multiplies a mat3 with a vec3.
        /// </summary>
        public static vec3 operator *(mat3 m, vec3 v) => new vec3(m.row1.dot(v), m.row2.dot(v), m.row3.dot(v));
        /// <summary>
        /// Multiplies a vec3 with a mat3.
        /// </summary>
        public static vec3 operator *(vec3 v, mat3 m ) => new vec3(m.col1.dot(v), m.col2.dot(v), m.col3.dot(v));
        /// <summary>
        /// Multiplies a mat3 with a mat3x2.
        /// </summary>
        public static mat3x2 operator *(mat3 m1, mat3x2 m2) => new mat3x2(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row3.dot(m2.col1), m1.row3.dot(m2.col2));
        /// <summary>
        /// Multiplies a mat3 with a mat3.
        /// </summary>
        public static mat3 operator *(mat3 m1, mat3 m2) => new mat3(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3), m1.row3.dot(m2.col1), m1.row3.dot(m2.col2), m1.row3.dot(m2.col3));
        /// <summary>
        /// Multiplies a mat3 with a mat3x4.
        /// </summary>
        public static mat3x4 operator *(mat3 m1, mat3x4 m2) => new mat3x4(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row1.dot(m2.col4), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3), m1.row2.dot(m2.col4), m1.row3.dot(m2.col1), m1.row3.dot(m2.col2), m1.row3.dot(m2.col3), m1.row3.dot(m2.col4));
        /// <summary>
        /// Multiplies all elements of a matrix with a scalar.
        /// </summary>
        public static mat3 operator *(mat3 m, float s) => new mat3(m.row1 * s, m.row2 * s, m.row3 * s);
        #endregion
    }
}
