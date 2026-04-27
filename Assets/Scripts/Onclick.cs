using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Onclick : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Button button;
    void Start()
    {
        button.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        Debug.Log(button);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
