using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [Header("Timer Settings")]
    private float timeRemaining; // seconds
    public bool timerIsRunning = false;
    [SerializeField] private WordCategory category;    

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

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void OnTimerEnd()
    {
        // You can trigger game over or any other action here
        SceneManager.LoadScene("ScoreScreen");
        // Example: FindObjectOfType<GameManager>().GameOver();
    }
}
