using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stopper
{
    public partial class Form1 : Form
    {
        private Timer stopperTimer = new Timer();
        private TimeSpan elapsedTime = TimeSpan.Zero;
        public Form1()
        {
            InitializeComponent();
            stopperTimer.Interval = 1000;
            stopperTimer.Tick += StopperTimer_Tick;
            button1.Click += BtnStart_Click;
            button2.Click += BtnPause_Click;
            button3.Click += BtnStop_Click;
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            stopperTimer.Start();
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            stopperTimer.Stop();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            stopperTimer.Stop();
            elapsedTime = TimeSpan.Zero;
            UpdateElapsedTimeLabel();
        }
        private void StopperTimer_Tick(object sender, EventArgs e)
        {
            elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(1));
            UpdateElapsedTimeLabel();
        }

        private void UpdateElapsedTimeLabel()
        {
            label1.Text = elapsedTime.ToString(@"hh\:mm\:ss");
        }
    }
}
