using Flurl;
using Flurl.Http;
using Flurl.Http.Testing;
using NuGetGems.NugetGems.POCO;

namespace NugetGems;

public class FlurlExamples {

    public async Task<string> Examples()
    {
        var joke = await "https://api.chucknorris.io"
            .AppendPathSegment("jokes/random")
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
