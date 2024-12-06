using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Particles_V1._0
{
    public class BlackHole
    {
        public int startx;
        public int starty;
        private System.Threading.Timer _timer;
        public int r ; //radius of BH
        public static int blackHoleCount = 0;
        private readonly Form1 _form1;

        public BlackHole(int startx, int starty, Form1 form1)
        {
            _form1 = form1;
            r = 50;
            blackHoleCount++;
            this.startx = startx;
            this.starty = starty;
            _timer = new System.Threading.Timer(OnTimerTick, null, 0, 50);
            _form1 = form1;
        }
        private void OnTimerTick(object o)
        {
            r++;
            _form1.Invalidate();
        }
    }
}
