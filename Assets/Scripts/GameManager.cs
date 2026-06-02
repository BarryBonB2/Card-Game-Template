using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public List<Card_data> deck = new List<Card_data>();
    public List<Card_data> player_deck = new List<Card_data>();
    public List<Card_data> ai_deck = new List<Card_data>();
    public List<Card> player_hand = new List<Card>();
    public List<GameObject> player_hand_object = new List<GameObject>();
    public List<Card> ai_hand = new List<Card>();
    public List<GameObject> ai_hand_object = new List<GameObject>();
    public List<Card_data> discard_pile = new List<Card_data>();
    public List<Card> Active_player_card = new List<Card>();
    public List<GameObject> Active_player_card_object = new List<GameObject>();
    public List<Card> Active_ai_card = new List<Card>();
    public List<GameObject> Active_ai_card_object = new List<GameObject>();

    public Canvas canvas;

    public GameObject Player_hand_space;
    public Vector3 player_hand_pos;
    public Vector3 ai_hand_pos;
    public int totalcardsinhand;

    public Card blank;
    public Card Active_card_blank;
    public Card AI_Blank_Card;
    public Card AI_Card_Back;

    public TextMeshProUGUI Season_Timer;
    public float season_count = 60;
    public int season = 1;
    public Onclick Draw_pile;
    public bool CardActive = false;
    public bool AI_CardActive = false;

    public Vector3 Offset;
    public Vector3 AI_Offset;
    [SerializeField] private int maxHandSize;
    [SerializeField] private SplineContainer splineContainer;
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private int AI_maxHandSize;
    [SerializeField] private SplineContainer AI_splineContainer;
    [SerializeField] private Transform AI_spawnpoint;
    public GameObject activeslot;
    public GameObject Ai_activeSlot;
    public int currentindex = 5555;

    //whole lotta ui stuff

    public TextMeshProUGUI Ability1name;
    public TextMeshProUGUI Ability1desc;
    public TextMeshProUGUI Ability1Dmg;
    public TextMeshProUGUI Ability2name;
    public TextMeshProUGUI Ability2desc;
    public TextMeshProUGUI Ability2Dmg;


    //AI ui stuff

     public TextMeshProUGUI AI_Ability1name;
    public TextMeshProUGUI AI_Ability1desc;
    public TextMeshProUGUI AI_Ability1Dmg;
    public TextMeshProUGUI AI_Ability2name;
    public TextMeshProUGUI AI_Ability2desc;
    public TextMeshProUGUI AI_Ability2Dmg;
    
    

    private void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        canvas = FindAnyObjectByType<Canvas>();
       // player_hand_pos.x = ;
        Shuffle();
        AI_Shuffle();
        Draw();
        AI_Draw();
        Player_turn();
    }

    // Update is called once per frame
    void Update()
    {
        season_count -= Time.deltaTime;
        float seconds = season_count%60;
        Season_Timer.text = Mathf.RoundToInt (seconds).ToString();


       if(season_count <= 0)
        {
            season_count=60;
            season += 1;

        }
        if(season > 3 && season_count <= 0)
        {
            season = 1;
        }

        totalcardsinhand = player_hand.Count;
        if (totalcardsinhand <1)
        {
            player_hand_pos.x = 0;
        }
    }

    public void UpdateCardPositions()
    {
        if (player_hand.Count ==0) return;
        float cardspacing = 1f/ maxHandSize;
        float firstcardposition = 0.5f - (player_hand.Count - 1) * cardspacing /2;
        Spline spline = splineContainer.Spline;
        for (int i=0; i <player_hand.Count; i++)
        {
            float p =firstcardposition + i *cardspacing;
            Vector3 splinePosition = spline.EvaluatePosition(p);
            Vector3 forward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateUpVector(p);
            Quaternion rotation = Quaternion.LookRotation(up,Vector3.Cross(up, forward).normalized);
            player_hand[i].transform.DOMove(splinePosition + Offset, 0.25f);
            player_hand[i].transform.DOLocalRotateQuaternion(rotation,0.25f);
        }
    }    
    

    public void AI_UpdateCardPositions()
    {
        if (ai_hand.Count ==0) return;
        float cardspacing = 1f/ AI_maxHandSize;
        float firstcardposition = 0.5f - (ai_hand.Count - 1) * cardspacing /2;
        Spline spline = AI_splineContainer.Spline;
        for (int i=0; i <ai_hand.Count; i++)
        {
            float p =firstcardposition + i *cardspacing;
            Vector3 splinePosition = spline.EvaluatePosition(p);
            Vector3 forward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateUpVector(p);
            Quaternion rotation = Quaternion.LookRotation(up,Vector3.Cross(up, forward).normalized);
            ai_hand[i].transform.DOMove(splinePosition + AI_Offset, 0.25f);
            ai_hand[i].transform.DOLocalRotateQuaternion(rotation,0.25f);
        }
    }   

    public void Draw()
    {
        if (player_hand.Count >= maxHandSize) return;
        Card top_card = Instantiate(blank, spawnpoint.position, spawnpoint.rotation, canvas.transform);
      
        top_card.data = player_deck[0];
        player_hand.Add(top_card);
        top_card.currentindex = player_hand.Count -1;
        player_hand_object.Add(top_card.gameObject);
        player_deck.RemoveAt(0);
        UpdateCardPositions();

    }


