using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Collections;

namespace MapGenerator
{
    public partial class Form1 : Form
    {
         Generator g;
        public Form1()
        {
            InitializeComponent();
             g = new Generator(panel1.CreateGraphics(),4);
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Console.Out.WriteLine("Panel Paint !");
            foreach (Room r in g.rooms)
            { 
                r.draw();
            }
            foreach (Door d in g.doors) 
            {
                    d.showLinkeRoom();
                    d.draw();
            }
            g.p.draw();


        }


        private void panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
    }
}
