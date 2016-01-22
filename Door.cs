using System;
using System.Drawing;
namespace MapGenerator
{

    public class Door
    {
        int x;
        int y;
        int length;
        int type;
        Graphics g;
        Pen p;
        public Door(Graphics g,int x, int y, int type)
        {
            
            this.x = x;
            this.y = y;
            this.type = type;
            Pen p = new Pen();
        }
        public void draw()
        {
            if (type==1)
            {
                
            }
            else
            {

            }
        }
    }
}
