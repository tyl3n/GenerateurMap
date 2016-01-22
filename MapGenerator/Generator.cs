using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MapGenerator
{
    class Generator
    {

        public  List<Room> rooms = new List<Room>();
        public  List<Door> doors = new List<Door>();
        public int seed;
        public  Player p;
        Graphics g;
        public Generator(Graphics g,int seed)
        {
            Room.r = new Random(seed);
            this.g = g;
            rooms.Add(new Room(g, 0, 0,3, 3));
            this.p = new Player(g);
            GenerateMap();
            agregateDoor();
        }
        public void GenerateMap()
        {
            bool isDone = true;
            int count = 1;
            do
            {
                isDone = true;
                for (int i = 0; i < rooms.Count; ++i)
                {
                    if (rooms[i].xL > 1 && rooms[i].yL > 1 && rooms[i].xL * rooms[i].yL > 2)
                    {
                        isDone = false;
                        break;
                    }
                }
                for (int i = 0; i < rooms.Count; ++i)
                {
                    if (rooms[i].xL > 1 && rooms[i].yL > 1 && rooms[i].xL * rooms[i].yL > 2)
                    {
                        Room r = rooms[i].split();
                        r.roomNumber = count;
                        ++count;
                        rooms.Add(r);
                    }
                }
            }
            while (!isDone);
            createWalls();

        }
        void createWalls()
        {
            foreach (Room r in rooms)
                r.createWalls();
        }
        void agregateDoor()
        {
            Console.WriteLine("Graph Room ");

            for (int i = 0; i < rooms.Count; ++i)
            {
                if (rooms[i].door != null)
                {
                    rooms[i].door.doorNumber = i;
                    doors.Add(rooms[i].door);

                }

            }
            linkDoorsToRooms();
        }
        void linkDoorsToRooms()
        {
            foreach (Door d in doors)
            {
                foreach (Room r in rooms)
                {
                    if (d.type == Util.HORIZONTAL)
                    {
                        if (d.y == r.y || d.y == r.y + r.yL)
                        {
                            if (d.x >= r.x && d.x < r.x + r.xL)
                            {
                                if (d.linkedRoom.Count < 2)
                                {
                                    d.linkedRoom.Add(r);
                                }
                            }
                        }
                    }
                    if (d.type == Util.VERTICAL)
                    {
                        if (d.x == r.x || d.x == r.x + r.xL)
                        {
                            if (d.y >= r.y && d.y < r.y + r.yL)
                            {
                                if (d.linkedRoom.Count < 2)
                                {
                                    d.linkedRoom.Add(r);
                                }
                            }
                        }
                    }

                }
            }
        }
    }
}
