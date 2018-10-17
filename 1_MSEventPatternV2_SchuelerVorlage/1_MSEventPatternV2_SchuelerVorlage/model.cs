using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace MSEventPattern
{
	public class Model 
	{
        // MS konformen Ereignistyp deklarieren: NumberChangedEventHandler
        // erg�nze hier den Code
        public delegate void NumberChangedEventhandler(object sender, EventArgs e);

        public event NumberChangedEventhandler Changed;

        // MS konformes Ereignis vom Typ des Delegaten deklarieren: NumberChanged
        // erg�nze hier den Code
         
		private Random random = new Random();
		private int number = 0;
		private bool halt = false;

		private void delay(long zeit)
		{
			long zeit1 = System.Environment.TickCount;
			while ((System.Environment.TickCount - zeit1) < zeit) Application.DoEvents();
		}

		public void Start()
        { // L�st periodisch NumberChanged-Event aus und verst�ndigt Observer
            this.halt = false;
            while (!halt)
			{
				number = random.Next(50) + 1;
                // Ereignis ausl�sen:
                this.OnNumberChanged(new NumberChangedEventArgs(number));

                // 1s warten
				this.delay(1000);
			}			
		}
        
        public void Stopp()		{ this.halt = true;	}
      
		protected void OnNumberChanged(EventArgs e)
		{
			if(this.Changed != null)
            {
                this.Changed(this, e);
            }

		}

	} // class
}
