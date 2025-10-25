using UnityEngine;

public class AppearAndDisappear : MonoBehaviour
{
    public float duration = 4f; // dura 4 segundos visible

    void Start()
    {
        // Llamamos a la función "Hide" después de 4 segundos
        Invoke("Hide", duration);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
}
