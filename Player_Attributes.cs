using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attributes : MonoBehaviour
{
    public enum Abilities
    {
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma
    }

    public enum Races
    {
        Dragonborn,
        Dwarf,
        Elf,
        Gnome,
        Half_Elf,
        Half_Orc,
        Halfling,
        Human,
        Tiefling
    };

    public enum Classes
    {
        Barbarian,
        Bard,
        Cleric,
        Druids,
        Fighter,
        Monk,
        Paladin,
        Ranger,
        Rogue,
        Sorcerer,
        Warlock,
        Wizard
    };

    public enum Alignment
    {
        Lawful_Good,
        Neutral_Good,
        Chaotic_Good,
        Lawful_Neutral,
        True_Neutral,
        Chaotic_Neutral,
        Lawful_Evil,
        Neutral_Evil,
        Chaotic_Evil
    };
}