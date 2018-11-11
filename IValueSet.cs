

namespace Nums {


    public interface IValueSet<Value> {
        Value AddAggregated { get; }
        Value SubAggregated { get; }
        Value MulAggregated { get; }
        Value DivAggregated { get; } 
    }
}