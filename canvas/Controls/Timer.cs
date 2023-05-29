using canvas.drawable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace canvas.Controls
{
    public class Timer:GraphicsView
    {
        public Timer()
        {
            var drawable = new timerdrawable();
            Drawable = drawable;
        }

        public string Time
        {
            get { return (string)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }


        public static  BindableProperty TimeProperty =
            BindableProperty.Create(nameof(Time), typeof(string), typeof(Timer), propertyChanged: timerChanged);

       static void timerChanged(BindableObject bindable,object oldvalue,object newvalue)
        {
            var control = (Timer)bindable;
            var text = control.Time;
            var dr = control.Drawable as timerdrawable;
            dr.Time = text;
            control.Invalidate();
        }
    }
}
