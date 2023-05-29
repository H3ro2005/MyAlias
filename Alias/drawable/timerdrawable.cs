
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Font = Microsoft.Maui.Graphics.Font;

namespace Alias.drawable
{
    public partial class timerdrawable : IDrawable

    {
        public float TimeLineSize { get; set; } = 5;
        public float prog = 0f;
        public float Time { get; set; } = 0;
        public float UpdaterTicks { get; set; } = 0;
        public Color TimerColor { get; set; } = Colors.Transparent;
        public Color InsideColor { get; set; } = Colors.Transparent;

        public  void Draw(ICanvas canvas, RectF dirtyRect)
        {
            dirtyRect.X = 10;
            dirtyRect.Y = 10;
            if (Time == UpdaterTicks)
            {
               
                
                canvas.StrokeColor = TimerColor;
                canvas.StrokeSize = TimeLineSize;
                canvas.DrawEllipse(dirtyRect.X, dirtyRect.Y, (dirtyRect.Width - dirtyRect.X * 2), (dirtyRect.Height - dirtyRect.Y * 2));
                canvas.StrokeColor = InsideColor;
                canvas.StrokeSize = TimeLineSize / 2;
                canvas.DrawEllipse(dirtyRect.X, dirtyRect.Y, (dirtyRect.Width - dirtyRect.X * 2), (dirtyRect.Height - dirtyRect.Y * 2));
            }
            else
            {
                var progress = (float)Time;
                prog += 1f / (progress);
                float endAngle = 90 - (float)Math.Round(prog * 360);
                canvas.StrokeColor = TimerColor;
                canvas.StrokeSize = TimeLineSize;
                canvas.DrawArc(dirtyRect.X, dirtyRect.Y, (dirtyRect.Width - dirtyRect.X*2), (dirtyRect.Height - dirtyRect.Y*2), 90, endAngle, false, false);
                canvas.StrokeColor = InsideColor;
                canvas.StrokeSize = TimeLineSize / 2;
                canvas.DrawArc(dirtyRect.X, dirtyRect.Y, (dirtyRect.Width - dirtyRect.X * 2), (dirtyRect.Height - dirtyRect.Y * 2), 90, endAngle, false, false);
            }
       


       

        }

    }
}
