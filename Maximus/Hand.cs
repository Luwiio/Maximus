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
                //Lets the player know what their cards do
                Console.Write($"{cardCounter}: {randomCard.Name}");
                if (randomCard.CardType == "Basic Attack")
                {
                    Console.WriteLine($"    DMG: {randomCard.Magnitude}. MP Cost: {randomCard.Cost} ");
                }
                else if (randomCard.CardType == "HP Cost Attack")
                {
                    Console.WriteLine($"    DMG: {randomCard.Magnitude}. HP Cost: {randomCard.Cost} ");
                }
                else if (randomCard.CardType == "Buff")
                { 
                    Console.WriteLine($"    Buff Attack by: {randomCard.Magnitude}. MP Cost: {randomCard.Cost} ");
                }
                //TO CATCH IF I HAVENT GIVEN EACH CARD A TYPE THAT CAN BE HANDLED BY THIS CODE
                else
                {
                    Console.WriteLine(" *Make a Type for this card* ");
                }
            }

        }

        public int HandSize { get; set; }
        public List<Card> CurrentHand { get; set; } = new List<Card>();
    }



}
