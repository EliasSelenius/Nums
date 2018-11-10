using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nums {
    interface IVec<T> {

        T Set(T a);

        T Cross(T v);
        float Dot(T v);
        float Dot(params float[] values);

        float Magnitude { get; }
        float SqMagnitude { get; }

        T Normalize();
        T Normalized { get; }

        float DistanceTo(T v);

        float AngleTo(T v);

        T Lerp(T v, float time);
    }
}
