using Alias.Models;
using Alias.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Alias.ViewModels
{
    [QueryProperty("X","X")]
    public partial class ScoreViewModel : propviewmodel
    {
        private int count = Preferences.Default.Get("count", 30);
        public int Count
        {
            get { return count; }
            set {
                if (count != value)
                {
                    count = value;
                    onpropchange(nameof(Count));
                }
            }
        }
        public IntroducerViewModel ivms { get; set; }
        public PlayerChoose sender { get; set; }
        public List<PlayerChoose> test { get; set; }
        public bool l = true;
        private byte b;
        public byte X
        {
            get
            {
                return b;
            }
            set
            {
               
                point(value);
            }
        }
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

        public ICommand Return { get; private set; }
        public ICommand ToStart { get; private set; }
        public ObservableCollection<Grouping<string, PlayerChoose>> teamPlay { get; set; }

        public async Task up()
        {
            if (teamPlay.Count != 0)
            {
                teamPlay.Clear();

            }


            teamPlay = new ObservableCollection<Grouping<string, PlayerChoose>>(test.GroupBy(p => { return $"{p.team.TeamName} : {p.team.TeamCount}"; }).Select(g => new Grouping<string, PlayerChoose>(g.Key, g)));

            onpropchange(nameof(teamPlay));
        }
        public void point(byte ivm)
        {
            sender = test.LastOrDefault(x => x.IsOne.Equals(false) && x.team.IsPlayer.Equals(false));
            test.LastOrDefault(x => x.IsOne.Equals(false) && x.team.IsPlayer.Equals(false)).Points += ivm;
            for (int i = 0; i < test.Where(x => x.team.TeamName.Equals(sender.team.TeamName)).ToList().Count; i++)
            {
                test.LastOrDefault(x => x.team.TeamName.Equals(sender.team.TeamName) && x.team.IsPlayer.Equals(false)).team.TeamCount += ivm;
                test.LastOrDefault(x => x.team.TeamName.Equals(sender.team.TeamName) && x.team.IsPlayer.Equals(false)).team.IsPlayer = true;
            }
            for (int i = 0; i < test.Where(x => x.team.TeamName.Equals(sender.team.TeamName)).ToList().Count; i++)
            {
                test.FirstOrDefault(x => x.team.TeamName.Equals(sender.team.TeamName) && x.team.IsPlayer.Equals(true)).team.IsPlayer = false;
            }
            up();
        }



        public async Task updater()
        {

            if (teamPlay.Count != 0)
            {
                teamPlay.Clear();

            }

        
            teamPlay = new ObservableCollection<Grouping<string, PlayerChoose>>(test.GroupBy(p => { return $"{p.team.TeamName} : {p.team.TeamCount}"; }).Select(g => new Grouping<string, PlayerChoose>(g.Key, g)));
           
            onpropchange(nameof(teamPlay));


        }

        public async Task picker()
        {

            if (test.FirstOrDefault(x => x.IsOne.Equals(true), null) == null)
            {
                for (int i = 0; i < test.Count; i++)
                {
                    test.FirstOrDefault(x => x.IsOne.Equals(false)).IsOne = true;
                }

            }
            if (test.FirstOrDefault(x => x.team.IsPlayer.Equals(true), null) == null)
            {
                for (int i = 0; i < test.Count;i++)
                {
                    test.FirstOrDefault(x => x.team.IsPlayer.Equals(false)).team.IsPlayer = true;
                }

            }
            sender = test.FirstOrDefault(x => x.IsOne.Equals(true) && x.team.IsPlayer.Equals(true));
            test.FirstOrDefault(x => x.IsOne.Equals(true) && x.team.IsPlayer.Equals(true)).IsOne = false;
            for (int i = 0; i < test.Where(x => x.team.TeamName.Equals(sender.team.TeamName)).ToList().Count; i++)
            {
                test.FirstOrDefault(x => x.team.TeamName.Equals(sender.team.TeamName) && x.team.IsPlayer.Equals(true)).team.IsPlayer=false;
            }
          
          

        }
        public ScoreViewModel(TeamsViewModel tm,IntroducerViewModel ivm)
        {

            if (l == true)
            {
              
                test = tm.teams;
                
                teamPlay = new ObservableCollection<Grouping<string, PlayerChoose>>();
                l = false;
                updater();
                ivms = new IntroducerViewModel();

            }

            ToStart = new Command(async() => { ivm.X = true;await picker(); ivm.intm = sender.team.TeamName; ivm.inname = sender.Players;
                await AppShell.Current.GoToAsync($"{nameof(IntroducerView)}"); });
            Return = new Command(async () =>
            {
                bool answer = await AppShell.Current.DisplayAlert("Question?", "Did you want to leave", "Yes", "No");
                if (answer)
                {
                    isbusy = false;
                    onpropchange(nameof(IsBusy));
                    await Task.Delay(500);
                    await AppShell.Current.GoToAsync("../", true);
                    isbusy = true;
                    onpropchange(nameof(IsBusy));
                  
                    
                }


            });
         


        }
    }
}
