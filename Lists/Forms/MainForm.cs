﻿using SimpleAlgorithmsApp;
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
using WindowsFormsApp1.Files;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        CustomList<GraphicBlock<string>> list;
        Graphics g;
        GraphicsManager<string> manager;

        GraphicBlock<string> moved;
        GraphicBlock<string> clicked;
        bool isOnMove = false;
        bool isOnBlock = false;
        bool isResized = false;
        bool canBeResized = true;

        int MaxCapacity = 50;
        

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
        }

        private bool IsPossibleToInsert()
        {
            return list.Count() < MaxCapacity;
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(DefaultBackColor);
            manager.SetGraphic(e.Graphics);
            manager.DrawList(list);
            if (canBeResized && !isResized)
            {
                manager.ResizeBlocks(list);
                isResized = true;
            }
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

        private void RightButtonInsert(object sender, MouseEventArgs e)
        {
            AddForm addForm = new AddForm(list.Count());
            addForm.Location = e.Location + ((Size)this.Location);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                int index = addForm.index;
                string data = addForm.data;
                if (addForm.isInsert)
                {
                    InsertAfterOrBefore(data, addForm.isAfter);
                    
                }
                else
                {
                    list.ElementAt(index).Data = data; 
                }
            }

        }

        private void MainPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && IsPossibleToInsert())
            {
                RightButtonInsert(sender, e);
                return;
            }

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

        private GraphicBlock<string> CreateGraphicBlock(string data, Point center, Point size)
        {
            Point point = manager.FindPlace(list, center, size);
            var newBlock = new GraphicBlock<string>(data, point.X, point.Y);
            return newBlock;
        }

        private void InsertAfterOrBefore(string data, bool isAfter)
        {
            GraphicBlock<string> newBlock;

            if (clicked != null)
            {
                Point center = new Point(clicked.X, clicked.Y);
                Point size = new Point(clicked.Width, clicked.Height);
                newBlock = CreateGraphicBlock(data, center, size);
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
                Point size = new Point(GraphicBlock<string>.DefaultWidth, GraphicBlock<string>.DefaultHeight);

                newBlock = CreateGraphicBlock(data, center, size);
                if (list.IsEmpty || isAfter)
                {
                    list.Add(newBlock);
                }
                else
                {
                    list.InsertBefore(0, newBlock);
                }
                
            }
            isResized = false;
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            if (!IsPossibleToInsert())
            {
                MessageBox.Show("Too many elements in list!", "Message", MessageBoxButtons.OK);
            }
            else
            {
                InsertAfterOrBefore(insertTextBox.Text, true);
            }
            MainPanel.Invalidate();
        }

        private void BeforeButton_Click(object sender, EventArgs e)
        {
            if (!IsPossibleToInsert())
            {
                MessageBox.Show("Too many elements in list!", "Message", MessageBoxButtons.OK);
            }
            else
            {
                InsertAfterOrBefore(insertTextBox.Text, false);
            }
            MainPanel.Invalidate();
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!list.IsEmpty && list != null)
                {
                    if (MessageBox.Show("Changes unsaved, do you want to save it?","Message",MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            FileParser.Save(list, SaveFileDialog.FileName);
                        }
                    }
                }
                var newList = FileParser.Parse(OpenFileDialog.FileName);
                list = newList;
                isResized = false;
            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileParser.Save(list, SaveFileDialog.FileName);
            }      
        }

    }
}
