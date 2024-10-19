using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Particles_V1._0
{
    internal class Particle
    {
        public PointF particlePosition;
        public  Vector2 vector;
        
        
        
        public Particle() { }
        public Particle(int pointX, int pointY,float vectorX,float vectorY)
        {
            Random rnd = new Random();
            particlePosition=new PointF(pointX, pointY);
            
            vector = new Vector2(vectorX, vectorY);
        }
    }
}
