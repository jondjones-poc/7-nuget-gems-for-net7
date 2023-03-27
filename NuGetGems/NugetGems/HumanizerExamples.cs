using Humanizer;

namespace NuGetGems.NugetGems;
public class HumanizerExamples {

    public string Examples(int number) {

        return number switch {
            1 => "PascalCaseInputString".Humanize(),
            2 => "Underscored_input_string".Humanize(),
            3 => "Underscored_input__INTO_sentence".Humanize(),
            4 => "HTML".Humanize(),
            5 => "HUMANIZER".Humanize()
        };
    }
}
