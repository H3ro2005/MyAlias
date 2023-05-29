

using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace testing
{
    public partial class MainPage : ContentPage
    {

     
        public MainPage(TeamsViewMode tvm)
        {
            InitializeComponent();    
            BindingContext = tvm;
        }

       
    }
}