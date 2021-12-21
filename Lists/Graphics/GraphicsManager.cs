using SimpleAlgorithmsApp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Geometry;

namespace WindowsFormsApp1
{
    class GraphicsManager<T>
    {

        private int MaxCapacity = 50;
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

        public Point FindPlace(CustomList<GraphicBlock<T>> list, Point point, Point size)
        {
            bool[,] place = new bool[Width, Height];
            foreach (GraphicBlock<string> item in list)
            {
                for (int i = item.Left.X - size.X; i< item.Right.X + size.X; i++)
                {
                    if (i >=0 && i < Width)
                    {
                        for (int j = item.Up.Y - size.Y; j < item.Down.Y + size.Y; j++)
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
                    double dist = GeometryHelper.GetDistance(point, new Point(i, j));
                    if (dist < mindist && !place[i,j])
                    {
                        mindist = dist;
                        minpoint = new Point(i, j);
                    }
                }
            }
            return minpoint;

        }

        private void DrawArrow(Pen pen, Point point, bool left, bool down, bool vertical, int size = 4)
        {
            Point l;
            Point r;
            if (vertical)
            {
                l = down ? new Point(point.X - size, point.Y - size) : new Point(point.X - size, point.Y + size);
                r = down ? new Point(point.X + size, point.Y - size) : new Point(point.X + size, point.Y + size);
            }
            else
            {
                //up
                l = left ? new Point(point.X - size, point.Y - size) : new Point(point.X + size, point.Y - size);
                //down
                r = left ? new Point(point.X - size, point.Y + size) : new Point(point.X + size, point.Y + size);
            }
            graphics.DrawLine(pen, point, l);
            graphics.DrawLine(pen, point, r);
        }

        private void DrawConnection(GraphicBlock<T> from, GraphicBlock<T> to, int pointRadix = 3)
        {
            if (from == to)
            {
                return;
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
            graphics.DrawEllipse(pen, f.X - pointRadix, f.Y - pointRadix, pointRadix*2, pointRadix*2);
            DrawLine(pen, f, t, left, down, vertical);
            DrawArrow(pen, t, left, down, vertical);
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
