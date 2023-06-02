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

        /*Delay times in milliseconds for text output*/
        /*Set to 0 for speed of testing. Should be 200 and 500?*/
        private const int midWait = 0;
        private const int longWait = 0;

        public static List<Card> CardList { get; set; }

        static void Main(string[] args)
        {





            string championName = "Maximus the Bold";
            Console.Write("Greetings, my leader! What should I, your champion, be called? ");

            string userInputtedName = Console.ReadLine().ToLower();

            /*Prints a response depending on user input*/
            if (userInputtedName != championName.ToLower())
            {
                Writing(userInputtedName, false);
                ThreeDotWritingLoop();
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
                ThreeDotWritingLoop();
                Writing(" What are you retarded? Obviously I am going to wield the " + championWeapon);

            }
            Thread.Sleep(longWait);

            //makes a new line
            Console.WriteLine();

            /*Declaring some cards*/

            Card imbueWithFire = new Card("Imbue with Fire", ElementType.Flame, 1, 2, "Buff");

            Card bloodTaintedStrike = new Card("Blood tainted Strike", ElementType.Blood, 3, 1, "HP Cost Attack");

            Card zingAttack = new Card("Zing Attack", ElementType.Lightning, 1, 0, "Basic Attack");
            Card swordSwing = new Card("Sword Swing", ElementType.None, 3, 1, "Basic Attack");
            Card boulderSplitter = new Card("Boulder Splitter", ElementType.Earth, 10, 3, "Basic Attack");

            //List of all starting cards
            CardList = new List<Card>() { imbueWithFire, zingAttack, swordSwing, bloodTaintedStrike, boulderSplitter };



            //Initialises the player
            /*Because player Max/current HP/MP are always the same upon initialisation (for now) 
            ,I made variables to change the values more quickly*/



            Champion championMaximus = new Champion(30, 30, 20, 20, 0, 10);







            //makes a new line
            Console.WriteLine();


            //initialises and introduces first enemy: Big Bozo
            BigBozo bigBozo = new BigBozo();
            Writing(bigBozo.Name + " appears before you! Use your cards to kill " + bigBozo.Name + " to demonstrate your skills ;)");
            Writing(bigBozo.Name + " currently has " + bigBozo.Health + " health");
            Writing("You currently have " + championMaximus.CurrentHealth + '/' + championMaximus.MaxHealth + " health");
            Writing("You currently have " + championMaximus.CurrentMana + '/' + championMaximus.MaxMana + " mana");

            //Allows the player to use cards to attack Big Bozo until he dies.
            while (bigBozo.Health > 0)
            {
                Console.WriteLine();
                Console.Write("Type the number of the card you want to use: ");
                int cardPlayedIndex = Convert.ToInt16(Console.ReadLine()) - 1;


                if (cardPlayedIndex >= 0 && cardPlayedIndex < championMaximus.HandSize)
                {
                    Card cardPlayed = championMaximus.Hand[cardPlayedIndex];

                    if (cardPlayed.CardType == "Basic Attack")
                    {
                        cardPlayed.BasicAttack(bigBozo, championMaximus);
                    }
                    else if (cardPlayed.CardType == "HP Cost Attack")
                    {
                        cardPlayed.HpCostAttack(bigBozo, championMaximus);
                    }
                    else if (cardPlayed.CardType == "Buff")
                    {
                        cardPlayed.Buff(championMaximus);
                    }
                    championMaximus.Hand.RemoveAt(cardPlayedIndex);
                    championMaximus.HandSize--;

                    for (int cardCounter = 1; cardCounter <= championMaximus.HandSize; cardCounter++)
                    {


                        Console.Write($"{cardCounter}: {championMaximus.Hand[cardCounter - 1].Name}");
                        if (championMaximus.Hand[cardCounter - 1].CardType == "Basic Attack")
                        {

                            Console.WriteLine($"    DMG: {championMaximus.Hand[cardCounter - 1].Magnitude + championMaximus.BonusAttack}. MP Cost: {championMaximus.Hand[cardCounter - 1].Cost} ");
                        }
                        else if (championMaximus.Hand[cardCounter - 1].CardType == "HP Cost Attack")
                        {

                            Console.WriteLine($"    DMG: {championMaximus.Hand[cardCounter - 1].Magnitude + championMaximus.BonusAttack}. HP Cost: {championMaximus.Hand[cardCounter - 1].Cost} ");
                        }
                        else if (championMaximus.Hand[cardCounter - 1].CardType == "Buff")
                        {

                            Console.WriteLine($"    Buff Attack by: {championMaximus.Hand[cardCounter - 1].Magnitude}. MP Cost: {championMaximus.Hand[cardCounter - 1].Cost} ");
                        }
                        //TO CATCH IF I HAVENT GIVEN EACH CARD A TYPE THAT CAN BE HANDLED BY THIS CODE
                        else
                        {
                            Console.WriteLine(" *Make a Type for this card* ");
                        }

                    }
                    bigBozo.CounterMove(championMaximus, cardPlayed.Element);



                }
                else
                {
                    Writing("My instructions were pretty clear", false);
                    Writing("...", midWait, false);
                    Writing(" ", longWait, false);
                    Writing("Try again, but this time use your brain? ");
                }
            }
            Writing($"{bigBozo.Name} is dead :O");


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

        public static void ThreeDotWritingLoop()
        {
            Thread.Sleep(midWait);
            for (int i = 0; i < 3; i++)
            {
                Console.Write('.');
                Thread.Sleep(midWait);
            }
            Thread.Sleep(longWait);
        }

    }
}
