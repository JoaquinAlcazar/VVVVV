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

    public AudioClip caminarSound;
    public AudioClip gravitySound;
    public AudioClip deathSound;
    private AudioSource audioSourceWalk;
    private AudioSource audioSourceGravity;
    private AudioSource audioSourceDeath;

    private GameObject copy;
    private bool isWalking = false;

    void Awake()
    {
        audioSourceWalk = gameObject.AddComponent<AudioSource>();
        audioSourceWalk.clip = caminarSound;
        audioSourceWalk.loop = true;
        audioSourceWalk.pitch = 0.3f;
        audioSourceWalk.volume = 1f;

        audioSourceGravity = gameObject.AddComponent<AudioSource>();
        audioSourceGravity.clip = gravitySound;
        audioSourceGravity.loop = false;
        audioSourceGravity.volume = 1f;

        audioSourceDeath = gameObject.AddComponent<AudioSource>();
        audioSourceDeath.clip = deathSound;
        audioSourceDeath.loop = false;
        audioSourceDeath.volume = 0.5f;
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
        bool moving = false;

        //Mueve al personaje cuando se pulsa D o A en la direccíón correspondiente
        if (Input.GetKey(KeyCode.D))
        {               
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
            sprite.flipX = false;
            moving = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + new Vector3(-(speed * Time.deltaTime), 0, 0);
            sprite.flipX = true;
            moving = true;
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
                audioSourceGravity.Play();
            }
        }

        if (moving && !isWalking)
        {
            PlayWalkingSound();
        }
        else if (!moving && isWalking)
        {
            StopWalkingSound();
        }



    }
    private void PlayWalkingSound()
    {
        if (!audioSourceWalk.isPlaying)
        {
            audioSourceWalk.Play();
            isWalking = true;
        }
    }

    private void StopWalkingSound()
    {
        audioSourceWalk.Stop();
        isWalking = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            Destroy(audioSourceWalk);
            Destroy(audioSourceGravity);
            StartCoroutine(PlayDeathSoundAndRespawn());
        }
    }

    private IEnumerator PlayDeathSoundAndRespawn()
    { 
        audioSourceDeath.Play();
        yield return new WaitForSeconds(audioSourceDeath.clip.length);
        Destroy(audioSourceDeath);

        // Resetea la gravedad y la orientación antes de hacer respawn
        sprite.flipY = false;
        if (rb.gravityScale < 0) rb.gravityScale *= -1;

        // Instancia un nuevo personaje en el punto de spawn y destruye el actual
        Instantiate(myPrefab, GameObject.FindGameObjectWithTag("SpawnPoint").transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
