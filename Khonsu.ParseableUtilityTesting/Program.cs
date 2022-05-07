using System;
using Khonsu.ParseableJsonObjectBuilder;

namespace Khonsu.ParseableUtilityTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var basicPermission = new ParseableJsonObjectBuilder<BasicPermission>()
                .SetJsonPath("Configurations/BasicPermissions.json")
                .Build();
            
            basicPermission.PrintSelf();
        }
    }
}
