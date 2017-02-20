using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Snake
{
    public class Game
    {
        public Worm worm;
        public Wall wall;
        public Food food;

        public Game()
        { }

        public Game(Worm worm,Wall wall,Food food)
        {
           
            this.worm = worm;
            this.wall = wall;
            this.food = food;
           

        }

    }
    
}
