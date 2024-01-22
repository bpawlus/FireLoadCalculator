using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FireLoadCalculator
{
    public static class Constants
    {
        public const string DatabaseFilename = "data.db3";
        public static string SaveDirectory = FileSystem.AppDataDirectory;

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath => Path.Combine(SaveDirectory, DatabaseFilename);
    }
}
