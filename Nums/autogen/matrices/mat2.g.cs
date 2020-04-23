using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 2 by 2 matrix
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mat2 {

        #region rows and columns
        public vec2 row1;
        public vec2 row2;

        public vec2 col1 {
            get => new vec2(row1.x, row2.x);
            set {
                row1.x = value.x;
                row2.x = value.y;
            }
        }
        public vec2 col2 {
            get => new vec2(row1.y, row2.y);
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
        public float m11 {
            get => row1.x;
            set => row1.x = value;
        }
        /// <summary>
        /// Gets the value at the first row in the second column
        /// </summary>
        public float m12 {
            get => row1.y;
            set => row1.y = value;
        }
        /// <summary>
        /// Gets the value at the second row in the first column
        /// </summary>
        public float m21 {
            get => row2.x;
            set => row2.x = value;
        }
        /// <summary>
        /// Gets the value at the second row in the second column
        /// </summary>
        public float m22 {
            get => row2.y;
            set => row2.y = value;
        }
        #endregion

        /// <summary>
        /// Gets the transpose of this matrix
        /// </summary>
        public mat2 transpose => new mat2(col1, col2);

        public mat2(vec2 row1, vec2 row2) {
            this.row1 = row1;
            this.row2 = row2;
        }
        public mat2(float m11, float m12, float m21, float m22) {
            row1.x = m11;
            row1.y = m12;
            row2.x = m21;
            row2.y = m22;
        }

        #region operators
        public static vec2 operator *(mat2 m, vec2 v) => new vec2(m.row1.dot(v), m.row2.dot(v));
        public static mat2 operator *(mat2 m1, mat2 m2) => new mat2(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2));
        public static mat2x3 operator *(mat2 m1, mat2x3 m2) => new mat2x3(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3));
        public static mat2x4 operator *(mat2 m1, mat2x4 m2) => new mat2x4(m1.row1.dot(m2.col1), m1.row1.dot(m2.col2), m1.row1.dot(m2.col3), m1.row1.dot(m2.col4), m1.row2.dot(m2.col1), m1.row2.dot(m2.col2), m1.row2.dot(m2.col3), m1.row2.dot(m2.col4));
        #endregion
    }
}
