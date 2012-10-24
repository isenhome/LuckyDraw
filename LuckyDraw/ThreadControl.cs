using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyDraw
{
    public class ThreadControl
    {
        public static ThreadControl threadControl;

        public ThreadControl() 
        { 
        
        }

        public static ThreadControl getEntity()
        {
            if (threadControl == null)
            {
                threadControl = new ThreadControl();
            }
            return threadControl;
        }

        public MainForm mainForm { get; set; }
    }
}
