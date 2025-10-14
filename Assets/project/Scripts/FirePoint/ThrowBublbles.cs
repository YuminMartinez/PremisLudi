using System.Collections.Generic;   // List<>
using UnityEngine;
using TMPro;                        // TMP_Text

public class ThrowBubbles : MonoBehaviour
{
    [Header("Configuración general")]
    public GameObject bubblePrefab;
    public WordPool wordPool;
    public WordCategory currentCategory;
    public float fireDelay = 2f;

    // Lista compartida por TODOS los FirePoints
    public static List<WordData2> sharedAvailableWords;

    // (Opcional pero útil si tienes Enter Play Mode sin Reload Domain)
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void ResetStatics() => sharedAvailableWords = null;

    void Start()
    {
        if (wordPool == null) { Debug.LogError("WordPool no asignado", this); return; }
        if (bubblePrefab == null) { Debug.LogError("BubblePrefab no asignado", this); return; }

        // Solo el primero inicializa la lista compartida
        if (sharedAvailableWords == null || sharedAvailableWords.Count == 0)
        {
            sharedAvailableWords = new List<WordData2>(wordPool.GetWordsByCategory(currentCategory));
            Debug.Log($"🔁 Palabras cargadas ({sharedAvailableWords.Count}) para categoría {currentCategory}");
        }

        InvokeRepeating(nameof(SpawnBubble), 1f, fireDelay);
    }

    void SpawnBubble()
    {
        if (sharedAvailableWords == null || sharedAvailableWords.Count == 0)
        {
            Debug.Log("⚠️ Sin palabras disponibles.");
            return;
        }

        // Elegir y retirar una palabra para no repetir
        int randomIndex = Random.Range(0, sharedAvailableWords.Count);
        WordData2 selectedWord = sharedAvailableWords[randomIndex];
        sharedAvailableWords.RemoveAt(randomIndex);

        // Instanciar la burbuja
        GameObject bubble = Instantiate(bubblePrefab, transform.position, Quaternion.identity);

        var cd = bubble.GetComponent<CollisionDetection>();
        if (cd != null) cd.SetWord(selectedWord);
        else Debug.LogError("El prefab de burbuja no tiene CollisionDetection.", bubble);

        // Mostrar la palabra justo al instanciar
        TMP_Text label = bubble.GetComponentInChildren<TMP_Text>();
        if (label != null)
        {
            label.text = selectedWord.Text;
            // opcional: color por correcta/incorrecta
            // label.color = selectedWord.IsCorrect ? Color.green : Color.red;
        }

        Debug.Log($"💬 {name} lanzó '{selectedWord.Text}' ({selectedWord.Category})");

        // (Opcional) Reiniciar cuando se agoten
        if (sharedAvailableWords.Count == 0)
        {
            sharedAvailableWords = new List<WordData2>(wordPool.GetWordsByCategory(currentCategory));
            Debug.Log("♻️ Todas las palabras usadas. Reiniciando lista.");
        }
    }
}
