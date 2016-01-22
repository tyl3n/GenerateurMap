using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MapGenerator
{
    class Player
    {
        public Graphics g;
        public int x = 0;
        public int y = 0;
        public Room currentRoom;
        public SolidBrush s = new SolidBrush(Color.Red);
        public Player(Graphics g )
        {
            this.g = g;
        }

        public void draw()
        {
            g.FillEllipse(s, x, y, Util.ECHELLE, Util.ECHELLE);
        }
        public void Move(int direction)
        {
            switch(direction)
            {
                case Util.UP:
                     
                    break;
                case Util.DOWN:

                    break;
                case Util.LEFT:

                    break;
                case Util.RIGHT:

                    break;
            }
        }
        public void checkMove(int x, int y)
        {
            
        }
    }
}
