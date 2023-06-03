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



        static void Main(string[] args)
        {
            //Initialises the player

            Trilby trilby = new Trilby(30, 30, 20, 20, 0, 10);
           
            //initialises and introduces first enemy: Big Bozo
            BigBozo bigBozo = new BigBozo();


            //Allows the player to use cards to attack Big Bozo until he dies.
            while (bigBozo.CurrentHealth > 0)
            {
                Console.Write("Type the number of the card you want to use: ");
                int cardPlayedIndex = Convert.ToInt16(Console.ReadLine()) - 1;


                if (cardPlayedIndex >= 0 && cardPlayedIndex < trilby.HandSize)
                {
                    Card cardPlayed = trilby.Hand[cardPlayedIndex];

                    if (cardPlayed.CardType == CardType.BasicAttack)
                    {
                        cardPlayed.BasicAttack(bigBozo, trilby);
                    }
                    else if (cardPlayed.CardType == CardType.HpCostAttack)
                    {
                        cardPlayed.HpCostAttack(bigBozo, trilby);
                    }
                    else if (cardPlayed.CardType == CardType.Buff)
                    {
                        cardPlayed.Buff(trilby);
                    }
                    trilby.Hand.RemoveAt(cardPlayedIndex);
                    trilby.HandSize--;

                    bigBozo.CounterMove(trilby, cardPlayed.Element);
                    trilby.DisplayStats();
                    Card.ShowPlayerCards(trilby.Hand);

                }
                //Code doesn't work. Need exception handling I think.
                else
                {
                    Writing("Prove you are fit to use magic", false);
                    ThreeDotWritingLoop();
                    Writing(" Try again: ");
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

        //Method used to print '...' dramatically slower than regular text
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
