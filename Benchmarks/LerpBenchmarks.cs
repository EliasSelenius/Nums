using Nums;
using BenchmarkDotNet.Attributes;
using System.Runtime.CompilerServices;

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



public class FractBenchmarks {

    float x = 12.12357f;

    [MethodImpl(MethodImplOptions.AggressiveInlining)] static float fract(float x) => x - System.MathF.Floor(x);

    [Benchmark]
    public float systemFract() {
        float sum = 0;
        for (int i = 0; i < 1000; i++) {
            sum += fract(x);
        }
        return sum;
    }

    [Benchmark]
    public float numsFract() {
        float sum = 0;
        for (int i = 0; i < 1000; i++) {
            sum += math.fract(x); 
        }
        return sum;
    }

    //[Benchmark]
    public float modFract() {
        return x % 1.0f;
    }
}