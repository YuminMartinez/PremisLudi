using UnityEngine;

public class ThrowBubbles : MonoBehaviour
{
    public Transform firePoint;     // Punto desde donde salen las burbujas
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
    }
}
