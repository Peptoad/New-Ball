using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    public void ReturnToFirstLevels()
    {
        SceneManager.LoadScene("FirstLevels");
    }
    public void ReturnToLastLevels()
    {
        SceneManager.LoadScene("LastLevels");
    }
}