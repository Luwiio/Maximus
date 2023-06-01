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

            int remainingEnemyHealth = enemy.Health - Magnitude - player.PlayerBonusAttack;
            int remainingPlayerMana = player.PlayerCurrentMana - Cost;
            if (remainingEnemyHealth > 0) 
            {
                Program.Writing("\nKIIYAA!!");
                Program.Writing($"You played {Name} and have struck {enemy.Name} for {Magnitude + player.PlayerBonusAttack} damage");
                Program.Writing($"{enemy.Name} has {remainingEnemyHealth} health remaining");
                Program.Writing($"You now have {remainingPlayerMana}/{player.PlayerMaxMana} mana");
                enemy.Health = remainingEnemyHealth;
                player.PlayerCurrentMana = remainingPlayerMana;
            }
            else
                Program.Writing("\nI... I think you murdered " + enemy.Name);
            //Writing("")
        }

        public void HpCostAttack(Enemy enemy, Player player)
        {
            int remainingEnemyHealth = enemy.Health - Magnitude - player.PlayerBonusAttack;
            int remainingPlayerHealth = player.PlayerCurrentHealth - Cost;
            if (remainingEnemyHealth > 0)
            {
                Program.Writing("\nAaArrGrrGJHCH!!!");
                Program.Writing($"You played {Name} and have struck {enemy.Name} for {Magnitude + player.PlayerBonusAttack} damage");
                Program.Writing($"{enemy.Name} has {remainingEnemyHealth} health remaining");
                Program.Writing($"You now have {remainingPlayerHealth}/{player.PlayerMaxHealth} health");
                enemy.Health = remainingEnemyHealth;
                player.PlayerCurrentHealth = remainingPlayerHealth;
            }
            else
                Program.Writing("\nI... I think you murdered " + enemy.Name);
            //Writing("")
        }

        public void Buff(Player player)
        {
            Program.Writing("\noh?", false);
            Program.ThreeDotWritingLoop();
            Program.Writing(" OH YEAH!!");
            player.PlayerBonusAttack = player.PlayerBonusAttack + Magnitude;
            Program.Writing($"You're invigorated to SMASH HARDER by {Magnitude}");
            Program.Writing($"You now have {player.PlayerBonusAttack} EXTRA SMASHING POWER!");
        }

    }


}
