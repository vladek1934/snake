using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Snake
{
    class Program
    {
        static void Serialize(Game q)
        {

            XmlSerializer xs = new XmlSerializer(typeof(Game));

            FileStream fs = new FileStream("complex.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            xs.Serialize(fs, q);
            fs.Close();
        }
        static Game  Deserialize()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Game));
            FileStream fs2 = new FileStream("complex.txt", FileMode.Open, FileAccess.Read);
            Game h = new Game();
            h = xs.Deserialize(fs2) as Game;
            fs2.Close();
            return h;
            
        }
        static void Main(string[] args)
        {
            Worm worm = new Worm();
            Food food = new Food();
            Wall wall = new Wall(1);
           worm.Start();
            while (worm.isAlive)
            {
                Console.Clear();
                worm.Draw();
                food.Draw();
               
                int currx = worm.Getheadx();
                int curry = worm.Getheady();
                int k=wall.Draw(currx,curry);
                if (k == 1) { break; }
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {   
                    case ConsoleKey.F8:
                        Game q = new Game(worm, wall, food);
                        Serialize(q);
                        break;
                    case ConsoleKey.F9:
        
                        Game h = Deserialize();
                        worm = h.worm;
                        food = h.food;
                        wall = h.wall;
                       
                        break;
                    case ConsoleKey.UpArrow:
                        worm.Move(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        worm.Move(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        worm.Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        worm.Move(1, 0);
                        break;
                    case ConsoleKey.Escape:
                        worm.isAlive = false;
                        break;
                }

                if (worm.CanEat(food))
                {
                    food = new Food();
                }
            }
            Console.Clear();
            Console.WriteLine( "YOU LOSE" );
        }
    }
}
