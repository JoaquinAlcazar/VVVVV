using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class PlayerSceneLoader : MonoBehaviour
{
    public string currentSceneName;
    public GameObject player;
    public GameObject currentBackPoint;
    private void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    //El método mirará la escena en la que se encuentra, y en base a eso, cargará la siguiente escena
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "LevelEnd")
        {
            if (currentSceneName == "Nivel1")
            {
                SceneManager.LoadScene("Nivel2");
            }
            if (currentSceneName == "Nivel2")
            {
                SceneManager.LoadScene("Nivel3");
            }
            if (currentSceneName == "Nivel3")
            {
                SceneManager.LoadScene("Nivel4");
            }
        }

        if(collision.gameObject.name == "LevelBack")
        {
            if (currentSceneName == "Nivel2")
            {
                SceneManager.LoadScene("Nivel1");
            }
            if (currentSceneName == "Nivel3")
            {
                SceneManager.LoadScene("Nivel2");
            }
            if (currentSceneName == "Nivel4")
            {
                SceneManager.LoadScene("Nivel3");
            }
        }


    }
}
