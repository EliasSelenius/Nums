using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 4 by 2 matrix
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct dmat4x2 {

        #region rows and columns
        public dvec2 row1;
        public dvec2 row2;
        public dvec2 row3;
        public dvec2 row4;

        public dvec4 col1 {
            get => new dvec4(row1.x, row2.x, row3.x, row4.x);
            set {
                row1.x = value.x;
                row2.x = value.y;
                row3.x = value.z;
                row4.x = value.w;
            }
        }
        public dvec4 col2 {
            get => new dvec4(row1.y, row2.y, row3.y, row4.y);
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
        #endregion

        /// <summary>
        /// Gets the transpose of this matrix
        /// </summary>
        public dmat2x4 transpose => new dmat2x4(col1, col2);
        public dmat4x2(dvec2 row1, dvec2 row2, dvec2 row3, dvec2 row4) {
            this.row1 = row1;
            this.row2 = row2;
            this.row3 = row3;
            this.row4 = row4;
        }
        public dmat4x2(double m11, double m12, double m21, double m22, double m31, double m32, double m41, double m42) {
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
        public static dvec4 operator *(dmat4x2 m, dvec2 v) => new dvec4(m.row1.dot(v), m.row2.dot(v), m.row3.dot(v), m.row4.dot(v));
        #endregion
    }
}
