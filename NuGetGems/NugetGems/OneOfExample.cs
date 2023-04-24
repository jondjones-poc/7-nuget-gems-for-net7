using NugetGems.POCO;
using OneOf;

namespace NuGetGems.NugetGems {

    public class OneOfExamples {

        public OneOf<MyObject, string> Examples(
                            MyObject myObject = null) {

            if (myObject == null) {
                return "A string";
            }

            return myObject;
        }

    }
}
