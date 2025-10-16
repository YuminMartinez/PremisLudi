using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Rigidbody2D fish;
    public float speed = 8f; // velocidad de movimiento

    private void Awake()
    {
        fish = GetComponent<Rigidbody2D>();
        fish.transform.position = Vector3.zero;
    }

    void Update()
    {
        // 1. Obtener posici�n del rat�n en el mundo
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 2. Calcular la direcci�n desde el objeto hacia el rat�n
        Vector2 direction = (mousePos - (Vector2)transform.position).normalized;

        // 3. Mover el objeto en esa direcci�n poco a poco
        transform.position = (Vector2)transform.position + direction * speed * Time.deltaTime;
    }
}