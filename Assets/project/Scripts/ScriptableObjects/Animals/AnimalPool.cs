using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimalPool", menuName = "Scriptable Objects/AnimalPool")]
public class AnimalPool : ScriptableObject
{
    [SerializeField] private List<palabras> palabrasPool;
    [SerializeField] private string[] palabras;
}
