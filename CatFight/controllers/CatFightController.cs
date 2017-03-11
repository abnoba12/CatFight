using System;
using System.Collections.Generic;
using System.Linq;

public class CatFight
{
    private int dicePlayedWith;
    private int round;
    private List<Player> players;
    private Dice dice;

    public CatFight(Array playerNames, int dicePlayedwith = 5)
    {
        this.dicePlayedWith = dicePlayedwith;
        this.dice = new Dice(this.dicePlayedWith, null);
        this.round = 1;
        this.players = new List<Player>();
        this.createPlayers(playerNames);
    }

    private void createPlayers(Array players)
    {
        this.players.Add(new Player
        {
            name = "Kitty"
        });
        foreach (string playerName in players)
        {
            this.players.Add(new Player
            {
                name = playerName
            });
        }
    }

    public List<Player> Roll()
    {
        foreach (Player player in players)
        {
            if (player.name == "Kitty" && player.savedDice.Count == 0)
            {
                player.savedDice = this.dice.RollDice(null);
                player.diceSum = player.savedDice.Sum();
            }
            else if (player.name != "Kitty")
            {
                int diceToRoll = this.dicePlayedWith - player.savedDice.Count;
                player.rolledDice = this.dice.RollDice(diceToRoll);
                player.diceSum = player.savedDice.Sum() + player.rolledDice.Sum();
            }
        }
        return this.players;
    }

    public void Meow(string playerName)
    {
        foreach (Player player in players)
        {
            if (player.name != "Kitty" && player.name != playerName)
            {
                int diceToRoll = this.dicePlayedWith - player.savedDice.Count;
                player.rolledDice = this.dice.RollDice(diceToRoll);
                player.diceSum = player.savedDice.Sum() + player.rolledDice.Sum();
            }
        }
        this.listPlayerData();
        Console.WriteLine(playerName + " Mewoed!!");
        int kittySum = this.players[0].diceSum;
        foreach (Player player in this.players)
        {
            if (player.name != "Kitty")
            {
                int offBy = player.diceSum - kittySum;
                if (offBy > 0)
                {
                    Console.WriteLine(player.name + " was over by " + Math.Abs(offBy));
                }
                else
                {
                    Console.WriteLine(player.name + " was under by " + Math.Abs(offBy));
                }
            }
        }
    }

    public void listPlayerData()
    {
        Console.WriteLine();
        foreach (Player player in this.players)
        {
            List<int> allDice = player.savedDice.Concat(player.rolledDice).ToList<int>();
            Console.WriteLine(player.name + " " + player.diceSum + " | " + string.Join(", ", allDice.ToArray()));
        }
        Console.WriteLine();
    }
}