using Microsoft.Maui.Controls;

namespace Triggers
{
    public partial class MainPage : ContentPage
    {
        int countdownSeconds = 60;
   
        public MainPage()
        {
            InitializeComponent();
            
         
         
            StartCountdown();
        }

        async Task StartCountdown()
        {

            for (int i = 60; i > 0; i--)
            {
                CountdownArc.IsLargeArc = i * 6 > 180;
                await CountdownPath.AngelTo(6, i, (x) => { CountdownArc.RotationAngle = x; }, 1000, Easing.Linear);
                int x = 0;
            }
                
              
            
          

        }










    }
}