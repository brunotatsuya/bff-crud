using BFF_CRUD.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace BFF_CRUD.Services
{
    public class RulesValidationService
    {
        private static string[] reservedWords = {"select ", "insert into ", "update ", "delete from ", "output ",
            "merge ", "bulk insert ", "truncate ", "alter ", "drop ", "rename "};

        private static bool ContainsReservedWordsExcept(string statement, string exceptWord)
        {
            foreach (string word in reservedWords)
            {
                if (String.Equals(word, exceptWord)) continue;
                if (statement.Contains(word)) return true;
            }
            return false;
        }

        public static bool ValidateStatement(DynamicStatement dynSt, string verb)
        {
            string statement = dynSt.statement.ToLower();
            switch (verb)
            {
                case "SELECT":
                    if (!statement.Contains("select ")) return false;
                    return !ContainsReservedWordsExcept(statement, "select ");
                case "INSERT":
                    if (!statement.Contains("insert ")) return false;
                    return !ContainsReservedWordsExcept(statement, "insert into ");
                case "UPDATE":
                    if (!statement.Contains("update ")) return false;
                    if (!statement.Contains("where ")) return false;
                    return !ContainsReservedWordsExcept(statement, "update ");
                case "DELETE":
                    if (!statement.Contains("delete from ")) return false;
                    if (!statement.Contains("where ")) return false;
                    return !ContainsReservedWordsExcept(statement, "delete from ");
            }
            return false;
        }

        public static bool ValidateTargetEnviroment(DynamicStatement dynSt)
        {
            string environment = dynSt.environment.ToLower();
            if (String.Equals(environment, "development")) return true;
            if (String.Equals(environment, "production")) return true;
            return false;
        }

        public static bool ValidateTargetDatabase(DynamicStatement dynSt, IConfiguration _configuration)
        {
            string environment = dynSt.environment.ToLower();
            var allowed_dbs = _configuration["DataAccess:" + environment + ":allowed_dbs"].Split(';').ToList();
            return allowed_dbs.Contains(dynSt.database);
        }
    }
}