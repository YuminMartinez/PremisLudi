using UnityEngine;
using TMPro;

public class FloatingDelta : MonoBehaviour
{
    public float upSpeed = 60f;
    public float life = 0.8f;
    private TextMeshProUGUI tmp;

    void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    public void Show(int delta)
    {
        if (tmp == null) return;

        tmp.text = $"{(delta >= 0 ? "+" : "")}{delta}";
        tmp.color = delta >= 0 ? Color.green : Color.red;

        // Destruir después de cierto tiempo
        Destroy(gameObject, life);
    }

    void Update()
    {
        // Mover hacia arriba un poco cada frame
        transform.Translate(Vector3.up * upSpeed * Time.deltaTime);

        // Desvanecer poco a poco
        if (tmp != null)
        {
            Color c = tmp.color;
            c.a -= Time.deltaTime / life;
            tmp.color = c;
        }
    }
}
