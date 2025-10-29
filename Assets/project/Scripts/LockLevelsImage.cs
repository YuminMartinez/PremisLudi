using UnityEngine;
using UnityEngine.UI;

public class LockLevelsImage : MonoBehaviour
{
    [SerializeField] private Image lockImage2;
    [SerializeField] private Image lockImage3;
    [SerializeField] private Image lockImage4;
    [SerializeField] private Image lockImage5;

    private void Awake()
    {
        // Siempre activar todas las imágenes al empezar
        lockImage2.gameObject.SetActive(true);
        lockImage3.gameObject.SetActive(true);
        lockImage4.gameObject.SetActive(true);
        lockImage5.gameObject.SetActive(true);
    }

    private void Start()
    {
       
        CheckImageLock();
    }

    private void CheckImageLock()
    {
        // Oculta el candado si el nivel anterior fue completado
        if (PlayerPrefs.GetInt("Level1Completed", 0) == 1) lockImage2.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("Level2Completed", 0) == 1) lockImage3.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("Level3Completed", 0) == 1) lockImage4.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("Level4Completed", 0) == 1) lockImage5.gameObject.SetActive(false);
    }
}
