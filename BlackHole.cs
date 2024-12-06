using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Particles_V1._0
{
    public class BlackHole
    {
        public int startx;
        public int starty;
        private Timer _timer;
        public int r ; //radius of BH
        public static int blackHoleCount = 0;

        public BlackHole() { startx = 0; starty = 0; }
        public BlackHole(int startx, int starty)
        {
            r = 10;
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
