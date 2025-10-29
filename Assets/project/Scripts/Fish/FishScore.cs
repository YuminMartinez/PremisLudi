using UnityEngine;
using System;
using UnityEngine.UI;


public class FishScore : MonoBehaviour
{
    [Header("Configuración de Puntos")]
    [SerializeField] private int correctWordsPoints = 10; // Points for correct answer
    [SerializeField] private int incorrectWordsPoints = -5; // Points for incorrect answer
    [SerializeField] private int firstComboPoint = 5; // Points added when first combo is reached (3 continued correct answers)

    [SerializeField] private Image foc; // Fire used to show combo and streak
    private int combo = 0;
    private int points = 0;
    private int previousPoints = 0;

    public int Score { get; private set; }

    // Event: (nuevoScore, delta)
    public event Action<int, int> OnScoreChanged;


    void Start()
    {
        foc.gameObject.SetActive(false);
    }


    public void AddPoints(bool correct)
    {
        if (correct)
        {
            FindObjectOfType<Timer>()?.IncrementWordsLearned();
            combo++;

            if (combo < 3)
            {
                // First and second combo done
                points = correctWordsPoints;
                foc.gameObject.SetActive(false);
            }
            else if (combo == 3)
            {
                // First combo of 3
                previousPoints = firstComboPoint;
                points = previousPoints;
                foc.gameObject.SetActive(true);
            }
            else // 
            {
                // If combo > 3, adding +2 points everytime
                previousPoints += 2;
                points = previousPoints;
                foc.gameObject.SetActive(true);
            }
        }
        else
        {
            // Combo is resetted when incorrect answer is selected
            combo = 0;
            previousPoints = 0;
            points = incorrectWordsPoints;
            foc.gameObject.SetActive(false);
        }

        Score += points;

        // Event invoked
        OnScoreChanged?.Invoke(Score, points);

        Debug.Log($"Combo actual: {combo}");
        Debug.Log($"Pez: {(points >= 0 ? "+" : "")}{points} → total {Score}");
    }
}
