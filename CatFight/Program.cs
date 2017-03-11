
using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cat Fight.");

            List<string> playerNames = Views.setupGame();
            CatFight catFight = new CatFight(playerNames.ToArray());

            Views.startRound(catFight);

            // catFight.listPlayerData();
        }
    }
}
