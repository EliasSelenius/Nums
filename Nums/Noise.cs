using System;
using System.Collections.Generic;
using System.Text;

namespace Nums {

    /// <summary>
    /// A static class of useful noise functions. <br />
    ///  • Random <br />
    ///  • Perlin <br /> 
    ///  • Worley <br />
    ///  • OpenSimplex <br />
    /// </summary>
    public static class Noise {

        #region random

        /// <summary>
        /// Generates a random number.
        /// </summary>
        /// <returns></returns>
        public static float Random() => Random(DateTime.Now.Millisecond);

        /// <summary>
        /// Generates a random number.
        /// </summary>
        /// <param name="x">The seed</param>
        /// <returns></returns>
        public static float Random(int x) {
            x = (x << 13) ^ x;
            return (1f - ((x * (x * x * 15731 + 789221) + 1376312589) & 0x7fffffff) / 1073741824f);
        }

        /// <summary>
        /// Generates a radnom number.
        /// </summary>
        /// <param name="x">The first component of the seed</param>
        /// <param name="y">The second component of the seed</param>
        /// <returns></returns>
        public static float Random(int x, int y) => Random(x + y * 57);

        #endregion

        #region perlin

        public static float Perlin(float x) {
            int i = (int)x;
            return Funcs.Cubicstep(Random(i - 1), Random(i), Random(i + 1), Random(i + 2), x - i);
        }

        public static float Perlin(float x, float y) {
            throw new NotImplementedException();
        }

        public static float Perlin(float x, float y, float z) => throw new NotImplementedException();
        
        public static float Perlin(float x, float y, float z, float w) => throw new NotImplementedException();

        #endregion



    }

}

