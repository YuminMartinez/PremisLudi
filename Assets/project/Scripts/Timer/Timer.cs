using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [Header("Timer Settings")]
    private float timeRemaining; // seconds
    public bool timerIsRunning = false;
    [SerializeField] private WordCategory category;


    [Header("Gameplay Data")]
    [SerializeField] private FishScore fishScore;  // arrástralo en el inspector (opcional)
    [SerializeField] private int wordsLearned = 0; // se irá incrementando durante la partida


    [Header("Level complete")]
    public bool level1 = false;
    public bool level2 = false;
    public bool level3 = false;
    public bool level4 = false;
    public bool level5 = false;


    [Header("UI Reference")]
    [SerializeField] TMP_Text timerText; // Assign your TMP text here in Inspector

    private void Awake()
    {
        if(category == WordCategory.Animales)
        {
            timeRemaining = 90.0f;
        } else if(category == WordCategory.Cuina)
        {
            timeRemaining = 75.0f;
        } else if(category==WordCategory.Casa || category == WordCategory.ColorsRoba)
        {
            timeRemaining = 60.0f;
        } else if (category == WordCategory.Verbs)
        {
            timeRemaining = 45.0f;
        }
    }

    void Start()
    {
        // Start timer automatically
        timerIsRunning = true;
        DisplayTime(timeRemaining);
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

                // Optional: call something when timer ends
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
        // Guarda los datos en PlayerPrefs
        PlayerPrefs.SetInt("FinalScore", FindObjectOfType<FishScore>().Score);
        PlayerPrefs.SetInt("WordsLearned", wordsLearned);

        PlayerPrefs.Save(); // Guarda los datos en disco

        // You can trigger game over or any other action here
        SceneManager.LoadScene("ScoreScreen");
        // Example: FindObjectOfType<GameManager>().GameOver();


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




    // Suma 1 (o la cantidad que pases)
    public void IncrementWordsLearned(int amount = 1)
    {
        wordsLearned += amount;
    }

    // Fija el valor directamente
    public void SetWordsLearned(int value)
    {
        wordsLearned = Mathf.Max(0, value);
    }

    // Leer el valor actual (por si lo necesitas)
    public int GetWordsLearned()
    {
        return wordsLearned;
    }

}
