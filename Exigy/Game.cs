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
            var shuffledDeck = ShuffledMessage(newDeck);

            var middleList = MiddlePile(shuffledDeck);
            var newList =  RemoveMidlePile(shuffledDeck, middleList);

        }

        private static List<string> MiddlePile(List<string> shuffledDeck)
        {
            List<string> MiddleList = new List<string>();
            var cards = 0;

            while(cards < 4)
            {
                Random rnd = new Random();
                int randomInd = rnd.Next(0, shuffledDeck.Count);
                var element = shuffledDeck[randomInd];
                MiddleList.Add(element);
                cards += 1;
            }
            Console.WriteLine("");
            Console.WriteLine("\nIn the middle we have: \n");

            foreach (var el in MiddleList)
            {
                Console.Write($" {el} ");
            }
            return MiddleList;
        }

        public static List<string> RemoveMidlePile(List<string> shuffledDeck,List<string> middleList)
        {
            var circlePiles = shuffledDeck.Except(middleList).ToList();
            Console.WriteLine("");
            Console.WriteLine("\nIn the circle we have: \n");
            var counter = 0;
            foreach (var el in circlePiles)
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

            return circlePiles;
        }


        public static string FindValue(string str)
        {
            var result = "";

            switch(str){
                case "A":
                    result = "0";
                    break;
                case "1":
                    result = "1";
                    break;
                case "2":
                    result = "2";
                    break;
                case "3":
                    result = "3";
                    break;
                case "4":
                    result = "4";
                    break;
                case "5":
                    result = "5";
                    break;
                case "6":
                    result = "6";
                    break;
                case "7":
                    result = "7";
                    break;
                case "8":
                    result = "8";
                    break;
                case "9":
                    result = "9";
                    break;
                case "T":
                    result = "10";
                    break;
                case "J":
                    result = "11";
                    break;
                case "Q":
                    result = "12";
                    break;
                case "K":
                    result = "13";
                    break;
            }
            return result;
        }

        private static List<string> NewDeck()
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

        private static void Player()
        {
            Console.WriteLine("\nPlease enter your name: ");
            var name = Console.ReadLine();
            var UpperName = name.ToUpper(new CultureInfo("en-US", false));

            var newPlayer = new Player()
            {
                Name = UpperName,
                Start = DateTime.UtcNow.ToLongDateString()
            };

            Console.WriteLine($"\n{newPlayer.Name} welcome!\n{newPlayer.Start} \n");
        }

        private static List<string> ShuffledMessage(List<string> newDeck)
        {
            var newShuffled = Shuffle(newDeck);
            Console.WriteLine("\nPlease allow us to shuffle the cards\n");
            var counter = 0;
            foreach (var el in newShuffled)
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

            return newShuffled;
        }

        private static List<string> Shuffle(List<string> deck)
        {
            return deck.OrderBy(x => Guid.NewGuid()).ToList();
        }

    }
}
