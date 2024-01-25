using FireLoadCalculator.Resources.Strings;
using System.Globalization;
using System.Reflection;

namespace FireLoadCalculator
{
    public partial class App : Application
    {
        public App()
        {
            //var loc = Thread.CurrentThread.CurrentCulture;
            var loc = new CultureInfo("pl-PL");
            CultureInfo.DefaultThreadCurrentCulture = AppResources.Culture = loc;

            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
