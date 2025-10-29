using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class LockLevelsImage : MonoBehaviour
{
    Timer timer;
    [SerializeField] private Image lockImage2;
    [SerializeField] private Image lockImage3;
    [SerializeField] private Image lockImage4;
    [SerializeField] private Image lockImage5;
    private void Awake()
    {
        lockImage2.gameObject.SetActive(true);
        lockImage3.gameObject.SetActive(true);
        lockImage4.gameObject.SetActive(true);
        lockImage5.gameObject.SetActive(true);
        timer = GetComponent<Timer>();
    }

    private void Update()
    {
        CheckImageLock();
    }

    private void CheckImageLock()
    {
        if (timer.level2 == true)
            lockImage2.gameObject.SetActive(false);
        if (timer.level3 == true)
            lockImage3.gameObject.SetActive(false);
        if (timer.level4 == true)
            lockImage4.gameObject.SetActive(false);
        if (lockImage5 == true)
            lockImage5.gameObject.SetActive(false);
    }

}
