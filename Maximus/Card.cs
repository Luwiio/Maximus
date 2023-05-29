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
        public Card(string name, string element, int magnitude, int cost, bool basicAttackTypeCard, bool buffTypeCard, bool hPCostTypeCard)
        {
            Name = name;
            Element = element;
            Magnitude = magnitude;
            Cost = cost;
            BasicAttackTypeCard = basicAttackTypeCard;
            BuffTypeCard = buffTypeCard;
            HPCostTypeCard = hPCostTypeCard;
        }



        public string Name { get; set; }
        public string Element { get; set; }
        public int Magnitude { get; set; }
        public int Cost { get; set; }
        public bool BasicAttackTypeCard { get; set; }
        public bool BuffTypeCard { get; set; }

        public bool HPCostTypeCard { get; set; }

        public void BasicAttack(Enemy enemy)
        {

            int remainingEnemyHealth = enemy.Health - Magnitude;
            if (remainingEnemyHealth > 0) 
            {
                Program.Writing("KIIYAA!!");
                Program.Writing($"You played {Name} and have struck {enemy.Name} for {Magnitude} damage");
                Program.Writing($"{enemy.Name} has {remainingEnemyHealth} health remaining");
                enemy.Health = remainingEnemyHealth;
            }

            //Writing("")
        }

    }


}
