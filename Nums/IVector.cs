using System;
using System.Collections.Generic;
using System.Text;

namespace Nums {
    public interface IVector<T> : IEquatable<T> where T : IVector<T> {

        /// <summary>
        /// The sum of this vectors component
        /// </summary>
        public float sum { get; }

        public int NumberOfElements { get; }
        public int ByteSize { get; }

        public float this[int i] { get; set; }

        public float sqLength => dot((T)this);
        public float length => (float)Math.Sqrt(dot((T)this));

        public T normalized => this.divide(length);

        float dot(T v) => this.multiply((T)this).sum;

        T multiply(T v);
        T divide(T v);
        T add(T v);
        T subtract(T v);

        T multiply(float f);
        T divide(float f);

        T negate();

        public float distTo(T t) => t.subtract((T)this).length;

        public float angleTo(T t) => (float)Math.Acos(dot(t) / (length * t.length));

        public T lerp(T t, float time) => add(t.subtract((T)this).multiply(time));
    }
}

