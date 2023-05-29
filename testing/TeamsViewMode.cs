
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using testing;

namespace testing
{
  
    public partial class TeamsViewMode :propviewmodel
    {
        public List<PlayerChoose> teams { get; set; }
        public IEnumerable<Grouping<string,PlayerChoose>> group { get; set; }   
        public string geter { get; set; }
        Random rnd = new Random();
        public byte p = 4;
        public ICommand ToStart { get; private set; }
        public ICommand ToCreate { get; private set; }
        public ICommand ToDelete { get; private set; }
        public ICommand ToAdd { get; private set; }
        public ICommand ToRename { get; private set; }

        public ObservableCollection<Grouping<string, PlayerChoose>> teamChooses { get; set; }

        
        public async Task mobn(object parameter)
        {
            string z = await AppShell.Current.DisplayPromptAsync("Rename Player", "Rename your player name", "Save Changes", "Cancel", "Enter a name", 20, Keyboard.Default);

            if (z is not null)
            {              
                    teams.FirstOrDefault(p => p.Id.Equals((int)parameter)).Players = z;
            
                }
            }
        

        public async Task rename (object parameter)
        {
            if (parameter.GetType() == typeof(int))
            {
                await mobn(parameter);
            }
            else
            {
                
                    string x = await AppShell.Current.DisplayPromptAsync("Rename Player", "Rename your player name", "Save Changes", "Cancel", "Enter a name", 20, Keyboard.Default);

                    if (x != null)
                    {
                   
                    for (int i = 0; i < teams.Where(g => g.team.TeamName.Equals((string)parameter)).ToList().Count;)
                    {
                        teams.FirstOrDefault(g => g.team.TeamName.Equals((string)parameter)).team.TeamName = x;
                    }
                    }
             
               
             
            }
        }

        public async Task delete(object parameter)
        {
            if (parameter == null)
            {
                string x = teams.Last().team.TeamName;
                    for (int i = 0; i < teams.Where(g => g.team.TeamName.Equals(x)).ToList().Count;)
                    {
                        teams.Remove(teams.FirstOrDefault(g => g.team.TeamName.Equals(teams.Last().team.TeamName)));
                    }

                p--;
            }
            else
            {           
                PlayerChoose par =new PlayerChoose {Id = (int)parameter };
                teams = teams.Where(p => p.Id != par.Id).ToList();

            }
          

        }
        public async Task add(object parameter)
        {
            if (parameter == null)
            {
                teams.Add(new PlayerChoose { Players = $"Player{teams.Count + 1}", Id = rnd.Next(0, 30000), IsOne = true, team = new TeamChoose { IsPlayer = true, TeamCount = 0, TeamName = $"Team{p}" } });
                teams.Add(new PlayerChoose { Players = $"Player{teams.Count + 1}", Id = rnd.Next(0, 30000), IsOne = true, team = new TeamChoose { IsPlayer = true, TeamCount = 0, TeamName = $"Team{p}" } });
                p++;

            }
            else
            {
                string par = (string)parameter;
                teams.Add(new PlayerChoose { Players = $"Player{teams.Count + 1}", Id = rnd.Next(0, 30000), IsOne = true, team = new TeamChoose { IsPlayer = true, TeamCount = 0, TeamName = $"{par}" } });

                
            }


        }
      
        public void updater()
        {

            if (teamChooses.Count != 0)
            {
                teamChooses.Clear();
                
            }

            group = teams.GroupBy(p => { return p.team.TeamName; }).Select(g => new Grouping<string, PlayerChoose>(g.Key, g));
            teamChooses = new ObservableCollection<Grouping<string, PlayerChoose>>(group);
          
            onpropchange(nameof(teamChooses));


        }
        public async Task NavigateToScore()
        {
          await AppShell.Current.GoToAsync($"{nameof(ScoreView)}?T={true}", new Dictionary<string, object> { ["test"] = teams });
        }

        public TeamsViewMode()
        {

         
            teams = new List<PlayerChoose>();
            teams.Add(new PlayerChoose { Players = "Player 1", Id = rnd.Next(0, 30000), IsOne = true, team = new TeamChoose { IsPlayer = true, TeamCount = 0, TeamName = "Team1" } });
            teams.Add(new PlayerChoose { Players = "Player 2", Id = rnd.Next(0, 30000), IsOne = true, team = new TeamChoose { IsPlayer = true, TeamCount = 0, TeamName = "Team1" } });
            teams.Add(new PlayerChoose { Players = "Player 3", Id = rnd.Next(0, 30000), IsOne = true, team = new TeamChoose { IsPlayer = true, TeamCount = 0, TeamName = "Team2" } });
            teams.Add(new PlayerChoose { Players = "Player 4", Id = rnd.Next(0, 30000), IsOne = true, team = new TeamChoose { IsPlayer = true, TeamCount = 0, TeamName = "Team2" } });
            teams.Add(new PlayerChoose { Players = "Player 5", Id = rnd.Next(0, 30000), IsOne = true, team = new TeamChoose { IsPlayer = true, TeamCount = 0, TeamName = "Team3" } });
            teams.Add(new PlayerChoose { Players = "Player 6", Id = rnd.Next(0, 30000), IsOne = true, team = new TeamChoose { IsPlayer = true, TeamCount = 0, TeamName = "Team3" } });
            var groups = teams.GroupBy(p => {  return p.team.TeamName; }).Select(g => new Grouping<string, PlayerChoose>(g.Key, g));
            teamChooses = new ObservableCollection<Grouping<string, PlayerChoose>>();
          
            ToDelete = new Command(async (object parameter) =>
            {
                await delete(parameter);
                
          
                updater();
               

            });
            ToRename = new Command(async (object parameter) =>
            {
                await rename(parameter);
               
                updater();
                



            });
            ToAdd = new Command(async (object parameter) =>
            {
                await add(parameter);
                
                updater();
                


            });
            ToStart = new Command(async () =>
            {

              await  NavigateToScore();


            });

            updater();
           
        } 
    }
}
