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

            v[0] = 2;


            //Vec3 myVec = new[]{ 1f, 0f, 4f };

           // Vec3 myVec2 = new Vec3(){ 1f, 2f, 3f };

            //Vec3 myVec3 = new[] { 1f, 2f, 3f };

            //VecParam(new[]{ 1f, 4f, 1f });

        }

        void VecParam(Vec3 a) {

        }


        void GeoTest() {
            Geometry.IShape shape = new Geometry.Generic.Cuboid(1);
            shape.Volume = 20;

            shape = new Nums.Geometry.Generic.Rect(1, 2);


            Nums.Angle a = 180;
            
        }

    }
}
