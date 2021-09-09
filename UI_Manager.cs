using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UI_Manager : MonoBehaviour
{
    Character_Generator myCharGen;

    public Text race, ui_class, align;
    public Text strString, dexString, conString, intString, wisString, charString;
    public int strInt, dexInt, conInt, intInt, charInt, wisInt;
    public int strModInt, dexModInt, conModInt, intModInt, wisModInt, charModInt;
    public Text strModString, dexModString, conModString, intModString, wisModString, charModString;
    public Text hpString, itemList, speed, armorClassString;
    public int mod, armorClassInt, hpInt;
    public InputField nameField;
    public List<string> item_List;
    public InputField jsonOutput;

    void Start()
    {
        myCharGen = GetComponent<Character_Generator>();
        myCharGen.InitCharacterGenerator();
        ChangeName();
        SaveRace();
        SaveClass();
        SaveAlignment();
        UpdateUI();
    }

    void UpdateUI()
    {
        myCharGen.SpeedCalc();
        race.text = myCharGen.myRace.ToString();
        ui_class.text = myCharGen.myClass.ToString();
        align.text = myCharGen.myAlignment.ToString();
        speed.text = myCharGen.mySpeed.ToString();
        strInt = PlayerPrefs.GetInt("Strength");
        dexInt = PlayerPrefs.GetInt("Dexterity");
        conInt = PlayerPrefs.GetInt("Constitution");
        intInt = PlayerPrefs.GetInt("Intelligence");
        charInt = PlayerPrefs.GetInt("Charisma");
        wisInt = PlayerPrefs.GetInt("Wisdom");
        strString.text = strInt.ToString();
        dexString.text = dexInt.ToString();
        conString.text = conInt.ToString();
        intString.text = intInt.ToString();
        charString.text = charInt.ToString();
        wisString.text = wisInt.ToString();
        strModInt = modifiersCalc(strInt);
        dexModInt = modifiersCalc(dexInt);
        conModInt = modifiersCalc(conInt);
        intModInt = modifiersCalc(intInt);
        wisModInt = modifiersCalc(wisInt);
        charModInt = modifiersCalc(charInt);
        strModString.text = convertModToString(strModInt);
        dexModString.text = convertModToString(dexModInt);
        conModString.text = convertModToString(conModInt);
        intModString.text = convertModToString(intModInt);
        charModString.text = convertModToString(charModInt);
        wisModString.text = convertModToString(wisModInt);
        armorClassInt = dexModInt + 10;
        armorClassString.text = armorClassInt.ToString();
        hpInt = myCharGen.HPCalc() + conModInt;
        hpString.text = hpInt.ToString();
    }

    public void ChangeName()
    {
        nameField.text = PlayerPrefs.GetString("name");

    }

    public void SaveNameChange()
    {
        PlayerPrefs.SetString("name", nameField.text);
    }

    public void NextRaceClicked()
    {
        myCharGen.ChangeRace(true);
        PlayerPrefs.SetString("thisRace", myCharGen.myRace.ToString());
        UpdateUI();
    }

    public void PrevRaceClicked()
    {
        myCharGen.ChangeRace(false);
        PlayerPrefs.SetString("thisRace", myCharGen.myRace.ToString());
        UpdateUI();
    }

    public void NextClassClicked()
    {
        myCharGen.ChangeClass(true);
        PlayerPrefs.SetString("thisClass", myCharGen.myClass.ToString());
        UpdateUI();
    }

    public void PrevClassClicked()
    {
        myCharGen.ChangeClass(false);
        PlayerPrefs.SetString("thisClass", myCharGen.myClass.ToString());
        UpdateUI();
    }

    public void NextAlignmentClicked()
    {
        myCharGen.ChangeAlignment(true);
        PlayerPrefs.SetString("thisAlignment", myCharGen.myAlignment.ToString());
        UpdateUI();
    }

    public void PrevAlignmentClicked()
    {
        myCharGen.ChangeAlignment(false);
        PlayerPrefs.SetString("thisAlignment", myCharGen.myAlignment.ToString());
        UpdateUI();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Dice_Roll");
    }

    public int modifiersCalc(int attribute)
    {
        if (attribute == 3)
            mod = -4;

        else if (attribute == 4 || attribute == 5)
            mod = -3;

        else if (attribute == 6 || attribute == 7)
            mod = -2;

        else if (attribute == 8 || attribute == 9)
            mod = -1;

        else if (attribute == 10 || attribute == 11)
            mod = 0;

        else if (attribute == 12 || attribute == 13)
            mod = 1;

        else if (attribute == 14 || attribute == 15)
            mod = 2;

        else if (attribute == 16 || attribute == 17)
            mod = 3;

        else if (attribute == 18)
            mod = 4;

        return mod;
    }

    public string convertModToString(int attribute)
    {
        if (attribute < 0)
            return attribute.ToString();

        else
            return "+" + attribute;
    }

    public void SaveRace()
    {
        string raceFound = PlayerPrefs.GetString("thisRace");

        if (raceFound == "Dragonborn")
            myCharGen.myRace = Player_Attributes.Races.Dragonborn;

        else if (raceFound == "Dwarf")
            myCharGen.myRace = Player_Attributes.Races.Dwarf;

        else if (raceFound == "Elf")
            myCharGen.myRace = Player_Attributes.Races.Elf;

        else if (raceFound == "Gnome")
            myCharGen.myRace = Player_Attributes.Races.Gnome;

        else if (raceFound == "Halfling")
            myCharGen.myRace = Player_Attributes.Races.Halfling;

        else if (raceFound == "Half_Elf")
            myCharGen.myRace = Player_Attributes.Races.Half_Elf;

        else if (raceFound == "Half_Orc")
            myCharGen.myRace = Player_Attributes.Races.Half_Orc;

        else if (raceFound == "Human")
            myCharGen.myRace = Player_Attributes.Races.Human;

        else if (raceFound == "Tiefling")
            myCharGen.myRace = Player_Attributes.Races.Tiefling;
    }

    public void SaveClass()
    {
        string classFound = PlayerPrefs.GetString("thisClass");

        if (classFound == "Barbarian")
            myCharGen.myClass = Player_Attributes.Classes.Barbarian;

        else if (classFound == "Bard")
            myCharGen.myClass = Player_Attributes.Classes.Bard;

        else if (classFound == "Cleric")
            myCharGen.myClass = Player_Attributes.Classes.Cleric;

        else if (classFound == "Druids")
            myCharGen.myClass = Player_Attributes.Classes.Druids;

        else if (classFound == "Fighter")
            myCharGen.myClass = Player_Attributes.Classes.Fighter;

        else if (classFound == "Monk")
            myCharGen.myClass = Player_Attributes.Classes.Monk;

        else if (classFound == "Paladin")
            myCharGen.myClass = Player_Attributes.Classes.Paladin;

        else if (classFound == "Ranger")
            myCharGen.myClass = Player_Attributes.Classes.Ranger;

        else if (classFound == "Rogue")
            myCharGen.myClass = Player_Attributes.Classes.Rogue;

        else if (classFound == "Sorcerer")
            myCharGen.myClass = Player_Attributes.Classes.Sorcerer;

        else if (classFound == "Warlock")
            myCharGen.myClass = Player_Attributes.Classes.Warlock;

        else if (classFound == "Wizard")
            myCharGen.myClass = Player_Attributes.Classes.Wizard;
    }

    public void SaveAlignment()
    {
        string alignmentFound = PlayerPrefs.GetString("thisAlignment");

        if (alignmentFound == "Chaotic_Evil")
            myCharGen.myAlignment = Player_Attributes.Alignment.Chaotic_Evil;

        else if (alignmentFound == "Chaotic_Good")
            myCharGen.myAlignment = Player_Attributes.Alignment.Chaotic_Good;

        else if (alignmentFound == "Chaotic_Neutral")
            myCharGen.myAlignment = Player_Attributes.Alignment.Chaotic_Neutral;

        else if (alignmentFound == "Lawful_Evil")
            myCharGen.myAlignment = Player_Attributes.Alignment.Lawful_Evil;

        else if (alignmentFound == "Lawful_Good")
            myCharGen.myAlignment = Player_Attributes.Alignment.Lawful_Good;

        else if (alignmentFound == "Lawful_Neutral")
            myCharGen.myAlignment = Player_Attributes.Alignment.Lawful_Neutral;

        else if (alignmentFound == "Neutral_Evil")
            myCharGen.myAlignment = Player_Attributes.Alignment.Neutral_Evil;

        else if (alignmentFound == "Neutral_Good")
            myCharGen.myAlignment = Player_Attributes.Alignment.Neutral_Good;

        else if (alignmentFound == "True_Neutral")
            myCharGen.myAlignment = Player_Attributes.Alignment.True_Neutral;
    }

    public void ConvertToJson()
    {
        int exp = 0;
        Dictionary<string, int> attributes = new Dictionary<string, int>();
        attributes.Add("Strength", strInt);
        attributes.Add("Dexteritiy", dexInt);
        attributes.Add("Constitution", conInt);
        attributes.Add("Intelligence", intInt);
        attributes.Add("Wisdom", wisInt);
        attributes.Add("Charisma", charInt);
        DNDCharacter dndCharacter = new DNDCharacter();
        dndCharacter.GetCharInfo(nameField.text, myCharGen.myRace.ToString(),
            myCharGen.myClass.ToString(), myCharGen.myAlignment.ToString(),
            attributes, exp, hpInt, armorClassInt, myCharGen.mySpeed,
            item_List);
        string json = JsonUtility.ToJson(dndCharacter, true);
        Debug.Log(json);
        jsonOutput.text = json;
    }
}

[Serializable]

public class DNDCharacter : MonoBehaviour
{

    public string Name, Race, Class, Alignment;
    public int Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma;
    public int ExperiencePoints, HitPoints, ArmorClass, Speed;
    public List<string> ItemLists;

    public void GetCharInfo(string name, string race, string uiClass, string
        alignment, Dictionary<string, int> abilities, int expPoints,
        int hp, int ac, int speedVal, List<string>items)
    {
        Name = name;
        Race = race;
        Class = uiClass;
        Alignment = alignment;
        ExperiencePoints = expPoints;
        HitPoints = hp;
        ArmorClass = ac;
        Speed = speedVal;
        ItemLists = items;

        foreach (KeyValuePair<string, int> pair in abilities)
        {
            if (pair.Key == "Strength")
                Strength = pair.Value;

            else if (pair.Key == "Dexterity")
                Dexterity = pair.Value;

            else if (pair.Key == "Constitution")
                Constitution = pair.Value;

            else if (pair.Key == "Intelligence")
                Intelligence = pair.Value;

            else if (pair.Key == "Wisdom")
                Wisdom = pair.Value;

            else if (pair.Key == "Charisma")
                Charisma = pair.Value;
        }
    }
}
