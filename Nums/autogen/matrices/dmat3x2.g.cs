using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 3 by 2 matrix
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct dmat3x2 {

        #region rows and columns
        public dvec2 row1;
        public dvec2 row2;
        public dvec2 row3;

        public dvec3 col1 {
            get => new dvec3(row1.x, row2.x, row3.x);
            set {
                row1.x = value.x;
                row2.x = value.y;
                row3.x = value.z;
            }
        }
        public dvec3 col2 {
            get => new dvec3(row1.y, row2.y, row3.y);
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
        #endregion

        /// <summary>
        /// Gets the transpose of this matrix
        /// </summary>
        public dmat2x3 transpose => new dmat2x3(col1, col2);
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
        public static dvec3 operator *(dmat3x2 m, dvec2 v) => new dvec3(m.row1.dot(v), m.row2.dot(v), m.row3.dot(v));
        #endregion
    }
}
