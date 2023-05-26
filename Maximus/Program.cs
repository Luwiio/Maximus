using System;
using System.Collections.Generic;
using System.Threading;

namespace Maximus
{
    class Program
    {
        private const int ShortWait = 40;

        static void Main(string[] args)
        {
            /*Delay times in milliseconds for text output*/
            int midWait = 200;
            int longWait = 500;

            
            string REALname = "Maximus the Bold";
            Console.Write("Greetings, my leader! What should I, your champion, be called? ");

            string username = Console.ReadLine().ToLower();

            /*Prints a response depending on user input*/
            if (username != REALname.ToLower())
            {
                Writing(username, false);
                Thread.Sleep(midWait);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write('.');
                    Thread.Sleep(midWait);
                }
                Thread.Sleep(longWait);
                Writing(" That name is pathetic! I will instead be called " + REALname);

            }
            else
            
                Writing("A GLORIOUS NAME! GOOD CHOICE, ADVENTURER");
            
            Thread.Sleep(longWait);

            /*Define the real weapon*/
            string realWeapon = "Sword";
            /*Creates a list of weapon options*/
            List<string> weapons = new List<string>() { "Banana", "Rock", "Flower", "Fishing Rod", realWeapon };
            /*Print on individual lines the weapon options*/
            for (int weaponIndex = 0; weaponIndex < weapons.Count; weaponIndex++)
            
                Writing(weapons[weaponIndex]);

            Thread.Sleep(longWait);

            Writing("Choose the weapon I will wield: ", false);
            
            /*Prints a response depending on use input*/
            string weapon = Console.ReadLine().ToLower();
            if (weapon == realWeapon.ToLower())
            
                Writing("The obvious choice for a capable leader!");    
            
            else
            {
                Writing(weapon, false);
                Thread.Sleep(midWait);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write('.');
                    Thread.Sleep(midWait);
                }
                Thread.Sleep(longWait);
                Writing(" What are you retarded? Obviously I am going to wield the " + realWeapon);
  
            }
            Thread.Sleep(longWait);  
        }
       /*Method that prints each individual character of a string with a delay 
        which is by default set to shortWait but can be overridden
       to any amount by putting a comma after the string and an integer*/
        private static void Writing(string sentence, int customWait = ShortWait, bool newLine = true)
        {
            for (int letterIndex = 0; letterIndex < sentence.Length; letterIndex++)
            {
                Console.Write(sentence[letterIndex]);
                Thread.Sleep(customWait);
            }
            if (newLine)

            Console.Write("\n");
        }
        /*Overload for Writing method allowing for the declaration
         of newLine to be false without needing to define an integer wait time*/
        private static void Writing(string sentence, bool newLine) => Writing(sentence, ShortWait, newLine);

    }
}
