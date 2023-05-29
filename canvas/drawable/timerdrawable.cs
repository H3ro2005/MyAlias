using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canvas.drawable
{
    public partial class timerdrawable : IDrawable

    {
        public string Time { get; set; } = "a";
        public  void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.FillColor = Colors.Coral; canvas.StrokeColor = Colors.AliceBlue;
            canvas.FontSize = 72;
         canvas.DrawString(Time, 100, 100, 380, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
        }

    }
}
