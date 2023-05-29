

using Microsoft.Extensions.Logging;

namespace testing
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
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<TeamsViewMode>();
            builder.Services.AddSingleton<ScoreViewMode>();
            builder.Services.AddSingleton<ScoreView>();
            builder.Services.AddSingleton<NewPage1>();
            builder.Services.AddSingleton<Start>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}