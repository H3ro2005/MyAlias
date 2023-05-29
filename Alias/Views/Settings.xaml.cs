using Alias.ViewModels;

namespace Alias.Views;

public partial class Settings : ContentPage
{
	Animation rotation;
    SettingsViewModel x;
	public Settings(SettingsViewModel gmv)
	{
		InitializeComponent();
  
        
        rotation = new Animation(r => Image1.Rotation = r, 0, 360, Easing.SinIn);
        BindingContext = gmv;
        gmv.PropertyChanged += Gmv_PropertyChanged;
	}

    private void Gmv_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "IsBusy")
        { x = (SettingsViewModel)sender;
            if (x.IsBusy == false)
            {
                Image1.IsEnabled = false;
                rotation.Commit(this, "rotate", 16, 500, Easing.SinIn, (r, c) => Image1.Rotation = 0, () => true);
            }
            else
            {
                Image1.IsEnabled = true;
                this.AbortAnimation("rotate");
            }
        }
    }
}