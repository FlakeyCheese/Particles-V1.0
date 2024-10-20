using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Particles_V1._0
{
    public partial class Form1 : Form
        
    {
        
        Particle[] p =new Particle[100];//create an array of particles
        
        public Form1()
        {
            InitializeComponent();
            
            for (int i = 0; i < p.Length; i++)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());//a very random seed
                Random rnd = new Random(Guid.NewGuid().GetHashCode());//another one
                float vX = (rand.Next(5000))-2500;//get 2 random values between -2500 and 2500
                float vY = (rnd.Next(5000) )-2500;
                //create a new particle. Vector values from vX and vY divided by 100 to create 2 floats
                p[i] = new Particle(this.Width/2, this.Height/2,vX/100, vY/100);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            for (int i = 0; i < p.Length; i++)//iterate through the particle array and draw each one
            {                
                e.Graphics.DrawEllipse(Pens.Red, p[i].particlePosition.X, p[i].particlePosition.Y, 5, 5);
            }  
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            for (int i = 0; i < p.Length; i++)
            {
                p[i].update();//call the particle method to update its position
            }

            
            Invalidate();//refresh the form, re-draw it.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
