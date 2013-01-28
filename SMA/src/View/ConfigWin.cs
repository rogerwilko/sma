using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMA.src.Controller;

namespace SMA.src.View
{
    public partial class ConfigWin : Form
    {
        public ConfigWin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bStart.Text == "STOP")
            {
                bStart.Text = "START";
                MainController.Instance.Paused = true;
            }

            else
            {
                bStart.Text = "STOP";
                MainController.Instance.Paused = false;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            labSpeed.Text = speedTB.Value.ToString();
            MainController.Instance.Fps = speedTB.Value;
            MainController.Instance.View.setFPS(speedTB.Value);
        }
    }
}
