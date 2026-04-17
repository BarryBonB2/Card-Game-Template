using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

    public Canvas canvas;

    public Vector3 player_hand_pos;
    public Vector3 ai_hand_pos;

    public Card blank;

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
        Shuffle();
        Deal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Deal()
    {
        for (int i = 0; i <3; i++)
        {
            Card top_card = Instantiate(blank, player_hand_pos, Quaternion.identity, canvas.transform);

            player_hand_pos.x += 350;
            
            top_card.data = player_deck[0];

            //add the card to the hand
            player_hand.Add(top_card);

            //add the card gameobject to the list of gameobjects
            player_hand_object.Add(top_card.gameObject);
            player_deck.RemoveAt(0);
            
    

        }
    }

    void Shuffle()
    {   
        
        player_deck = player_deck.OrderBy(x => Random.value).ToList();
    }

    void AI_Turn()
    {


    }



    
}
