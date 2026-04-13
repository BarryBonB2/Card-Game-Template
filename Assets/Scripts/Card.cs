using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Card_data data;
    public string card_name;
    public int health;
    public Sprite sprite;
    public Sprite season_sprite;
    public string Attack_name1;
    public string attack_description1;
    public int damage1;
    public string Attack_name2;
    public string attack_description2;
    public int damage2;
    public int shield;
    public Sprite shield_sprite;
    public string runaway;
    // below are physical
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI healthText;
    public Image spriteImage;
    public Image seasonImage;
    public TextMeshProUGUI attack_name1Text;
    public TextMeshProUGUI attack_desc1Text;
    public TextMeshProUGUI dmg1Text;
    public TextMeshProUGUI attack_name2Text;
    public TextMeshProUGUI attack_desc2Text;
    public TextMeshProUGUI dmg2Text;
    public TextMeshProUGUI shield_count;
    public TextMeshProUGUI run;
    

    // Start is called before the first frame update
    void Start()
    {
        card_name = data.card_name;
        health = data.health;
        sprite = data.sprite;
        season_sprite = data.Season_Sprite;
        Attack_name1 = data.Attack_name1;
        attack_description1 = data.attack_description1;
        damage1 = data.damage1;
        Attack_name2 = data.Attack_name2;
        attack_description2 = data.attack_description2;
        damage2 = data.damage2;
        shield = data.shield;
        runaway = data.runaway;
        //
        nameText.text = card_name;
        healthText.text = health.ToString();
        spriteImage.sprite = sprite;
        seasonImage.sprite = season_sprite;
        attack_name1Text.text = Attack_name1;
        attack_desc1Text.text = attack_description1;
        dmg1Text.text = damage1.ToString();
        attack_name2Text.text = Attack_name2;
        attack_desc2Text.text = attack_description2;
        dmg2Text.text = damage2.ToString();
        shield_count.text = shield.ToString();
        run.text = runaway;
        
        if(damage1 != 0)
        {
            dmg1Text.text = dmg1Text.text + " Dmg";
        }
        else
        {
            dmg1Text.text = "";
        }


          if(damage2 != 0)
        {
            dmg2Text.text = dmg2Text.text + " Dmg";
        }
        else
        {
            dmg2Text.text = "";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
