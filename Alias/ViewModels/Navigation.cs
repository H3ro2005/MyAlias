using Alias.Views;
using Microsoft.Maui.LifecycleEvents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Alias.ViewModels
{
   
    public class Navigation
    {

       public event PropertyChangedEventHandler PropertyChanged;


        protected void onpropchange(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        public ICommand ToCreate { get; private set; }
        public ICommand Settings { get; private set; }

        private bool isbusy;
        public bool IsBusy
        {
            get
            {
                return isbusy;
            }
            set
            {
                if (value != isbusy)
                {
                    isbusy = value;
                    onpropchange(nameof(IsBusy));
                }
            }
        }

        Task NavigateToTeam() =>  AppShell.Current.GoToAsync(nameof(TeamCreate));





        public Navigation()
        {
            SettingsViewModel settingsViewModel= new SettingsViewModel();
            settingsViewModel.themechanger(Preferences.Default.Get<string>("Theme", "Water"));
            ToCreate = new Command(async () =>
            {

                await NavigateToTeam();
                

            });
            Settings = new Command(async () =>
            {
                
                isbusy= false;
                onpropchange(nameof(IsBusy));
                await Task.Delay(1000); 
                await AppShell.Current.GoToAsync(nameof(Settings));
                isbusy = true;
                onpropchange(nameof(IsBusy));

            });


        }
           
        
    }
}
