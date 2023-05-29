
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace testing;

public partial class ScoreView : ContentPage
{
	public ScoreView(ScoreViewMode svm)
	{

        InitializeComponent();
        BindingContext = svm;
        
    }



}