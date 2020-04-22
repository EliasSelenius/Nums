using System;
using System.Collections.Generic;
using System.Text;

namespace Nums {

    /// <summary>
    /// Static class of diverse math functions.
    /// </summary>
    public static partial class Funcs {


        /// <summary>
        /// Linear interpolation.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="t"></param>
        /// <returns>The interpolated value between x and y</returns>
        public static float Linearstep(float x, float y, float t) => x + (y - x) * t;


        public static float Cosinestep(float x, float y, float t) => Linearstep(x, y, (1f - (float)Math.Cos(t * Consts.Pi)) * .5f);


        public static float Cubicstep(float v0, float v1, float v2, float v3, float t) {
            float p = (v3 - v2) - (v0 - v1),
                  q = (v0 - v1) - p,
                  r = v2 - v0,
                  s = v1,
                  t2 = t * t,
                  t3 = t2 * t;
            return p * t3 + q * t2 + r * t + s;
        }

        public static float floor(float x) => (float)Math.Floor(x);
        public static float fract(float x) => x - floor(x);
    }
}
