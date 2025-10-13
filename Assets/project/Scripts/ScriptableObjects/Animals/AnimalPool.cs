using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimalPool", menuName = "Scriptable Objects/AnimalPool")]
public class AnimalPool : ScriptableObject
{
    [SerializeField] private List<Animal> palabrasPool;
}
