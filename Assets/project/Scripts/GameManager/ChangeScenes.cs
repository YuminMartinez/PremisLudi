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
        SceneManager.LoadScene("Level1"); // el 1 siempre disponible
    }

    public void GoToLevel2()
    {
        if (PlayerPrefs.GetInt("Level1Completed", 0) == 1)
            SceneManager.LoadScene("Level2");
        else
            Debug.Log("❌ Nivel 2 bloqueado");
    }

    public void GoToLevel3()
    {
        if (PlayerPrefs.GetInt("Level2Completed", 0) == 1)
            SceneManager.LoadScene("Level3");
        else
            Debug.Log("❌ Nivel 3 bloqueado");
    }

    public void GoToLevel4()
    {
        if (PlayerPrefs.GetInt("Level3Completed", 0) == 1)
            SceneManager.LoadScene("Level4");
        else
            Debug.Log("❌ Nivel 4 bloqueado");
    }

    public void GoToLevel5()
    {
        if (PlayerPrefs.GetInt("Level4Completed", 0) == 1)
            SceneManager.LoadScene("Level5");
        else
            Debug.Log("❌ Nivel 5 bloqueado");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("InitScreen");
    }
}

