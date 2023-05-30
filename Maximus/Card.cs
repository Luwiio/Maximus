using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Maximus
{
    internal class Card
    {
        public Card(string name, string element, int magnitude, int cost, string cardType)
        {
            Name = name;
            Element = element;
            Magnitude = magnitude;
            Cost = cost;
            CardType = cardType;
        }



        public string Name { get; set; }
        public string Element { get; set; }
        public int Magnitude { get; set; }
        public int Cost { get; set; }
        public string CardType { get; set; }

        public void BasicAttack(Enemy enemy, Player player)
        {

            int remainingEnemyHealth = enemy.Health - Magnitude;
            int remainingPlayerMana = player.CurrentMana - Cost;
            if (remainingEnemyHealth > 0) 
            {
                Program.Writing("\nKIIYAA!!");
                Program.Writing($"You played {Name} and have struck {enemy.Name} for {Magnitude} damage");
                Program.Writing($"{enemy.Name} has {remainingEnemyHealth} health remaining");
                Program.Writing($"You now have {remainingPlayerMana}/{player.MaxMana} mana");
                enemy.Health = remainingEnemyHealth;
                player.CurrentMana = remainingPlayerMana;
            }
            else
                Program.Writing("\nI... I think you murdered " + enemy.Name);
            //Writing("")
        }

    }


}
