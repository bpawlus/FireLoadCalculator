using FireLoadCalculator.Data;
using FireLoadCalculator.Models;

namespace FireLoadCalculator
{
    public static class Constants
    {
        public const string DatabaseFilename = "data.db3";
        public const string ExcelFilename = "fireloaddata.xlsx";

        public static string SaveDirectory = FileSystem.AppDataDirectory;
        public static string MoveFromDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath => Path.Combine(SaveDirectory, DatabaseFilename);
        public static string ExcelPath => Path.Combine(SaveDirectory, ExcelFilename);

        public static void MoveFilesToAppdata()
        {
            var databasePathFrom = Path.Combine(MoveFromDirectory, DatabaseFilename);
            var excelPathFrom = Path.Combine(MoveFromDirectory, ExcelFilename);

            var a = File.Exists(databasePathFrom);
            var b = File.Exists(excelPathFrom);

            var c = File.Exists(DatabasePath);
            var d = File.Exists(ExcelPath);

            if(!c) File.Copy(databasePathFrom, DatabasePath);
            if (!d) File.Copy(excelPathFrom, ExcelPath);
        }

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
