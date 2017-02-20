using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Worm
    {
        public char sign = '*';
        public List<Point> body = new List<Point>();
        public bool isAlive = true;
        public Worm()
        {
            body.Add(new Point(10, 10));
        }
        public void Draw()
        {
            for (int i = 0; i < body.Count; ++i)
            {
                Console.SetCursorPosition(body[i].x,body[i].y);
                Console.Write(sign);
            }
        }

        public void Move(int dx, int dy)
        {
            if (body[0].x + dx < 0) return;
            if (body[0].y + dy < 0) return;
            if (body[0].x + dx > 40) return;
            if (body[0].y + dy > 40) return;

            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;

        }
        public int Getheadx()
        { return body[0].x; }
        public int Getheady()
        { return body[0].y; }
        public bool CanEat(Food food)
        {
            if (body[0].Equals(food.location))
            {
                body.Add(food.location);
                return true;
            }
            return false;
        }
    }
}
