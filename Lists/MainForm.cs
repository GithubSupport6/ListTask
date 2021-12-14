using SimpleAlgorithmsApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        CustomList<GraphicBlock<string>> list;
        CustomList<GraphicBlock<string>> freeBlocks;
        Graphics g;
        GraphicsManager<string> manager;

        GraphicBlock<string> moved;
        GraphicBlock<string> clicked;
        bool isOnMove = false;
        bool isOnBlock = false;

        

        public MainForm()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                MainPanel,
                new object[] { true }
            );

            manager = new GraphicsManager<string>(MainPanel.Width,MainPanel.Height);
            list = new CustomList<GraphicBlock<string>>();
            //list.Add(new GraphicBlock<string>("Element 1",50,10));
            //list.Add(new GraphicBlock<string>("Element 2", 200, 10));
            //list.Add(new GraphicBlock<string>("Element 3", 350, 10));
            var renderTimer = new Timer();
            

        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(DefaultBackColor);
            manager.SetGraphic(e.Graphics);
            manager.DrawList(list);
        }

        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isOnMove)
            {
                moved.X = e.X - moved.Width / 2;
                moved.Y = e.Y - moved.Height / 2;
            }
            else
            {
                var movedBlock = manager.GetBlock(list, e.X, e.Y);
                if (movedBlock != null)
                {
                    moved = movedBlock;
                    moved.Select();
                    isOnBlock = true;
                }
                else
                {
                    if (moved != null)
                    {
                        moved.Select(false);
                    };
                    isOnBlock = false;
                }
            }
            if (clicked != null) { 
                clicked.Select(true);
            }
            MainPanel.Invalidate();
        }

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (moved != null)
            {
                isOnMove = true;
            }
                
        }

        private void MainPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isOnMove = false;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && clicked != null)
            {
                list.Remove(clicked);
                clicked = null;
                MainPanel.Invalidate();
                dataTextBox.Text = "";
            }
        }

        private void MainPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (isOnBlock)
            {
                if (clicked != null)
                {
                    clicked.Select(false);
                }
                
                clicked = moved;
                dataTextBox.Text = clicked.Data;
                clicked.Select(true);
            }
            else
            {
                if (clicked != null)
                {
                    clicked.Select(false);
                }

                dataTextBox.Text = "";
                clicked = null;
            }
        }

        private void InsertAfterOrBefore(object sender, EventArgs e, bool isAfter)
        {
            GraphicBlock<string> newBlock;

            if (clicked != null)
            {
                Point center = new Point(clicked.X, clicked.Y);
                Point size = new Point(clicked.Width, clicked.Height);

                Point point = manager.FindPlace(list, center, size);
                newBlock = new GraphicBlock<string>(insertTextBox.Text, point.X, point.Y);
                int index = 0;
                foreach (var item in list)
                {
                    if (item == clicked)
                    {
                        break;
                    }
                    index++;
                }
                if (isAfter)
                {
                    list.InsertAfter(index, newBlock);
                }
                else
                {
                    list.InsertBefore(index, newBlock);
                }
                
            }
            else
            {
                Point center = new Point(Width / 2, Height / 2);
                Point size = new Point(100, 20);

                Point point = manager.FindPlace(list, center, size);
                newBlock = new GraphicBlock<string>(insertTextBox.Text,
                    point.X,
                    point.Y
                );
                if (list.IsEmpty || isAfter)
                {
                    list.Add(newBlock);
                }
                else
                {
                    list.InsertBefore(0, newBlock);
                }
                
            }
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            InsertAfterOrBefore(sender, e, true);
            MainPanel.Invalidate();
        }

        private void BeforeButton_Click(object sender, EventArgs e)
        {
            InsertAfterOrBefore(sender, e, false);
            MainPanel.Invalidate();
        }
    }
}
