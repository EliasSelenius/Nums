using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nums {
    public interface IArithmetic<T, U> {
        T Add(U a);
        T Sub(U a);
        T Mul(U a);
        T Div(U a);
    }
}
