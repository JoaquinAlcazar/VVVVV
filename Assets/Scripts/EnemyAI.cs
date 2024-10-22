using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float actionTime;
    public int moveState;
    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("directionChanger", 0f, actionTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveState == 1)
        {
            gameObject.transform.position += new Vector3((movementSpeed * 0.002f), 0, 0);
        } else if (moveState == 3)
        {
            gameObject.transform.position += new Vector3(-(movementSpeed * 0.002f), 0, 0);
        }
    }

    public IEnumerator directionChanger()
    {
        moveState++;
        if (moveState > 3) moveState = 0;
        yield return null;
    }
}
