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
        
        public List<Explosion> Explosions= new List<Explosion>();//a list to hold all the explosions
        int curX = 0;//somewhere to store the current location of the pointer
        int curY = 0;
        BlackHole myBlackHole;
        public Form1()
        {
            this.DoubleBuffered = true;//smooths the animation
            InitializeComponent();
            
            
        }
        

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            
            bool isNullOrEmpty = Explosions?.Any() != true;//the list may be empty best to check
            if (isNullOrEmpty) { return; }//a little backwards but it works
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
            if (BlackHole.blackHoleCount!=0)
            {
                SolidBrush bhBrush = new SolidBrush(Color.Red);
                e.Graphics.FillEllipse(bhBrush, myBlackHole.startx, myBlackHole.starty, myBlackHole.r, myBlackHole.r);
            }
             
        }

        private void Form1_Click(object sender, EventArgs e)
        { 
            
                   
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        { //track the mouse and store the cursor position
           Point cursorPosition = this.PointToClient(Cursor.Position);

            curX = cursorPosition.X;    
            curY = cursorPosition.Y;  
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //no need to check form closed now. Added a start up form it reverts to when the main form is closed
        }

        private void timer1_Tick(object sender, EventArgs e)
        {int parts = 0;
            if (Explosions.Count > 0)
            {
              parts = Explosions[0].p.Length;
            }
            else { parts = 0; }
            label1.Text = Explosions.Count.ToString();
            label4.Text =(Explosions.Count*parts).ToString();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //when the mouse is clicked create a new explosion at the current location
            if (e.Button == MouseButtons.Left)
            {
                Explosion explosion = new Explosion(curX, curY, this);
                Explosions.Add(explosion);
            }
            else
            {
                if (BlackHole.blackHoleCount < 1)
                {
                    //make a black hole
                    BlackHole myBlackHole = new BlackHole(curX, curY);
                }
            }
        }
    }
}
