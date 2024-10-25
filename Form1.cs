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
        
        List<Explosion> Explosions= new List<Explosion>();
        int curX = 0;
        int curY = 0;
        public Form1()
        {
            this.DoubleBuffered = true;//smooths the animation
            InitializeComponent();
            
            
        }
        

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            
            bool isNullOrEmpty = Explosions?.Any() != true;
            if (isNullOrEmpty) { return; }
            else
            {
                
                foreach (Explosion s in Explosions)
                {
                    
                    for (int i = 0; i < s.p.Length; i++)//iterate through the particle array and draw each one
                    {
                        if (s.p[i].time_to_death > 5)
                        {
                            SolidBrush brush = new SolidBrush(Color.FromArgb(s.p[i].time_to_death * 5, s.r, s.g,s.b));
                            e.Graphics.FillEllipse(brush, s.p[i].particlePosition.X, s.p[i].particlePosition.Y, 5, 5);
                            brush.Dispose();
                        }
                    }
                }
            }
            
             
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Explosion explosion = new Explosion(curX, curY);
            Explosions.Add(explosion);
                   
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           Point cursorPosition = this.PointToClient(Cursor.Position);

            curX = cursorPosition.X;    
            curY = cursorPosition.Y;  
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
    }
}
