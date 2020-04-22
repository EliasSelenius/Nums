using System;
using System.Collections.Generic;
using System.Text;

namespace Nums {

    /// <summary>
    /// collection of commonly used constants and functions
    /// </summary>
    public static partial class math {

        // • ₁¹₂²₃³₄⁴ ↑ → ↗ √ ∑ ∠ ∞ θ π τ Δ

        #region constants

        /// <summary> The constant π (pi). </summary>
        public const float pi = 3.1415926535897932384626433832795f;

        /// <summary> The constant τ (tau). equal to 2π. </summary>
        public const float tau = pi * 2f;

        /// <summary> multiply this with a degree to convert to radian. </summary>
        public const float deg2rad = 180 / pi;

        /// <summary> multiply this with a radian to convert to degree. </summary>
        public const float rad2deg = pi / 180;

        #endregion


        public static double lerp(double x, double y, double t) => x + (y - x) * t;
        public static float lerp(float x, float y, float t) => x + (y - x) * t;


        public static double pow(double x, double y) => Math.Pow(x, y);
        public static float pow(float x, float y) => (float)Math.Pow(x, y);


        public static double sqrt(double x) => Math.Sqrt(x);
        public static float sqrt(float x) => (float)Math.Sqrt(x);


        public static double floor(double x) => Math.Floor(x);
        public static float floor(float x) => (float)Math.Floor(x);
        
        
        public static double fract(double x) => x - floor(x);
        public static float fract(float x) => x - floor(x);


        public static double abs(double x) => Math.Abs(x);
        public static float abs(float x) => Math.Abs(x);


        public static double sin(double x) => Math.Sin(x);
        public static float sin(float x) => (float)Math.Sin(x);


        public static double cos(double x) => Math.Cos(x);
        public static float cos(float x) => (float)Math.Cos(x);


        public static double tan(double x) => Math.Tan(x);
        public static float tan(float x) => (float)Math.Tan(x);


        public static double min(double a, double b) => a < b ? a : b;
        public static float min(float a, float b) => a < b ? a : b;


        public static double max(double a, double b) => a < b ? b : a;
        public static float max(float a, float b) => a < b ? b : a;

    }
}
