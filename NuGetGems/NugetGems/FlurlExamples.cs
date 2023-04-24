using Flurl;
using Flurl.Http;
using Flurl.Http.Testing;
using NuGetGems.NugetGems.POCO;

namespace NugetGems;

public class FlurlExamples {

    public async Task<string> Examples()
    {
        using (var client = new FlurlClient("https://api.chucknorris.io")) {
            var post = await client
                        .Request("jokes/random")
                        .GetJsonAsync<Joke>();
        }

        var joke = await "https://api.chucknorris.io"
                .AppendPathSegment("jokes/random")
                .ConfigureRequest(settings => settings.Timeout = TimeSpan.FromSeconds(1))
                .GetJsonAsync<Joke>();

        return joke.Value;
    }

    public void Test() {
        using (var httpTest = new HttpTest()) {
            httpTest.RespondWith("OK", 200);
            httpTest.ShouldHaveCalled("https://api.chucknorris.io*")
                    .WithVerb(HttpMethod.Post)
                    .WithContentType("application/json");
        }
    }
}
