using Alias.Graphics;
using Alias.ViewModels;

namespace Alias.Views;

public partial class ScoreView : ContentPage
{
    ScoreViewModel x;
	Animation rotation;
	public ScoreView(ScoreViewModel svm)
	{
		
		InitializeComponent();
		BindingContext = svm;
        rotation = new Animation(r => Image2.Rotation = r, 0, 360, Easing.SinIn);
        svm.PropertyChanged += Svm_PropertyChanged;
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

    private void Svm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "IsBusy")
        {
            x = (ScoreViewModel)sender;
            if (x.IsBusy == false)
            {
                Image2.IsEnabled = false;
                rotation.Commit(this, "rotate", 16, 500, Easing.SinIn, (r, c) => Image2.Rotation = 0, () => true);
            }
            else
            {
                Image2.IsEnabled = true;
                this.AbortAnimation("rotate");
            }
        }
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
		
        base.OnNavigatedTo(args);
		
	
    }

}