using System;
using System.Collections.Generic;
using System.Linq;

public class Views
{
    public static List<string> setupGame()
    {
        Console.Write("How many players? ");
        string numOfPlayers = Console.ReadLine();
        List<string> playerNames = new List<string>();
        for (int x = 1; x <= int.Parse(numOfPlayers); x++)
        {
            Console.Write("Player " + x + "'s Name ");
            playerNames.Add(Console.ReadLine());
        }
        return playerNames;
    }

    public static void startRound(CatFight catFight)
    {
        List<Player> players = catFight.Roll();
        Views.menu(catFight, players);
    }

    public static void menu(CatFight catFight, List<Player> players)
    {
        catFight.listPlayerData();
        Console.Write("1 - Save Dice, 2 - Show Saved Dice, 3 - Done, 4 - Meow ");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Views.saveDice(players[1]);
                break;
            case 2:
                Views.showSaved(players[1]);
                break;
            case 3:
                players = catFight.Roll();
                break;
            case 4:
                Views.meow(catFight, players[1]);
                break;
            default:
                //error
                break;
        }
        Views.menu(catFight, players);
    }

    public static void saveDice(Player player)
    {
        Console.WriteLine("Dice to save by dice number:");
        string diceIndexes = String.Join(" | ", player.rolledDice.Select((x, i) => i));
        string diceValues = String.Join(" | ", player.rolledDice.ToArray());
        Console.WriteLine("Dice Number: |" + diceIndexes + "|");
        Console.WriteLine("Dice Value:  |" + diceValues + "|");
        int[] save = Console.ReadLine().Split(',').Select(x => int.Parse(x.Trim())).ToArray();
        foreach(int i in save){
            player.savedDice.Add(player.rolledDice[i]);
        }
        foreach(int i in save){
            player.rolledDice.RemoveAt(i);
        }
    }

    public static void showSaved(Player player)
    {
        string diceValues = String.Join(" | ", player.savedDice.ToArray());
        Console.WriteLine("Dice Value:  |" + diceValues + "|");
    }

    public static void meow(CatFight catFight, Player player){
        foreach(int dice in player.rolledDice){
            player.savedDice.Add(dice);
        }
        player.rolledDice.Clear();
        catFight.Meow(player.name);
    }
}