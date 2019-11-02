using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nums.Vectors {
    public interface IVec {

        float Sum { get; }

        float SqMagnitude { get; }
        float Magnitude { get; }

    }
}
