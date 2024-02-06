using FireLoadCalculator.Data;
using FireLoadCalculator.Models;
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
        public const string ExcelFilename = "fireloaddata.xlsx";

        public static string SaveDirectory = FileSystem.AppDataDirectory;

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath => Path.Combine(SaveDirectory, DatabaseFilename);
        public static string ExcelPath => Path.Combine(SaveDirectory, ExcelFilename);


        public static MaterialDatabase Material_DB;
        public static RoomDatabase Room_DB;
        public static RoomMaterialDatabase RoomMaterial_DB;
        public static ExcelReader ExcelReader;

        public static List<Material> Material_DB_List = new List<Material>();

        public const double MaxTotalFireLoadDisplay = 100000;

        public static string TotalFireLoadDensityCache = "";
        public static string TotalAreaCache = "";
    }
}
