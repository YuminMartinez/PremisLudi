using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Rigidbody2D fish;
    public float speed = 8f; // Velocidad del movimiento

    private void Awake()
    {
        fish = GetComponent<Rigidbody2D>();
        fish.transform.position = Vector3.zero;


    }

    void Update()
    {
        //  Si hay un toque en pantalla (móvil)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Solo queremos reaccionar cuando toca o arrastra el dedo
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(touch.position);
                worldPos.z = 0f;

                Vector2 direction = ((Vector2)worldPos - (Vector2)transform.position).normalized;
                transform.position = (Vector2)transform.position + direction * speed * Time.deltaTime;
            }
        }
        else // es qe es pc entonces
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = (mousePos - (Vector2)transform.position).normalized;
                transform.position = (Vector2)transform.position + direction * speed * Time.deltaTime;
            }
        }
    }
} 