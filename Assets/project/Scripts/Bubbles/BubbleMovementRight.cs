using UnityEngine;

public class BubbleMovementRight : MonoBehaviour
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
        // Movimiento horizontal constante
        transform.position += Vector3.right * horizontalSpeed * Time.deltaTime;

        // Oscilación vertical tipo zigzag
        transform.position = new Vector3(
            transform.position.x,
            startPos.x + Mathf.Sin(Time.time * verticalFrequency) * verticalAmplitude,
            transform.position.z
        );
    }
}
