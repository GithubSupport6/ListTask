using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class GraphicBlock<T>
    {
        public Color DefaultColor { get; } = Color.Black;

        public T Data { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public static int DefaultWidth { get; } = 100;

        public static int DefaultHeight { get; } = 40;

        public Point Up
        {
            get
            {
                return new Point(X + Width / 2, Y);
            }
        }

        public Point Down
        {
            get
            {
                return new Point(X + Width / 2, Y + Height);
            }
        }

        public Point Left
        {
            get
            {
                return new Point(X, Y + Height / 2);
            }
        }

        public Point Right
        {
            get
            {
                return new Point(X + Width, Y + Height / 2);
            }
        }

        public Color Color { get; private set; } = Color.Black;

        public bool IsSelected { get; private set; }

        public void Select(bool select = true)
        {
            IsSelected = select;
            Color = select ? Color.Red : Color.Black;
        }

        public int FontSize { get; } = 10;


        public void SetSize(double size)
        {
            Width = (int)(Width * size * 5);
            Height = (int)(Height * size);
        }

        public void Resize(Graphics graphics)
        {
            Font font = new Font("Arial", FontSize);
            SizeF size = graphics.MeasureString("Data: " + Data.ToString(), font);
            SizeF numsize = graphics.MeasureString("N: ", font);
            size.Height = size.Height + numsize.Height;

            Width = Width < size.Width ? (int)size.Width : Width;
            Height = Height < size.Height ? (int)size.Height : Height;
        }

        public GraphicBlock(T data, int x, int y, int w = 100, int h = 20)
        {
            this.Data = data;
            this.X = x;
            this.Y = y;
            Width = w;
            Height = h;
        }
    }
}
