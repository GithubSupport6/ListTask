using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddForm : Form
    {
        int Size = 0;
        int MaxCapacity = 0;

        public string data;
        public int index;
        public bool isInsert;
        public bool isAfter;
        public AddForm(int currSize)
        {
            InitializeComponent();
            Size = currSize;
            IndexCounter.Maximum = Math.Max(currSize, 1);
            IndexCounter.Minimum = 1;
        }

        private void PrepareData(bool insert,bool after)
        {
            isInsert = insert;
            isAfter = after;
            data = DataTextBox.Text;
            index = (int)IndexCounter.Value - 1;
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            PrepareData(true, false);
        }

        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            PrepareData(false, true);
        }

        private void AfterButton_Click(object sender, EventArgs e)
        {
            PrepareData(true, true);
        }
    }
}
