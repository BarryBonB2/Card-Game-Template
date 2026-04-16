using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;

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
    public int season_number;
    // below are physical
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI healthText;
    public Image spriteImage;
    public Image seasonImage;
    public Image background;
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
        season_number = data.season_number;
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

      // rgb(138, 192, 241);
        
        Color32 Spring_color = new Color32(72, 116, 47,255);
        Color32 Summer_color = new (233, 224, 141,255);
        Color32 Autumn_color = new (100, 41, 23,255);
        Color32 winter_color = new (138, 192, 241,255);
        Debug.Log(Spring_color);
        if (season_number >0 && season_number <2)
        {
            background.color = Spring_color;
            Debug.Log(background.color);
        }
        else if (season_number>1 && season_number<3)
        {
            background.color = Summer_color;
        }
        else if (season_number>2 && season_number<4)
        {
            background.color = Autumn_color;
        }
        else if (season_number>3 && season_number<5)
        {
            background.color = winter_color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
