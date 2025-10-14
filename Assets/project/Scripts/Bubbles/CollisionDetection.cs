using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private WordData2 wordData;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Fish")) return;

        FishScore fishScore = other.GetComponent<FishScore>();
        if (fishScore != null)
        {
            int puntos = wordData.IsCorrect ? +10 : -10;
            fishScore.AddPoints(puntos);
        }

        Destroy(gameObject);
    }

    public void SetWord(WordData2 newWord)
    {
        wordData = newWord;
        // Aquí podrías actualizar visualmente el texto si tu burbuja lo muestra
    }

    public WordData2 GetWord()
    {
        return wordData;
    }
}
