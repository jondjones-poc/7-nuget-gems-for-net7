using Ardalis.GuardClauses;
using NugetGems.POCO;

namespace NugetGems;

public class GuardClausesExamples {

    public void Examples(MyObject example) {

        Guard.Against.Null(example, nameof(example));

        Guard.Against.NullOrEmpty(example.Name);

        Guard.Against.NullOrWhiteSpace(example.Name);

        Guard.Against.OutOfRange(example.Id, nameof(example), 0, 5);

        Guard.Against.OutOfSQLDateRange(example.DateTime);

        Guard.Against.Zero(example.Id);

        Guard.Against.Negative(example.Id);
    }
}
