using System;
using Microsoft.Maui.Animations;
using Microsoft.Maui.Graphics;

namespace Triggers
{


    public static class ColorAnimation
    {


        public static Task<bool> AngelTo(this VisualElement self,double angel,double Tick, Action<double> callback, uint length = 250, Easing easing = null)
        {


            Func<double, double> transform = (t) => angel*Tick- (1 - t);


            return AngelAnimation(self, "AngelTo", transform, callback, length, easing);

        }
        static Task<bool> AngelAnimation(VisualElement element, string name, Func<double, double> transform, Action<double> callback, uint length, Easing easing)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            element.Animate<double>(name, transform, callback, 16, length, easing, (v,c) => { taskCompletionSource.SetResult(c);   } , () => false);
            return taskCompletionSource.Task;
        }
        public static Task<bool> ColorTo(this VisualElement self, Color fromColor, Color toColor, Action<Color> callback, uint length = 250, Easing easing = null)
        {


            Func<double, Color> transform = (t) => t <= 0.5f ?

                 Color.FromRgba(fromColor.Red + 2f * t * (toColor.Red - fromColor.Red),
                               fromColor.Green + 2f * t * (toColor.Green - fromColor.Green),
                               fromColor.Blue + 2f * t * (toColor.Blue - fromColor.Blue),
                               fromColor.Alpha + 2f * t * (fromColor.Alpha - toColor.Alpha)) : Color.FromRgba(toColor.Red + 2f * (t - 0.5f) * (fromColor.Red - toColor.Red),
                                 toColor.Green + 2f * (t - 0.5f) * (fromColor.Green - toColor.Green),
                                 toColor.Blue + 2f * (t - 0.5f) * (fromColor.Blue - toColor.Blue),
                                 toColor.Alpha + 2f * (t - 0.5f) * (fromColor.Alpha - toColor.Alpha));


            return ColorsAnimation(self, "ColorTo", transform, callback, length, easing);

        }

        public static void CancelAnimation(this VisualElement self)
        {
            self.AbortAnimation("AngelTo");
        }
        static Task<bool> ColorsAnimation(VisualElement element, string name, Func<double, Color> transform, Action<Color> callback, uint length, Easing easing)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            element.Animate<Color>(name, transform, callback, 16, length, easing, (v, c) => element.Background = v, () => true);
            return taskCompletionSource.Task;
        }
        static Task<bool> ColorsAnimation(VisualElement element, string name, Func<double, LinearGradientBrush> transform, Action<LinearGradientBrush> callback, uint length, Easing easing, bool istrue)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            element.Animate<LinearGradientBrush>(name, transform, callback, 16, length, easing, (v, c) => element.Background = v, () => false);
            return taskCompletionSource.Task;
        }
    }
}
