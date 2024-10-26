﻿using System;
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
        public int time_to_death = 50;//number of steps to death
        public Vector2 particlePosition;//particles position
        public  Vector2 vector;     //vector representing direction and speed
        public Vector2 environment =new Vector2(0f, 0.25f);//a vector that can be used for wind or gravity
        public int d =5;
                
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
