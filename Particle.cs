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
    public class Particle
    {
        public int time_to_death = 50;//number of steps to death. This is used to calculate the fade out on the particle so don'tmess with it too much
        public Vector2 particlePosition;//particles position
        public  Vector2 vector;     //vector representing direction and speed
        public Vector2 environment =new Vector2(0.0f, 0.0f);//a vector that can be used for wind or gravity. Try (0f, 0.25f) fro gentle gravity
                                                        // or (-0.5f, -0.5f) for a wing blowing towards the top left of the screen
        public int d =5;//diameter of a particle less works...more does not
                
        public Particle(int pointX, int pointY,float vectorX,float vectorY)//constructor
        {            
            particlePosition=new Vector2(pointX, pointY);            
            vector = new Vector2(vectorX, vectorY);
        }   
        public void update()//update the particle position
        { 
            particlePosition = Vector2.Add(particlePosition, vector);//update position
            vector = Vector2.Add(vector, environment);//update vector
            time_to_death--;    

        }
    }
}
