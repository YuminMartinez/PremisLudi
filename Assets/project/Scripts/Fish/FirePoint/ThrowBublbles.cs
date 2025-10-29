using System.Collections;
using System.Collections.Generic;   // List<>
using TMPro;                        // TMP_Text
using UnityEngine;

public class ThrowBubbles : MonoBehaviour
{
    [Header("Configuración general")]
    public GameObject bubblePrefab;
    public WordPool wordPool;
    public WordCategory currentCategory;
    [SerializeField] private float fireDelay = 2f;
    [SerializeField]  private float wait = 6f; // Visible for 4 seconds 

    // Shared list between all firepoints in the scene
    public static List<WordData2> sharedAvailableWords;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void ResetStatics() => sharedAvailableWords = null;
    void Start()
    {
        // sharedAvailableWords = null;
        if (wordPool == null) { Debug.LogError("WordPool no asignado", this); return; }
        if (bubblePrefab == null) { Debug.LogError("BubblePrefab no asignado", this); return; }

        // Only first firepoint initializes list
        if (sharedAvailableWords == null || sharedAvailableWords.Count == 0)
        {
            sharedAvailableWords = new List<WordData2>(wordPool.GetWordsByCategory(currentCategory));
            Debug.Log($"🔁 Palabras cargadas ({sharedAvailableWords.Count}) para categoría {currentCategory}");
        }
        StartCoroutine(Explicacion());
       
    }
    IEnumerator Explicacion()
    {
        yield return new WaitForSeconds(wait);
        InvokeRepeating(nameof(SpawnBubble), 1f, fireDelay);
        Debug.Log("Coroutine finalizada tras 2 segundos.");
    }
    void SpawnBubble()
    {
        if (sharedAvailableWords == null || sharedAvailableWords.Count == 0)
        {
            Debug.Log(" Sin palabras disponibles.");
            return;
        }
        int randomIndex = Random.Range(0, sharedAvailableWords.Count);
        WordData2 selectedWord = sharedAvailableWords[randomIndex];
        sharedAvailableWords.RemoveAt(randomIndex);

        // Intantiate bubble prefab
        GameObject bubble = Instantiate(bubblePrefab, transform.position, Quaternion.identity);

        var cd = bubble.GetComponent<CollisionDetection>();
        if (cd != null) cd.SetWord(selectedWord);
        else Debug.LogError("El prefab de burbuja no tiene CollisionDetection.", bubble);

        // Show word when instantiating
        TMP_Text label = bubble.GetComponentInChildren<TMP_Text>();
        if (label != null)
        {
            label.text = selectedWord.Text;
        }

        Debug.Log($"💬 {name} lanzó '{selectedWord.Text}' ({selectedWord.Category})");

        if (sharedAvailableWords.Count == 0)
        {
            sharedAvailableWords = new List<WordData2>(wordPool.GetWordsByCategory(currentCategory));
            Debug.Log("♻️ Todas las palabras usadas. Reiniciando lista.");
        }
    }
}
