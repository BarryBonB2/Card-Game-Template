using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card_data", menuName = "Cards/Card_data", order = 1)]
public class Card_data : ScriptableObject
{
    

    
    public string card_name;
    public int health;     
    public Sprite sprite;
    public Type season;
    public Type group;
    public string Attack_name1;
    public string attack_description1;
    public int damage1;
    public string Attack_name2;
    public string attack_description2;
    public int damage2;
    public int shield;
    public Sprite shield_sprite;
    public string runaway;
    public int season_number;

}
