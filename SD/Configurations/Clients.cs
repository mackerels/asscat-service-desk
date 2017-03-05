using System.Collections.Generic;
using IdentityServer4.Models;

namespace SD.Configurations
{
    public class Clients
    {
        public static ICollection<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "crm-client",
                    ClientSecrets = new List<Secret> {new Secret("crm-client-secret".Sha256())},
                    AllowedScopes = new List<string> {"2x2crmscope"},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword
                }
            };
    }
}