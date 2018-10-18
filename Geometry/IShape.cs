using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nums.Geometry {
    public interface IShape {
        float Volume { get; set; }
        float Area { get; set; }
        float FurthestLengthFromPivot { get; set; }
    }
}
