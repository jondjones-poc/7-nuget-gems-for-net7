using NugetGems.POCO;
using ZiggyCreatures.Caching.Fusion;

namespace NugetGems;

public class FusionCacheExamples {

    public string Examples()
    {
        var cache = new FusionCache(new FusionCacheOptions());


        if (cache.TryGet<MyObject>("cache-key").HasValue) {
            return cache.TryGet<MyObject>("cache-key").Value.DateTime.ToString();
        }

        var exampleObject = new MyObject();
        exampleObject.DateTime = DateTime.Now;
        var cachedItem = cache.GetOrSet(
            "cache-key",
            exampleObject,
            TimeSpan.FromSeconds(30)
        );

        return exampleObject.DateTime.ToString();
    }
}
