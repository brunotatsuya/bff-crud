using System;

namespace BFF_CRUD.Services
{
    public class StatementValidationService
    {
        private static string[] reservedWords = {"select ", "insert into ", "update ", "delete from ", "output ",
            "merge ", "bulk insert ", "truncate ", "alter ", "drop ", "rename "};

        private static bool ContainsReservedWordsExcept(string statement, string command)
        {
            foreach (string word in reservedWords)
            {
                if (String.Equals(word, command)) continue;
                if (statement.Contains(word)) return true;
            }
            return false;
        }

        public static bool ValidateSelectStatement(string statement)
        {
            if (!statement.Contains("select ")) return false;
            if (ContainsReservedWordsExcept(statement, "select ")) return false;
            return true;
        }

        public static bool ValidateInsertStatement(string statement)
        {
            if (!statement.Contains("insert into ")) return false;
            if (ContainsReservedWordsExcept(statement, "insert into ")) return false;
            return true;
        }

        public static bool ValidateUpdateStatement(string statement)
        {
            if (!statement.Contains("update ")) return false;
            if (!statement.Contains("where ")) return false;
            if (ContainsReservedWordsExcept(statement, "update ")) return false;
            return true;
        }

        public static bool ValidateDeleteStatement(string statement)
        {
            if (!statement.Contains("delete from ")) return false;
            if (!statement.Contains("where ")) return false;
            if (ContainsReservedWordsExcept(statement, "delete from ")) return false;
            return true;
        }
    }
}
