using System;
using System.Collections.Generic;
using System.Linq;

public class Dice
{
    private int numberOfDice;
    private int numberOfSidesPerDice;
    private List<int> diceValues;
    private Random rnd;

    public Dice(int numberOfDice, int? numberOfSidesPerDice)
    {
        this.numberOfDice = numberOfDice;
        this.numberOfSidesPerDice = numberOfSidesPerDice ?? 6;
        rnd = new Random();
    }

    public List<int> RollDice(int? numberOfDice)
    {
        this.numberOfDice = numberOfDice ?? this.numberOfDice;
        this.diceValues = new List<int>();
        for (int x = 1; x <= this.numberOfDice; x++)
        {
            this.diceValues.Add(rnd.Next(1, this.numberOfSidesPerDice + 1));
        }
        return this.diceValues;
    }

    public int getSum()
    {
        return this.diceValues.Sum();
    }

    public List<int> getRoll()
    {
        return this.diceValues;
    }
}