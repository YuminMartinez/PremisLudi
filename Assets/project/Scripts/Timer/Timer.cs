using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] private float timeRemaining = 90f; // seconds
    public bool timerIsRunning = false;

    [Header("UI Reference")]
    [SerializeField] TMP_Text timerText; // Assign your TMP text here in Inspector

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
        Debug.Log("Game Over!");
        // Example: FindObjectOfType<GameManager>().GameOver();
    }
}
