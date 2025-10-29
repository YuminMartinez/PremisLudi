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
        // Siempre activar todas las imágenes
        lockImage2.gameObject.SetActive(true);
        lockImage3.gameObject.SetActive(true);
        lockImage4.gameObject.SetActive(true);
        lockImage5.gameObject.SetActive(true);
    }

    private void Start()
    {
        RefreshLocks();
    }

    // Llama a esto cuando vuelvas del nivel o tras guardar PlayerPrefs
    public void RefreshLocks()
    {
        int l1 = PlayerPrefs.GetInt("Level1Completed", 0);
        int l2 = PlayerPrefs.GetInt("Level2Completed", 0);
        int l3 = PlayerPrefs.GetInt("Level3Completed", 0);
        int l4 = PlayerPrefs.GetInt("Level4Completed", 0);

        Debug.Log($"[Locks] L1={l1} L2={l2} L3={l3} L4={l4}");

        // Muestra el candado si NO has completado el nivel previo
        lockImage2.gameObject.SetActive(l1 == 0);
        lockImage3.gameObject.SetActive(l2 == 0);
        lockImage4.gameObject.SetActive(l3 == 0);
        lockImage5.gameObject.SetActive(l4 == 0);

        Debug.Log($"[Locks] lock2={(lockImage2.gameObject.activeSelf ? "ON" : "OFF")}, " +
                  $"lock3={(lockImage3.gameObject.activeSelf ? "ON" : "OFF")}, " +
                  $"lock4={(lockImage4.gameObject.activeSelf ? "ON" : "OFF")}, " +
                  $"lock5={(lockImage5.gameObject.activeSelf ? "ON" : "OFF")}");
    }
}
