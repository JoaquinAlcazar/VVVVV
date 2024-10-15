using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class PlayerSceneLoader : MonoBehaviour
{
    public string currentSceneName;
    private void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    //El m�todo mirar� la escena en la que se encuentra, y en base a eso, cargar� la siguiente escena
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "LevelEnd")
        {
            if (currentSceneName == "Nivel1")
            {
                SceneManager.LoadScene("Nivel2");
            }
        }
    }
}
