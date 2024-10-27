using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Panel del men� de pausa
    public Button pauseButton; // Bot�n de pausa en la interfaz
    private bool isPaused = false;

    void Start()
    {
        Time.timeScale = 1f;
        // Asigna los listeners a los botones del men�
        pauseButton.onClick.AddListener(TogglePause);
        pauseMenuUI.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        pauseButton.interactable = true;
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true); // Activa el men� de pausa
        Time.timeScale = 0f; // Detiene el tiempo
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Oculta el men� de pausa
        pauseButton.gameObject.SetActive(true); // Muestra el bot�n de pausa
        Time.timeScale = 1f; // Restablece el tiempo
        isPaused = false;
    }

    public void QuitGame()
    {
        // Acci�n del bot�n de salida (aqu� cierra la aplicaci�n)
        Application.Quit();
        // Si est�s en el editor de Unity, puedes usar:
        // UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Nivel1");
    }
}
