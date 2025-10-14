using UnityEngine;

[CreateAssetMenu(fileName = "KitchenWords", menuName = "Scriptable Objects/KitchenWords")]
public class KitchenWords : ScriptableObject
{
    [SerializeField] private string text;
    [SerializeField] private bool isCorrect;
}
