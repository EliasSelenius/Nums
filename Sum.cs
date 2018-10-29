using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nums {
    public static class Sum {
        public const float Pi = 3.1415926535897932384626433832795f;
        public const float Tau = 2 * Pi;

        public static float Abs(float v) => (v < 0) ? -v : v;
        public static float Normalize(float v) => v / Abs(v);

        public static float Clamp(float v, float min, float max) => (v < min) ? min : (v > max) ? max : v;
        public static float ClampMin(float v, float min) => (v < min) ? min : v;
        public static float ClampMax(float v, float max) => (v > max) ? max : v;

        public static float Max(float a, float b) => (a < b) ? b : a;
        public static float Min(float a, float b) => (a < b) ? a : b;
    }
}
