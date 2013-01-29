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


            // abonnement des méthodes du contrôleur

            bStart.Click += ConfigController.Instance.startClick;
            bReset.Click += ConfigController.Instance.resetClick;
            speedTB.Scroll += ConfigController.Instance.speedScroll;
            rowsTB.Scroll += ConfigController.Instance.rowsScroll;
            colsTB.Scroll += ConfigController.Instance.colsScroll;

            speedTB.Value = MainController.Instance.Fps;
        }


        public String GetStart()
        {
            return bStart.Text;
        }

        public void SetStart(String txt)
        {
            bStart.Text = txt;
        }

        public void UpdateSpeed()
        {
            labSpeed.Text = speedTB.Value.ToString();
        }

        public int GetSpeed()
        {
            return speedTB.Value;
        }

        public void UpdateRows()
        {
            labRows.Text = rowsTB.Value.ToString();
        }

        public int GetRows()
        {
            return rowsTB.Value;
        }

        public void UpdateCols()
        {
            labCols.Text = colsTB.Value.ToString();
        }

        public int GetCols()
        {
            return colsTB.Value;
        }
    }
}
