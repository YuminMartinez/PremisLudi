using UnityEngine;
using System;

public class FishScore : MonoBehaviour
{
    [Header("Configuración de Puntos")]
    [SerializeField] private int correctWordsPoints = 1;     // puntos normales
    [SerializeField] private int incorrectWordsPoints = -1;  // puntos por error
    [SerializeField] private int firstComboPoint = 5;        // puntos al llegar a combo 3

    private int combo = 0;
    private int points = 0;
    private int previousPoints = 0;

    public int Score { get; private set; }

    // Evento: (nuevoScore, delta)
    public event Action<int, int> OnScoreChanged;

    public void AddPoints(bool correct)
    {
        if (correct)
        {
            combo++;

            if (combo < 3)
            {
                // combo 1 y 2
                points = correctWordsPoints;
            }
            else if (combo == 3)
            {
                // primer combo de 3
                previousPoints = firstComboPoint;
                points = previousPoints;
            }
            else // combo > 3
            {
                // después del combo 3, +2 cada vez
                previousPoints += 2;
                points = previousPoints;
            }
        }
        else
        {
            // reinicia combo
            combo = 0;
            previousPoints = 0;
            points = incorrectWordsPoints;
        }

        // 🔹 Aplica los puntos
        Score += points;

        // 🔹 Dispara evento
        OnScoreChanged?.Invoke(Score, points);

        // 🔹 Mensajes de depuración
        Debug.Log($"Combo actual: {combo}");
        Debug.Log($"Pez: {(points >= 0 ? "+" : "")}{points} → total {Score}");
    }
}
