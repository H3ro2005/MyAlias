
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using testing;

namespace testing
{
    
    public partial class ScoreViewMode:propviewmodel
    {
        public PlayerChoose sender { get; set; }
        public TeamsViewMode mode = new TeamsViewMode();

        public List<PlayerChoose> test { get; set; }


     

        public byte poin;
        public byte pointer
        {
            get
            {
                return poin;
            }
            set
            {
                if (poin != null)
                {

                    point();



                }
                poin = value;             
                updater();
                if (value != 0)
                {
                    onpropchange(nameof(pointer));
                }
            }
        }

      

     
        public ICommand ToStart { get; private set; }
        public ObservableCollection<Grouping<string,PlayerChoose>> teamPlay { get; set; }
       
        public async Task up()
        {
            await updater();
        }
        public void point()
        {
            sender = test.LastOrDefault(x => x.IsOne.Equals(false) && x.team.IsPlayer.Equals(false));
            test.LastOrDefault(x => x.IsOne.Equals(false) && x.team.IsPlayer.Equals(false)).Points += pointer;
            for (int i = 0; i < test.Where(x => x.team.TeamName.Equals(sender.team.TeamName)).ToList().Count;)
            {
                test.LastOrDefault(x => x.team.TeamName.Equals(sender.team.TeamName)).team.TeamCount += pointer;
            }
            
            
        }

      
       
        public async Task updater()
        {
           
            if (teamPlay.Count != 0)
            {
                teamPlay.Clear();

            }
           
                
               teamPlay =  new ObservableCollection<Grouping<string, PlayerChoose>>(mode.teamChooses);
           
            onpropchange(nameof(teamPlay));


        }
      
        public async Task picker()
        {
            
                if (test.FirstOrDefault(x => x.IsOne.Equals(true),null) == null)
                {
                    for (int i = 1; i < test.Count;)
                    {
                        test.FirstOrDefault(x => x.IsOne.Equals(false)).IsOne = true;
                    }
                    
                }
                if (test.FirstOrDefault(x => x.team.IsPlayer.Equals(true), null) == null)
                {
                    for (int i = 1; i < test.Count;)
                    {
                        test.FirstOrDefault(x => x.team.IsPlayer.Equals(false)).team.IsPlayer = true;
                    }

                }
                sender = test.FirstOrDefault(x => x.IsOne.Equals(true) && x.team.IsPlayer.Equals(true));
            test.FirstOrDefault(x => x.IsOne.Equals(true) && x.team.IsPlayer.Equals(true)).IsOne = false;
            for (int i = 0; i < test.Where(x => x.team.TeamName.Equals(sender.team.TeamName)).ToList().Count;)
            {
                test.FirstOrDefault(x => x.team.TeamName.Equals(sender.team.TeamName)).team.IsPlayer = false;
            }

        }
        public ScoreViewMode(TeamsViewMode tm) 
        {
            mode = tm;
            teamPlay = new ObservableCollection<Grouping<string, PlayerChoose>>();
            

            ToStart = new Command( () => {updater();  });
        

           
        }
    }
}
