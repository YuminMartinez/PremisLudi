using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Rigidbody2D fish;
    public float speed = 8f; // Velocidad del movimiento
    private bool isFacingRight = true;

    private void Awake()
    {
        fish = GetComponent<Rigidbody2D>();
        fish.transform.position = Vector3.zero;
    }

    void Update()
    {
        Vector2 targetPos = Vector2.zero;
        bool hasInput = false;

        // 🟢 Movimiento con toque (móvil)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(touch.position);
                worldPos.z = 0f;
                targetPos = worldPos;
                hasInput = true;
            }
        }
        // 🖱️ Movimiento con ratón (PC)
        else if (Input.GetMouseButton(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;
            targetPos = mouseWorldPos;
            hasInput = true;
        }

        // 🔹 Movimiento + flip
        if (hasInput)
        {
            Vector2 direction = (targetPos - (Vector2)transform.position).normalized;
            transform.position = (Vector2)transform.position + direction * speed * Time.deltaTime;

            // Si el pez se mueve hacia la izquierda y está mirando a la derecha → girar
            if (direction.x < 0 && isFacingRight)
                Flip();
            // Si se mueve a la derecha y está mirando a la izquierda → girar
            else if (direction.x > 0 && !isFacingRight)
                Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
