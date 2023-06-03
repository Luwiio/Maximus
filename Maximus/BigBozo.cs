using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus
{
    internal class BigBozo: Enemy 
    {
        public BigBozo(): base("Big Bozo", 30, 30) 
        {
            Program.Writing($"{Name} appears before you!");
            Program.Writing($"{Name} currently has {CurrentHealth}/{MaxHealth} health");
            Console.WriteLine();
        }
        public override void NoneCounter(Trilby trilby) 
        {
            SingleAttack(trilby, 5);
        }
        public override void EarthCounter(Trilby trilby)
        {
            SingleAttack(trilby, 5);
        }
        public override void WaterCounter(Trilby trilby)
        {
            SingleAttack(trilby, 5);
        }
        public override void AirCounter(Trilby trilby)
        {
            SingleAttack(trilby, 5);
        }
        public override void BloodCounter(Trilby trilby)
        {
            SingleAttack(trilby, 5);
        }
        public override void LightningCounter(Trilby trilby)
        {
            Stunned();
        }
        public override void FlameCounter(Trilby trilby)
        {
            ManaBurn(trilby, 3);
        }


    }



}
