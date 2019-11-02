using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nums.Vectors {
    public static class Vectors {

        public static T Min<T>(this T v1, T v2) where T : IVec => v1.SqMagnitude < v2.SqMagnitude ? v1 : v2;
        public static T Max<T>(this T v1, T v2) where T : IVec => v1.SqMagnitude < v2.SqMagnitude ? v2 : v1;
    }
}
