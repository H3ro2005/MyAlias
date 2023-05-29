using Alias.drawable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Alias.Controls
{
    public class Timer:GraphicsView
    {
       

        public float UpdaterTicks
        {
            get { return (float)GetValue(UpdaterTicksProperty); }
            set { SetValue(TimeProperty, value); }
        }


        public static  BindableProperty UpdaterTicksProperty =
            BindableProperty.Create(nameof(UpdaterTicks), typeof(float), typeof(Timer), propertyChanged: updaterticksChanged);

        public float Time
        {
            get { return (float)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }


        public static BindableProperty TimeProperty =
            BindableProperty.Create(nameof(Time), typeof(float), typeof(Timer), propertyChanged: timerChanged);

        public Color TimerColor
        {
            get { return (Color)GetValue(TimerColorProperty); }
            set { SetValue(TimerColorProperty, value); }
        }
        public Color InsideColor
        {
            get { return (Color)GetValue(InsideColorProperty); }
            set { SetValue(InsideColorProperty, value); }
        }

        public static BindableProperty TimerColorProperty =
            BindableProperty.Create(nameof(TimerColor), typeof(Color), typeof(Timer), propertyChanged: timercolorChanged);

        public float TimeLineSize
        {
            get { return (float)GetValue(TimeLineSizeProperty); }
            set { SetValue(TimeLineSizeProperty, value); }
        }

        public static BindableProperty InsideColorProperty =
           BindableProperty.Create(nameof(InsideColor), typeof(Color), typeof(Timer), propertyChanged: insidecolorChanged);

        public static BindableProperty TimeLineSizeProperty =
            BindableProperty.Create(nameof(TimeLineSize), typeof(float), typeof(Timer), propertyChanged: timelinesizeChanged);

        public Timer()
        {
            var drawable = new timerdrawable();
            Drawable = drawable;

        }

        static void timerChanged(BindableObject bindable,object oldvalue,object newvalue)
        {
            var control = (Timer)bindable;
            var text = control.Time;
            if (control.Drawable is timerdrawable thisDrawable)
                thisDrawable.Time = text;
      
            control.Invalidate();
        }
        static void timelinesizeChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var control = (Timer)bindable;
            var text = control.TimeLineSize;
            if (control.Drawable is timerdrawable thisDrawable)
                thisDrawable.TimeLineSize = text;

            control.Invalidate();
        }
        static void timercolorChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var control = (Timer)bindable;
            var text = control.TimerColor;
            if (control.Drawable is timerdrawable thisDrawable)
                thisDrawable.TimerColor = text;

            control.Invalidate();
        }
        static void insidecolorChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var control = (Timer)bindable;
            var text = control.InsideColor;
            if (control.Drawable is timerdrawable thisDrawable)
                thisDrawable.InsideColor = text;

            control.Invalidate();
        }
        static void updaterticksChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var control = (Timer)bindable;
            var text = control.UpdaterTicks;
            if (control.Drawable is timerdrawable thisDrawable)
                thisDrawable.UpdaterTicks = text;

            control.Invalidate();
        }
    }
}
