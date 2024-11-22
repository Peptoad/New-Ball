using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button myButton;
    void Start()
    {
        
        if (myButton != null)
        {
            myButton.onClick.AddListener(OnButtonClick);
        }
    }
    void OnButtonClick()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
