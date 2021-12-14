using SimpleAlgorithmsApp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class GraphicsManager<T>
    {

        private int MaxCapacity = 100;
        Graphics graphics;
        Pen pen;
        Color color = Color.Black;
        int Width;
        int Height;

        public GraphicsManager(int Width, int Height)
        {
            pen = new Pen(color);
            this.Width = Width;
            this.Height = Height;
        }

        public void SetGraphic(Graphics graphics)
        {
            this.graphics = graphics;
        }

        private void DrawBlock(GraphicBlock<T> block, int index)
        {
            int fontSize = block.FontSize;
            pen.Color = block.Color;
            graphics.DrawRectangle(pen, block.X, block.Y, block.Width, block.Height);
            Font font = new Font("Arial", fontSize);
            graphics.DrawString("N:" + index + " " + block.Data.ToString(), font, new SolidBrush(pen.Color), block.X + 1, block.Y + 1);
        }

        private void DrawLineUpDown(Point from, Point to)
        {
            int middleX = 0;
            if (from.X < to.X)
            {
                middleX = to.X + (to.X - from.X) / 2;
            }
            else
            {
                middleX = from.X + (from.X - to.X) / 2;
            }
        }

        private void DrawLine(Pen pen, Point from, Point to, bool left, bool down, bool vertical)
        {
            int middleX = 0;
            int middleY = 0;

            middleX = left ? from.X + (to.X - from.X) / 2 : to.X + (from.X - to.X) / 2;
            middleY = down ? from.Y + (to.Y - from.Y) / 2 : to.Y + (from.Y - to.Y) / 2;

            if (!vertical)
            {
                graphics.DrawLine(pen, from, new Point(middleX,from.Y));
                graphics.DrawLine(pen, new Point(middleX, from.Y), new Point(middleX, to.Y));
                graphics.DrawLine(pen, new Point(middleX, to.Y), to);
            }
            else
            {
                graphics.DrawLine(pen, from, new Point(from.X, middleY));
                graphics.DrawLine(pen, new Point(from.X, middleY), new Point(to.X, middleY));
                graphics.DrawLine(pen, new Point(to.X, middleY), to);
            }
        }

        private double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        public Point FindPlace(CustomList<GraphicBlock<T>> list, Point point, Point size)
        {
            bool[,] place = new bool[Width, Height];
            foreach (var item in list)
            {
                var elem = (GraphicBlock<T>)item;
                for (int i = elem.Left.X - size.X; i< elem.Right.X + size.X; i++)
                {
                    if (i >=0 && i < Width)
                    {
                        for (int j = elem.Up.Y - size.Y; j < elem.Down.Y + size.Y; j++)
                        {
                            if (j>=0 && j < Height)
                            {
                                place[i, j] = true;
                            }
                        }
                    }
                }
            }

            Point minpoint = new Point(0, 0);
            double mindist = Int32.MaxValue;
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    double dist = GetDistance(point, new Point(i, j));
                    if (dist < mindist && !place[i,j])
                    {
                        mindist = dist;
                        minpoint = new Point(i, j);
                    }
                }
            }
            return minpoint;

        }

        private void DrawConnection(GraphicBlock<T> from, GraphicBlock<T> to)
        {
            if (from == to)
            {
                return;
            }

            if (from.X < to.X)
            {

            }

            pen.Color = to.DefaultColor;
            bool left = from.X < to.X;
            bool down = from.Y < to.Y;
            Point f;
            Point t;

            bool vertical = Math.Abs(from.X - to.X) < Math.Abs(from.Y - to.Y) 
                || (from.Right.X > to.Left.X && left)
                || (to.Right.X > from.Left.X && !left);
            if (vertical)
            {
                f = down ? from.Down : from.Up;
                t = down ? to.Up : to.Down;
            }
            else
            {
                f = left ? from.Right : from.Left;
                t = left ? to.Left : to.Right;
            }
            DrawLine(pen, f, t, left, down, vertical);
        }

        public void DrawList(CustomList<GraphicBlock<T>> list)
        {
            if (list.IsEmpty)
            {
                return;
            }
            GraphicBlock<T> prev = list.First();
            int index = 0;
            foreach (var item in list)
            {
                GraphicBlock<T> itemCast = (GraphicBlock<T>)item;
                DrawConnection(prev, itemCast);
                DrawBlock(itemCast, index);
                prev = itemCast;
                index++;
            }
        }

        public GraphicBlock<T> GetBlock(CustomList<GraphicBlock<T>> list, int x, int y)
        {
            
            foreach (var i in list)
            {
                GraphicBlock<T> item = (GraphicBlock<T>)i;
                if (x > item.X 
                    && x < item.X + item.Width 
                    && y > item.Y
                    && y < item.Y + item.Height
                    )
                {
                    return item;
                }
            }
            return null;
        }
    }
}
