using System;
using System.Runtime.InteropServices;

namespace Nums {

    /// <summary>
    /// A 3 by 3 matrix
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct mat3 {

        #region rows and columns
        public vec3 row1;
        public vec3 row2;
        public vec3 row3;

        public vec3 col1 {
            get => new vec3(row1.x, row2.x, row3.x);
            set {
                row1.x = value.x;
                row2.x = value.y;
                row3.x = value.z;
            }
        }
        public vec3 col2 {
            get => new vec3(row1.y, row2.y, row3.y);
            set {
                row1.y = value.x;
                row2.y = value.y;
                row3.y = value.z;
            }
        }
        public vec3 col3 {
            get => new vec3(row1.z, row2.z, row3.z);
            set {
                row1.z = value.x;
                row2.z = value.y;
                row3.z = value.z;
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
        /// Gets the value at the third row in the first column
        /// </summary>
        public float m31 {
            get => row3.x;
            set => row3.x = value;
        }
        /// <summary>
        /// Gets the value at the third row in the second column
        /// </summary>
        public float m32 {
            get => row3.y;
            set => row3.y = value;
        }
        /// <summary>
        /// Gets the value at the third row in the third column
        /// </summary>
        public float m33 {
            get => row3.z;
            set => row3.z = value;
        }
        #endregion

        public mat3(vec3 row1, vec3 row2, vec3 row3) {
            this.row1 = row1;
            this.row2 = row2;
            this.row3 = row3;
        }
        public mat3(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33) {
            row1.x = m11;
            row1.y = m12;
            row1.z = m13;
            row2.x = m21;
            row2.y = m22;
            row2.z = m23;
            row3.x = m31;
            row3.y = m32;
            row3.z = m33;
        }
    }
}