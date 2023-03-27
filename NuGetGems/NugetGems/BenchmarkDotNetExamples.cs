using BenchmarkDotNet.Attributes;

namespace NugetGems;

public class BenchmarkDotNetExamples {

    [Benchmark]
    public async Task<string> MakeRequest() {
        var flurlExamples = new FlurlExamples();
        var result = await flurlExamples.Examples();

        return result;
    }
}