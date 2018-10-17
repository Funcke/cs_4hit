using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MSEventPattern
{
	public class Observer1 : System.Windows.Forms.Form
	{
        private int sum = 0;
		private System.Windows.Forms.Label label1;
        private Button button1;
        private System.ComponentModel.Container components = null;

		// ******* Methode des Observers, die durch das Event aufgerufen wird *****
		public void UpdateDisplay(object sender, EventArgs e)
		{
            this.label1.Text = ((NumberChangedEventArgs)e).Number.ToString() + ' ' +(sum += ((NumberChangedEventArgs)e).Number).ToString();
            this.Refresh();
		}

        public void ResetSum()
        {
            this.sum = 0;
        }
		//***************************************************************************************

		public Observer1()
		{
				InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Vom Windows Form-Designer generierter Code

		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Check Checkbox!";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Reset Sum";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Observer1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(272, 157);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Observer1";
            this.Text = "Observer1";
            this.ResumeLayout(false);

		}
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.ResetSum();
        }
    }
}
