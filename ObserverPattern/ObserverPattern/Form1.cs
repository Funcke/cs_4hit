using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ObserverPattern
{
    public partial class Form1 : Form
    {
        private LocationReporter reporter;
        private LocationTracker tracker;
        public Form1()
        {
            this.tracker = new LocationTracker();
            this.tracker.Subscribe(new LocationReporter("yes"));
            new Thread(() =>
            {
                track(tracker);
            }).Start();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        
        void track(LocationTracker tracker)
        {
            while(true)
            {
                tracker.TrackLocation("hello");
                Thread.Sleep(3000);
            }
        }
    }
}
