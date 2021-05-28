using Nums;
using BenchmarkDotNet.Attributes;

public class NoiseBenchmarks {

    //[Params()]
    //float x;


    [Benchmark]
    public vec2 gradientNoise2D() {
        return math.gradnoise(vec2.one);
    }

    [Benchmark]
    public vec3 gradientNoise3D() {
        return math.gradnoise(vec3.one);
    }


    
}
