using System.Diagnostics;

namespace NugetGems;

public class DemystifyExamples {

    public string DemystifyException() {

        var hello = "HellO";

        try {

            throw new NotImplementedException($"Hi, " + hello + ", Bye");
        } catch(Exception ex) {
            return ex.Demystify().StackTrace;
        }
    }

    public string NormalException() {

        var hello = "HellO";

        try {
            throw new NotImplementedException($"Hi, " + hello + ", Bye");
        }
        catch (Exception ex) {
            return ex.StackTrace;
        }
    }
}
