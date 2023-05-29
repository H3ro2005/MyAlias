using Alias.Graphics;
using Alias.ViewModels;

namespace Alias.Views;

public partial class TeamCreate : ContentPage
{
	public TeamCreate(TeamsViewModel tvm)
	{
		InitializeComponent();
		BindingContext = tvm;
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
}