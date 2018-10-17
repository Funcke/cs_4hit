using System.Collections;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MSEventPattern
{
	public class Observer2 : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;
		
		//**********
		private int y = 0;
		private const int fy = 3;
    
		protected override void OnPaint(PaintEventArgs e)
		{
			const int x1 = 120;
			const int y1 = 30;
			const int b = 30;
			const int ymax = 50;
			Graphics g = e.Graphics;
			g.FillRectangle(new SolidBrush(Color.Red), x1, fy * ymax + y1 - y, b, y);
			base.OnPaint(e);
		}

		// ******* Methode des Observers, die durch das Event aufgerufen wird *****
		public void UpdateDisplay(object sender, EventArgs e)
		{
            y = ((NumberChangedEventArgs)e).Number * fy;
			this.Refresh();
		}       
		// ***************************************************************************************
		
		public Observer2()
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
			// 
			// Observer2
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(272, 133);
			this.Name = "Observer2";
			this.Text = "Observer2";
		}
		#endregion
	}
}
