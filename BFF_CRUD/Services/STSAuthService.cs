using BFF_CRUD.Models;
using Microsoft.Extensions.Configuration;
using System;

namespace BFF_CRUD.Services
{
    public class STSAuthService
    {
        public static string TrySTSAuthentication(Credentials credentials)
        {
            if (credentials.user == "admin" && credentials.password == "123") return "G_TB5";
            else return "";
        }
        public static bool ValidateGSIGroup(string stsAccessToken, IConfiguration _configuration)
        {
            string requiredGSIGroup = _configuration["STS:GSI_group"];
            if (String.Equals(stsAccessToken, requiredGSIGroup)) return true;
            return false;
        }
    }
}
