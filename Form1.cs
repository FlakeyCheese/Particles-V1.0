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
        
        Particle[] p =new Particle[50];//create an array of particles
        
        public Form1()
        {
            this.DoubleBuffered = true;//smooths the animation
            InitializeComponent();
            Initialise();//call initialise( ) to randomise the particle vectors.
            
        }
        public void Initialise()
        {
            for (int i = 0; i < p.Length; i++)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());//a very random seed
                var (x,y) = RandomCirclePoint.GenerateRandomPoint(5,rand);

                //create a new particle. Vector values from vX and vY divided by 100 to create 2 floats
                p[i] = new Particle(this.Width/2, this.Height/2,x, y);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //SolidBrush brush = new SolidBrush(Color.FromArgb(255,255,0,0)); 
            
            for (int i = 0; i < p.Length; i++)//iterate through the particle array and draw each one
            {if (p[i].time_to_death > 5)
                {
                    SolidBrush brush = new SolidBrush(Color.FromArgb(p[i].time_to_death * 5, 255, 0, 0));
                    e.Graphics.FillEllipse(brush, p[i].particlePosition.X, p[i].particlePosition.Y, 5, 5);
                    brush.Dispose();
                }
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

        private void button2_Click(object sender, EventArgs e)
        {
            Initialise();
            timer1.Enabled=false;   
        }
    }
}
