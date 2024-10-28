using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNonDestroyer : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.1f;
    }
}
