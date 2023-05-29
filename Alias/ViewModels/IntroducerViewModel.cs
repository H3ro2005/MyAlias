using Alias.Models;
using Alias.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Alias.ViewModels
{

    public class IntroducerViewModel:propviewmodel
    {
        public ICommand start { get; private set; }
        public ICommand end { get; private set; }
        private bool x = true;
        public bool X { get
            {
                return x;
            }
            set
            {
                if (x!= value)
                {
                    x = value;
                    if (value == true) { updater(); } else { score(); }
                }
               
            }
        } 

        public bool Y => !X;
        public byte ins { get; set; }
        public string intm { get; set; }
        public string inname { get; set; }
 
        public async Task go()
        {
           await AppShell.Current.GoToAsync($"/{nameof(GameView)}");
        }
        public async Task away()
        {
            
           await AppShell.Current.GoToAsync($"../?X={ins}");
        }
        public void updater()
        {
           onpropchange(nameof(inname));
            onpropchange(nameof(intm));
            onpropchange(nameof(X));
            onpropchange(nameof(Y));
        }
        public void score()
        {
           
            onpropchange(nameof(X));
            onpropchange(nameof(Y));
            onpropchange(nameof(ins));

        }
        public IntroducerViewModel()
        {
            start = new Command(async() => { await go(); });
            end = new Command(async () => { await away(); }) ;

        }
    }
}
