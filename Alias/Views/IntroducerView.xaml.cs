using Alias.Graphics;
using Alias.ViewModels;


#if ANDROID

using Android.Widget;

#endif

namespace Alias.Views;

public partial class IntroducerView : ContentPage
{
    
#if ANDROID
    Toast z { get; set; }
    DateTime x = DateTime.Now;
#endif
    public IntroducerView(IntroducerViewModel ivm)
	{
		InitializeComponent();
		BindingContext= ivm;
#if ANDROID
        x = x.AddMilliseconds(-2000);
#endif
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
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

    protected override bool OnBackButtonPressed()
    {
#if ANDROID
       
        if (x.AddMilliseconds(2000) > DateTime.Now)
        {
            z.Cancel();
            AppShell.Current.GoToAsync($"../../");
        }
        else
        {
          z =  Toast.MakeText(Android.App.Application.Context, "CLick again to go to Menu", ToastLength.Short);
            z.Show();
            x = DateTime.Now;
        }
#endif
        return true;
    }
}