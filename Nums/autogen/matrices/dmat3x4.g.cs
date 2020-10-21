using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 3 by 4 matrix
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct dmat3x4 {

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
        /// The first column in the matrix.
        /// </summary>
        public dvec3 col1 {
            get => new dvec3(row1.x, row2.x, row3.x);
            set {
                row1.x = value.x;
                row2.x = value.y;
                row3.x = value.z;
            }
        }
        /// <summary>
        /// The second column in the matrix.
        /// </summary>
        public dvec3 col2 {
            get => new dvec3(row1.y, row2.y, row3.y);
            set {
                row1.y = value.x;
                row2.y = value.y;
                row3.y = value.z;
            }
        }
        /// <summary>
        /// The third column in the matrix.
        /// </summary>
        public dvec3 col3 {
            get => new dvec3(row1.z, row2.z, row3.z);
            set {
                row1.z = value.x;
                row2.z = value.y;
                row3.z = value.z;
            }
        }
        /// <summary>
        /// The fourth column in the matrix.
        /// </summary>
        public dvec3 col4 {
            get => new dvec3(row1.w, row2.w, row3.w);
            set {
                row1.w = value.x;
                row2.w = value.y;
                row3.w = value.z;
            }
        }
        #endregion


        #region indexed properties
        /// <summary>
        /// Gets the value at the first row in the first column
        /// </summary>
        public double m11 {
            get => row1.x;
            set => row1.x = value;
        }
        /// <summary>
        /// Gets the value at the first row in the second column
        /// </summary>
        public double m12 {
            get => row1.y;
            set => row1.y = value;
        }
        /// <summary>
        /// Gets the value at the first row in the third column
        /// </summary>
        public double m13 {
            get => row1.z;
            set => row1.z = value;
        }
        /// <summary>
        /// Gets the value at the first row in the fourth column
        /// </summary>
        public double m14 {
            get => row1.w;
            set => row1.w = value;
        }
        /// <summary>
        /// Gets the value at the second row in the first column
        /// </summary>
        public double m21 {
            get => row2.x;
            set => row2.x = value;
        }
        /// <summary>
        /// Gets the value at the second row in the second column
        /// </summary>
        public double m22 {
            get => row2.y;
            set => row2.y = value;
        }
        /// <summary>
        /// Gets the value at the second row in the third column
        /// </summary>
        public double m23 {
            get => row2.z;
            set => row2.z = value;
        }
        /// <summary>
        /// Gets the value at the second row in the fourth column
        /// </summary>
        public double m24 {
            get => row2.w;
            set => row2.w = value;
        }
        /// <summary>
        /// Gets the value at the third row in the first column
        /// </summary>
        public double m31 {
            get => row3.x;
            set => row3.x = value;
        }
        /// <summary>
        /// Gets the value at the third row in the second column
        /// </summary>
        public double m32 {
            get => row3.y;
            set => row3.y = value;
        }
        /// <summary>
        /// Gets the value at the third row in the third column
        /// </summary>
        public double m33 {
            get => row3.z;
            set => row3.z = value;
        }
        /// <summary>
        /// Gets the value at the third row in the fourth column
        /// </summary>
        public double m34 {
            get => row3.w;
            set => row3.w = value;
        }
        #endregion

        /// <summary>
        /// Gets the transpose of this matrix
        /// </summary>
        public dmat4x3 transpose => new dmat4x3(col1, col2, col3, col4);
        /// <summary>
        /// The number of bytes the matrix type uses.
        /// </summary>
        public const int bytesize = sizeof(double) * 12;
        /// <summary>
        /// Gets or sets the element at row r and column c.
        /// </summary>
        public double this[int r, int c] {
            get => r switch {
                0 => row1[c],
                1 => row2[c],
                2 => row3[c],
                _ => throw new IndexOutOfRangeException(r + " is not a valid row index for dmat3x4")
            };
            set {
                switch(r) {
                    case 0: row1[c] = value; return;
                    case 1: row2[c] = value; return;
                    case 2: row3[c] = value; return;
                    default: throw new IndexOutOfRangeException(r + " is not a valid row index for dmat3x4");
                }
            }
        }

        public dmat3x4(dvec4 row1, dvec4 row2, dvec4 row3) {
            this.row1 = row1;
            this.row2 = row2;
            this.row3 = row3;
        }
        public dmat3x4(double m11, double m12, double m13, double m14, double m21, double m22, double m23, double m24, double m31, double m32, double m33, double m34) {
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
        }

        #region operators
        /// <summary>
        /// multiplies a dmat3x4 with a dvec4
        /// </summary>
        public static dvec3 operator *(dmat3x4 m, dvec4 v) => new dvec3(m.row1.dot(v), m.row2.dot(v), m.row3.dot(v));
        /// <summary>
        /// multiplies a dmat3x4 with a dmat4x2
        /// </summary>
        public static dmat3x2 operator *(dmat3x4 m1, dmat4x2 m2) => new dmat3x2(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row3.dot(m2.col1), m1.row3.dot(m2.col2));
        /// <summary>
        /// multiplies a dmat3x4 with a dmat4x3
        /// </summary>
        public static dmat3 operator *(dmat3x4 m1, dmat4x3 m2) => new dmat3(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3), m1.row3.dot(m2.col1), m1.row3.dot(m2.col2), m1.row3.dot(m2.col3));
        /// <summary>
        /// multiplies a dmat3x4 with a dmat4
        /// </summary>
        public static dmat3x4 operator *(dmat3x4 m1, dmat4 m2) => new dmat3x4(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row1.dot(m2.col4), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3), m1.row2.dot(m2.col4), m1.row3.dot(m2.col1), m1.row3.dot(m2.col2), m1.row3.dot(m2.col3), m1.row3.dot(m2.col4));
        /// <summary>
        /// multiplies all elements of a matrix with a scalar
        /// </summary>
        public static dmat3x4 operator *(dmat3x4 m, double s) => new dmat3x4(m.row1 * s, m.row2 * s, m.row3 * s);
        #endregion
    }
}
