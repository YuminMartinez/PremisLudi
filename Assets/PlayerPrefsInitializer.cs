using UnityEngine;

public class PlayerPrefsInitializer : MonoBehaviour
{
    private void Awake()
    {
        // Verifica si es la primera vez que se inicia el juego
        if (PlayerPrefs.GetInt("HasInitialized", 0) == 0)
        {
            Debug.Log("🎮 Primera vez que se inicia el juego — reiniciando progreso.");

            // 🔹 Inicializa todos los niveles como no completados
            PlayerPrefs.SetInt("Level1Completed", 0);
            PlayerPrefs.SetInt("Level2Completed", 0);
            PlayerPrefs.SetInt("Level3Completed", 0);
            PlayerPrefs.SetInt("Level4Completed", 0);
            PlayerPrefs.SetInt("Level5Completed", 0);

            // 🔹 Marca que ya se hizo la inicialización
            PlayerPrefs.SetInt("HasInitialized", 1);
            PlayerPrefs.Save();
        }
    }
}
