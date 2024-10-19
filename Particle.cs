using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Particles_V1._0
{
    internal class Particle
    {
        public PointF particlePosition;//particles position
        public  Vector2 vector;     //vector representing direction and speed...I think :-)
                
        public Particle(int pointX, int pointY,float vectorX,float vectorY)//constructor
        {            
            particlePosition=new PointF(pointX, pointY);            
            vector = new Vector2(vectorX, vectorY);
        }   
        public void update()//update the particle position
        {
            particlePosition.X += vector.X;
            particlePosition.Y += vector.Y;

        }
    }
}
