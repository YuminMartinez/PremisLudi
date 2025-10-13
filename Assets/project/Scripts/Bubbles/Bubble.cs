using UnityEngine;

public class Bubble : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Detecta solo objetos con tag "Fish"
        if (other.CompareTag("Fish"))
        {
            Debug.Log("¡La burbuja tocó el pez!");
            Destroy(gameObject); // opcional: destruir la burbuja
        }
    }
}