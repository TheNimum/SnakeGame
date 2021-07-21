using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models
{
    class GameModels  // name is not final, this will help Doing the Apples and the Sneak Model.
    {
        public int X { get; set; }
        public int Y { get; set; }
        public GameModels()
        {
            X = 0;
            Y = 0;
        }
    }
}
