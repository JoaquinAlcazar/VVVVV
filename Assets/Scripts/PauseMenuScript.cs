using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Panel del menú de pausa
    public Button pauseButton; // Botón de pausa en la interfaz
    private bool isPaused = false;

    void Start()
    {
        Time.timeScale = 1f;
        // Asigna los listeners a los botones del menú
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
        pauseMenuUI.SetActive(true); // Activa el menú de pausa
        Time.timeScale = 0f; // Detiene el tiempo
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Oculta el menú de pausa
        pauseButton.gameObject.SetActive(true); // Muestra el botón de pausa
        Time.timeScale = 1f; // Restablece el tiempo
        isPaused = false;
    }

    public void QuitGame()
    {
        // Acción del botón de salida (aquí cierra la aplicación)
        Application.Quit();
        // Si estás en el editor de Unity, puedes usar:
        // UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Nivel1");
    }
}
