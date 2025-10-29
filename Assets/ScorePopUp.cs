using System.Collections;
using TMPro;
using UnityEngine;

public class ScorePopUp : MonoBehaviour
{
    public TextMeshProUGUI points;
    public float duration = 1f;

    public void ShowPoints(string message)
    {
        StartCoroutine(DurationMessage(message));
    }

    private IEnumerator DurationMessage(string message)
    {
        points.text = message;
        points.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        points.gameObject.SetActive(false);
    }
}
