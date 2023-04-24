using NugetGems.POCO;
using System.Diagnostics;

namespace NugetGems;

public class DemystifyExamples {

    public async Task<string> DemystifyException(List<MyObject> list = null) {

        var hello = "HellO";

        try {

            await ThrowNestedException(hello);

        } catch(NotImplementedException ex) {

            var example = ex.Demystify<Exception>();
            var exampleTwo = ex.ToStringDemystified();

            return exampleTwo;
        }

        return string.Empty;
    }

    public async Task<string> NormalException(
                                List<MyObject> list = null) {

        var hello = "HellO";

        try {
            await ThrowNestedException(hello);
        }
        catch (NotImplementedException ex) {

            return ex.ToString();

        }

        return string.Empty;
    }

    private async Task<string> ThrowNestedException(string message) {

        try {
            throw new NotImplementedException($"Hi, " + message + ", Bye");
        } catch(Exception ex) { throw ex; }

        return "";
    }
}
