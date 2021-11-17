using System;
using System.Collections.Generic;
using System.Text;

namespace Exigy
{
    public class Cards
    {
        public Cards()
        {
            _cards = new List<char>() { 'A', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K' };
            _suits = new List<char>() { 'H', 'D', 'C', 'S' };
        }

        public List<char> _cards { get; set; }

        public List<char> _suits { get; set; }

        public List<string> CardDeck()
        {
            List<string> deck = new List<string>() { };

            for (var i = 0; i < _cards.Count; i++)
            {
                for (var j = 0; j < _suits.Count; j++)
                {
                    if (_cards[i] != _suits[j])
                    {
                        string pair = _cards[i].ToString() + _suits[j];
                        deck.Add(pair);
                    }
                }
            }
            return deck;
        }

    }
}
