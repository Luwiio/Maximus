using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus
{
    internal class Player
    {

        public Player(int playerMaxHealth, int playerCurrentHealth, int playerMaxMana, int playerCurrentMana, int playerBonusAttack)
        {
            PlayerMaxHealth = playerMaxHealth;
            PlayerCurrentHealth = playerCurrentHealth;
            PlayerMaxMana = playerMaxMana;
            PlayerCurrentMana = playerCurrentMana;
            PlayerBonusAttack = playerBonusAttack;  
        }

        public int PlayerMaxHealth { get; set; }
        public int PlayerCurrentHealth { get; set; }
        public int PlayerMaxMana { get; set; }
        public int PlayerCurrentMana { get; set; }

        public int PlayerBonusAttack { get; set; }



    }
}
