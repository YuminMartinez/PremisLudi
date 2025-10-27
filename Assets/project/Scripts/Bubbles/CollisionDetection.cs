using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private WordData2 wordData;

    // 👇 Añade estas dos referencias en el inspector
    [SerializeField] private GameObject floatingDeltaPrefab; // Prefab con el script FloatingDelta
    [SerializeField] private Transform canvasTransform;      // Canvas (para UI Text)

    [SerializeField] private GameObject correctParticles;    // Prefab de partículas para respuestas correctas
    [SerializeField] private GameObject incorrectParticles;  // Prefab de partículas para respuestas incorrectas

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
        {
            AudioManager.Instance.PlayCorrectClip(); // Reproduce sonido de respuesta correcta
            if (correctParticles != null)
                Instantiate(correctParticles, transform.position, Quaternion.identity); // Instancia partículas correctas
        }
        else
        {
            AudioManager.Instance.PlayIncorrectClip(); // Reproduce sonido de respuesta incorrecta
            if (incorrectParticles != null)
                Instantiate(incorrectParticles, transform.position, Quaternion.identity); // Instancia partículas incorrectas
        }


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
