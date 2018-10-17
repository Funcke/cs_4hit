using System;

namespace MSEventPattern
{
	public class NumberChangedEventArgs: EventArgs
	{	
			private object number;
	
		    // Konstruktoren:
			public NumberChangedEventArgs()	{}
			public NumberChangedEventArgs(object nr) {number = nr;}

			// Read-Only Eigenschaft:
			public int Number {	get { return (int)number; }	}
		
	} //class
} //ns
