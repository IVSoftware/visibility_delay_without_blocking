using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace visibility_delay_without_blocking
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            timer.Start();
            var count = 0;
            timer.Tick += (sender, e1) =>
            {
                switch (count++)
                {
                    case 0:
                        panel1.Visible = true;
                        break;
                    case 1:
                        panel2.Visible = true;
                        timer.Stop();
                        break;
                    default:
                        Debug.Assert(false, "Expecting timer to stop on count 1");
                        break;
                }
            };
        }

        Timer timer = new Timer() { Interval = 1000 };
    }
}

