using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private WordData2 wordData;

    [SerializeField] private GameObject floatingDeltaPrefab;
    [SerializeField] private Transform canvasTransform;

    [SerializeField] private GameObject correctParticles;
    [SerializeField] private GameObject incorrectParticles;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Fish")) return;

        FishScore fishScore = other.GetComponent<FishScore>();
        if (fishScore == null) return;

        // Assign bool value for checking answer later
        bool correct = (wordData != null) && wordData.IsCorrect;

        // Assign value depending on answer
        int delta = correct ? +10 : -5;
        fishScore.AddPoints(correct);

        if (correct)
        {
            AudioManager.Instance.PlayCorrectClip(); // Correct answer audio clip
            if (correctParticles != null)
                Instantiate(correctParticles, transform.position, Quaternion.identity); // Instantiate correct particles
        }
        else
        {
            AudioManager.Instance.PlayIncorrectClip(); // Incorrect answer audio clip
            if (incorrectParticles != null)
                Instantiate(incorrectParticles, transform.position, Quaternion.identity); // Instantiate incorrect particles
        }


        // Instantiate string message
        if (floatingDeltaPrefab != null && canvasTransform != null)
        {
            var instance = Instantiate(floatingDeltaPrefab, canvasTransform);
            instance.GetComponent<FloatingDelta>().Show(delta);
        }

        // Destroy bubble
        Destroy(gameObject);
    }

    public void SetWord(WordData2 newWord) => wordData = newWord;
    public WordData2 GetWord() => wordData;
}
