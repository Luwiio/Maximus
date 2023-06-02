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
        public Card(string name, ElementType element, int magnitude, int cost, string cardType)
        {
            Name = name;
            Element = element;
            Magnitude = magnitude;
            Cost = cost;
            CardType = cardType;
        }



        public string Name { get; set; }
        public ElementType Element { get; set; }
        public int Magnitude { get; set; }
        public int Cost { get; set; }
        public string CardType { get; set; }

        public void BasicAttack(Enemy enemy, Champion player)
        {

            
            enemy.Health -= (Magnitude + player.BonusAttack);
            player.CurrentMana -= Cost;
 
            if (enemy.Health > 0) 
            {
                Program.Writing("\nKIIYAA!!");
                Program.Writing($"You played {Name} and have struck {enemy.Name} for {Magnitude + player.BonusAttack} damage");
                Program.Writing($"{enemy.Name} has {enemy.Health} health remaining");
                Program.Writing($"You now have {player.CurrentMana}/{player.MaxMana} mana");
            }
            else
                Program.Writing("\nI... I think you murdered " + enemy.Name);
            
        }

        public void HpCostAttack(Enemy enemy, Champion player)
        {
            enemy.Health -= (Magnitude + player.BonusAttack);
            player.CurrentHealth -= Cost;
            if (enemy.Health > 0)
            {
                Program.Writing("\nAaArrGrrGJHCH!!!");
                Program.Writing($"You played {Name} and have struck {enemy.Name} for {Magnitude + player.BonusAttack} damage");
                Program.Writing($"{enemy.Name} has {enemy.Health} health remaining");
                Program.Writing($"You now have {player.CurrentHealth}/{player.MaxHealth} health");
            }
            else
                Program.Writing("\nI... I think you murdered " + enemy.Name);
            
        }

        public void Buff(Champion player)
        {
            Program.Writing("\noh?", false);
            Program.ThreeDotWritingLoop();
            Program.Writing(" OH YEAH!!");
            player.BonusAttack += Magnitude;
            Program.Writing($"You're invigorated to SMASH HARDER by {Magnitude}");
            Program.Writing($"You now have {player.BonusAttack} EXTRA SMASHING POWER!");
        }

    }


}
