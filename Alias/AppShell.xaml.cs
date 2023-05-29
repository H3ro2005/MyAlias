using Alias.ViewModels;
using Alias.Views;
using System.Runtime.CompilerServices;

namespace Alias;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(ScoreView), typeof(ScoreView));
        Routing.RegisterRoute(nameof(StartView), typeof(StartView));
        Routing.RegisterRoute(nameof(TeamCreate), typeof(TeamCreate));
        Routing.RegisterRoute(nameof(IntroducerView), typeof(IntroducerView));
        Routing.RegisterRoute(nameof(GameView), typeof(GameView));
        Routing.RegisterRoute(nameof(Settings), typeof(Settings));

      

    }
 

}
