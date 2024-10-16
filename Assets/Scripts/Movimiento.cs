using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    public Animator animator;
    public RuntimeAnimatorController idle;
    public RuntimeAnimatorController walk;
    public GameObject myPrefab;


    private GameObject copy;

    void Awake()
    {
        
    }

    void Start()
    {
        

        rb = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        animator.runtimeAnimatorController = idle;

        
    }

    void Update()
    {
        

        //Mueve al personaje cuando se pulsa D o A en la direccíón correspondiente
        if (Input.GetKey(KeyCode.D))
        {               
            transform.position = transform.position + new Vector3(speed * 0.002f, 0, 0);
            sprite.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + new Vector3(-(speed * 0.002f), 0, 0);
            sprite.flipX = true;
        }

        //Cambia las animaciones cuando se pulsa o deja de pulsar A o D (va un poco clunky al cambiar de direccion rapidamente)
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) animator.runtimeAnimatorController = idle;
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)) animator.runtimeAnimatorController = walk;

        
        // Cambia la gravedad cuando se pulsa el botón W, y solo permite cambiarla cuando el personaje está tocando el suelo (velocidad y = 0)
        if (rb.velocity.y == 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.gravityScale *= -1;

                if (sprite.flipY == false) sprite.flipY = true;
                else if (sprite.flipY == true) sprite.flipY = false;
            }
        }
        

        
    }

    //Al colisionar con un objeto del tag "Hazard", la gravedad se vuelve normal para que el personaje spawnee con gravedad normal.
    //Se instancia un nuevo personaje, y justo después se elimina el original
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard") {
            sprite.flipY = false;
            if (rb.gravityScale < 0) rb.gravityScale *= -1;
            Instantiate(myPrefab, GameObject.FindGameObjectWithTag("SpawnPoint").transform.position, Quaternion.identity);            
            Destroy(gameObject);
        }
    }
}
