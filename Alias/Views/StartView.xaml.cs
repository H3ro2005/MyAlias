using Alias.Graphics;
using Alias.ViewModels;


#if ANDROID

using Android.Widget;
using Microsoft.Maui.Controls;



#endif

namespace Alias.Views;

public partial class StartView : ContentPage
{
    readonly Animation rotation;



#if ANDROID
    Toast z { get; set; }
    DateTime x = DateTime.Now;
#endif
    public StartView(Navigation nvm)
    {
        InitializeComponent();


        Content.Metod();

        rotation = new Animation(r => Image.Rotation = r, 0, 360, Easing.Linear);

        BindingContext = nvm;
        
        nvm.PropertyChanged += StartView_PropertyChanged;
        

#if ANDROID
        x = x.AddMilliseconds(-2000);

#endif
      
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

    private void StartView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "IsBusy")
        {
            Navigation x = (Navigation)sender;
            if (x.IsBusy == false)
            {
                Image.IsEnabled= false;
                rotation.Commit(this, "rotate", 16, 500, Easing.Linear, (r, c) => Image.Rotation = 0, () => true);
            }
            else
            {
                Image.IsEnabled = true;
                this.AbortAnimation("rotate");
            }
        }
    }

    protected override bool OnBackButtonPressed()
    {
#if ANDROID

        if (x.AddMilliseconds(2000) > DateTime.Now)
        {
            z.Cancel();
            Application.Current.Quit();
        }
        else
        {
            z = Toast.MakeText(Android.App.Application.Context, "Click again to quit", ToastLength.Short);
            z.Show();
            x = DateTime.Now;

        }
#endif
        return true;
    }


}