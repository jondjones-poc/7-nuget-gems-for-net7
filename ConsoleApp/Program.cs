using BenchmarkDotNet.Running;
using NugetGems;

namespace ConsoleApp {
    internal class Program {
        static void Main(string[] args) {
            BenchmarkRunner.Run<BenchmarkDotNetExamples>();
        }
    }
}