using UnityEngine;

public class BoundCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bound"))
        {
            Destroy(gameObject);
        }
    }
}
