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
        public Enemy(string name, int maxHealth, int currentHealth)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
        }

        #endregion Constructor

        #region Parameters
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }





        #endregion Parameters

        public void CounterMove(Trilby trilby, ElementType element)
        {
            switch (element)
            {
                case ElementType.None:
                    NoneCounter(trilby);
                    break;

                case ElementType.Earth:
                    EarthCounter(trilby);
                    break;

                case ElementType.Water:
                    WaterCounter(trilby);
                    break;

                case ElementType.Air:
                    AirCounter(trilby);
                    break;

                case ElementType.Blood:
                    BloodCounter(trilby);
                    break;

                case ElementType.Lightning:
                    LightningCounter(trilby);
                    break;

                case ElementType.Flame:
                    FlameCounter(trilby);
                    break;



            }

        }

      
        virtual public void NoneCounter(Trilby trilby) 
        {
            throw new NotImplementedException();
        }
        virtual public void EarthCounter(Trilby trilby) 
        {
            throw new NotImplementedException();
        }
        virtual public void WaterCounter(Trilby trilby)
        {
            throw new NotImplementedException();
        }
        virtual public void AirCounter(Trilby trilby)
        {
            throw new NotImplementedException();
        }
        virtual public void BloodCounter(Trilby trilby)
        {
            throw new NotImplementedException();
        }
        virtual public void LightningCounter(Trilby trilby)
        {
            throw new NotImplementedException();
        }
        virtual public void FlameCounter(Trilby trilby)
        {
            throw new NotImplementedException();
        }


        public void SingleAttack(Trilby trilby, int damage)

        {
            trilby.CurrentHealth -= damage;
            Program.Writing("OEUHNNG!");
            Program.Writing($"You were hit for {damage} damage!");

        }
               
        public void MultiAttack(Trilby trilby, int damage, int attacks)
        {
            for (int attacksIndex = 0; attacksIndex < attacks; attacksIndex++)
            {
                trilby.CurrentHealth -= damage;
                Program.Writing("DOOSH! ", false);
            }
            Console.WriteLine();

            Program.Writing($"You were hit for {damage} damage {attacks} times", false);
            for (int attacksIndex = 0; attacksIndex < attacks; attacksIndex++)
            {
                Program.Writing("!", false);
            }

        }
        public void ManaBurn(Trilby trilby, int manaBurn)
        {
            trilby.CurrentMana -= manaBurn;
            Program.Writing("REEHEHEHEHEHE!");
            Program.Writing($"Your mana was burned by {manaBurn}!");
        }

        public void Stunned() 
        {
            Program.Writing("zzZZzvzvzZZzz!!");
            Program.Writing($"{Name} was stunned for one turn");
        }



    }
}
