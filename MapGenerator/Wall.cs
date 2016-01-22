using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MapGenerator
{
    class Wall
    {
        int x;
        int y;
        int length;
        int type;
        Graphics g;
        Pen p = new Pen(Color.Black);
        public Wall(Graphics g, int x, int y, int type)
        {
            this.g = g;
            this.x = x;
            this.y = y;
            this.type = type;
            this.length = 1;

        }
        public void draw()
        {
            if (type == Util.HORIZONTAL) 
            {
                g.DrawLine(p, new Point(x * Util.ECHELLE, y * Util.ECHELLE), new Point(x * Util.ECHELLE + length * Util.ECHELLE, y * Util.ECHELLE));
            }
            else if (type == Util.VERTICAL)
            {
                g.DrawLine(p, new Point(x * Util.ECHELLE, y * Util.ECHELLE), new Point(x * Util.ECHELLE, y * Util.ECHELLE + length * Util.ECHELLE));
            }
        }
    }
}
