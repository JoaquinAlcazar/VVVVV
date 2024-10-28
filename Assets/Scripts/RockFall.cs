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
        gameObject.transform.position = gameObject.transform.position + new Vector3(0, -10 * Time.deltaTime, 0);
        gameObject.transform.Rotate(0, 0, 1f);
    }

    public IEnumerator killMyself()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
