using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nums.Geometry {
    abstract class Shape {
        abstract public float Volume { get; set; }
        abstract public float Area { get; set; }
        abstract public float FurthestLengthFromPivot { get; set; }
    }
}
