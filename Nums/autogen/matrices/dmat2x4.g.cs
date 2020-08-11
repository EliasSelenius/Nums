using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 2 by 4 matrix
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct dmat2x4 {

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
        /// The first column in the matrix.
        /// </summary>
        public dvec2 col1 {
            get => new dvec2(row1.x, row2.x);
            set {
                row1.x = value.x;
                row2.x = value.y;
            }
        }
        /// <summary>
        /// The second column in the matrix.
        /// </summary>
        public dvec2 col2 {
            get => new dvec2(row1.y, row2.y);
            set {
                row1.y = value.x;
                row2.y = value.y;
            }
        }
        /// <summary>
        /// The third column in the matrix.
        /// </summary>
        public dvec2 col3 {
            get => new dvec2(row1.z, row2.z);
            set {
                row1.z = value.x;
                row2.z = value.y;
            }
        }
        /// <summary>
        /// The fourth column in the matrix.
        /// </summary>
        public dvec2 col4 {
            get => new dvec2(row1.w, row2.w);
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
        #endregion

        /// <summary>
        /// Gets the transpose of this matrix
        /// </summary>
        public dmat4x2 transpose => new dmat4x2(col1, col2, col3, col4);
        /// <summary>
        /// The number of bytes the matrix type uses.
        /// </summary>
        public const int bytesize = sizeof(double) * 8;
        /// <summary>
        /// Gets or sets the element at row r and column c.
        /// </summary>
        public double this[int r, int c] {
            get => r switch {
                0 => row1[c],
                1 => row2[c],
                _ => throw new IndexOutOfRangeException(r + " is not a valid row index for dmat2x4")
            };
            set {
                switch(r) {
                    case 0: row1[c] = value; return;
                    case 1: row2[c] = value; return;
                    default: throw new IndexOutOfRangeException(r + " is not a valid row index for dmat2x4");
                }
            }
        }

        public dmat2x4(dvec4 row1, dvec4 row2) {
            this.row1 = row1;
            this.row2 = row2;
        }
        public dmat2x4(double m11, double m12, double m13, double m14, double m21, double m22, double m23, double m24) {
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
        public static dvec2 operator *(dmat2x4 m, dvec4 v) => new dvec2(m.row1.dot(v), m.row2.dot(v));
        public static dmat2 operator *(dmat2x4 m1, dmat4x2 m2) => new dmat2(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2));
        public static dmat2x3 operator *(dmat2x4 m1, dmat4x3 m2) => new dmat2x3(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3));
        public static dmat2x4 operator *(dmat2x4 m1, dmat4 m2) => new dmat2x4(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row1.dot(m2.col4), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3), m1.row2.dot(m2.col4));
        #endregion
    }
}
