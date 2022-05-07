using System;
using System.Collections.Generic;

namespace Khonsu.ParseableUtilityTesting
{
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
}