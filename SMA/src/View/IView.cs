﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMA.src.View
{
    interface IView
    {
        void InitView();
        void UpdateView();
        bool IsRunning();
        void setFPS(int fps);
        void Screenshot(String path);
    }
}
