using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void GoToLevelSelector()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void GoToLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void GoToLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void GoToLevel4()
    {
        SceneManager.LoadScene("Level4");
    }

    public void GoToLevel5()
    {
        SceneManager.LoadScene("Level5");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("InitScreen");

    }
}
