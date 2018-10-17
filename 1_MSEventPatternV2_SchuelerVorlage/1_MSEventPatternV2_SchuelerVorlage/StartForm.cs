using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MSEventPattern
{
	public class StartForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button cmdStop;
		private System.Windows.Forms.Button cmdStart;
		private System.ComponentModel.Container components = null;
		private Model model=null;
		private Observer1 observer1=null;
        private Button cmdExit;
        private CheckBox checkBox3;
        private Observer2 observer2=null;
        private Observer3 observer3 = null;

	public StartForm()		
    {	
        InitializeComponent();
        model = new Model();
        observer1 = new Observer1();
        observer2 = new Observer2();
            observer3 = new Observer3();
        cmdStart.Enabled = true; cmdStop.Enabled = false;
    }

	protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Vom Windows Form-Designer generierter Code
		private void InitializeComponent()
		{
            this.cmdStart = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.cmdStop = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(67, 28);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(125, 46);
            this.cmdStart.TabIndex = 0;
            this.cmdStart.Text = "Start generateing numbers";
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(77, 102);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(125, 27);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Observer 1";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(230, 102);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(125, 27);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Observer 2";
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // cmdStop
            // 
            this.cmdStop.Location = new System.Drawing.Point(221, 28);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(115, 46);
            this.cmdStop.TabIndex = 3;
            this.cmdStop.Text = "Stop generating numbers";
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(354, 122);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(43, 28);
            this.cmdExit.TabIndex = 4;
            this.cmdExit.Text = "exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(67, 80);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(98, 21);
            this.checkBox3.TabIndex = 5;
            this.checkBox3.Text = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // StartForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(344, 141);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdStop);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cmdStart);
            this.Name = "StartForm";
            this.Text = "Start Observers";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		private void cmdStart_Click(object sender, System.EventArgs e)
		{		
			cmdStart.Enabled=false;	cmdStop.Enabled=true;
			observer1.Show();
			observer2.Show();
            observer3.Show();
            try
            {
                model.Start(); // Aufrufen der Events in model
            }
            catch (Exception ex)
            {
                model.Stopp();
                MessageBox.Show(ex.Message);
            }
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (checkBox1.Checked)
                 model.Changed += new Model.NumberChangedEventhandler(observer1.UpdateDisplay);
            else model.Changed -= new Model.NumberChangedEventhandler(observer1.UpdateDisplay);
		}

		private void checkBox2_CheckedChanged(object sender, System.EventArgs e)
		{
			if (checkBox2.Checked)
                 model.Changed += new Model.NumberChangedEventhandler(observer2.UpdateDisplay);
            else model.Changed -= new Model.NumberChangedEventhandler(observer2.UpdateDisplay);
		}

		private void cmdStop_Click(object sender, System.EventArgs e)
		{			
			cmdStart.Enabled=true; cmdStop.Enabled=false;
            model.Stopp(); // Beenden der Schleife der Events in model
		}

        private void cmdExit_Click(object sender, EventArgs e)
        {
            model.Stopp();
            observer1.Close();
            observer2.Close();
            this.Close();
            Application.Exit();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                model.Changed += new Model.NumberChangedEventhandler(this.observer3.DisplayUpdate);
            else model.Changed -= new Model.NumberChangedEventhandler(this.observer3.DisplayUpdate);
        }
    }
}
