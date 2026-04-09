using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Card_data data;
    public Attack_data attack_data;
    public string card_name;
    public int health;
    public Sprite sprite;
    public Sprite season_sprite;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI healthText;
    public Image spriteImage;
    public Image seasonImage;
    

    // Start is called before the first frame update
    void Start()
    {
        card_name = data.card_name;
        //description = data.description;
        health = data.health;
        //cost = data.cost;
        //damage = data.damage;
        sprite = data.sprite;
        season_sprite = data.Season_Sprite;
        nameText.text = card_name;
        //descriptionText.text = description;
        healthText.text = health.ToString();
        //costText.text = cost.ToString();
        //damageText.text = damage.ToString();
        spriteImage.sprite = sprite;
        seasonImage.sprite = season_sprite;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
