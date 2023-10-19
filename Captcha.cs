using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Graphics;

namespace kysMaui
{
    public class Captcha : IDrawable
    {
        string _value;
        public string Value => _value;

        Random random = new();
        int _length = 4;
        string[] alphabets = { "abcdefghijklmnopqrstuvwxyz", "ABCDEFGHIJKLMNOPQRSTUVWXYZ" };
        
        public Captcha()
        {
            Generate();
        }

        public void Generate(int length)
        {
            _value = "";
            for (int i = 0; i < length; i++)
            {
                string alphabet = alphabets[random.Next(alphabets.Length)];
                _value += alphabet[random.Next(alphabet.Length)];
            }
        }

        public void Generate()
        {
            _value = "";
            for (int i = 0; i < _length; i++)
            {
                string alphabet = alphabets[random.Next(alphabets.Length)];
                _value += alphabet[random.Next(alphabet.Length)];
            }
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 2;
            canvas.DrawRectangle(dirtyRect);

            canvas.FontSize = 40;
            canvas.DrawString(_value, dirtyRect, HorizontalAlignment.Center, VerticalAlignment.Center);

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
            canvas.DrawArc(arcBounds, 0, 180 + random.Next(30), true, false);
        }
    }
}
