using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI textoPuntos;

    [Header("Puntuación")]
    private int puntos = 0;

    void Start()
    {
        ActualizarUI();
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        ActualizarUI();
        Debug.Log($"+{cantidad} puntos! Total: {puntos}");
    }

    public void RestarPuntos(int cantidad)
    {
        puntos -= cantidad;
        if (puntos < 0) puntos = 0; // No permitir puntos negativos
        ActualizarUI();
        Debug.Log($"-{cantidad} puntos! Total: {puntos}");
    }

    void ActualizarUI()
    {
        if (textoPuntos != null)
        {
            textoPuntos.text = "Puntos: " + puntos;
        }
    }

    public int ObtenerPuntos()
    {
        return puntos;
    }
}