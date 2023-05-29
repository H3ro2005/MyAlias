using System;
using Alias;
using Microsoft.Maui.Animations;
using Microsoft.Maui.Graphics;

namespace Alias.Graphics
{


    public static class ColorAnimation
    {
        public static Task<bool> GradientColorTo(this VisualElement self, Color fromColor, Color toColor, Action<LinearGradientBrush> callback, uint length = 250, Easing easing = null,bool istrue = true)
        {
            Func<double, LinearGradientBrush> transform = (t) => t <= 0.5f ? new LinearGradientBrush(new GradientStopCollection() { new GradientStop(Color.FromRgba(fromColor.Red + 2f*t * (toColor.Red - fromColor.Red),
                               fromColor.Green + 2f * t * (toColor.Green - fromColor.Green),
                               fromColor.Blue + 2f * t * (toColor.Blue - fromColor.Blue),
                               fromColor.Alpha + 2f * t * (toColor.Alpha - fromColor.Alpha)), 0), new GradientStop(Color.FromRgba(toColor.Red + 2f*t * (fromColor.Red - toColor.Red),
                                 toColor.Green + 2f * t  * (fromColor.Green - toColor.Green),
                                 toColor.Blue + 2f * t  * (fromColor.Blue - toColor.Blue),
                                 toColor.Alpha + 2f * t  * (fromColor.Alpha - toColor.Alpha)) , 1) }): new LinearGradientBrush(new GradientStopCollection() { new GradientStop(Color.FromRgba(toColor.Red + 2f*(t-0.5f) * (fromColor.Red - toColor.Red),
                                 toColor.Green + 2f * (t - 0.5f) * (fromColor.Green - toColor.Green),
                                 toColor.Blue + 2f * (t - 0.5f) * (fromColor.Blue - toColor.Blue),
                                 toColor.Alpha + 2f * (t - 0.5f) * (fromColor.Alpha - toColor.Alpha)) , 0), new GradientStop(Color.FromRgba(fromColor.Red + 2f*(t-0.5f) * (toColor.Red - fromColor.Red),
                               fromColor.Green + 2f*(t-0.5f) * (toColor.Green - fromColor.Green),
                               fromColor.Blue + 2f*(t-0.5f) * (toColor.Blue - fromColor.Blue),
                               fromColor.Alpha + 2f*(t-0.5f) * (toColor.Alpha - fromColor.Alpha)), 1) });


            return ColorsAnimation(self, "ColorTo", transform, callback, length, easing,istrue);
        }
        public static Task<bool> AngelTo(this VisualElement self, double tick,  Action<double> callback, uint length = 250, Easing easing = null)
        {


            Func<double, double> transform = (t) => tick*tick * (1f - t);


            return AngelAnimation(self, "AngelTo", transform, callback, length, easing);

        }
        public static Task<bool> ColorTo(this VisualElement self, Color fromColor, Color toColor, Action<Color> callback, uint length = 250, Easing easing = null)
        {
         
            
            Func<double, Color> transform = (t) => t<=0.5f?

                 Color.FromRgba(fromColor.Red + 2f*t * (toColor.Red - fromColor.Red),
                               fromColor.Green + 2f * t * (toColor.Green - fromColor.Green),
                               fromColor.Blue + 2f * t * (toColor.Blue - fromColor.Blue),
                               fromColor.Alpha + 2f * t * (fromColor.Alpha - toColor.Alpha)) : Color.FromRgba(toColor.Red + 2f*(t-0.5f) * (fromColor.Red - toColor.Red),
                                 toColor.Green + 2f * (t - 0.5f) * (fromColor.Green - toColor.Green),
                                 toColor.Blue + 2f * (t - 0.5f) * (fromColor.Blue - toColor.Blue),
                                 toColor.Alpha + 2f * (t - 0.5f) * (fromColor.Alpha - toColor.Alpha)) ;
           

            return ColorsAnimation(self, "ColorTo", transform, callback, length, easing);

        }

        public static void CancelAnimation(this VisualElement self)
        {
            self.AbortAnimation("ColorTo");
        }
        static Task<bool> ColorsAnimation(VisualElement element, string name, Func<double, Color> transform, Action<Color> callback, uint length, Easing easing)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            element.Animate<Color>(name, transform, callback, 16, length, easing, (v, c) => element.Background = v,()=>true);
            return taskCompletionSource.Task;
        }
        static Task<bool> ColorsAnimation(VisualElement element, string name, Func<double, LinearGradientBrush> transform, Action<LinearGradientBrush> callback, uint length, Easing easing,bool istrue)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            element.Animate<LinearGradientBrush>(name, transform, callback, 16, length, easing, (v, c) => element.Background = v, () => istrue);
            return taskCompletionSource.Task;
        }
        static Task<bool> AngelAnimation(VisualElement element, string name, Func<double, double> transform, Action<double> callback, uint length, Easing easing)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            element.Animate<double>(name, transform, callback, 16, length, easing, (v, c) => { taskCompletionSource.SetResult(c); }, () => false);
            return taskCompletionSource.Task;
        }
    }
}
