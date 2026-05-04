using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    public Vector2 Initial_transform;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }   

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("started draggin : " + gameObject.name);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag (PointerEventData eventData)
    {
        Debug.Log(" finished dragging : " + gameObject.name);
        transform.position = Initial_transform;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initial_transform = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
