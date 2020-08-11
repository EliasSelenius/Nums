using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 4 by 3 matrix
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct dmat4x3 {

        #region rows and columns
        /// <summary>
        /// The first row in the matrix.
        /// </summary>
        public dvec3 row1;
        /// <summary>
        /// The second row in the matrix.
        /// </summary>
        public dvec3 row2;
        /// <summary>
        /// The third row in the matrix.
        /// </summary>
        public dvec3 row3;
        /// <summary>
        /// The fourth row in the matrix.
        /// </summary>
        public dvec3 row4;

        /// <summary>
        /// The first column in the matrix.
        /// </summary>
        public dvec4 col1 {
            get => new dvec4(row1.x, row2.x, row3.x, row4.x);
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
            get => new dvec4(row1.y, row2.y, row3.y, row4.y);
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
            get => new dvec4(row1.z, row2.z, row3.z, row4.z);
            set {
                row1.z = value.x;
                row2.z = value.y;
                row3.z = value.z;
                row4.z = value.w;
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
        /// Gets the value at the fourth row in the first column
        /// </summary>
        public double m41 {
            get => row4.x;
            set => row4.x = value;
        }
        /// <summary>
        /// Gets the value at the fourth row in the second column
        /// </summary>
        public double m42 {
            get => row4.y;
            set => row4.y = value;
        }
        /// <summary>
        /// Gets the value at the fourth row in the third column
        /// </summary>
        public double m43 {
            get => row4.z;
            set => row4.z = value;
        }
        #endregion

        /// <summary>
        /// Gets the transpose of this matrix
        /// </summary>
        public dmat3x4 transpose => new dmat3x4(col1, col2, col3);
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
                3 => row4[c],
                _ => throw new IndexOutOfRangeException(r + " is not a valid row index for dmat4x3")
            };
            set {
                switch(r) {
                    case 0: row1[c] = value; return;
                    case 1: row2[c] = value; return;
                    case 2: row3[c] = value; return;
                    case 3: row4[c] = value; return;
                    default: throw new IndexOutOfRangeException(r + " is not a valid row index for dmat4x3");
                }
            }
        }

        public dmat4x3(dvec3 row1, dvec3 row2, dvec3 row3, dvec3 row4) {
            this.row1 = row1;
            this.row2 = row2;
            this.row3 = row3;
            this.row4 = row4;
        }
        public dmat4x3(double m11, double m12, double m13, double m21, double m22, double m23, double m31, double m32, double m33, double m41, double m42, double m43) {
            row1.x = m11;
            row1.y = m12;
            row1.z = m13;
            row2.x = m21;
            row2.y = m22;
            row2.z = m23;
            row3.x = m31;
            row3.y = m32;
            row3.z = m33;
            row4.x = m41;
            row4.y = m42;
            row4.z = m43;
        }

        #region operators
        public static dvec4 operator *(dmat4x3 m, dvec3 v) => new dvec4(m.row1.dot(v), m.row2.dot(v), m.row3.dot(v), m.row4.dot(v));
        public static dmat4x2 operator *(dmat4x3 m1, dmat3x2 m2) => new dmat4x2(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row3.dot(m2.col1), m1.row3.dot(m2.col2), m1.row4.dot(m2.col1), m1.row4.dot(m2.col2));
        public static dmat4x3 operator *(dmat4x3 m1, dmat3 m2) => new dmat4x3(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3), m1.row3.dot(m2.col1), m1.row3.dot(m2.col2), m1.row3.dot(m2.col3), m1.row4.dot(m2.col1), m1.row4.dot(m2.col2), m1.row4.dot(m2.col3));
        public static dmat4 operator *(dmat4x3 m1, dmat3x4 m2) => new dmat4(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row1.dot(m2.col4), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3), m1.row2.dot(m2.col4), m1.row3.dot(m2.col1), m1.row3.dot(m2.col2), m1.row3.dot(m2.col3), m1.row3.dot(m2.col4), m1.row4.dot(m2.col1), m1.row4.dot(m2.col2), m1.row4.dot(m2.col3), m1.row4.dot(m2.col4));
        #endregion
    }
}
