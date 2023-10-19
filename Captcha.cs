using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Graphics;

namespace kysMaui
{
    class Captcha : IDrawable
    {
        string value;
        Random random = new();
        string[] alphabets = { "abcdefghijklmnopqrstuvwxyz", "ABCDEFGHIJKLMNOPQRSTUVWXYZ" };

        public void Generate(int length)
        {
            value = "";
            for (int i = 0; i < length; i++)
            {
                string alphabet = alphabets[random.Next(alphabets.Length)];
                value += alphabet[random.Next(alphabet.Length)];
            }
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            Generate(4);
            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 2;
            canvas.DrawRectangle(dirtyRect);

            canvas.FontSize = 40;
            canvas.DrawString(value, dirtyRect, HorizontalAlignment.Center, VerticalAlignment.Center);

            //canvas.StrokeSize = 1;
            for (int x = 0; x < dirtyRect.Width; x++)
            {
                for (int y = 0; y < dirtyRect.Height; y++)
                {
                    canvas.StrokeSize = random.Next(1, 3);
                    if (random.NextDouble() > 0.9)
                    {
                        canvas.DrawRectangle(x, y, 1, 1);
                    }
                }
            }

            canvas.StrokeSize = 2;
            var arcBounds = dirtyRect;
            arcBounds.Right += random.Next(-20, 20);
            arcBounds.Left += random.Next(-20, 20);
            arcBounds.Bottom /= 2;
            canvas.DrawArc(arcBounds, 0, 180+random.Next(30), true, false);
        }
    }
}
