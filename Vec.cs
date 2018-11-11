using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nums {
    public abstract class Vec<T> : IVec<T>
        where T : Vec<T>, IArithmetic<T, T>, IArithmetic<T, float> {

        protected abstract T Instance { get; }

        public abstract T Set(T a);

        public float Magnitude => (float)Math.Sqrt(Dot(Instance));
        public float SqMagnitude => Dot(Instance);

        public T Normalized => Instance.Div(Magnitude);

        public abstract float AddAggregated { get; }
        public abstract float SubAggregated { get; }
        public abstract float MulAggregated { get; }
        public abstract float DivAggregated { get; }

        public T Normalize() => Set(Normalized);

        public float AngleTo(T v) => (float)Math.Acos(Dot(v) / (Magnitude * v.Magnitude));

        public T Cross(T v) {
            throw new NotImplementedException();
        }

        public float DistanceTo(T v) => (Instance.Sub(v)).Magnitude;

        public float Dot(T v) => Instance.Mul(v).AddAggregated;


        public T Lerp(T v, float time) => v.Add(Instance.Sub(v).Mul(time));
    }
}
