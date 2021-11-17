using Exigy.Data;
using Exigy.ErrorHandler;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Timers;

namespace Exigy
{
    public class Game
    {
        public Game()
        {
            _allPlayersList = new Players();
        }

        public Players _allPlayersList { get; set; }

        public void Start()
        {
            try
            {
                Welcome();

                Console.WriteLine("\nPlease enter your name: ");
                var name = Console.ReadLine();
                var UpperName = name.ToUpper(new CultureInfo("en-US", false));

                var newPlayerId = Player(UpperName);

                var newDeck = NewDeck();
                var shuffledDeck = ShuffledMessage(newDeck);

                var middleList = MiddlePile(shuffledDeck);
                var circleList = RemoveMidlePile(shuffledDeck, middleList);

                DivideInHours(circleList, middleList, newPlayerId);
            }
            catch(MajorError ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            
        }

        public void DivideInHours(List<string> circleList, List<string> middleList,int newPlayerId)
        {
            var ConvertionOne = ConvertToHour(circleList);
            var OneHour = ConvertionOne.Item1;
            var newCircleListOne = ConvertionOne.Item2;

            var ConvertionTwo = ConvertToHour(newCircleListOne);
            var TwoHour = ConvertionTwo.Item1;
            var newCircleListTwo = ConvertionOne.Item2;

            var ConvertionTree = ConvertToHour(newCircleListTwo);
            var TreeHour = ConvertionTree.Item1;
            var newCircleListTree = ConvertionTree.Item2;

            var ConvertionFour = ConvertToHour(newCircleListTree);
            var FourHour = ConvertionFour.Item1;
            var newCircleListFour = ConvertionFour.Item2;

            var ConvertionFive = ConvertToHour(newCircleListFour);
            var FiveHour = ConvertionFive.Item1;
            var newCircleListFive = ConvertionFive.Item2;

            var ConvertionSix = ConvertToHour(newCircleListFive);
            var SixHour = ConvertionSix.Item1;
            var newCircleListSix = ConvertionSix.Item2;

            var ConvertionSeven = ConvertToHour(newCircleListSix);
            var SevenHour = ConvertionSeven.Item1;
            var newCircleListSeven = ConvertionSeven.Item2;

            var ConvertionEight = ConvertToHour(newCircleListSeven);
            var EigthHour = ConvertionEight.Item1;
            var newCircleListEigth = ConvertionEight.Item2;

            var ConvertionNine = ConvertToHour(newCircleListEigth);
            var NineHour = ConvertionNine.Item1;
            var newCircleListNine = ConvertionNine.Item2;

            var ConvertionTen = ConvertToHour(newCircleListNine);
            var TenHour = ConvertionTen.Item1;
            var newCircleListTen = ConvertionTen.Item2;

            var ConvertionEleven = ConvertToHour(newCircleListTen);
            var ElevenHour = ConvertionEleven.Item1;
            var newCircleListEleven = ConvertionEleven.Item2;


            var ConvertionTwelve = ConvertToHour(newCircleListEleven);
            var TwelveHour = ConvertionTwelve.Item1;
            var newCircleListTwelve = ConvertionTwelve.Item2;

            var One = "One";
            DisplayHours(OneHour, One);

            var Two = "Two";
            DisplayHours(TwoHour, Two);

            var Three = "Three";
            DisplayHours(TreeHour, Three);

            var Four = "Four";
            DisplayHours(FourHour, Four);

            var Five = "Five";
            DisplayHours(FiveHour, Five);

            var Six = "Six";
            DisplayHours(SixHour, Six);

            var Seven = "Seven";
            DisplayHours(SevenHour, Seven);

            var Eigth = "Eigth";
            DisplayHours(EigthHour, Eigth);

            var Nine = "Nine";
            DisplayHours(NineHour, Nine);

            var Ten = "Ten";
            DisplayHours(TenHour, Ten);

            var Eleven = "Eleven";
            DisplayHours(ElevenHour, Eleven);

            var Twelve = "Twelve";
            DisplayHours(TwelveHour, Twelve);

            // For cards that are used
            List<string> UsedCard = new List<string>();

            for(var i = 0; i < middleList.Count; i++)
            {
                // If we still have cards
                if (middleList.Count > 0)
                {
                    // Start from the middle card
                    var middleCard = middleList[i];

                    // Get the value from the middle card
                    var middleCardValue = FindValue(middleCard.Substring(0, 1));

                    // Remove the used card
                    middleList.Remove(middleCard);
                    UsedCard.Add(middleCard); // Add to used cards

                    // Go to the Hour of the Middle Card if the card is not K or 13
                    if (middleCardValue != "13" && middleCard != "")
                    {
                        var theHour = FindHour(middleCardValue, OneHour, TwoHour, TreeHour, FourHour, FiveHour, SixHour, SevenHour, EigthHour, NineHour, TenHour, ElevenHour, TwelveHour);

                        var counter = 0;
                        while (counter < 48)
                        {
                            if(theHour.Count > 0)
                            {
                                // Get Hour card
                                var theHourCard = theHour[0];

                                // Hour Card value
                                var theHourValue = FindValue(theHourCard.Substring(0, 1));

                                // Remove the used card
                                theHour.Remove(theHourCard);
                                UsedCard.Add(theHourCard); // Add to used cards

                                // For the NExt hour
                                var NextHour = FindHour(theHourValue, OneHour, TwoHour, TreeHour, FourHour, FiveHour, SixHour, SevenHour, EigthHour, NineHour, TenHour, ElevenHour, TwelveHour);
                                
                            }
                            counter += 1;
                        }
                    }
                }

            }

            Results(UsedCard, newPlayerId);
        }


        public void Results(List<string> UsedCard,int newPlayerId)
        {
            var thePlayer = _allPlayersList.PlayersList.FirstOrDefault(x => x.Id == newPlayerId);
            if (UsedCard.Count == 52)
            {

                thePlayer.Result = "WON";
                Console.WriteLine($"\nCongratulations {thePlayer.Name},you won!");

                Console.WriteLine($"\nUsed cards:{UsedCard.Count}");
            }
            else
            {
                thePlayer.Result = "LOSE";
                Console.WriteLine($"\nYou lose {thePlayer.Name}, try again!");
                Console.WriteLine($"\nUsed cards:{UsedCard.Count}");
            }

            // Update Json file
            _allPlayersList.WriteToFile();
        }
        private void DisplayHours(List<string> Hour,string HourName)
        {
            Console.WriteLine($"\n{HourName}: ");
            for (var i = 0; i < Hour.Count; i++)
            {
                  Console.Write($"{Hour[i]} ");
            }
        }

        public (List<string>, List<string>) ConvertToHour(List<string> circleList)
        {
            List<string> Hour = new List<string>();
            var cards = 0;

            while (cards < 4)
            {
                Random rnd = new Random();
                int randomInd = rnd.Next(0, circleList.Count);
                var element = circleList[randomInd];
                Hour.Add(element);
                circleList.Remove(element);

                cards += 1;
            }

            return (Hour, circleList);
        }

        private List<string> MiddlePile(List<string> shuffledDeck)
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

        public List<string> RemoveMidlePile(List<string> shuffledDeck,List<string> middleList)
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

        public List<string> FindHour(string str,List<string> OneHour, List<string> TwoHour, List<string> TreeHour, List<string> FourHour, List<string> FiveHour, List<string> SixHour, List<string> SevenHour, List<string> EigthHour, List<string> NineHour, List<string> TenHour, List<string> ElevenHour, List<string> TwelveHour)
        {
            List<string> result = new List<string>();

            switch (str)
            {
                case "1":
                    result = OneHour;
                    break;
                case "2":
                    result = TwoHour;
                    break;
                case "3":
                    result = TreeHour;
                    break;
                case "4":
                    result = FourHour;
                    break;
                case "5":
                    result = FiveHour;
                    break;
                case "6":
                    result = SixHour;
                    break;
                case "7":
                    result = SevenHour;
                    break;
                case "8":
                    result = EigthHour;
                    break;
                case "9":
                    result = NineHour;
                    break;
                case "10":
                    result = TenHour;
                    break;
                case "11":
                    result = ElevenHour;
                    break;
                case "12":
                    result = TwelveHour;
                    break;
            }
            return result;
        }
        public string FindValue(string str)
        {
            var result = "";

            switch(str){
                case "A":
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

        private List<string> NewDeck()
        {
            return new Cards().CardDeck();
        }

        private void Welcome()
        {
            string welcome = "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n!!Welcome to Clock Patiance Game!!\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n";
            foreach (var str in welcome)
            {
                Console.Write(str);
                System.Threading.Thread.Sleep(10);
            }
        }

        private int Player(string UpperName)
        {
            Random rnd = new Random();
            int randomInd = rnd.Next(0, 1000);

            var newPlayer = new Player()
            {
                Id = randomInd,
                Name = UpperName,
                Start = DateTime.UtcNow.ToLongDateString()
            };


            _allPlayersList.AddNew(newPlayer);

            Console.WriteLine($"\n{newPlayer.Name} welcome!\n{newPlayer.Start} \n");

            return newPlayer.Id;
        }

        private List<string> ShuffledMessage(List<string> newDeck)
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

        private List<string> Shuffle(List<string> deck)
        {
            return deck.OrderBy(x => Guid.NewGuid()).ToList();
        }

    }
}
