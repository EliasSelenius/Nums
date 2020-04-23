using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 2 by 3 matrix
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct dmat2x3 {

        #region rows and columns
        public dvec3 row1;
        public dvec3 row2;

        public dvec2 col1 {
            get => new dvec2(row1.x, row2.x);
            set {
                row1.x = value.x;
                row2.x = value.y;
            }
        }
        public dvec2 col2 {
            get => new dvec2(row1.y, row2.y);
            set {
                row1.y = value.x;
                row2.y = value.y;
            }
        }
        public dvec2 col3 {
            get => new dvec2(row1.z, row2.z);
            set {
                row1.z = value.x;
                row2.z = value.y;
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
        #endregion

        /// <summary>
        /// Gets the transpose of this matrix
        /// </summary>
        public dmat3x2 transpose => new dmat3x2(col1, col2, col3);
        public dmat2x3(dvec3 row1, dvec3 row2) {
            this.row1 = row1;
            this.row2 = row2;
        }
        public dmat2x3(double m11, double m12, double m13, double m21, double m22, double m23) {
            row1.x = m11;
            row1.y = m12;
            row1.z = m13;
            row2.x = m21;
            row2.y = m22;
            row2.z = m23;
        }

        #region operators
        public static dvec2 operator *(dmat2x3 m, dvec3 v) => new dvec2(m.row1.dot(v), m.row2.dot(v));
        #endregion
    }
}
