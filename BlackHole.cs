using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Particles_V1._0
{
    internal class BlackHole
    {
        public int startx;
        public int starty;
        private Timer _timer;
        public int r =10; //radius of BH
        public static int blackHoleCount = 0;

        public BlackHole() { }
        public BlackHole(int startx, int starty)
        {
            blackHoleCount++;
            this.startx = startx;
            this.starty = starty;
            _timer = new Timer(OnTimerTick, null, 0, 50);
        }
        private void OnTimerTick(object o)
        {
            r++;
        }
    }
}
