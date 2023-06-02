using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Maximus
{
    internal class Trilby
    {


        public Trilby(int maxHealth, int currentHealth, int maxMana, int currentMana, int bonusAttack, int handSize)
        {


            // randomly generates a hand from starting cards
            for (int cardCounter = 1; cardCounter <= handSize; cardCounter++)
            {
                Random random = new Random();
                int randomIndex = random.Next(Card.CardList.Count);
                Card randomCard = Card.CardList[randomIndex];
                Hand.Add(randomCard);
              
            }
            Card.ShowPlayerCards(Hand);

            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
            MaxMana = maxMana;
            CurrentMana = currentMana;
            BonusAttack = bonusAttack;
            HandSize = handSize;

            DisplayStats();
        }

        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int MaxMana { get; set; }
        public int CurrentMana { get; set; }

        public int BonusAttack { get; set; }
        public int HandSize { get; set; }

        public List<Card> Hand { get; set; } = new List<Card>();

        public void DisplayStats()
        {
            Console.WriteLine();
            Program.Writing($"You currently have {CurrentHealth}/{MaxHealth} health");
            Program.Writing($"You currently have {CurrentMana}/{MaxMana} mana");
        }

    }
}
