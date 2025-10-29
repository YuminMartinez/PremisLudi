using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
public class Timer : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] private float startDelay = 4f;
    private float timeRemaining;
    public bool timerIsRunning = false;
    [SerializeField] private WordCategory category;

    [Header("Gameplay Data")]
    [SerializeField] private FishScore fishScore;
    [SerializeField] private int wordsLearned = 0;

    [Header("Level complete")]
    public bool level1 = false;
    public bool level2 = false;
    public bool level3 = false;
    public bool level4 = false;
    public bool level5 = false;

    [Header("UI Reference")]
    [SerializeField] TMP_Text timerText;

    private void Awake()
    {
        if(category == WordCategory.Animales)
        {
            timeRemaining = 45.0f;
        } else if(category == WordCategory.Cuina)
        {
            timeRemaining = 75.0f;
        } else if(category == WordCategory.Casa || category == WordCategory.ColorsRoba)
        {
            timeRemaining = 60.0f;
        } else if (category == WordCategory.Verbs)
        {
            timeRemaining = 45.0f;
        }
    }

    void Start()
    {
        
        timerIsRunning = false;
      

        DisplayTime(timeRemaining);

        
        StartCoroutine(StartTimerWithDelay());
    }
    private IEnumerator StartTimerWithDelay()
    {
        Debug.Log($"Esperando {startDelay} segundos antes de iniciar el timer...");
        yield return new WaitForSecondsRealtime(startDelay);
        Debug.Log("Timer iniciado!");
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time's up!");
                timeRemaining = 0;
                timerIsRunning = false;

                // Call something when timer ends
                OnTimerEnd();
            }
        }
   
    }

    void DisplayTime(float timeToDisplay)
    {
        // Add one second to make it look smooth
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("TEMPS: {0:00}:{1:00}", minutes, seconds);
    }

    void OnTimerEnd()
    {
        PlayerPrefs.SetInt("FinalScore", FindObjectOfType<FishScore>().Score);
        PlayerPrefs.SetInt("WordsLearned", wordsLearned);

        PlayerPrefs.Save();

        SceneManager.LoadScene("ScoreScreen");

        if (category == WordCategory.Animales)
        {
            PlayerPrefs.SetInt("Level1Completed", 1);
        }
        else if (category == WordCategory.Cuina)
        {
            PlayerPrefs.SetInt("Level2Completed", 1);
        }
        else if (category == WordCategory.Casa)
        {
            PlayerPrefs.SetInt("Level3Completed", 1);
        }
        else if (category == WordCategory.ColorsRoba)
        {
            PlayerPrefs.SetInt("Level4Completed", 1);
        }
        else if (category == WordCategory.Verbs)
        {
            PlayerPrefs.SetInt("Level5Completed", 1);
        }

        PlayerPrefs.Save();
    }

    public void IncrementWordsLearned(int amount = 1)
    {
        wordsLearned += amount;
    }

    public void SetWordsLearned(int value)
    {
        wordsLearned = Mathf.Max(0, value);
    }

    public int GetWordsLearned()
    {
        return wordsLearned;
    }

}
