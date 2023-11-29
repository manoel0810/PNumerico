using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PNumerico
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            WaitTime.Start();
        }

        private void SplashImage_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WaitTime_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
