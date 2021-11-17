using System;
using System.Collections.Generic;
using System.Linq;

namespace Exigy
{
    class Program
    {
        static void Main(string[] args)
        {
            var stop = false;
            while(stop != true)
            {
                Game newGame = new Game();
                newGame.Start();
                Console.WriteLine("\nNew game?\nyes - for new game\nno - to quit");
                var response = Console.ReadLine().Trim();
                if(response == "no")
                {
                    stop = true;
                }
            }
        }


    }
}
