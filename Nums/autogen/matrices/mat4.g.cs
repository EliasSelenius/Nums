using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 4 by 4 matrix
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mat4 {
        /// <summary>
        /// The identity matrix
        /// </summary>
        public static readonly mat4 identity = new mat4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);

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
        /// The third row in the matrix.
        /// </summary>
        public vec4 row3;
        /// <summary>
        /// The fourth row in the matrix.
        /// </summary>
        public vec4 row4;

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
        /// <summary>
        /// The third column in the matrix.
        /// </summary>
        public vec4 col3 {
            readonly get => new vec4(row1.z, row2.z, row3.z, row4.z);
            set {
                row1.z = value.x;
                row2.z = value.y;
                row3.z = value.z;
                row4.z = value.w;
            }
        }
        /// <summary>
        /// The fourth column in the matrix.
        /// </summary>
        public vec4 col4 {
            readonly get => new vec4(row1.w, row2.w, row3.w, row4.w);
            set {
                row1.w = value.x;
                row2.w = value.y;
                row3.w = value.z;
                row4.w = value.w;
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
        /// <summary>
        /// Gets the value at the third row in the fourth column
        /// </summary>
        public float m34 {
            readonly get => row3.w;
            set => row3.w = value;
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
        /// <summary>
        /// Gets the value at the fourth row in the third column
        /// </summary>
        public float m43 {
            readonly get => row4.z;
            set => row4.z = value;
        }
        /// <summary>
        /// Gets the value at the fourth row in the fourth column
        /// </summary>
        public float m44 {
            readonly get => row4.w;
            set => row4.w = value;
        }
        #endregion

        /// <summary>
        /// Gets the transpose of this matrix
        /// </summary>
        public readonly mat4 transpose => new mat4(col1, col2, col3, col4);
        /// <summary>
        /// The number of bytes the matrix type uses.
        /// </summary>
        public const int bytesize = sizeof(float) * 16;
        /// <summary>
        /// Gets or sets the diagonal of the matrix.
        /// </summary>
        public vec4 diagonal {
            readonly get => new vec4(row1.x, row2.y, row3.z, row4.w);
            set => (row1.x, row2.y, row3.z, row4.w) = (value.x, value.y, value.z, value.w);
        }
        /// <summary>
        /// Gets the sum of the diagonal.
        /// </summary>
        public readonly float trace => row1.x + row2.y + row3.z + row4.w;
        /// <summary>
        /// Gets the scale of this transformation matrix.
        /// </summary>
        public vec3 getScale() => new vec3(row1.xyz.length, row2.xyz.length, row3.xyz.length);
        /// <summary>
        /// Gets the translation of this transformation matrix.
        /// </summary>
        public vec3 getTranslation() => row4.xyz;
        /// <summary>
        /// Gets the rotation of this transformation matrix.
        /// </summary>
        // TODO: implement... 
        /// <summary>
        /// Clears the scale of this transformation matrix.
        /// </summary>
        public void clearScale() {
            row1.xyz /= row1.xyz.length;
            row2.xyz /= row2.xyz.length;
            row3.xyz /= row3.xyz.length;
        }
        /// <summary>
        /// Clears the translation of this transformation matrix.
        /// </summary>
        public void clearTranslation() => row4.xyz = vec3.zero;
        /// <summary>
        /// Clears the rotation of this transformation matrix.
        /// </summary>
        public void clearRotation() {
            row1.xyz = new vec3(row1.xyz.length, 0, 0);
            row2.xyz = new vec3(0, row1.xyz.length, 0);
            row3.xyz = new vec3(0, 0, row1.xyz.length);
        }
        /// <summary>
        /// Gets or sets the element at row r and column c.
        /// </summary>
        public float this[int r, int c] {
            readonly get => r switch {
                0 => row1[c],
                1 => row2[c],
                2 => row3[c],
                3 => row4[c],
                _ => throw new IndexOutOfRangeException(r + " is not a valid row index for mat4")
            };
            set {
                switch(r) {
                    case 0: row1[c] = value; return;
                    case 1: row2[c] = value; return;
                    case 2: row3[c] = value; return;
                    case 3: row4[c] = value; return;
                    default: throw new IndexOutOfRangeException(r + " is not a valid row index for mat4");
                }
            }
        }

        public mat4(vec4 row1, vec4 row2, vec4 row3, vec4 row4) {
            this.row1 = row1;
            this.row2 = row2;
            this.row3 = row3;
            this.row4 = row4;
        }
        public mat4(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24, float m31, float m32, float m33, float m34, float m41, float m42, float m43, float m44) {
            row1.x = m11;
            row1.y = m12;
            row1.z = m13;
            row1.w = m14;
            row2.x = m21;
            row2.y = m22;
            row2.z = m23;
            row2.w = m24;
            row3.x = m31;
            row3.y = m32;
            row3.z = m33;
            row3.w = m34;
            row4.x = m41;
            row4.y = m42;
            row4.z = m43;
            row4.w = m44;
        }
        /// <summary>
        /// creates a mat4 from the given mat2
        /// </summary>
        public mat4(mat2 m) {
            row1.x = m.row1.x;
            row1.y = m.row1.y;
            row1.z = 0;
            row1.w = 0;
            row2.x = m.row2.x;
            row2.y = m.row2.y;
            row2.z = 0;
            row2.w = 0;
            row3.x = 0;
            row3.y = 0;
            row3.z = 1;
            row3.w = 0;
            row4.x = 0;
            row4.y = 0;
            row4.z = 0;
            row4.w = 1;
        }
        /// <summary>
        /// creates a mat4 from the given mat3
        /// </summary>
        public mat4(mat3 m) {
            row1.x = m.row1.x;
            row1.y = m.row1.y;
            row1.z = m.row1.z;
            row1.w = 0;
            row2.x = m.row2.x;
            row2.y = m.row2.y;
            row2.z = m.row2.z;
            row2.w = 0;
            row3.x = m.row3.x;
            row3.y = m.row3.y;
            row3.z = m.row3.z;
            row3.w = 0;
            row4.x = 0;
            row4.y = 0;
            row4.z = 0;
            row4.w = 1;
        }

        #region operators
        /// <summary>
        /// Multiplies a mat4 with a vec4.
        /// </summary>
        public static vec4 operator *(mat4 m, vec4 v) => new vec4(m.row1.dot(v), m.row2.dot(v), m.row3.dot(v), m.row4.dot(v));
        /// <summary>
        /// Multiplies a vec4 with a mat4.
        /// </summary>
        public static vec4 operator *(vec4 v, mat4 m ) => new vec4(m.col1.dot(v), m.col2.dot(v), m.col3.dot(v), m.col4.dot(v));
        /// <summary>
        /// Multiplies a mat4 with a mat4x2.
        /// </summary>
        public static mat4x2 operator *(mat4 m1, mat4x2 m2) => new mat4x2(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row3.dot(m2.col1), m1.row3.dot(m2.col2), m1.row4.dot(m2.col1), m1.row4.dot(m2.col2));
        /// <summary>
        /// Multiplies a mat4 with a mat4x3.
        /// </summary>
        public static mat4x3 operator *(mat4 m1, mat4x3 m2) => new mat4x3(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3), m1.row3.dot(m2.col1), m1.row3.dot(m2.col2), m1.row3.dot(m2.col3), m1.row4.dot(m2.col1), m1.row4.dot(m2.col2), m1.row4.dot(m2.col3));
        /// <summary>
        /// Multiplies a mat4 with a mat4.
        /// </summary>
        public static mat4 operator *(mat4 m1, mat4 m2) => new mat4(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row1.dot(m2.col4), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3), m1.row2.dot(m2.col4), m1.row3.dot(m2.col1), m1.row3.dot(m2.col2), m1.row3.dot(m2.col3), m1.row3.dot(m2.col4), m1.row4.dot(m2.col1), m1.row4.dot(m2.col2), m1.row4.dot(m2.col3), m1.row4.dot(m2.col4));
        /// <summary>
        /// Multiplies all elements of a matrix with a scalar.
        /// </summary>
        public static mat4 operator *(mat4 m, float s) => new mat4(m.row1 * s, m.row2 * s, m.row3 * s, m.row4 * s);
        #endregion
    }
}
