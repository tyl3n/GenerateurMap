using System;
using System.Drawing;
using System.Collections.Generic;
namespace MapGenerator
{

    public class Door
    {
        public int x;
        public int y;
        int length;
        public int type;
        public int doorNumber;
        Graphics g;
        Pen p = new Pen(Color.LightGray);
        SolidBrush s = new SolidBrush(Color.Red);
        public List<Room> linkedRoom = new  List<Room>();
        public Door(Graphics g,int x, int y, int type)
        {
            this.g = g;
            this.x = x;
            this.y = y;
            this.type = type;
            this.length = 1;
           // this.to = t;
            
        }
        public void showLinkeRoom()
        {
            Console.Write("Door : " + doorNumber);
            Console.Write(" Type : " + ((type == Util.HORIZONTAL) ? "Horizontal":"Vertical"));
            foreach(Room r in linkedRoom)
            {
                Console.Write(" Room : " + r.roomNumber);
            }
            Console.WriteLine();
        }
        public void draw()
        {
            g.DrawString(doorNumber.ToString(), new Font("Arial", 8 ),s , x * Util.ECHELLE, y * Util.ECHELLE);
            if (type==0)
            {
                g.DrawLine(p, new Point(x*Util.ECHELLE, y*Util.ECHELLE), new Point(x*Util.ECHELLE + length*Util.ECHELLE, y*Util.ECHELLE));
            }
            else if (type == 1)
            {
                g.DrawLine(p, new Point(x*Util.ECHELLE, y*Util.ECHELLE), new Point(x*Util.ECHELLE , y*Util.ECHELLE+ length*Util.ECHELLE));
            }
        }
    }
}
