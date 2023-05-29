using Alias.Graphics;
using Alias.ViewModels;
#if ANDROID
using Android.Widget;
#endif
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Alias.Views;

public partial class GameView : ContentPage
{
    Animation x;
    public GameView(GameViewModel gmv)
	{
		InitializeComponent();
		BindingContext= gmv;
        
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
        Content.CancelAnimation();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Content.Metod();
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        tick.Time = tick.UpdaterTicks;
        x = new Animation(r => tick.Time = Convert.ToSingle(r), 0, 90000, Easing.Linear);
        x.Commit(this, "rotate", 16, 90000, Easing.Linear, (r, c) => tick.Time = 0, () => false);

    }
    protected override bool OnBackButtonPressed()
    {
#if ANDROID
       
 Toast.MakeText(Android.App.Application.Context, "Can not leave", ToastLength.Short).Show();
      
#endif
        
        return true;
    }



}