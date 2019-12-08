using System;
using System.Collections.Generic;
using System.Text;

using Nums.old;

namespace Nums {
    public struct mat2 {

        public vec2 row0, row1;

        #region props and indexing

        public float _00 {
            get => row0.x;
            set => row0.x = value;
        }
        public float _01 {
            get => row0.y;
            set => row0.y = value;
        }
        public float _10 {
            get => row1.x;
            set => row1.x = value;
        }
        public float _11 {
            get => row1.y;
            set => row1.y = value;
        }


        public vec2 col0 {
            get => new vec2(row0.x, row1.x);
            set {
                row0.x = value.x;
                row1.x = value.y;
            }
        }

        public vec2 col1 {
            get => new vec2(row0.y, row1.y);
            set {
                row0.y = value.x;
                row1.y = value.y;
            }
        }

        public float this[int row, int col] {
            get => row switch {
                0 => row0[col],
                1 => row1[col],
                _ => throw new IndexOutOfRangeException(row + " is not a valid matrix index")
            };
            set { 
                switch (row) {
                    case 0: row0[col] = value; return;
                    case 1: row1[col] = value; return;
                    default: throw new IndexOutOfRangeException(row + " is not a valid matrix index");
                }
            }
        }

        #endregion


        public mat2(vec2 r0, vec2 r1) {
            row0 = r0; row1 = r1;
        }

        public mat2(float m00, float m01, float m10, float m11) {
            row0 = new vec2(m00, m01);
            row1 = new vec2(m10, m11);
        }

        #region operators

        #region arithmetic

        //public static vec2 operator *(mat2 m, vec2 v) => new vec2((m.row0 as IVector<vec2>).dot(v), m.row1.dot(v));

        #endregion

        #region conversion

        public static implicit operator mat2((float, float, float, float) t) => new mat2(t.Item1, t.Item2, t.Item3, t.Item4);

        #endregion

        #endregion
    }
}
