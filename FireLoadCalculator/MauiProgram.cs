using FireLoadCalculator.Models;
using FireLoadCalculator.Views;
using Microsoft.Extensions.Logging;

namespace FireLoadCalculator
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<AllMaterialsPage>();
            builder.Services.AddSingleton<AllMaterials>();
            builder.Services.AddSingleton<AllRooms>();
            return builder.Build();
        }
    }
}
