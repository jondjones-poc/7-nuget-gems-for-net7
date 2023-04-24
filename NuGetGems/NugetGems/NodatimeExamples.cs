using NodaTime;
using NodaTime.Text;

namespace NugetGems;

public class NodatimeExamples {

    public string Examples() {

        var now = SystemClock.Instance.GetCurrentInstant();

        var pattern = LocalDateTimePattern.CreateWithInvariantCulture("yyyy/MM/dd HH:mm");
        var parseResult = pattern.Parse(now.ToDateTimeUtc().ToString());
        if (!parseResult.Success) {
        }

        var london = DateTimeZoneProviders.Tzdb["Europe/London"];
        ZonedDateTime nowInIsoUtc = now.InZone(london);
        var instant = nowInIsoUtc.ToInstant();

        var duration = Duration.FromMinutes(3);

    
        return duration.ToString();
    }
}
