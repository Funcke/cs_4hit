using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MSEventPattern
{
    public partial class Observer3 : Form
    {
        int nums = 0;
        public Observer3()
        {
            InitializeComponent();
        }

        public void DisplayUpdate(object sender, EventArgs e)
        {
            int num = ((NumberChangedEventArgs)e).Number;
            this.label1.Text = (num > 25 ? num:0).ToString();
            this.label2.Text = (num > 25 ? ++nums : nums).ToString();
            this.Refresh();
        }

        public void ResetCounter()
        {
            this.nums = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ResetCounter();
        }
    }
}
