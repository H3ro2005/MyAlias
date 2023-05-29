using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alias.Graphics
{
    public static class AnimateMetod
    {
        public static void Metod(this VisualElement sender)
        {
         
            if (Preferences.Default.Get<int>("isgradient", 1) == 1)
            {
                if (Preferences.Default.Get<int>("isanimated", 1) == 1)
                {
                    sender.CancelAnimation();
                    sender.Background = (Color)Application.Current.Resources.MergedDictionaries.ToList()[0].ToList()[1].Value;

                }
                else
                {
                    sender.ColorTo((Color)Application.Current.Resources.MergedDictionaries.ToList()[0].ToList()[0].Value, (Color)Application.Current.Resources.MergedDictionaries.ToList()[0].ToList()[2].Value, c => sender.Background = c, 10000, Easing.Linear);
                }

            }
            else
            {
                if (Preferences.Default.Get<int>("isanimated", 1) == 1)
                {
                    sender.CancelAnimation();
                    sender.Background = new LinearGradientBrush(new GradientStopCollection() { new GradientStop((Color)Application.Current.Resources.MergedDictionaries.ToList()[0].ToList()[3].Value, 0), new GradientStop((Color)Application.Current.Resources.MergedDictionaries.ToList()[0].ToList()[4].Value, 1) });


                }
                else
                {
                    sender.GradientColorTo((Color)Application.Current.Resources.MergedDictionaries.ToList()[0].ToList()[3].Value, (Color)Application.Current.Resources.MergedDictionaries.ToList()[0].ToList()[4].Value, c => sender.Background = c, 5000, Easing.Linear);
                }



            }
        }
    }
}
