using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Maximus
{

    internal class Enemy
    {

        #region Constructor
        /// <summary>
        /// Guy to beat
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        public Enemy(string name, int health)
        {
            Name = name;
            Health = health;
        }

        #endregion Constructor

        #region Parameters
        public string Name { get; set; }
        public int Health { get; set; }




        #endregion Parameters

        public void CounterMove(Champion champion, ElementType element)
        {
            switch (element)
            {
                case ElementType.None:
                    SingleAttack(champion, 5);

                    break;

                case ElementType.Earth:
                    SingleAttack(champion, 7);
                    break;

                case ElementType.Water:
                    SingleAttack(champion, 5);
                    break;

                case ElementType.Air:
                    DoubleAttack(champion, 1);
                    break;

                case ElementType.Blood:
                    SingleAttack(champion, 4);
                    break;

                case ElementType.Lightning:
                    SingleAttack(champion, 2);
                    break;

                case ElementType.Flame:
                    Flamed(champion);
                    SingleAttack(champion, 5);                    
                    break;

              

            }
  
        }

        private void SingleAttack(Champion champion, int damage)

        {
            champion.CurrentHealth -= damage;
            Program.Writing("OEUHNNG!");
            Program.Writing($"You were hit for {damage} damage!");
            Program.Writing($"Your health is now {champion.CurrentHealth}/{champion.MaxHealth}");
        }

        private void Flamed(Champion champion)
        {
            champion.CurrentMana -= 1;
            Program.Writing("REEHEHEHEHEHE!");
            Program.Writing($"Your mana was burned down to {champion.CurrentMana}/{champion.MaxMana}!");
        }


        private void DoubleAttack(Champion champion, int damage)
        {
            
            champion.CurrentHealth -= damage;
            champion.CurrentHealth -= damage;
            Program.Writing("DOOSH DOOSH!");
            Program.Writing($"You were hit for {damage} damage TWICE!!");
            Program.Writing($"Your health is now {champion.CurrentHealth}/{champion.MaxHealth}");
        }

        //receive champions most recent elemntal attack used against enemy
        //decide response based on element




    }
}
