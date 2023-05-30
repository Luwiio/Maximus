using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Maximus
{
    class Program
    {
        //Used in Writing method as default delay between characters printed
        //Currently set to 0 for speed and convenience when testing program
        private const int ShortWait = 0;

        static void Main(string[] args)
        {


            /*Delay times in milliseconds for text output*/
            int midWait = 200;
            int longWait = 500;
            //Just to speed up testing
            midWait = 0;
            longWait = 0;


            string championName = "Maximus the Bold";
            Console.Write("Greetings, my leader! What should I, your champion, be called? ");

            string userInputtedName = Console.ReadLine().ToLower();

            /*Prints a response depending on user input*/
            if (userInputtedName != championName.ToLower())
            {
                Writing(userInputtedName, false);
                Thread.Sleep(midWait);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write('.');
                    Thread.Sleep(midWait);
                }
                Thread.Sleep(longWait);
                Writing(" That name is pathetic! I will instead be called " + championName);

            }
            else

                Writing("A GLORIOUS NAME! GOOD CHOICE, ADVENTURER");

            Thread.Sleep(longWait);

            /*Define the real weapon of the champion*/
            string championWeapon = "Sword";
            /*Creates a list of weapon options*/
            List<string> weapons = new List<string>() { "Banana", "Rock", "Flower", "Fishing Rod", championWeapon };
            /*Print on individual lines the weapon options*/
            for (int weaponIndex = 0; weaponIndex < weapons.Count; weaponIndex++)

                Writing(weapons[weaponIndex]);

            Thread.Sleep(longWait);

            Writing("Choose the weapon I will wield: ", false);

            /*Prints a response depending on use input*/
            string userInputtedWeapon = Console.ReadLine().ToLower();
            if (userInputtedWeapon == championWeapon.ToLower())

                Writing("The obvious choice for a capable leader!");

            else
            {
                Writing(userInputtedWeapon, false);
                Thread.Sleep(midWait);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write('.');
                    Thread.Sleep(midWait);
                }
                Thread.Sleep(longWait);
                Writing(" What are you retarded? Obviously I am going to wield the " + championWeapon);

            }
            Thread.Sleep(longWait);

            //makes a new line
            Console.WriteLine();


            //Initialises the player

            Player Player = new Player(30, 20, 20);
            
            

            
            /*Declaring some cards*/

            Card imbueWithFire = new Card("Imbue with Fire", "Flame", 1, 2, "Buff");
            
            Card bloodTaintedStrike = new Card("Blood tainted Strike", "Blood", 3, 1, "HP Cost Attack");
            
            Card zingAttack = new Card("Zing Attack", "Lightning", 1, 0, "Basic Attack");
            Card swordSwing = new Card("Sword Swing", null, 3, 1, "Basic Attack");
            Card boulderSplitter = new Card("Boulder Splitter", "Earth", 10, 3, "Basic Attack");

            //List of all starting cards
            List<Card> CardList = new List<Card>() { imbueWithFire, zingAttack, swordSwing, bloodTaintedStrike, boulderSplitter };

            //Initialises first Hand
            Hand startingHand = new Hand(10, CardList);


            //makes a new line
            Console.WriteLine();


            //initialises and introduces first enemy: Big Bozo
            Enemy bigBozo = new Enemy("Big Bozo", 30);
            Writing(bigBozo.Name + " appears before you! Use your cards to kill " + bigBozo.Name + " to demonstrate your skills ;)");
            Writing(bigBozo.Name + " currently has " + bigBozo.Health + " health");
            Writing("You currently have " + Player.CurrentMana + '/' + Player.MaxMana + " mana");

            //Allows the player to use cards to attack Big Bozo until he dies.
            while (bigBozo.Health > 0)
            {
                Console.WriteLine();
                Console.Write("Type the number of the card you want to use: ");
                int cardPlayedIndex = Convert.ToInt16(Console.ReadLine()) - 1;

                
                if (cardPlayedIndex >= 0 && cardPlayedIndex < startingHand.HandSize)
                {
                    Card cardPlayed = startingHand.CurrentHand[cardPlayedIndex];

                    cardPlayed.BasicAttack(bigBozo, Player);
                    startingHand.CurrentHand.RemoveAt(cardPlayedIndex);
                    startingHand.HandSize--;
                    for (int cardCounter = 1; cardCounter <= startingHand.HandSize; cardCounter++)
                    {

                    
                        Console.Write($"{cardCounter}: {startingHand.CurrentHand[cardCounter - 1].Name}");
                        if (startingHand.CurrentHand[cardCounter - 1].CardType == "Basic Attack")
                        {
                            Console.WriteLine($"    DMG: {startingHand.CurrentHand[cardCounter - 1].Magnitude}. MP Cost: {startingHand.CurrentHand[cardCounter - 1].Cost} ");
                        }
                        else if (startingHand.CurrentHand[cardCounter - 1].CardType == "HP Cost Attack")
                        {
                            Console.WriteLine($"    DMG: {startingHand.CurrentHand[cardCounter - 1].Magnitude}. HP Cost: {startingHand.CurrentHand[cardCounter - 1].Cost} ");
                        }
                        else if (startingHand.CurrentHand[cardCounter - 1].CardType == "Buff")
                        {
                            Console.WriteLine($"    Buff Attack by: {startingHand.CurrentHand[cardCounter - 1].Magnitude}. MP Cost: {startingHand.CurrentHand[cardCounter - 1].Cost} ");
                        }
                        //TO CATCH IF I HAVENT GIVEN EACH CARD A TYPE THAT CAN BE HANDLED BY THIS CODE
                        else
                        {
                            Console.WriteLine(" *Make a Type for this card* ");
                        }
                    }

                }
                else
                {
                    Writing("My instructions were pretty clear", false);
                    Writing("...", midWait, false);
                    Writing(" ", longWait, false);
                    Writing("Try again, but this time use your brain? ");
                }
            }
            Writing("${bigBozo.Name} is dead :O");


        }
        /*Method that prints each individual character of a string with a delay 
         which is by default set to shortWait but can be overridden
        to any amount by putting a comma after the string and an integer*/
        public static void Writing(string sentence, int customWait = ShortWait, bool newLine = true)
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
        public static void Writing(string sentence, bool newLine) => Writing(sentence, ShortWait, newLine);



    }
}
