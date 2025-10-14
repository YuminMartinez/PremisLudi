using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class ThrowBubbles : MonoBehaviour
{


    [Header("Configuración general")]
    public GameObject bubblePrefab;
    public WordPool wordPool;
    public WordCategory currentCategory;
    public float fireDelay = 2f;

    // 🔸 Lista compartida por TODOS los FirePoints
    public static List<WordData2> sharedAvailableWords;

    void Start()
    {
        // Solo el primer FirePoint inicializa la lista compartida
        if (sharedAvailableWords == null || sharedAvailableWords.Count == 0)
        {
            sharedAvailableWords = new List<WordData2>(wordPool.GetWordsByCategory(currentCategory));
            Debug.Log($"🔁 Palabras cargadas ({sharedAvailableWords.Count}) para categoría {currentCategory}");
        }

        // Lanza burbujas periódicamente (o puedes hacerlo por evento)
        InvokeRepeating(nameof(SpawnBubble), 1f, fireDelay);
    }

    void SpawnBubble()
    {
        if (bubblePrefab == null || sharedAvailableWords == null || sharedAvailableWords.Count == 0)
        {
            Debug.Log("⚠️ Sin palabras disponibles o prefab vacío.");
            return;
        }

        // Elegir una palabra al azar de la lista compartida
        int randomIndex = Random.Range(0, sharedAvailableWords.Count);
        WordData2 selectedWord = sharedAvailableWords[randomIndex];

        // Eliminarla para que no se repita
        sharedAvailableWords.RemoveAt(randomIndex);

        // Instanciar la burbuja en este punto
        GameObject bubble = Instantiate(bubblePrefab, transform.position, Quaternion.identity);
        bubble.GetComponent<CollisionDetection>().SetWord(selectedWord);

        Debug.Log($"💬 FirePoint '{name}' lanzó '{selectedWord.Text}' ({selectedWord.Category})");

        // Si se acaban las palabras, opcionalmente reiniciamos
        if (sharedAvailableWords.Count == 0)
        {
            sharedAvailableWords = new List<WordData2>(wordPool.GetWordsByCategory(currentCategory));
            Debug.Log("♻️ Todas las palabras usadas. Reiniciando lista.");
        }
    }






    /*public Transform firePoint;     // Punto desde donde salen las burbujas
    public GameObject bubblePrefab;  // Prefab de la burbuja

    void Update()
    {
        // Si presionas Space, dispara una burbuja
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instanciar la burbuja en la posición y rotación del firePoint
        Instantiate(bubblePrefab, firePoint.position, firePoint.rotation);
    }*/
}
