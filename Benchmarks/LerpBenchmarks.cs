using Nums;
using BenchmarkDotNet.Attributes;

public class LerpBenchmarks {
    float x, y;


    [Benchmark]
    public float traditionalLerp() {

        float sum = 0;
        
        for (float i = 0; i <= 1; i += 0.001f) {
            sum += (1 - i) * x + i * y;
        }
        
        return sum;
    }
    
    [Benchmark]
    public float myLerp() {
        
        float sum = 0;
        
        for (float i = 0; i <= 1; i += 0.001f) {
            sum += x + (y - x) * i;
        }
        
        return sum;
    }


    [Benchmark]
    public float myLerpFromNums() {
        float sum = 0;
        
        for (float i = 0; i <= 1; i += 0.001f) {
            sum += math.lerp(x, y, i);
        }
        
        return sum;
    }
}