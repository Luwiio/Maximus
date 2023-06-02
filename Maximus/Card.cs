using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Threading;

namespace Maximus
{
    internal class Card
    {
        #region constructor
        public Card(string name, ElementType element, int magnitude, int cost, CardType cardType)
        {
            Name = name;
            Element = element;
            Magnitude = magnitude;
            Cost = cost;
            CardType = cardType;
        }
        #endregion constructor

        #region parameters

        public string Name { get; set; }
        public ElementType Element { get; set; }
        public int Magnitude { get; set; }
        public int Cost { get; set; }
        public CardType CardType { get; set; }
        public static List<Card> CardList { get; set; } = GenerateCards();

        #endregion parameters


        //Generating the cards
        public static List<Card> GenerateCards()
        {


            Card imbueWithFire = new Card("Imbue with Fire", ElementType.Flame, 1, 2, CardType.Buff);

            Card bloodTaintedStrike = new Card("Blood tainted Strike", ElementType.Blood, 3, 1, CardType.HpCostAttack);

            Card zingAttack = new Card("Zing Attack", ElementType.Lightning, 1, 0, CardType.BasicAttack);
            Card swordSwing = new Card("Sword Swing", ElementType.None, 3, 1, CardType.BasicAttack);
            Card boulderSplitter = new Card("Boulder Splitter", ElementType.Earth, 10, 3, CardType.BasicAttack);


            //List of all starting cards
            return new List<Card>() { imbueWithFire, zingAttack, swordSwing, bloodTaintedStrike, boulderSplitter };


        }

        public static void ShowPlayerCards(List<Card> hand)
        {

            int maxCardTextLength = 0;
            foreach (Card card in CardList)
            {
                if (card.Name.Length > maxCardTextLength)
                    maxCardTextLength = card.Name.Length;
            }
            int cardPostion = "10:".Length + maxCardTextLength + 5;


            // randomly generates a hand from starting cards
            for (int cardCounter = 1; cardCounter <= hand.Count; cardCounter++)
            {
               Card currentCard = hand[cardCounter - 1];

                //Lets the player know what their cards do
                int currentCardPosition = cardPostion - $"{cardCounter}: {currentCard.Name}".Length;
                Console.Write($"{cardCounter}: {currentCard.Name}");
                //Add padding dynamically so the next piece of text is aligned to a certain position
                Console.Write("".PadLeft(currentCardPosition));


                if (currentCard.CardType == CardType.BasicAttack)
                {
                    Console.WriteLine($"DMG: {currentCard.Magnitude}. MP Cost: {currentCard.Cost} ");
                }
                else if (currentCard.CardType == CardType.HpCostAttack)
                {
                    Console.WriteLine($"DMG: {currentCard.Magnitude}. HP Cost: {currentCard.Cost} ");
                }
                else if (currentCard.CardType == CardType.Buff)
                {
                    Console.WriteLine($"DMG: {currentCard.Magnitude}. MP Cost: {currentCard.Cost} ");
                }
                //TO CATCH IF I HAVENT GIVEN EACH CARD A TYPE THAT CAN BE HANDLED BY THIS CODE
                else
                {
                    Console.WriteLine(" *Make a Type for this card* ");
                }
            }
        }
            public void BasicAttack(Enemy enemy, Trilby trilby)
        {


            enemy.CurrentHealth -= (Magnitude + trilby.BonusAttack);
            trilby.CurrentMana -= Cost;

            if (enemy.CurrentHealth > 0)
            {
                Program.Writing("\nKIIYAA!!");
                Program.Writing($"You played {Name} and have struck {enemy.Name} for {Magnitude + trilby.BonusAttack} damage");
                Program.Writing($"{enemy.Name} now has {enemy.CurrentHealth}/{enemy.MaxHealth} health remaining");

            }
            else
                Program.Writing("\nI... I think you murdered " + enemy.Name);

        }

        public void HpCostAttack(Enemy enemy, Trilby trilby)
        {
            enemy.CurrentHealth -= (Magnitude + trilby.BonusAttack);
            trilby.CurrentHealth -= Cost;
            if (enemy.CurrentHealth > 0)
            {
                Program.Writing("\nAaArrGrrGJHCH!!!");
                Program.Writing($"You played {Name} and have struck {enemy.Name} for {Magnitude + trilby.BonusAttack} damage");
                Program.Writing($"{enemy.Name} has {enemy.CurrentHealth}/{enemy.MaxHealth} health remaining");

            }
            else
                Program.Writing("\nI... I think you murdered " + enemy.Name);

        }

        public void Buff(Trilby trilby)
        {
            Program.Writing("\noh?", false);
            Program.ThreeDotWritingLoop();
            Program.Writing(" OH YEAH!!");
            trilby.BonusAttack += Magnitude;
            Program.Writing($"You're invigorated to SMASH HARDER by {Magnitude}");
            Program.Writing($"You now have {trilby.BonusAttack} EXTRA SMASHING POWER!");
        }

    }


}
