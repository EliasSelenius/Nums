using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 4 by 4 matrix
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct dmat4 {
        /// <summary>
        /// The identity matrix
        /// </summary>
        public static readonly dmat4 identity = new dmat4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);

        #region rows and columns
        /// <summary>
        /// The first row in the matrix.
        /// </summary>
        public dvec4 row1;
        /// <summary>
        /// The second row in the matrix.
        /// </summary>
        public dvec4 row2;
        /// <summary>
        /// The third row in the matrix.
        /// </summary>
        public dvec4 row3;
        /// <summary>
        /// The fourth row in the matrix.
        /// </summary>
        public dvec4 row4;

        /// <summary>
        /// The first column in the matrix.
        /// </summary>
        public dvec4 col1 {
            readonly get => new dvec4(row1.x, row2.x, row3.x, row4.x);
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
        public dvec4 col2 {
            readonly get => new dvec4(row1.y, row2.y, row3.y, row4.y);
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
        public dvec4 col3 {
            readonly get => new dvec4(row1.z, row2.z, row3.z, row4.z);
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
        public dvec4 col4 {
            readonly get => new dvec4(row1.w, row2.w, row3.w, row4.w);
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
        public double m11 {
            readonly get => row1.x;
            set => row1.x = value;
        }
        /// <summary>
        /// Gets the value at the first row in the second column
        /// </summary>
        public double m12 {
            readonly get => row1.y;
            set => row1.y = value;
        }
        /// <summary>
        /// Gets the value at the first row in the third column
        /// </summary>
        public double m13 {
            readonly get => row1.z;
            set => row1.z = value;
        }
        /// <summary>
        /// Gets the value at the first row in the fourth column
        /// </summary>
        public double m14 {
            readonly get => row1.w;
            set => row1.w = value;
        }
        /// <summary>
        /// Gets the value at the second row in the first column
        /// </summary>
        public double m21 {
            readonly get => row2.x;
            set => row2.x = value;
        }
        /// <summary>
        /// Gets the value at the second row in the second column
        /// </summary>
        public double m22 {
            readonly get => row2.y;
            set => row2.y = value;
        }
        /// <summary>
        /// Gets the value at the second row in the third column
        /// </summary>
        public double m23 {
            readonly get => row2.z;
            set => row2.z = value;
        }
        /// <summary>
        /// Gets the value at the second row in the fourth column
        /// </summary>
        public double m24 {
            readonly get => row2.w;
            set => row2.w = value;
        }
        /// <summary>
        /// Gets the value at the third row in the first column
        /// </summary>
        public double m31 {
            readonly get => row3.x;
            set => row3.x = value;
        }
        /// <summary>
        /// Gets the value at the third row in the second column
        /// </summary>
        public double m32 {
            readonly get => row3.y;
            set => row3.y = value;
        }
        /// <summary>
        /// Gets the value at the third row in the third column
        /// </summary>
        public double m33 {
            readonly get => row3.z;
            set => row3.z = value;
        }
        /// <summary>
        /// Gets the value at the third row in the fourth column
        /// </summary>
        public double m34 {
            readonly get => row3.w;
            set => row3.w = value;
        }
        /// <summary>
        /// Gets the value at the fourth row in the first column
        /// </summary>
        public double m41 {
            readonly get => row4.x;
            set => row4.x = value;
        }
        /// <summary>
        /// Gets the value at the fourth row in the second column
        /// </summary>
        public double m42 {
            readonly get => row4.y;
            set => row4.y = value;
        }
        /// <summary>
        /// Gets the value at the fourth row in the third column
        /// </summary>
        public double m43 {
            readonly get => row4.z;
            set => row4.z = value;
        }
        /// <summary>
        /// Gets the value at the fourth row in the fourth column
        /// </summary>
        public double m44 {
            readonly get => row4.w;
            set => row4.w = value;
        }
        #endregion

        /// <summary>
        /// Gets the transpose of this matrix
        /// </summary>
        public readonly dmat4 transpose => new dmat4(col1, col2, col3, col4);
        /// <summary>
        /// The number of bytes the matrix type uses.
        /// </summary>
        public const int bytesize = sizeof(double) * 16;
        /// <summary>
        /// Gets or sets the diagonal of the matrix.
        /// </summary>
        public dvec4 diagonal {
            readonly get => new dvec4(row1.x, row2.y, row3.z, row4.w);
            set => (row1.x, row2.y, row3.z, row4.w) = (value.x, value.y, value.z, value.w);
        }
        /// <summary>
        /// Gets the sum of the diagonal.
        /// </summary>
        public readonly double trace => row1.x + row2.y + row3.z + row4.w;
        /// <summary>
        /// Gets the scale of this transformation matrix.
        /// </summary>
        public dvec3 getScale() => new dvec3(row1.xyz.length, row2.xyz.length, row3.xyz.length);
        /// <summary>
        /// Gets the translation of this transformation matrix.
        /// </summary>
        public dvec3 getTranslation() => row4.xyz;
        /// <summary>
        /// Gets the rotation of this transformation matrix.
        /// </summary>
        // TODO: implement.
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
        public void clearTranslation() => row4.xyz = dvec3.zero;
        /// <summary>
        /// Clears the rotation of this transformation matrix.
        /// </summary>
        public void clearRotation() {
            row1.xyz = new dvec3(row1.xyz.length, 0, 0);
            row2.xyz = new dvec3(0, row1.xyz.length, 0);
            row3.xyz = new dvec3(0, 0, row1.xyz.length);
        }
        /// <summary>
        /// Gets or sets the element at row r and column c.
        /// </summary>
        public double this[int r, int c] {
            readonly get => r switch {
                0 => row1[c],
                1 => row2[c],
                2 => row3[c],
                3 => row4[c],
                _ => throw new IndexOutOfRangeException(r + " is not a valid row index for dmat4")
            };
            set {
                switch(r) {
                    case 0: row1[c] = value; return;
                    case 1: row2[c] = value; return;
                    case 2: row3[c] = value; return;
                    case 3: row4[c] = value; return;
                    default: throw new IndexOutOfRangeException(r + " is not a valid row index for dmat4");
                }
            }
        }

        public dmat4(dvec4 row1, dvec4 row2, dvec4 row3, dvec4 row4) {
            this.row1 = row1;
            this.row2 = row2;
            this.row3 = row3;
            this.row4 = row4;
        }
        public dmat4(double m11, double m12, double m13, double m14, double m21, double m22, double m23, double m24, double m31, double m32, double m33, double m34, double m41, double m42, double m43, double m44) {
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
        /// creates a dmat4 from the given dmat2
        /// </summary>
        public dmat4(dmat2 m) {
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
        /// creates a dmat4 from the given dmat3
        /// </summary>
        public dmat4(dmat3 m) {
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
        /// multiplies a dmat4 with a dvec4
        /// </summary>
        public static dvec4 operator *(dmat4 m, dvec4 v) => new dvec4(m.row1.dot(v), m.row2.dot(v), m.row3.dot(v), m.row4.dot(v));
        /// <summary>
        /// multiplies a dmat4 with a dmat4x2
        /// </summary>
        public static dmat4x2 operator *(dmat4 m1, dmat4x2 m2) => new dmat4x2(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row3.dot(m2.col1), m1.row3.dot(m2.col2), m1.row4.dot(m2.col1), m1.row4.dot(m2.col2));
        /// <summary>
        /// multiplies a dmat4 with a dmat4x3
        /// </summary>
        public static dmat4x3 operator *(dmat4 m1, dmat4x3 m2) => new dmat4x3(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3), m1.row3.dot(m2.col1), m1.row3.dot(m2.col2), m1.row3.dot(m2.col3), m1.row4.dot(m2.col1), m1.row4.dot(m2.col2), m1.row4.dot(m2.col3));
        /// <summary>
        /// multiplies a dmat4 with a dmat4
        /// </summary>
        public static dmat4 operator *(dmat4 m1, dmat4 m2) => new dmat4(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row1.dot(m2.col4), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3), m1.row2.dot(m2.col4), m1.row3.dot(m2.col1), m1.row3.dot(m2.col2), m1.row3.dot(m2.col3), m1.row3.dot(m2.col4), m1.row4.dot(m2.col1), m1.row4.dot(m2.col2), m1.row4.dot(m2.col3), m1.row4.dot(m2.col4));
        /// <summary>
        /// multiplies all elements of a matrix with a scalar
        /// </summary>
        public static dmat4 operator *(dmat4 m, double s) => new dmat4(m.row1 * s, m.row2 * s, m.row3 * s, m.row4 * s);
        #endregion
    }
}
