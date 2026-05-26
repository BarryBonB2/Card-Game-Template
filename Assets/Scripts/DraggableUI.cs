using Unity.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameManager gameManager;
    private RectTransform rectTransform;
    private Canvas canvas;
    public Quaternion Initial_rotation;
    public Vector2 Active_transform;
    public GameObject activeslot;
    public bool OnActive = false;
    public int number;
    public Card Card;
    public GameObject CardExist;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }   

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("started draggin : " + gameObject.name);
       // Debug.Log(gameManager.player_hand);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        
    }

    public void OnEndDrag (PointerEventData eventData)
    {
        Debug.Log(" finished dragging : " + gameObject.name);
        if (OnActive == true && gameManager.CardActive == false)
        {
            Debug.Log("blegh");
            gameManager.CardActive = true;
            // transform.position = Active_transform;
            // transform.rotation = Initial_rotation;
            gameManager.currentindex = number;
            gameManager.Activate();
            Destroy(CardExist);
            gameManager.UpdateCardPositions();
        }
        
        else 
        {
            gameManager.UpdateCardPositions();
            Debug.Log("niffle");
            
        }

        
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Active"))
        {
            OnActive = true;
            Debug.Log("test 1");
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {   
        if(collision.gameObject.CompareTag("Active"))
        {
            OnActive = false;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initial_rotation = activeslot.transform.rotation;
        Active_transform =activeslot.transform.position;
        number = Card.currentindex;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
