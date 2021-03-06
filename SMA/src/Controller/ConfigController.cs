﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMA.src.View;

namespace SMA.src.Controller
{
    class ConfigController
    {
        private static ConfigController _instance;

        public static ConfigController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ConfigController();

                return _instance;
            }
        }

        private ConfigController() { }


        private ConfigWin _win;
        

        public void ShowWin()
        {
            _win = new ConfigWin();
            _win.Show(); 
        }


        public void startClick(object sender, EventArgs e)
        {
            if (_win.GetStart() == "STOP")
            {
                _win.SetStart("START");
                MainController.Instance.Paused = true;
            }

            else
            {
                _win.SetStart("STOP");
                MainController.Instance.Paused = false;
            }
        }

        public void colorsClick(object sender, EventArgs e)
        {
            if (_win.GetColors() == "Activate colors on Antzz")
            {
                _win.SetColors("Deactivate colors on Antzz");
                MainController.Instance.Colored = true;
            }

            else
            {
                _win.SetColors("Activate colors on Antzz");
                MainController.Instance.Colored = false;
            }
        }

        public void speedScroll(object sender, EventArgs e)
        {
            _win.UpdateSpeed();
            MainController.Instance.Fps = _win.GetSpeed();
            MainController.Instance.View.setFPS(_win.GetSpeed());
        }

        public void resetClick(object sender, EventArgs e)
        {
            int cols = _win.GetCols();
            int rows = _win.GetRows();

            _win.Close();

            MainController.Instance.ResetAll(cols, rows, /*speedTB.Value*/10);
        }

        public void screenClick(object sender, EventArgs e)
        {
            MainController.Instance.View.Screenshot("screenshots/screen_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".bmp");
        }

        public void colsScroll(object sender, EventArgs e)
        {
            _win.UpdateCols();
        }

        public void rowsScroll(object sender, EventArgs e)
        {
            _win.UpdateRows();
        }
    }
}
