using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using static UnityEditor.PlayerSettings;

public class PlayerSceneLoader : MonoBehaviour
{
    public string currentSceneName;
    public GameObject player;
    public SpriteRenderer spriteRenderer;
    public Transform currentBackPoint;
    public bool wantsToBack;
    private void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.sceneLoaded += OnSceneLoaded;
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
            wantsToBack = true;
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
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (wantsToBack)
        {
            player = GameObject.FindWithTag("Player");
            currentBackPoint = GameObject.FindWithTag("BackPoint").transform;
            player.transform.position = currentBackPoint.position;
            spriteRenderer = player.GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = true;
            wantsToBack = false;
        }
    }

}
