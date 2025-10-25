using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Rigidbody2D fish;
    public float speed = 8f;
    private bool isFacingRight = true;

    private Vector2 targetPos;
    private bool hasTarget = false;
    public float stopDistance = 0.1f; // distancia mínima para "llegar"

    private void Awake()
    {
        fish = GetComponent<Rigidbody2D>();
        fish.transform.position = Vector3.zero;
    }

    void Update()
    {
        bool hasInput = false;

        // --- Movimiento con toque (móvil) ---
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(touch.position);
                worldPos.z = 0f;
                targetPos = worldPos;
                hasTarget = true;
                hasInput = true;
            }
        }
        // --- Movimiento con ratón (PC) ---
        else if (Input.GetMouseButton(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;
            targetPos = mouseWorldPos;
            hasTarget = true;
            hasInput = true;
        }

        if (hasTarget)
        {
            Vector2 currentPos = transform.position;
            Vector2 direction = (targetPos - currentPos);

            // si ya llegó (o muy cerca)
            if (direction.magnitude < stopDistance)
            {
                hasTarget = false;
                return; // se queda quieto mirando al último lado
            }

            direction.Normalize();
            transform.position = currentPos + direction * speed * Time.deltaTime;

            // Flip solo cuando se mueve en dirección contraria a su mirada actual
            if (direction.x < 0 && isFacingRight)
                Flip();
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
