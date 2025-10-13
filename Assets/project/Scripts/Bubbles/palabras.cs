using UnityEngine;

[CreateAssetMenu(fileName = "palabras", menuName = "Scriptable Objects/palabras")] //para crear un scriptableobject

public class palabras : ScriptableObject
{
    [SerializeField] private string text;
    [SerializeField] private bool isCorrect;

}
