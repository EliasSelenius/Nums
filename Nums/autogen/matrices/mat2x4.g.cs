using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 2 by 4 matrix
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mat2x4 {

        #region rows and columns
        public vec4 row1;
        public vec4 row2;

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
        public vec2 col3 {
            get => new vec2(row1.z, row2.z);
            set {
                row1.z = value.x;
                row2.z = value.y;
            }
        }
        public vec2 col4 {
            get => new vec2(row1.w, row2.w);
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
        /// Gets the value at the first row in the third column
        /// </summary>
        public float m13 {
            get => row1.z;
            set => row1.z = value;
        }
        /// <summary>
        /// Gets the value at the first row in the fourth column
        /// </summary>
        public float m14 {
            get => row1.w;
            set => row1.w = value;
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
        /// <summary>
        /// Gets the value at the second row in the third column
        /// </summary>
        public float m23 {
            get => row2.z;
            set => row2.z = value;
        }
        /// <summary>
        /// Gets the value at the second row in the fourth column
        /// </summary>
        public float m24 {
            get => row2.w;
            set => row2.w = value;
        }
        #endregion

        public mat2x4(vec4 row1, vec4 row2) {
            this.row1 = row1;
            this.row2 = row2;
        }
        public mat2x4(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24) {
            row1.x = m11;
            row1.y = m12;
            row1.z = m13;
            row1.w = m14;
            row2.x = m21;
            row2.y = m22;
            row2.z = m23;
            row2.w = m24;
        }
    }
}
