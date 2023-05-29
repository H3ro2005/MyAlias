using Alias.Graphics;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alias.Triggers
{
    public class GradientTrigger: TriggerAction<VisualElement>
    {

       
        public int isanimated { get; set; } = 0;
        public int isgradient { get; set; } = 0;

        protected override void Invoke(VisualElement sender)
        {
            if (sender.GetType() == typeof(Button)) { sender = AppShell.Current.CurrentPage; }
            if (isanimated != 0)
            {
                Preferences.Default.Set<int>("isanimated", isanimated);
            }
            if (isgradient != 0)
            {
                Preferences.Default.Set<int>("isgradient", isgradient);
            }
            if (Preferences.Default.Get<int>("isgradient",1) == 1)
            {
                if (Preferences.Default.Get<int>("isanimated", 1)==1)
                {
                    sender.CancelAnimation();
                    sender.Background = (Color)Application.Current.Resources.MergedDictionaries.ToList()[0].ToList()[1].Value;
                    
                }
               else
                {
                    sender.CancelAnimation();
                    sender.ColorTo((Color)Application.Current.Resources.MergedDictionaries.ToList()[0].ToList()[0].Value, (Color)Application.Current.Resources.MergedDictionaries.ToList()[0].ToList()[2].Value, c => sender.Background = c, 10000, Easing.Linear);
                }
              
            }
            else
            {
                if (Preferences.Default.Get<int>("isanimated", 1) == 1)
                {
                    sender.CancelAnimation();
                    sender.Background = new LinearGradientBrush(new GradientStopCollection() { new GradientStop((Color)Application.Current.Resources.MergedDictionaries.ToList()[0].ToList()[3].Value,0), new GradientStop((Color)Application.Current.Resources.MergedDictionaries.ToList()[0].ToList()[4].Value, 1) });
                        
                    
                }
                else
                {
                    sender.CancelAnimation();
                    sender.GradientColorTo((Color)Application.Current.Resources.MergedDictionaries.ToList()[0].ToList()[3].Value, (Color)Application.Current.Resources.MergedDictionaries.ToList()[0].ToList()[4].Value, c => sender.Background = c, 5000, Easing.Linear);
                }



            }

        }
    }
}
