using System.Collections.Generic;
using IdentityServer4.Models;

namespace SD.Configurations
{
    public class ApiResources
    {
        public static ICollection<ApiResource> GetApiResources() =>
            new List<ApiResource>
            {
                new ApiResource
                {
                    Scopes = new List<Scope>
                    {
                        new Scope
                        {
                            Name = "2x2crmscope",
                            Description = "generalized scope of crm"
                        }
                    },
                    Name = "2x2crmapi"
                }
            };
    }
}