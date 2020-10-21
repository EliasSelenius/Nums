using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;
using System.Net;
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

        /// <summary> The constant π/2 (pi divided by two). </summary>
        public const float half_pi = pi / 2f;

        /// <summary> The constant π/4 (pi divided by four). </summary>
        public const float quarter_pi = pi / 4f;

        /// <summary> The constant τ (tau). equal to 2π. </summary>
        public const float tau = pi * 2f;

        /// <summary> multiply this with a degree to convert to radian. </summary>
        public const float deg2rad = pi / 180f;

        /// <summary> multiply this with a radian to convert to degree. </summary>
        public const float rad2deg = 180f / pi;

        /// <summary> The square-root of two (√2) </summary>
        public const float sqrt2 = 1.414213562f;
        /// <summary> The square-root of three (√3) </summary>
        public const float sqrt3 = 1.732050807f;

        #endregion

        #region basic funcs

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


        public static double clamp(double x, double min, double max) => x < min ? min : x > max ? max : x;
        public static float clamp(float x, float min, float max) => x < min ? min : x > max ? max : x;

        #endregion

        #region noise

        private static int _seed = int.MinValue;
        private static int getSeed() => _seed++;

        /// <summary>
        /// Generates a random number in the specified range
        /// </summary>
        /// <param name="min_value">The minimum value of the random number</param>
        /// <param name="max_value">The maximum value of the random number</param>
        /// <returns></returns>
        public static float range(float min_value, float max_value) => min_value + (rand() * 0.5f + 0.5f) * (max_value - min_value);

        /// <summary>
        /// Generates a random number in the specified range, using the specified seed
        /// </summary>
        /// <param name="seed">The seed of the random number</param>
        /// <param name="min_value">The minimum value of the random number</param>
        /// <param name="max_value">The maximum value of the random number</param>
        /// <returns></returns>
        public static float range(int seed, float min_value, float max_value) => min_value + (rand(seed) * 0.5f + 0.5f) * (max_value - min_value);


        /// <summary>
        /// Generates a random number in the range [-1..1]
        /// </summary>
        /// <returns>A random number</returns>
        public static float rand() => rand(getSeed());
        
        /// <summary>
        /// Generates a random number in the range [-1..1]
        /// </summary>
        /// <param name="seed">The seed</param>
        /// <returns>A random number</returns>
        public static float rand(int seed) {
            seed = (seed << 13) ^ seed;
            return (1f - ((seed * (seed * seed * 15731 + 789221) + 1376312589) & 0x7fffffff) / 1073741824f);
        }

        // TODO: the 'quality' of randomnes is not tested here
        public static float rand(int seed_x, int seed_y) => rand(seed_x + seed_y * 57);
        public static float rand(ivec2 seed) => rand(seed.x, seed.y);

        public static float valuenoise(float x) {
            int i = (int)x;
            float f = fract(x);
            float u = f * f * (3f - 2f * f);
            return lerp(rand(i), rand(i + 1), u);
        }

        public static float valuenoise(vec2 v) {
            ivec2 i = (ivec2)v;
            vec2 f = fract(v);

            float a = rand(i),
                  b = rand(i + ivec2.unitx),
                  c = rand(i + ivec2.unity),
                  d = rand(i + ivec2.one);

            vec2 u = f * f * (3f - f * 2f);

            return lerp(a, b, u.x) +
                    (c - a) * u.y * (1f - u.x) +
                    (d - b) * u.x * u.y;
        }



        private static vec2 rand2(vec2 v) {
            v = new vec2(v.dot(new vec2(127.1f, 311.7f)),
                         v.dot(new vec2(268.5f, 183.3f)));
            return fract(sin(v) * 43758.5453123f) * 2f - 1f;
        }
        private static vec3 rand3(vec3 v) {
            v = new vec3(v.dot(new vec3(127.1f, 311.7f, 74.4f)),
                         v.dot(new vec3(268.5f, 183.3f, 246.1f)),
                         v.dot(new vec3(113.5f, 271.9f, 124.6f)));
            return fract(sin(v) * 43758.5453123f) * 2f - 1f;
        }
        public static float gradnoise(vec2 v) {
            vec2 i = floor(v);
            vec2 f = fract(v);
            vec2 u = f * f * (-f * 2f + 3f);
            return lerp(lerp(rand2(i).dot(f),
                             rand2(i + vec2.unitx).dot(f - vec2.unitx), u.x),
                        lerp(rand2(i + vec2.unity).dot(f - vec2.unity),
                             rand2(i + vec2.one).dot(f - vec2.one), u.x), u.y);
        }

        public static float gradnoise(vec3 v) {
            vec3 i = floor(v);
            vec3 f = fract(v);
            vec3 u = f * f * (-f * 2f + 3f);
            return lerp(lerp(lerp(rand3(i).dot(f),
                                rand3(i + vec3.unitx).dot(f - vec3.unitx), u.x),
                            lerp(rand3(i + vec3.unity).dot(f - vec3.unity),
                                rand3(i + new vec3(1f, 1f, 0f)).dot(f - new vec3(1f, 1f, 0f)), u.x), u.y),
                        lerp(lerp(rand3(i + vec3.unitz).dot(f - vec3.unitz),
                                rand3(i + new vec3(1f, 0f, 1f)).dot(f - new vec3(1f, 0f, 1f)), u.x),
                            lerp(rand3(i + new vec3(0f, 1f, 1f)).dot(f - new vec3(0f, 1f, 1f)),
                                rand3(i + vec3.one).dot(f - vec3.one), u.x), u.y), u.z);
        }


        #endregion

        /// <summary>
        /// Randomly picks any of the provided elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static T pick<T>(params T[] ts) => ts[(int)((rand() * 0.5f + 0.5f) * ts.Length)];

        public static T pick<T>(out int index, params T[] ts) => ts[(index = (int)((rand() * 0.5f + 0.5f) * ts.Length))];

        // unsure if this works TODO: test
        public static void swap<T>(ref T t1, ref T t2) {
            var t = t1;
            t1 = t2;
            t2 = t;
        }

        public static IEnumerable<vec2> gen_points(vec2 start_point, float radius, int tries = 30) {
            List<vec2> spawn_points = new List<vec2>();
            float size = radius / sqrt2;
            while (true) {
                var spawn_point = pick(out int index, spawn_points);
                for (int i = 0; i < tries; i++) {
                    
                }
            }

        }

        public static mat4 lookAt(vec3 eye, vec3 target, vec3 up) {
            var z = (eye - target).normalized();
            var x = up.cross(z).normalized();
            var y = z.cross(x).normalized();

            mat4 res;

            res.row1.x = x.x;
            res.row1.y = y.x;
            res.row1.z = z.x;
            res.row1.w = 0;

            res.row2.x = x.y;
            res.row2.y = y.y;
            res.row2.z = z.y;
            res.row2.w = 0;

            res.row3.x = x.z;
            res.row3.y = y.z;
            res.row3.z = z.z;
            res.row3.w = 0;

            res.row4.x = -x.dot(eye);
            res.row4.y = -y.dot(eye);
            res.row4.z = -z.dot(eye);
            res.row4.w = 1;

            return res;
        }
    }
}
