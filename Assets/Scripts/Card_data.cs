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
    public Sprite Season_Sprite;
    public Type season;
    public Type group;

}
