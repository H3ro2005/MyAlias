using Alias.drawable;
using Alias.Services;
using Alias.Triggers;
using Alias.ViewModels;
using Alias.Views;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace Alias;

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

        builder.Services.AddSingleton<serialaizer>();
		builder.Services.AddSingleton<Navigation>();
        builder.Services.AddSingleton<StartView>();
		builder.Services.AddTransient<ScoreViewModel>();
        builder.Services.AddSingleton<SettingsViewModel>();
		builder.Services.AddTransient<ScoreView>();
        builder.Services.AddSingleton<TeamCreate>();
        builder.Services.AddSingleton<TeamsViewModel>();
        builder.Services.AddSingleton<IntroducerViewModel>();
        builder.Services.AddTransient<IntroducerView>();
        builder.Services.AddTransient<GameViewModel>();
        builder.Services.AddSingleton<Settings>();
        builder.Services.AddTransient<GameView>();
        builder.Services.AddSingleton<GradientTrigger>();

        
        builder.ConfigureLifecycleEvents(events =>
             {
#if ANDROID
                 events.AddAndroid(android => android.OnCreate((activity, bundle) => MakeStatusBarTranslucent(activity)));

               
                 static void MakeStatusBarTranslucent(Android.App.Activity activity)
                 {
               
                    
                     activity.Window.SetFlags(Android.Views.WindowManagerFlags.LayoutNoLimits, Android.Views.WindowManagerFlags.LayoutNoLimits);

                     activity.Window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);

                     activity.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
                 }
              
#endif
             });

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
