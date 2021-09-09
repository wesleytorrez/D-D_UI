using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Generator : MonoBehaviour
{
    public Player_Attributes.Races myRace;
    public Player_Attributes.Classes myClass;
    public Player_Attributes.Alignment myAlignment;
    public int mySpeed, myHP;

    
    public void InitCharacterGenerator() {
        myRace = Player_Attributes.Races.Dwarf;
        myClass = Player_Attributes.Classes.Barbarian;
        myAlignment = Player_Attributes.Alignment.Lawful_Good;
    }
    

    public void SpeedCalc()
    {
        if (myRace == Player_Attributes.Races.Dwarf || myRace == Player_Attributes.Races.Halfling ||
            myRace == Player_Attributes.Races.Gnome)
        {
            mySpeed = 25;
        }
        else
        {
            mySpeed = 30;
        }
    }

    public int HPCalc()
    {
        if (myClass == Player_Attributes.Classes.Barbarian)
            myHP = 12;

        else if (myClass == Player_Attributes.Classes.Bard || myClass == Player_Attributes.Classes.Cleric ||
            myClass == Player_Attributes.Classes.Druids || myClass == Player_Attributes.Classes.Monk ||
            myClass == Player_Attributes.Classes.Rogue || myClass == Player_Attributes.Classes.Warlock)
            myHP = 8;

        else if (myClass == Player_Attributes.Classes.Fighter || myClass == Player_Attributes.Classes.Paladin ||
            myClass == Player_Attributes.Classes.Ranger)
            myHP = 10;

        else if (myClass == Player_Attributes.Classes.Sorcerer || myClass == Player_Attributes.Classes.Wizard)
            myHP = 6;

        return myHP;
    }

    public void ChangeRace(bool goNext)
    {
        bool found = false;

        if (goNext)
        {
            foreach (Player_Attributes.Races thisRace in System.Enum.GetValues(typeof(Player_Attributes.Races)))
            {
                if (found)
                {
                    found = false;
                    myRace = thisRace;
                    break;
                }
                else if (myRace == thisRace)
                {
                    found = true;
                }
            }

            if (found)
            {
                myRace = 0;
            }
        }
        else
        {
            int lastVal = System.Enum.GetValues(typeof(Player_Attributes.Races)).Length - 1;

            Player_Attributes.Races lastRace = (Player_Attributes.Races)lastVal;

            foreach (Player_Attributes.Races thisRace in System.Enum.GetValues(typeof(Player_Attributes.Races)))
            {
             if (myRace == thisRace)
                {
                    myRace = lastRace;
                    break;
                }
                lastRace = thisRace;
            }
        }
    }

    public void ChangeClass(bool goNext)
    {
        bool found = false;

        if (goNext)
        {
            foreach (Player_Attributes.Classes thisClass in System.Enum.GetValues(typeof(Player_Attributes.Classes)))
            {
                if (found)
                {
                    found = false;
                    myClass = thisClass;
                    break;
                }
                else if (myClass == thisClass)
                {
                    found = true;
                }
            }

            if (found)
            {
                myClass = 0;
            }
        }
        else
        {
            int lastVal = System.Enum.GetValues(typeof(Player_Attributes.Classes)).Length - 1;

            Player_Attributes.Classes lastClass = (Player_Attributes.Classes)lastVal;

            foreach (Player_Attributes.Classes thisClass in System.Enum.GetValues(typeof(Player_Attributes.Classes)))
            {
                if (myClass == thisClass)
                {
                    myClass = lastClass;
                    break;
                }
                lastClass = thisClass;
            }
        }
    }

    public void ChangeAlignment(bool goNext)
    {
        bool found = false;

        if (goNext)
        {
            foreach (Player_Attributes.Alignment thisAlignment in System.Enum.GetValues(typeof(Player_Attributes.Alignment)))
            {
                if (found)
                {
                    found = false;
                    myAlignment = thisAlignment;
                    break;
                }
                else if (myAlignment == thisAlignment)
                {
                    found = true;
                }
            }

            if (found)
            {
                myAlignment = 0;
            }
        }
        else
        {
            int lastVal = System.Enum.GetValues(typeof(Player_Attributes.Alignment)).Length - 1;

            Player_Attributes.Alignment lastAlignment = (Player_Attributes.Alignment)lastVal;

            foreach (Player_Attributes.Alignment thisAlignment in System.Enum.GetValues(typeof(Player_Attributes.Alignment)))
            {
                if (myAlignment == thisAlignment)
                {
                    myAlignment = lastAlignment;
                    break;
                }
                lastAlignment = thisAlignment;
            }
        }
    }
}
