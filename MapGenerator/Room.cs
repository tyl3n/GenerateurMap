using System;
using System.Drawing;
using System.Collections.Generic;
namespace MapGenerator
{
    public class Room
    {
        public int xL;
        public int yL;
        public int x;
        public int y;
        Graphics g;
        Pen p;
        SolidBrush s;
        public Room parent;
        public Door door;
        List<Wall> walls;
        public int roomNumber;
        public static Random r;
        public Room(Graphics g,int x,int y,int xL,int yL)
        {
            this.x = x;
            this.y = y;
            this.xL = xL;
            this.yL = yL;
            this.g = g;
            p = new Pen(Color.Black);
            s = new SolidBrush(Color.Black);
            walls = new List<Wall>();
           // doors = new List<Door>();

        }
        public void drawWalls()
        {
            foreach (Wall w in walls)
            {
                w.draw();
            }
        }
        public void draw()
        {

            g.DrawString(roomNumber.ToString(), new Font("Arial", 10), s, x * Util.ECHELLE + xL/2 *Util.ECHELLE, y * Util.ECHELLE + yL/2 *Util.ECHELLE);
            // g.DrawRectangle(p, x*Util.ECHELLE, y*Util.ECHELLE, xL*Util.ECHELLE, yL*Util.ECHELLE);//drawWalls();
            drawWalls();


        }
        public void createWalls()
        {
            for (int i = x;i<x+xL; ++i)
            {

                    walls.Add(new Wall(g, i, y, Util.HORIZONTAL));
                    walls.Add(new Wall(g, i, y + yL, Util.HORIZONTAL));
            }
            for (int i = y; i < y + yL; ++i)
            {
                    walls.Add(new Wall(g, x, i, Util.VERTICAL));
                    walls.Add(new Wall(g, x + xL, i, Util.VERTICAL));
            }
        }
        public Room split()
        {
            Room nouvelleRoom = null;
            int splitType = r.Next(0,2);
            int splitIndex = 0;
            int doorIndex = 0;
            if (splitType == Util.HORIZONTAL)// Horizontal
            {
                splitIndex = r.Next(1, yL);
                nouvelleRoom = new Room(g, x, y + splitIndex, xL, yL - splitIndex);
                doorIndex = r.Next(0, xL);
                Console.WriteLine(doorIndex);
                nouvelleRoom.door = new Door(this.g, x + doorIndex, y + splitIndex, splitType);
                this.yL = splitIndex;
                nouvelleRoom.parent = this;
            }
            else if(splitType == Util.VERTICAL)//Vertical1
            {
                splitIndex = r.Next(1, xL);
                nouvelleRoom = new Room(g, x+splitIndex, y ,xL-splitIndex, yL);
                doorIndex = r.Next(0, yL);
                Console.WriteLine(doorIndex);
                nouvelleRoom.door = new Door(this.g, x + splitIndex, y + doorIndex, splitType);
                this.xL = splitIndex;
                nouvelleRoom.parent = this;
            }
            g.DrawRectangle(p, x * Util.ECHELLE, y * Util.ECHELLE, xL * Util.ECHELLE, yL * Util.ECHELLE);
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Type :" + splitType);
            Console.WriteLine("Split :" + splitIndex);
            Console.WriteLine("Door :" + doorIndex);
            Console.WriteLine("-------------------------------");
            return nouvelleRoom;
        }

    }
}
