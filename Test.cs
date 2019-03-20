using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Nums.Vectors;

namespace Nums {
    internal class Test {

        void VectorTest() {

            var v = new Vec3();

            
            v *= 1;

            var w = v / 3;

            v += w;

            v = v / v;

            v = v * w;

        }

    }
}
