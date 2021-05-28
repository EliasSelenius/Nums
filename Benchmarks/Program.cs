using System;
using BenchmarkDotNet.Running;

class Program {
    static void Main(string[] args) {
        //BenchmarkRunner.Run<NoiseBenchmarks>();
        //BenchmarkRunner.Run<LerpBenchmarks>();
        BenchmarkRunner.Run<FractBenchmarks>();
    }
}
