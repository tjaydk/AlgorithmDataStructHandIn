using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DequeueSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Random ran = new Random();
            LinkedList<int> deck = new LinkedList<int>();
            HashSet<int> cards = new HashSet<int>();
            
            while(cards.Count != 52)
            {
                int index = ran.Next(52) + 1;
                if(!cards.Contains(index)) { cards.Add(index); }
            }

            foreach (int card in cards)
            {
                deck.AddFirst(card);
            }

            LinkedList<int> sortedDeck = sortDeck(deck);
            foreach (int card in sortedDeck)
            {
                Console.Write(card + ", ");
            }

            while (true) { }
             
        }

        /// <summary>
        /// Sorts a shuffled deck of cards by looking at the two first cards, and then either swapping them, or moving the top card
        /// to the buttom of the deck.
        /// 
        /// When it finds the first card it puts it in the back of the deck, then it searches for the next card in line, when
        /// it finds the card it pushes the card down the deck of cards until it reaches the value just before it. When the card
        /// with the value just below it is found, they are sequntially put to the buttom of the deck and the search begins for the
        /// next card in line.
        /// 
        /// eg. 
        /// - searching for card 1
        /// - found, put to buttom of deck,
        /// - search for card number 2
        /// - found, push card number 2 down the stack until the card below it is card number 1
        /// - take card number 2 and put to buttom, then card number 1 and put to buttom and search for card number 3
        /// - this cycle continues until card number 52 is the card searched for
        /// - found, then return deck cause the cards will be sorted now.
        /// </summary>
        /// <param name="deck">Shuffled LinkedList<int></param>
        /// <returns>Sorted LinkedList<int></returns>
        public static LinkedList<int> sortDeck(LinkedList<int> deck)
        {
            int searchFor = 1;
            int rounds = 1;

            while (searchFor != 53)
            {
                rounds++;
                if      (searchFor == 1  && deck.First() == 1)   { deck.AddLast(deck.First()); deck.RemoveFirst(); searchFor++; }
                else if (searchFor == 52 && deck.First() == 52)  { Console.WriteLine(rounds/52); return deck; }
                //find card and push down through stack and arrange
                else if (deck.First() == searchFor)
                {
                    int found = deck.First();
                    deck.RemoveFirst();
                    int second = deck.First();
                    while (second != searchFor - 1)
                    {
                        deck.AddLast(second);
                        deck.RemoveFirst();
                        second = deck.First();
                    }
                    deck.AddLast(found);
                    searchFor++;
                }
                //put all non searched for cards back in the button of the deck
                int cardTomove = deck.First();
                deck.RemoveFirst();
                deck.AddLast(cardTomove);
            }
            return deck;
        }
    }
}
