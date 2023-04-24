
using Forge.OpenAI.Interfaces.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
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
        app.MapPost("/chatgpt", async (string? option, string searchTerm) => {

            var chatGPTExamples = new ChatGPTExamples();

            if (option == "1") {
                return await chatGPTExamples.OpenAIAPIExamples(searchTerm);
            }
            else if (option == "2") {
                IOpenAIService openAi = app.Services.GetService<IOpenAIService>();
                return await chatGPTExamples.ForgeOpenAIExamples(openAi, searchTerm);
            }


            return await chatGPTExamples.BetalgoExamples(searchTerm);

        });

        app.MapPost("/demystify", async (bool enabled) => {
            var demystify = new DemystifyExamples();
            if (enabled) {
                return await demystify.DemystifyException();
            }

            return await demystify.NormalException();
        });

        app.MapGet("/nodatime", () => {

            var nodatime = new NodatimeExamples();
            return nodatime.Examples();
        });

        app.MapGet("/guardclause", () => {

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

            var createUserResult = oneOfExample.Examples(exampleObject);

            string myTest = createUserResult.Match(
               myObj => myObj.Name,
               name => name
            );

            if (createUserResult.IsT0) { }
            if (createUserResult.IsT1) { }

            var test = createUserResult.AsT0 ?? throw new ArgumentException();;

            createUserResult.Switch(
                x => oneOfExample.Examples(),
                y => oneOfExample.Examples());


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

