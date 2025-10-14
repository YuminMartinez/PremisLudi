using UnityEngine;

public class FishScore : MonoBehaviour
{
    public int score = 0;

    public void AddPoints(int amount)
    {
        score += amount;
        string signo = amount > 0 ? "+" : "";
        Debug.Log($"Pez: {signo}{amount} puntos → total: {score}");
    }
}