using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Onclick : MonoBehaviour
{


    public bool drawable = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Button button;
    void Start()
    {
        button.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        Debug.Log(button);
        drawable = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
