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
        
        Particle[] p =new Particle[100];
        
        public Form1()
        {
            InitializeComponent();
            
            for (int i = 0; i < p.Length; i++)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                float vX = (rand.Next(5000))-2500;
                float vY = (rnd.Next(5000) )-2500;
                p[i] = new Particle(this.Width/2, this.Height/2,vX/100, vY/100);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < p.Length; i++)
            {
                Pen pen = new Pen(Color.FromArgb(255, 255, 0, 0), 1);
                g.DrawEllipse(pen, p[i].particlePosition.X, p[i].particlePosition.Y, 5, 5);
            }  
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Update the particle position based on the vector
            for (int i = 0; i < p.Length; i++)
            {
                p[i].particlePosition.X += p[i].vector.X;
                p[i].particlePosition.Y += p[i].vector.Y;
            }

            
            Invalidate();
        }
    }
}
