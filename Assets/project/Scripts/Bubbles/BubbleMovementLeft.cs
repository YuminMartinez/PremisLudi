using UnityEngine;
using UnityEngine.UIElements;

public class BubbleMovementLeft : MonoBehaviour
{
    private Vector3 startPos;
    private float horizontalSpeed;
    private float verticalAmplitude;
    private float verticalFrequency;

    void Start()
    {
        startPos = transform.position;
        horizontalSpeed = Random.Range(1.5f, 3f);
        verticalAmplitude = Random.Range(0.3f, 0.7f);
        verticalFrequency = Random.Range(1.5f, 3f);
    }

    void Update()
    {
        // Horizontal movement
        transform.position += Vector3.left * horizontalSpeed * Time.deltaTime;

        // Sinus vertical kinda oscillation
        transform.position = new Vector3(
            transform.position.x,
            startPos.y + Mathf.Sin(Time.time * verticalFrequency) * verticalAmplitude,
            transform.position.z
        );
    }
}
