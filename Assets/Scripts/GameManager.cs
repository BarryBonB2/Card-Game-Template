using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.Android.Gradle.Manifest;
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
    public List<Card_data> ai_hand = new List<Card_data>();
    public List<Card_data> discard_pile = new List<Card_data>();
    public List<Card> Active_player_card = new List<Card>();
    public List<GameObject> Active_player_card_object = new List<GameObject>();

    public Canvas canvas;

    public GameObject Player_hand_space;
    public Vector3 player_hand_pos;
    public Vector3 ai_hand_pos;
    public int totalcardsinhand;

    public Card blank;
    public Card Active_card_blank;

    public TextMeshProUGUI Season_Timer;
    public float season_count = 60;
    public int season = 1;
    public Onclick Draw_pile;
    public bool CardActive = false;

    public Vector3 Offset;
    [SerializeField] private int maxHandSize;
    [SerializeField] private SplineContainer splineContainer;
    [SerializeField] private Transform spawnpoint;
    

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
        Draw();
        
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
    // void Deal()
    // {
    //     for (int i = 0; i <1; i++)
    //     {
    //         Draw();
    //         // Card top_card = Instantiate(blank, player_hand_pos, Quaternion.identity, canvas.transform);

    //         // player_hand_pos.x += 200;
            
    //         // top_card.data = player_deck[0];

    //         // //add the card to the hand
    //         // player_hand.Add(top_card);

    //         // //add the card gameobject to the list of gameobjects
    //         // player_hand_object.Add(top_card.gameObject);
    //         // player_deck.RemoveAt(0);
            
    
    //     }


    // }

    public void Draw()
    {
        if (player_hand.Count >= maxHandSize) return;
        Card top_card = Instantiate(blank, spawnpoint.position, spawnpoint.rotation, canvas.transform);
        top_card.data = player_deck[0];
        player_hand.Add(top_card);
        player_hand_object.Add(top_card.gameObject);
        player_deck.RemoveAt(0);
        UpdateCardPositions();













        // Card top_card = Instantiate(blank, player_hand_pos, Quaternion.identity, canvas.transform);

        //     player_hand_pos.x += 200;
            
        //     top_card.data = player_deck[0];

        //     //add the card to the hand
        //     player_hand.Add(top_card);

        //     //add the card gameobject to the list of gameobjects
        //     player_hand_object.Add(top_card.gameObject);
        //     player_deck.RemoveAt(0);
        // // if (totalcardsinhand <1)
        // // {
        // //     player_hand_pos.x = 0;
        // // }
        // // this supposedly works but cant test rn

    }

    void Shuffle()
    {   
        
        player_deck = player_deck.OrderBy(x => Random.value).ToList();
    }

    void AI_Turn()
    {


    }

    public void Activate()
    {
        
    }

    
}
