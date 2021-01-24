using BFF_CRUD.Models;
using Microsoft.Extensions.Configuration;
using System;

namespace BFF_CRUD.Services
{
    public class STSAuthService
    {
        public static string TrySTSAuthentication(ResourceOwner credentials)
        {
            if (credentials.user == "admin" && credentials.password == "123") return "G_TB5";
            else return "";
        }
        public static bool ValidateGSIGroup(string stsAccessToken, IConfiguration _configuration)
        {
            string requiredGSIGroup = _configuration["STS:authorized_GSI"];
            return String.Equals(stsAccessToken, requiredGSIGroup);
        }

        public static bool TrySTSAuthentication(ClientCredentials credentials)
        {
            return credentials.client_id == "abc";
        }
    }
}
