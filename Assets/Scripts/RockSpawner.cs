using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rock;
    public float spawnRate;
    public Transform pos;
    private Coroutine corr;
    private int rockRotationRandomizer;

    void Start()
    {
        pos = gameObject.transform;
        corr = StartCoroutine(SpawnRock());        
    }

    // Update is called once per frame
    public IEnumerator SpawnRock()
    {
        yield return new WaitForSeconds(spawnRate);
        rockRotationRandomizer = Random.Range(0, 360);
        Instantiate(rock, new Vector3(pos.position.x, pos.position.y, rockRotationRandomizer), Quaternion.identity);
        yield return SpawnRock();
    }

    public void StopSpawning()
    {
        StopCoroutine(corr);
    }
}
