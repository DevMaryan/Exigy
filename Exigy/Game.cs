using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Timers;

namespace Exigy
{
    public static class Game
    {
        public static void Start()
        {
            Welcome();
            Player();
            var newDeck = NewDeck();
            Shuffle(newDeck);
        }


        public static List<string> NewDeck()
        {
            return new Cards().CardDeck();
        }

        private static void Welcome()
        {
            string welcome = "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n!!Welcome to Clock Patiance Game!!\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n";
            foreach (var str in welcome)
            {
                Console.Write(str);
                System.Threading.Thread.Sleep(10);
            }
        }

        public static void Player()
        {
            Console.WriteLine("\nPlease enter your name: ");
            var name = Console.ReadLine();
            var UpperName = name.ToUpper(new CultureInfo("en-US", false));

            var newPlayer = new Player()
            {
                Name = UpperName,
                Start = DateTime.UtcNow.ToLongDateString()
            };

            Console.WriteLine($"Welcome to {newPlayer.Name}\n{newPlayer.Start} \n");
        }

        private static void Shuffle(List<string> deck)
        {
            List<string> shuffle = deck.OrderBy(x => Guid.NewGuid()).ToList();

            Console.WriteLine("\nPlease allow us to shuffle the cards\n");
            var counter = 0;
            foreach (var el in shuffle)
            {

                System.Threading.Thread.Sleep(200);
                Console.Write(el + " ");
                counter += 1;
                if (counter == 12)
                {
                    Console.WriteLine(" ");
                    counter = 0;
                }
            }
        }

    }
}
