using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 2 by 2 matrix
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct dmat2 {

        #region rows and columns
        public dvec2 row1;
        public dvec2 row2;

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
        #endregion

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
    }
}
