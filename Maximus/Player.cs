using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus
{
    internal class Player
    {

        public Player(int playerHealth, int maxMana, int currentMana)
        {
            PlayerHealth = playerHealth;
            MaxMana = maxMana;
            CurrentMana = currentMana;
        }

        public int PlayerHealth { get; set; }
        public int MaxMana { get; set; }
        public int CurrentMana { get; set; }



    }
}
