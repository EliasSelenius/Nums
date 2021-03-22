using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 3 by 2 matrix
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct dmat3x2 {

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
        /// The third row in the matrix.
        /// </summary>
        public dvec2 row3;

        /// <summary>
        /// The first column in the matrix.
        /// </summary>
        public dvec3 col1 {
            readonly get => new dvec3(row1.x, row2.x, row3.x);
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
            readonly get => new dvec3(row1.y, row2.y, row3.y);
            set {
                row1.y = value.x;
                row2.y = value.y;
                row3.y = value.z;
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
        #endregion

        /// <summary>
        /// Gets the transpose of this matrix
        /// </summary>
        public readonly dmat2x3 transpose => new dmat2x3(col1, col2);
        /// <summary>
        /// The number of bytes the matrix type uses.
        /// </summary>
        public const int bytesize = sizeof(double) * 6;
        /// <summary>
        /// Gets or sets the element at row r and column c.
        /// </summary>
        public double this[int r, int c] {
            readonly get => r switch {
                0 => row1[c],
                1 => row2[c],
                2 => row3[c],
                _ => throw new IndexOutOfRangeException(r + " is not a valid row index for dmat3x2")
            };
            set {
                switch(r) {
                    case 0: row1[c] = value; return;
                    case 1: row2[c] = value; return;
                    case 2: row3[c] = value; return;
                    default: throw new IndexOutOfRangeException(r + " is not a valid row index for dmat3x2");
                }
            }
        }

        public dmat3x2(dvec2 row1, dvec2 row2, dvec2 row3) {
            this.row1 = row1;
            this.row2 = row2;
            this.row3 = row3;
        }
        public dmat3x2(double m11, double m12, double m21, double m22, double m31, double m32) {
            row1.x = m11;
            row1.y = m12;
            row2.x = m21;
            row2.y = m22;
            row3.x = m31;
            row3.y = m32;
        }

        #region operators
        /// <summary>
        /// Multiplies a dmat3x2 with a dvec2.
        /// </summary>
        public static dvec3 operator *(dmat3x2 m, dvec2 v) => new dvec3(m.row1.dot(v), m.row2.dot(v), m.row3.dot(v));
        /// <summary>
        /// Multiplies a dvec3 with a dmat3x2.
        /// </summary>
        public static dvec2 operator *(dvec3 v, dmat3x2 m ) => new dvec2(m.col1.dot(v), m.col2.dot(v));
        /// <summary>
        /// Multiplies a dmat3x2 with a dmat2.
        /// </summary>
        public static dmat3x2 operator *(dmat3x2 m1, dmat2 m2) => new dmat3x2(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row3.dot(m2.col1), m1.row3.dot(m2.col2));
        /// <summary>
        /// Multiplies a dmat3x2 with a dmat2x3.
        /// </summary>
        public static dmat3 operator *(dmat3x2 m1, dmat2x3 m2) => new dmat3(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3), m1.row3.dot(m2.col1), m1.row3.dot(m2.col2), m1.row3.dot(m2.col3));
        /// <summary>
        /// Multiplies a dmat3x2 with a dmat2x4.
        /// </summary>
        public static dmat3x4 operator *(dmat3x2 m1, dmat2x4 m2) => new dmat3x4(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row1.dot(m2.col4), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3), m1.row2.dot(m2.col4), m1.row3.dot(m2.col1), m1.row3.dot(m2.col2), m1.row3.dot(m2.col3), m1.row3.dot(m2.col4));
        /// <summary>
        /// Multiplies all elements of a matrix with a scalar.
        /// </summary>
        public static dmat3x2 operator *(dmat3x2 m, double s) => new dmat3x2(m.row1 * s, m.row2 * s, m.row3 * s);
        #endregion
    }
}
