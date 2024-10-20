using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rock;
    private float spawnRate = 4;
    public Transform pos;
    private Coroutine corr;

    void Start()
    {
        pos = gameObject.transform;
        corr = StartCoroutine(SpawnRock());
    }

    // Update is called once per frame
    public IEnumerator SpawnRock()
    {
        yield return new WaitForSeconds(spawnRate);
        Instantiate(rock, pos.position, Quaternion.identity);
        yield return SpawnRock();
    }

    public void StopSpawning()
    {
        StopCoroutine(corr);
    }
}
