using NodaTime;

namespace NugetGems;

public class NodatimeExamples {

    public string Examples() {

        var now = SystemClock.Instance.GetCurrentInstant();

        var london = DateTimeZoneProviders.Tzdb["Europe/London"];
        var nowInIsoUtc = now.InZone(london);

        var duration = Duration.FromMinutes(3);

        return duration.ToString();
    }
}
