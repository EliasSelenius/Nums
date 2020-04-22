using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nums;

namespace UnitTest {
    [TestClass]
    public class VectorTest {
        [TestMethod]
        public void ImplicitTupleCast() {

            vec2 v = (12, 4);

            Assert.AreEqual(v, new vec2(12, 4));
        }

        [TestMethod]
        public void Arithmetic() {
            vec2 v = (2, 3);

            Assert.AreEqual(-v, new vec2(-2, -3));

            v += (1, 1);
            Assert.AreEqual(v, new vec2(3, 4));

            v -= (2, 5);
            Assert.AreEqual(v, new vec2(1, -1));

            v *= 2;
            Assert.AreEqual(v, new vec2(2, -2));

            v /= 2;
            Assert.AreEqual(v, new vec2(1, -1));

            v *= (2, 6);
            Assert.AreEqual(v, new vec2(2, -6));

            v /= (2, 3);
            Assert.AreEqual(v, new vec2(1, -2));

            //Assert.AreEqual(v., v.dot(v))
        }

        [TestMethod]
        public void VectorCrossProduct() {
            Assert.AreEqual(vec3.unitx.cross(vec3.unity), vec3.unitz);
        }
    }
}
