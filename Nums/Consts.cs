using System;
using System.Collections.Generic;
using System.Text;

namespace Nums {
    /// <summary>
    /// A static class of constants
    /// </summary>
    public static class Consts {

        // • ₁¹₂²₃³₄⁴ ↑ → ↗ √ ∑ ∠ ∞ θ π τ Δ

        /// <summary> The constant π (pi). </summary>
        public const float Pi = 3.1415926535897932384626433832795f;

        /// <summary> The constant τ (tau). equal to 2π. </summary>
        public const float Tau = Pi * 2f;

        /// <summary> multiply this with a degree to convert to radian. </summary>
        public const float deg2rad = 180 / Pi;

        /// <summary> multiply this with a radian to convert to degree. </summary>
        public const float rad2deg = Pi / 180;
    }
}
