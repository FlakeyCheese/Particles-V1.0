using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Particles_V1._0
{
    internal class Explosion
    {
        public Particle[] p = new Particle[50];//create an array of particles
        private Timer _timer;
        Random rnd = new Random();
        public int r,g,b;
        public Explosion(int startX, int startY)
        {
             r = rnd.Next(0, 255);
             g = rnd.Next(0, 255);
             b = rnd.Next(0, 255);

            for (int i = 0; i < p.Length; i++)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());//a very random seed
                // now get a random point from the helper class
                var (x, y) = RandomCirclePoint.GenerateRandomPoint(5, rand);

                //create a new particle. 
                p[i] = new Particle(startX, startY, x, y);
            }
            _timer = new Timer(OnTimerTick,null,0,100);//create a new timer.
             //This needs to be after we create the particles because the timer references the particles
            
        }
        private void OnTimerTick(object o)
        {
            for (int i = 0; i < p.Length; i++)
            {
                p[i].update();//call the particle method to update its position
            }
            //redraw the active form (used this because it may try to draw on Form1 after it has closed)
            //still crashes here on exit on occassion
            System.Windows.Forms.Form.ActiveForm.Invalidate();
        }

    }
}
