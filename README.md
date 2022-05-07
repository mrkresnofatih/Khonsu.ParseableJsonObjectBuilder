# Khonsu.ParseableJsonObjectBuilder

A simple json-to-class-object parser utility. A simple usage case is displayed below.

Target Json File:

```json
{
  "Policy": "Basic Permissions",
  "Version": "v1.3.12",
  "GrantedPermissions": {
    "Authentication": [
      "APP.AUTH.LOGIN",
      "APP.AUTH.SIGNUP",
      "APP.AUTH.LOGOUT"
    ],
    "Management": [
      "APP.MNG.CREATE_IAM",
      "APP.MNG.REVOKE_IAM",
      "APP.MNG.UPDATE_IAM"
    ]
  },
  "PolicyActive": true,
  "CreatedAt": 2341209
}
```

Basic Permission Class is the example class object.

```c#
public class BasicPermission
    {
        public string Policy { get; set; }
        
        public string Version { get; set; }
        
        public Dictionary<string, List<string>> GrantedPermissions { get; set; }
        
        public bool PolicyActive { get; set; }
        
        public long CreatedAt { get; set; }

        public void PrintSelf()
        {
            Console.WriteLine($"Policy: {Policy}");
            Console.WriteLine($"Version: {Version}");
            
            foreach (var grantedPermissionsKey in GrantedPermissions.Keys)
            {
                Console.Write(grantedPermissionsKey + ": [");
                foreach (var value in GrantedPermissions[grantedPermissionsKey])
                {
                    Console.Write(value + ",");
                }
                Console.WriteLine("]");
            }
            
            Console.WriteLine($"PolicyActive: {PolicyActive}");
            Console.WriteLine($"CreatedAt: {CreatedAt}");
        }
    }
```

We parse the json to object as follows.

```c#
    class Program
    {
        static void Main(string[] args)
        {
            var basicPermission = new ParseableJsonObjectBuilder<BasicPermission>()
                .SetJsonPath("Configurations/BasicPermissions.json")    // Path from the root dir of project
                .Build();
            
            basicPermission.PrintSelf();
            
            // Policy: Basic Permissions
            // Version: v1.3.12
            // Authentication: [APP.AUTH.LOGIN,APP.AUTH.SIGNUP,APP.AUTH.LOGOUT,]
            // Management: [APP.MNG.CREATE_IAM,APP.MNG.REVOKE_IAM,APP.MNG.UPDATE_IAM,]
            // PolicyActive: True
            // CreatedAt: 2341209
        }
    }
```