public void AI_Draw()
    {
        if (ai_hand.Count >= AI_maxHandSize) return;
        Card top_card = Instantiate(AI_Card_Back, AI_spawnpoint.position, AI_spawnpoint.rotation, canvas.transform);
      
        top_card.data = ai_deck[0];
        ai_hand.Add(top_card);
        top_card.currentindex = ai_hand.Count -1;
        ai_hand_object.Add(top_card.gameObject);
        ai_deck.RemoveAt(0);
        AI_UpdateCardPositions();

    }
    

    void Shuffle()
    {   
        
        player_deck = player_deck.OrderBy(x => Random.value).ToList();
    }

    void AI_Shuffle()
    {   
        
        ai_deck = ai_deck.OrderBy(x => Random.value).ToList();
    }

    public void AI_Turn()
    {
         if(AI_CardActive == false)
        {
            //prompt player to activate card
            Debug.Log("place a card in the open slot");
            AI_Activate();
        }
        
        
        if (AI_CardActive == true)
        {
            AI_Draw();
            //then they need to use an ability
            Debug.Log("select a move to use");
        }

    }

    void Player_turn()
    {
        if(CardActive == false)
        {
            //prompt player to activate card
            Debug.Log("place a card in the open slot");
        }
        
        
        if (CardActive == true)
        {
            Draw();
            //then they need to use an ability
            Debug.Log("select a move to use");
        }


        
    }


    public void Activate()
    {   
        
        Card activecard = Instantiate(Active_card_blank,activeslot.transform.position, activeslot.transform.rotation,canvas.transform);

        activecard.data =player_hand[currentindex].data;

        Active_player_card.Add(activecard);
        Active_player_card_object.Add(activecard.gameObject);

        player_hand.RemoveAt(currentindex);
        player_hand_object.RemoveAt(currentindex);

        activecard.currentindex = Active_player_card.Count -1;

        Ability1name.text = activecard.data.Attack_name1.ToString();
        Ability1desc.text = activecard.data.attack_description1.ToString();
        Ability1Dmg.text = activecard.data.damage1.ToString();
        Ability2name.text = activecard.data.Attack_name2.ToString();
        Ability2desc.text = activecard.data.attack_description2.ToString();
        Ability2Dmg.text = activecard.data.damage2.ToString();


         if(activecard.data.damage1 != 0)
        {
            Ability1Dmg.text = Ability1Dmg.text + " Dmg";
        }
        else
        {
            Ability1Dmg.text = "";
        }


          if(activecard.data.damage2 != 0)
        {
            Ability2Dmg.text = Ability2Dmg.text + " Dmg";
        }
        else
        {
            Ability2Dmg.text = "";
        }
        CardActive = true;
        Player_turn();
    }
    

        public void AI_Activate()
    {
        currentindex = 0;
        
        Card activecard = Instantiate(AI_Blank_Card,Ai_activeSlot.transform.position, Ai_activeSlot.transform.rotation,canvas.transform);

        activecard.data =ai_hand[currentindex].data;

        Active_ai_card.Add(activecard);
        Active_ai_card_object.Add(activecard.gameObject);

        ai_hand.RemoveAt(currentindex);
        ai_hand_object.RemoveAt(currentindex);

        activecard.currentindex = Active_ai_card.Count -1;

        AI_Ability1name.text = activecard.data.Attack_name1.ToString();
        AI_Ability1desc.text = activecard.data.attack_description1.ToString();
        AI_Ability1Dmg.text = activecard.data.damage1.ToString();
        AI_Ability2name.text = activecard.data.Attack_name2.ToString();
        AI_Ability2desc.text = activecard.data.attack_description2.ToString();
        AI_Ability2Dmg.text = activecard.data.damage2.ToString();


         if(activecard.data.damage1 != 0)
        {
            AI_Ability1Dmg.text = AI_Ability1Dmg.text + " Dmg";
        }
        else
        {
            AI_Ability1Dmg.text = "";
        }


          if(activecard.data.damage2 != 0)
        {
            AI_Ability2Dmg.text = AI_Ability2Dmg.text + " Dmg";
        }
        else
        {
            AI_Ability2Dmg.text = "";
        }
        AI_CardActive = true;
        AI_Turn();
    }


}
