using UnityEngine;
using System;

public class FishScore : MonoBehaviour
{
    public int Score { get; private set; }

    // Evento: se dispara cada vez que cambia la puntuación
    public event Action<int, int> OnScoreChanged;
    // args = (nuevoScore, delta)

    public void AddPoints(int amount)
    {
        Score += amount;
        OnScoreChanged?.Invoke(Score, amount);
        
        Debug.Log($"Pez: {(amount>=0?"+":"")}{amount} → total {Score}");
    }
}
