using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private WordData2 wordData;

    // 👇 Añade estas dos referencias en el inspector
    [SerializeField] private GameObject floatingDeltaPrefab; // Prefab con el script FloatingDelta
    [SerializeField] private Transform canvasTransform;      // Canvas (para UI Text)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Fish")) return;

        FishScore fishScore = other.GetComponent<FishScore>();
        if (fishScore == null) return;

        // Ver si la palabra es correcta
        bool correct = (wordData != null) && wordData.IsCorrect;

        // Asignar puntos según el resultado
        int delta = correct ? +10 : -5;
        fishScore.AddPoints(correct);

        if (correct)
            AudioManager.Instance.PlayCorrectClip();
        else
            AudioManager.Instance.PlayIncorrectClip();

        // 👇 Instanciar y mostrar el texto flotante
        if (floatingDeltaPrefab != null && canvasTransform != null)
        {
            var instance = Instantiate(floatingDeltaPrefab, canvasTransform);
            instance.GetComponent<FloatingDelta>().Show(delta);
        }

        // Destruir el objeto con el que colisionó
        Destroy(gameObject);
    }

    public void SetWord(WordData2 newWord) => wordData = newWord;
    public WordData2 GetWord() => wordData;
}
