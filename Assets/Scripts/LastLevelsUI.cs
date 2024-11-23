using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastLevelsUI : MonoBehaviour
{
    public void FirstLevelSelector()
    {
        SceneManager.LoadScene("Level4");
    }
    public void SecondLevelSelector()
    {
        SceneManager.LoadScene("Level5");
    }
    public void ThirdLevelSelector()
    {
        SceneManager.LoadScene("Level6");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LastLevelsSelector()
    {
        SceneManager.LoadScene("FirstLevels");
    }
}
