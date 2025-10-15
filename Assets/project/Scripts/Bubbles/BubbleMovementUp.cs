using UnityEngine;

public class BubbleMovementUp : MonoBehaviour
{
    private Vector3 startPos;
    private float verticalSpeed;
    private float horizontalAmplitude;
    private float horizontalFrequency;

    void Start()
    {
        startPos = transform.position;
        verticalSpeed = Random.Range(1.5f, 3f);
        horizontalAmplitude = Random.Range(0.3f, 0.7f);
        horizontalFrequency = Random.Range(1.5f, 3f);
    }

    void Update()
    {
        // Movimiento vertical constante
        transform.position += Vector3.up * verticalSpeed * Time.deltaTime;

        // Oscilación horizontal tipo zigzag
        transform.position = new Vector3(
            startPos.x + Mathf.Sin(Time.time * horizontalFrequency) * horizontalAmplitude,
            transform.position.y,
            transform.position.z
        );
    }
}
