using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLevelsUI : MonoBehaviour
{
    public void FirstLevelSelector()
    {
        SceneManager.LoadScene("Level1");
    }
    public void SecondLevelSelector()
    {
        SceneManager.LoadScene("Level2");
    }
    public void ThirdLevelSelector()
    {
        SceneManager.LoadScene("Level3");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LastLevelsSelector()
    {
        SceneManager.LoadScene("LastLevels");
    }
}
