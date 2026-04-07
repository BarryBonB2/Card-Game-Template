using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack_data", menuName = "Attacks/Attack_data", order = 1)]
public class Attack_data : ScriptableObject
{
    public string card_name;
    public string description;
    public int health;
    //public int cost;
    public int damage;
    public Sprite sprite;

}
