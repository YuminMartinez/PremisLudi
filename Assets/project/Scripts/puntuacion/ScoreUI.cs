using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [Header("Referencias")]
    public FishScore fish;
    public TextMeshProUGUI scoreText;

    [Header("Floating Text Feedback")]
    public FloatingDelta floatingPrefab;       // arrastra el prefab aquí
    public RectTransform floatingRoot;         // un contenedor dentro del Canvas

    [Header("Formato")]
    public string prefix = "Score: ";

    void Reset()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        if (fish != null)
        {
            fish.OnScoreChanged += HandleScoreChanged;
            HandleScoreChanged(fish.Score, 0);
        }
    }

    void OnDisable()
    {
        if (fish != null)
            fish.OnScoreChanged -= HandleScoreChanged;
    }

    void HandleScoreChanged(int newScore, int delta)
    {
        if (scoreText != null)
            scoreText.text = $"{prefix}{newScore}";

        // Crear el texto flotante
        if (delta != 0 && floatingPrefab != null && floatingRoot != null)
        {
            FloatingDelta fx = Instantiate(floatingPrefab, floatingRoot);
            fx.transform.position = scoreText.transform.position + new Vector3(0, 40f, 0);
            fx.Show(delta);
        }
    }
}
