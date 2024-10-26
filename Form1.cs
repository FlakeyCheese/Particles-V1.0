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
        
        List<Explosion> Explosions= new List<Explosion>();//a list to hold all the explosions
        int curX = 0;//somewhere to store the current location of the pointer
        int curY = 0;
        public Form1()
        {
            this.DoubleBuffered = true;//smooths the animation
            InitializeComponent();
            
            
        }
        

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            
            bool isNullOrEmpty = Explosions?.Any() != true;//the list may be empty best to check
            if (isNullOrEmpty) { return; }
            else
            {
                
                foreach (Explosion s in Explosions)//iterate through each explosion
                {
                    
                    for (int i = 0; i < s.p.Length; i++)//iterate through the particle array and draw each one
                    {
                        if (s.p[i].time_to_death > 5)
                        {   //solid brush uses the r,g,b colour elements generated for each explosion.
                            //Transparency is calculated from the age of the particle
                            SolidBrush brush = new SolidBrush(Color.FromArgb(s.p[i].time_to_death * 5, s.r, s.g,s.b));
                            e.Graphics.FillEllipse(brush, s.p[i].particlePosition.X, s.p[i].particlePosition.Y, s.p[i].d, s.p[i].d);
                            brush.Dispose();//clear up after ourselves
                        }
                        
                    }
                }
            }           
             
        }

        private void Form1_Click(object sender, EventArgs e)
        { //when the mouse is clicked create a new explosion at the current location
            Explosion explosion = new Explosion(curX, curY);
            Explosions.Add(explosion);
                   
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        { //track the mouse and store the cursor position
           Point cursorPosition = this.PointToClient(Cursor.Position);

            curX = cursorPosition.X;    
            curY = cursorPosition.Y;  
        }

        
    }
}
