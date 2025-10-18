using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // o usa UnityEngine.UI si no usas TextMeshPro

public class FinalScreenController : MonoBehaviour
{
    [SerializeField] private TMP_Text paraulesText;
    [SerializeField] private TMP_Text puntuacioText;

    [Header("Nombres de escenas")]
    [SerializeField] private string menuScene = "Menu";
    [SerializeField] private string levelsScene = "MenuNivells";

    void Start()
    {
        int words = PlayerPrefs.GetInt("WordsLearned", 0);
        int score = PlayerPrefs.GetInt("FinalScore", 0);

        if (paraulesText != null)
            paraulesText.text = "Paraules apreses: " + words;

        if (puntuacioText != null)
            puntuacioText.text = "Puntuació: " + score;
    }

   
}
