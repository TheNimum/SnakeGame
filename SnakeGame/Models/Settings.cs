using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models
{
    class Settings
    {
        // Defult Settings. 

        public static int Width { get; set; }
        public static int Height { get; set; }

        public static string Direction;

        public Settings()
        {
            Width = 16;
            Height = 16;

            Direction = "right";

        }
    }
}
