using FireLoadCalculator.Data;
using FireLoadCalculator.Models;
using FireLoadCalculator.Resources.Strings;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

namespace FireLoadCalculator
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public App(FireLoadCalculatorDatabase db, ExcelReader excelReader, RoomDatabase roomDatabase, MaterialDatabase materialDatabase, RoomMaterialDatabase roomMaterialDatabase)
        {           
            Constants.Material_DB = materialDatabase;
            Constants.Room_DB = roomDatabase;
            Constants.RoomMaterial_DB = roomMaterialDatabase;
            Constants.ExcelReader = excelReader;

            InitializeComponent();
            MainPage = new AppShell();
        }

    }
}
