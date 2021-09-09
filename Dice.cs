using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Dice : MonoBehaviour
{
    public int diceCount;
    public int dice1;
    public int dice2;
    public int dice3;
    public int dice4;
    public int dice5;
    public int total;

    public int[] diceVals = new int[5];

    public void initializeRoll()
    {
        diceCount = 0;
        dice1 = 0;
        dice2 = 0;
        dice3 = 0;
        dice4 = 0;
        dice5 = 0;
        total = 0;
}

    public void rollDice()
    {
        int randomVal = UnityEngine.Random.Range(1, 7);
        if (diceCount == 0)
        {
            dice1 = randomVal;
            diceVals[0] = dice1;
        }
        else if (diceCount == 1)
        {
            dice2 = randomVal;
            diceVals[1] = dice2;
        }
        else if (diceCount == 2)
        {
            dice3 = randomVal;
            diceVals[2] = dice3;
        }
        else if (diceCount == 3)
        {
            dice4 = randomVal;
            diceVals[3] = dice4;
        }

        else if (diceCount == 4)
        {
            dice5 = randomVal;
            diceVals[4] = dice5;
            calculatedTotal();
        }
        diceCount++;
    }

    public void calculatedTotal()
    {
        Array.Sort(diceVals);
        total = diceVals[2] + diceVals[3] + diceVals[4];
    }
}