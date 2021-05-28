using System;
using BenchmarkDotNet;

class Program {
    static void Main(string[] args) {
        BenchmarkDotNet.Running.BenchmarkRunner.Run<NoiseBenchmarks>();
    }
}
