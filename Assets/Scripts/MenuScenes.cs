using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class MenuScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PlayButton")
        {
            SceneManager.LoadScene("Nivel1");
        }
        if (collision.gameObject.name == "ExitButton")
        {
            Application.Quit();
        }
    }
}
