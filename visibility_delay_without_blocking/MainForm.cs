using System;
using System.Threading;
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
            new Thread(makeVisibleOnDelay).Start();
        }

        private void makeVisibleOnDelay()
        {
            Thread.Sleep(1000);
            Invoke((MethodInvoker)delegate { panel1.Visible = true; });
            Thread.Sleep(1000);
            Invoke((MethodInvoker)delegate { panel2.Visible = true; });
        }
    }
}

