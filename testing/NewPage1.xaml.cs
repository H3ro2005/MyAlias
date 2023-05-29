namespace testing;

public partial class NewPage1 : ContentPage
{
	public NewPage1(Start nb)
	{
		InitializeComponent();
		BindingContext = nb;
	}
}