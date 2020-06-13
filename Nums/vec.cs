using System;
using System.Collections.Generic;
using System.Text;

namespace Nums {
    public interface vec {
        float length { get; }
        float sqlength { get; }
        float sum { get; }
        void normalize();
        float this[int i] { get; set; }
    }
    public interface dvec {
        double length { get; }
        double sqlength { get; }
        double sum { get; }
        void normalize();
        double this[int i] { get; set; }
    }
    public interface ivec {
        int length { get; }
        int sqlength { get; }
        int sum { get; }
        void normalize();
        int this[int i] { get; set; }
    }
}
