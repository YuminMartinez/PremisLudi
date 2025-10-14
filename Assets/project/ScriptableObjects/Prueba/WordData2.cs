using UnityEngine;

public enum WordCategory
{
    Animales,
    Cocina,
    Casa,
    colorsRoba,
    Escuela
}

[CreateAssetMenu(fileName = "WordData2", menuName = "Scriptable Objects/Word Data 2")]
public class WordData2 : ScriptableObject
{
    [SerializeField] private string text;
    [SerializeField] private bool isCorrect;
    [SerializeField] private WordCategory category;

    public string Text => text;
    public bool IsCorrect => isCorrect;
    public WordCategory Category => category;
}