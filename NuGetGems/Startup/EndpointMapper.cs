using BenchmarkDotNet.Running;
using NugetGems;
using NugetGems.POCO;
using NuGetGems.NugetGems;

namespace NuGetGems;

public static partial class EndpointMapper
{
    public static WebApplication RegisterEndpoints(this WebApplication app)
    {
        app.MapEndPoints();

        return app;
    }

    public static WebApplication MapEndPoints(this WebApplication app)
    {
        app.MapGet("/demystify", (bool enabled = true) => {
            var demystify = new DemystifyExamples();

            if (enabled) {
                return demystify.DemystifyException();
            }

            return demystify.NormalException();
        });

        app.MapGet("/nodatime", () => {
            var nodatime = new NodatimeExamples();
            return nodatime.Examples();
        });

        app.MapGet("/guardclauseexamples", () => {
            var guardClauseExamples = new GuardClausesExamples();

            var exampleObject = new MyObject();

            guardClauseExamples.Examples(exampleObject);

            return true;
        });

        app.MapPost("/fusioncache", () => {
            var fusionCacheExample = new FusionCacheExamples();
            return fusionCacheExample.Examples();
        });

        app.MapPost("/oneof", (bool enabled = true) => {

            var oneOfExample = new OneOfExamples();
            var exampleObject = new MyObject();

            if (enabled) {
                return oneOfExample.Examples(exampleObject);
            }
            return oneOfExample.Examples().ToString();
        });

        app.MapPost("/humanizer", (int caseNumber = 1) => {

            var oneOfExample = new HumanizerExamples();
            return oneOfExample.Examples(caseNumber);
        });

        app.MapPost("/flurl", () => {

            var flurlExamples = new FlurlExamples();
            flurlExamples.Test();

            return flurlExamples.Examples();
        });

        return app;
    }
}

