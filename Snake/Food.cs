using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
   public class Food
    {
        public Point location;
        public char sign = '♠';
        public Food()
        {
            location = new Point(new Random().Next() % 30, new Random().Next() % 30);
        }
        public void Draw()
        {
            Console.SetCursorPosition(location.x, location.y);
            Console.Write(sign);
        }
    }
}
