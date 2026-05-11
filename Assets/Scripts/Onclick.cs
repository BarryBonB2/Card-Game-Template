using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Onclick : MonoBehaviour
{
    public GameManager gameManager;

    public bool drawable = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Button button;
    void Start()
    {
        button.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        if (drawable == true)
        {
            gameManager.Draw();
        }
        Debug.Log(button);
        drawable = false;

        // gameManager.Draw();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
