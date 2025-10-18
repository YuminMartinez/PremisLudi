using UnityEngine;


public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private WordData2 wordData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Fish")) return;

        FishScore fishScore = other.GetComponent<FishScore>();
        if (fishScore == null) return;

        bool correct = (wordData != null) && wordData.IsCorrect;
        fishScore.AddPoints(correct);

        Destroy(gameObject);
    }

    public void SetWord(WordData2 newWord) => wordData = newWord;
    public WordData2 GetWord() => wordData;
}
