using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            /*Declaring some cards*/

            Card imbueWithFire = new Card("Imbue with Fire", "Flame", 1, 2);

            Card zingAttack = new Card("Zing Attack", "Lightning", 1, 0);
            Card swordSwing = new Card("Sword Swing", null, 3, 1);
            Card bloodTaintedStrike = new Card("Blood tainted Strike", "Blood", 3, 1);
            Card boulderSplitter = new Card("Boulder Splitter", "Earth", 10, 3);

            //List of all starting cards
            List<Card> CardList = new List<Card>() { imbueWithFire, zingAttack, swordSwing, bloodTaintedStrike, boulderSplitter };

            //Initialises first Hand
            Hand StartingHand = new Hand();
            StartingHand.HandSize = 5;


            Console.Write("\n");
            // randomly generates a hand from starting cards



            for (int cardCounter = 0; cardCounter < StartingHand.HandSize; cardCounter++)
            {
                Random random = new Random();
                int randomIndex = random.Next(CardList.Count);
                Card randomCard = CardList[randomIndex];
                StartingHand.Cards.Add(randomCard);
                Console.WriteLine(StartingHand.Cards[cardCounter].Name);
            }
            Console.Write("\n");

            Enemy bigBozo = new Enemy("Big Bozo", 30);

            Writing(bigBozo.Name + " appears before you! Use your cards to kill " + bigBozo.Name + " to demonstrate your skills ;)");
            Writing(bigBozo.Name + " currently has " + bigBozo.Health + " health");
            Console.Write("Type the card you wabt to use: ");
            
            string cardPlayed = Console.ReadLine().ToLower();

            //if (cardPlayed == basicAttackTypeCard && Card is in hand)
            //if (cardPlayed == zingAttack.Name.ToLower() || cardPlayed == swordSwing.Name.ToLower() || cardPlayed == boulderSplitter.Name.ToLower())
            //{
            //   convert string to Card.BasicAttack(CurrentEnemy, Card.Magnitude, Card.Cost); 
            //}

            if (cardPlayed == zingAttack.Name.ToLower())
            {
                zingAttack.BasicAttack(bigBozo, zingAttack.Magnitude, zingAttack.Cost);

            }
            else if (cardPlayed == swordSwing.Name.ToLower())
            {
                swordSwing.BasicAttack(bigBozo, swordSwing.Magnitude, swordSwing.Cost);

            }
            else if (cardPlayed == boulderSplitter.Name.ToLower())
            {
                boulderSplitter.BasicAttack(bigBozo, boulderSplitter.Magnitude, boulderSplitter.Cost);
            }
            else
                Writing("I won't act on behalf of an illiterate leader. Type the card name properly!");




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
