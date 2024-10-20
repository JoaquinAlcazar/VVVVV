using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(killMyself());
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = gameObject.transform.position + new Vector3(0, -0.01f, 0);
        gameObject.transform.Rotate(0, 0, 0.2f);
    }

    public IEnumerator killMyself()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
