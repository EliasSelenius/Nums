using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 2 by 2 matrix
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct dmat2 {
        /// <summary>
        /// The identity matrix
        /// </summary>
        public static readonly dmat2 identity = new dmat2(1, 0, 0, 1);

        #region rows and columns
        /// <summary>
        /// The first row in the matrix.
        /// </summary>
        public dvec2 row1;
        /// <summary>
        /// The second row in the matrix.
        /// </summary>
        public dvec2 row2;

        /// <summary>
        /// The first column in the matrix.
        /// </summary>
        public dvec2 col1 {
            readonly get => new dvec2(row1.x, row2.x);
            set {
                row1.x = value.x;
                row2.x = value.y;
            }
        }
        /// <summary>
        /// The second column in the matrix.
        /// </summary>
        public dvec2 col2 {
            readonly get => new dvec2(row1.y, row2.y);
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
        #endregion

        /// <summary>
        /// Gets the transpose of this matrix
        /// </summary>
        public readonly dmat2 transpose => new dmat2(col1, col2);
        /// <summary>
        /// The number of bytes the matrix type uses.
        /// </summary>
        public const int bytesize = sizeof(double) * 4;
        /// <summary>
        /// Gets or sets the diagonal of the matrix.
        /// </summary>
        public dvec2 diagonal {
            readonly get => new dvec2(row1.x, row2.y);
            set => (row1.x, row2.y) = (value.x, value.y);
        }
        /// <summary>
        /// Gets the sum of the diagonal.
        /// </summary>
        public readonly double trace => row1.x + row2.y;
        /// <summary>
        /// Gets or sets the element at row r and column c.
        /// </summary>
        public double this[int r, int c] {
            readonly get => r switch {
                0 => row1[c],
                1 => row2[c],
                _ => throw new IndexOutOfRangeException(r + " is not a valid row index for dmat2")
            };
            set {
                switch(r) {
                    case 0: row1[c] = value; return;
                    case 1: row2[c] = value; return;
                    default: throw new IndexOutOfRangeException(r + " is not a valid row index for dmat2");
                }
            }
        }

        public dmat2(dvec2 row1, dvec2 row2) {
            this.row1 = row1;
            this.row2 = row2;
        }
        public dmat2(double m11, double m12, double m21, double m22) {
            row1.x = m11;
            row1.y = m12;
            row2.x = m21;
            row2.y = m22;
        }
        /// <summary>
        /// creates a dmat2 from the given dmat3
        /// </summary>
        public dmat2(dmat3 m) {
            row1.x = m.row1.x;
            row1.y = m.row1.y;
            row2.x = m.row2.x;
            row2.y = m.row2.y;
        }
        /// <summary>
        /// creates a dmat2 from the given dmat4
        /// </summary>
        public dmat2(dmat4 m) {
            row1.x = m.row1.x;
            row1.y = m.row1.y;
            row2.x = m.row2.x;
            row2.y = m.row2.y;
        }

        #region operators
        /// <summary>
        /// multiplies a dmat2 with a dvec2
        /// </summary>
        public static dvec2 operator *(dmat2 m, dvec2 v) => new dvec2(m.row1.dot(v), m.row2.dot(v));
        /// <summary>
        /// multiplies a dmat2 with a dmat2
        /// </summary>
        public static dmat2 operator *(dmat2 m1, dmat2 m2) => new dmat2(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2));
        /// <summary>
        /// multiplies a dmat2 with a dmat2x3
        /// </summary>
        public static dmat2x3 operator *(dmat2 m1, dmat2x3 m2) => new dmat2x3(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3));
        /// <summary>
        /// multiplies a dmat2 with a dmat2x4
        /// </summary>
        public static dmat2x4 operator *(dmat2 m1, dmat2x4 m2) => new dmat2x4(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row1.dot(m2.col4), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3), m1.row2.dot(m2.col4));
        /// <summary>
        /// multiplies all elements of a matrix with a scalar
        /// </summary>
        public static dmat2 operator *(dmat2 m, double s) => new dmat2(m.row1 * s, m.row2 * s);
        #endregion
    }
}
