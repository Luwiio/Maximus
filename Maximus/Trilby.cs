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

        #region Constructor
        public Trilby(int maxHealth, int currentHealth, int maxMana, int currentMana, int bonusAttack, int handSize)
        {
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
            MaxMana = maxMana;
            CurrentMana = currentMana;
            BonusPower = bonusAttack;
            HandSize = handSize;

            // randomly generates a hand from cards declared in Card class
            for (int cardCounter = 1; cardCounter <= handSize; cardCounter++)
            {
                Random random = new Random();
                int randomIndex = random.Next(Card.CardList.Count);
                Card randomCard = Card.CardList[randomIndex];
                Hand.Add(randomCard);
            }
            Card.ShowPlayerCards(Hand);

            //Calls method that shows health and mana of Trilby
            DisplayStats();
        }

        #endregion Constructor

        #region Parameters
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int MaxMana { get; set; }
        public int CurrentMana { get; set; }

        public int BonusPower { get; set; }
        public int HandSize { get; set; }

        public List<Card> Hand { get; set; } = new List<Card>();

        #endregion Parameters

        //Method that shows health and mana of Trilby
        public void DisplayStats()
        {
            Program.Writing($"You currently have {CurrentHealth}/{MaxHealth} health");
            Program.Writing($"You currently have {CurrentMana}/{MaxMana} mana");
            Console.WriteLine();
        }

    }
}
