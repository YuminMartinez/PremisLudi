using UnityEngine;

[CreateAssetMenu(fileName = "Animal", menuName = "Scriptable Objects/Animal")]
public class Animal : ScriptableObject
{
    [SerializeField] private string text;
    [SerializeField] private bool isCorrect;

    //getters modernos del c-sharp

    public string Text => text;
    public bool IsCorrect => isCorrect;
}
