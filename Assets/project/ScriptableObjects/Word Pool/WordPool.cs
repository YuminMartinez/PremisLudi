using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "WordPool", menuName = "Scriptable Objects/Word Pool")]
public class WordPool : ScriptableObject
{
    [SerializeField] private List<WordData2> allWords;

    public List<WordData2> GetWordsByCategory(WordCategory category)
    {
        return allWords.Where(w => w.Category == category).ToList();
    }
}