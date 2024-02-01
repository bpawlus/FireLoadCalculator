﻿using FireLoadCalculator.Data;
using FireLoadCalculator.Resources.Strings;
using System.Globalization;
using System.Reflection;

namespace FireLoadCalculator
{
    public partial class App : Application
    {
        public App(RoomDatabase roomDatabase, MaterialDatabase materialDatabase, RoomMaterialDatabase roomMaterialDatabase)
        {
            //var loc = Thread.CurrentThread.CurrentCulture;
            var loc = new CultureInfo("pl-PL");
            CultureInfo.DefaultThreadCurrentCulture = AppResources.Culture = loc;

            Constants.Material_DB = materialDatabase;
            Constants.Room_DB = roomDatabase;
            Constants.RoomMaterial_DB = roomMaterialDatabase;

            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
