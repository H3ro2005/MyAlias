using Alias.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Alias.ViewModels
{
    public class SettingsViewModel:propviewmodel
    {
        
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
        private int time = Preferences.Default.Get<int>("time", 30);
        public int Time
        {
            get { return time; }    
            set {
                if (time != value)
                {
                    time = value;
                    Preferences.Default.Set<int>("time", time);
                    onpropchange(nameof(Time));
                }
               
              
            }

        }
        private int count = Preferences.Default.Get<int>("count", 30);
        public int Count
        {
            get { return count; }
            set
            {
                if (count != value)
                {
                    count = value;
                    Preferences.Default.Set<int>("count", count);
                    onpropchange(nameof(Count));
                }


            }

        }
        private int isanimated = Preferences.Default.Get<int>("isanimated", 1);
        public bool IsAnimated
        {
            get { return isanimated == 1 ? false : true ; }
            set
            {
                if (isanimated == 1 ? false : true != value)
                {
                    isanimated = value == false? 1 : 2;
                    Preferences.Default.Set<int>("isanimated", isanimated);
                    onpropchange(nameof(IsAnimated));
                }


            }

        }
        private int isgradient = Preferences.Default.Get<int>("isgradient", 1);
        public bool IsGradient
        {
            get { return isgradient == 1 ? false : true; }
            set
            {
                if (isgradient == 1 ? false : true != value)
                {
                    isgradient = value == false ? 1 : 2;
                    Preferences.Default.Set<int>("isgradient", isgradient);
                    onpropchange(nameof(IsGradient));
                }


            }

        }
        public ICommand Theme { get; private set; }
        public ICommand startview { get; private set; }
        public async Task themechanger(string themeName)
        {
            Preferences.Set("Theme", themeName);

            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                foreach (ResourceDictionary dictionaries in mergedDictionaries)
                {
                    var primaryFound = dictionaries.TryGetValue(themeName + "Primary", out var primary);
                    if (primaryFound)
                        dictionaries["Primary"] = primary;

                    var secondaryFound = dictionaries.TryGetValue(themeName + "Secondary", out var secondary);
                    if (secondaryFound)
                        dictionaries["Secondary"] = secondary;

                    var tertiaryFound = dictionaries.TryGetValue(themeName + "Tertiary", out var tertiary);
                    if (tertiaryFound)
                        dictionaries["Tertiary"] = tertiary;

                    var accentFound = dictionaries.TryGetValue(themeName + "Light", out var light);
                    if (accentFound)
                        dictionaries["Light"] = light;

                    var darkAccentFound = dictionaries.TryGetValue(themeName + "Dark", out var dark);
                    if (darkAccentFound)
                        dictionaries["Dark"] = dark;

                    var disabledAccentFound = dictionaries.TryGetValue(themeName + "Disabled", out var disabled);
                    if (disabledAccentFound)
                        dictionaries["Disabled"] = disabled;


                }
            }
        }

        public SettingsViewModel()
        {
            
            Theme = new Command(async (object x) => { await themechanger(x.ToString());  });
            startview = new Command(async () => { 
                
                isbusy = false;
                onpropchange(nameof(IsBusy));
                await Task.Delay(500);
                await AppShell.Current.GoToAsync("../", true);
                isbusy = true;
                onpropchange(nameof(IsBusy));
            });
        }
    }
}
