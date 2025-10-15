using UnityEngine;

public enum WordCategory
{
    Animales,
    Cuina,
    Casa,
    ColorsRoba,
    Verbs
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