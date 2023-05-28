using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus
{


    internal class Hand
    {
        public Hand(int handSize, List<Card> allCardsThatExist)
        {
            HandSize = handSize;

            // randomly generates a hand from starting cards
            for (int cardCounter = 1; cardCounter <= handSize; cardCounter++)
            {
                Random random = new Random();
                int randomIndex = random.Next(allCardsThatExist.Count);
                Card randomCard = allCardsThatExist[randomIndex];
                CurrentHand.Add(randomCard);
                Console.WriteLine($"{cardCounter}: {randomCard.Name} ");
            }

        }

        public int HandSize { get; set; }
        public List<Card> CurrentHand { get; set; } = new List<Card>();
    }



}
