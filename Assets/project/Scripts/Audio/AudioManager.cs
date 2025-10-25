using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioClip correctClip;
    [SerializeField] private AudioClip incorrectClip;

    private AudioSource source;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        source = GetComponent<AudioSource>();
    }

    public void PlayCorrectClip()
    {
        source.PlayOneShot(correctClip);
    }

    public void PlayIncorrectClip()
    {
        source.PlayOneShot(incorrectClip);
    }
}
