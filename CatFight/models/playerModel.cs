using System.Collections.Generic;

public class Player{
    public Player(){
        this.rolledDice = new List<int>();
        this.savedDice = new List<int>();
    }

    public string name;
    public List<int> rolledDice;

    public List<int> savedDice;
    public int diceSum;
}