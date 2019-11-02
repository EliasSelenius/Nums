using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections;

namespace Nums {
    [StructLayout(LayoutKind.Sequential)]
    public struct vector : IVector<vector>, IEnumerable<float> {

        private readonly float[] values;

        public float sum => values.Aggregate((x, y) => x + y);
        public int NumberOfElements => values.Length;
        public int ByteSize => sizeof(float) * NumberOfElements;

        public float this[int i] {
            get => values[i];
            set => values[i] = value;
        }

        public vector(params float[] values) {
            this.values = values;
        }

        private void checkCompatibility(vector v) {
            if (NumberOfElements != v.NumberOfElements) {
                throw new Exception("wrong number of elements");
            }
        }

        public vector add(vector v) {
            checkCompatibility(v);
            var res = new float[NumberOfElements];
            for (int i = 0; i < NumberOfElements; i++) {
                res[i] = this[i] + v[i];
            }
            return new vector(res);
        }
        public static vector operator +(vector a, vector b) => a.add(b);

        public vector divide(vector v) {
            checkCompatibility(v);
            var res = new float[NumberOfElements];
            for (int i = 0; i < NumberOfElements; i++) {
                res[i] = this[i] / v[i];
            }
            return new vector(res);
        }
        public static vector operator /(vector a, vector b) => a.divide(b);

        public vector divide(float f) => new vector(values.Select(x => x / f).ToArray());
        public static vector operator /(vector v, float f) => v.divide(f);

        public bool Equals(vector other) {
            throw new NotImplementedException();
        }

        public vector multiply(vector v) {
            checkCompatibility(v);
            var res = new float[NumberOfElements];
            for (int i = 0; i < NumberOfElements; i++) {
                res[i] = this[i] * v[i];
            }
            return new vector(res);
        }
        public static vector operator *(vector a, vector b) => a.multiply(b);

        public vector multiply(float f) => new vector(values.Select(x => x * f).ToArray());
        public static vector operator *(vector v, float f) => v.multiply(f);

        public vector negate() => new vector(values.Select(x => -x).ToArray());
        public static vector operator -(vector v) => v.negate();

        public vector subtract(vector v) {
            checkCompatibility(v);
            var res = new float[NumberOfElements];
            for (int i = 0; i < NumberOfElements; i++) {
                res[i] = this[i] - v[i];
            }
            return new vector(res);
        }

        public static vector operator -(vector a, vector b) => a.subtract(b);

        public IEnumerator<float> GetEnumerator() {
            return ((IEnumerable<float>)values).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable<float>)values).GetEnumerator();
        }

    }
}
