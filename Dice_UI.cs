using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Dice_UI : MonoBehaviour
{
    Dice rollDice;
    public Text diceVal1, diceVal2, diceVal3, diceVal4, diceVal5;
    public Text rollTotal;
    public Dropdown attributesList;
    string[] attArr = { "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" };

    private void Start()
    {
        rollDice = GetComponent<Dice>();
        rollDice.initializeRoll();

    }

    public void UIUpdate()
    {
        diceVal1.text = rollDice.dice1.ToString();
        diceVal2.text = rollDice.dice2.ToString();
        diceVal3.text = rollDice.dice3.ToString();
        diceVal4.text = rollDice.dice4.ToString();
        diceVal5.text = rollDice.dice5.ToString();
        rollTotal.text = rollDice.total.ToString();

    }

    public void roll()
    {
        rollDice.rollDice();
        UIUpdate();
    }

    public void save()
    {
        if (rollDice.diceCount >= 5)
        {
            string att = attArr[attributesList.value];
            int key = attributesList.value;
            shiftArray(key);
            PlayerPrefs.SetInt(att, rollDice.total);
            attributesList.options.RemoveAt(attributesList.value);
            rollDice.initializeRoll();
            UIUpdate();
        }
    }

    public void shiftArray(int key)
    {
        for (int i = key; i < attArr.Length - 1; i++)
        {
            if (key == 5)
                break;
            attArr[i] = attArr[i + 1];
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Create_Character");
    }
}
