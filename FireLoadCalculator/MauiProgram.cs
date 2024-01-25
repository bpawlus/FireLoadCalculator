using FireLoadCalculator.Models;
using FireLoadCalculator.Views;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using FireLoadCalculator.ViewModels;
using FireLoadCalculator.Data;

namespace FireLoadCalculator
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiAppAsync()
        {
            var builder = MauiApp.CreateBuilder()
#if DEBUG
            .UseMauiCommunityToolkit()
#else
            .UseMauiCommunityToolkit(options =>
            {
                options.SetShouldSuppressExceptionsInConverters(true);
                options.SetShouldSuppressExceptionsInBehaviors(true);
                options.SetShouldSuppressExceptionsInAnimations(true);
            })
#endif
            .UseMauiApp<App>();

            builder.ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<FireLoadCalculatorDatabase>();
            builder.Services.AddSingleton<MaterialDatabase>();
            builder.Services.AddSingleton<RoomDatabase>();

            builder.Services.AddSingleton<AllMaterialsPage>();
            builder.Services.AddSingleton<AllRoomsPage>();
            builder.Services.AddSingleton<AllMaterials>();
            builder.Services.AddSingleton<AllRooms>();
            builder.Services.AddTransientPopup<AllRoomsPopup, AllRoomsPopupViewModel>();

            return builder.Build();
        }
    }
}