using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Threading;
using Alias.Views;
using Alias.Models;
using Alias.Services;
using System.Collections.ObjectModel;

namespace Alias.ViewModels
{
    
    public partial class GameViewModel:propviewmodel
    {
        
        public ObservableCollection<wordsmodel> wordsmodels { get; set; }
        public List<wordsmodel> words = new List<wordsmodel>();
        Random rnd = new Random();
        serialaizer serialize;
        public ICommand changed { get; private set; }
       public ICommand startview { get; private set; }
      

       
   
        private int timer = Preferences.Default.Get<int>("time", 30);
   
        public int Timer {
            get
            {
                return timer;
            }
            set
            {
                try
                {
                    timer = Convert.ToInt32(value);
                }
                catch (Exception)
                {

                   
                }
             
            }
        
        
        }
        public int Time
        {
            get
            {
                return timer;
            }
            set
            {
                try
                {
                    timer = value;
                }
                catch (Exception)
                {

                    timer = Preferences.Default.Get<int>("time", 30); ;
                    Timer = Preferences.Default.Get<int>("time", 30);
                }
            }


        }

        public SelectableItemsView item = new SelectableItemsView();
        private byte points = 0;
        private List<object> it;
        public List<object> sitem
        {
            get
            {
                return it;
            }
            set
            {
                if (value != it)
                {
                    
                    value= it;
                  
                }
            }


        }


        public float prog = 0f ;
        
        public async Task setlist()
        {
         var word =  await serialize.GetMainwords();
            if (wordsmodels.Count != 0)
            {
                wordsmodels.Clear();
            }

            foreach (var item in word)
            {
               words.Add(item);
            }

          
        }
        public async Task startlist()
        {
            if (words.Count == 0)
            {
                await setlist();
            }
          
            for (int i = 0; i<5; i++)
            {
                int x = rnd.Next(1,words.Count+1);
                wordsmodels.Add(words[x-1]);
                words.Remove(words[x-1]);
               
            }
           
        }

        public async Task navback()
        {
           await AppShell.Current.GoToAsync(nameof(StartView));
        }


        public async Task starter(IntroducerViewModel ivm)
        {

          

           
            for (int i = 0; i < 1; )
            {
               
              
                
               
                await Task.Delay(1000);
           
                
                    timer -= 1;
                    onpropchange(nameof(Timer));
                  
               
                if (timer == 0)
                {
                    i = 1;
                }
                
            }
           
            ivm.ins = points;
            ivm.X = false;
            await AppShell.Current.GoToAsync($"../");
            wordsmodels.Clear();
            words.Clear();
           
          
        }

    

        public GameViewModel(serialaizer serialaizer,IntroducerViewModel ivm)
        {
            points = 0;
            it = new List<object>();
            wordsmodels = new ObservableCollection<wordsmodel>();
            changed = new Command(() => {
                if (sitem != it)
                {
                    onpropchange(nameof(sitem));
                
                }
                points = Convert.ToByte(it.Count);




            });
            startview = new Command(() => { ivm.ins = points; });
            this.serialize= serialaizer;
           
            startlist();
       
            starter(ivm);
           
           



        }
    }
}
