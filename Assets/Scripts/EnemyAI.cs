using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Animator animator;
    public RuntimeAnimatorController idle;
    public RuntimeAnimatorController walk;

    public float moveTime;
    public float stopTime;
    public int moveState;
    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        animator.runtimeAnimatorController = idle;

        StartCoroutine(directionChanger());
    }

    // Update is called once per frame
    void Update()
    {
        if (moveState == 1)
        {
            sprite.flipX = false;
            gameObject.transform.position += new Vector3((movementSpeed * Time.deltaTime), 0, 0);           
        } else if (moveState == 3)
        {
            sprite.flipX = true;
            gameObject.transform.position += new Vector3(-(movementSpeed * Time.deltaTime), 0, 0);           
        }
    }

    public IEnumerator directionChanger()
    {
        while (true)
        {
            moveState++;
            if (moveState == 1 || moveState == 3)
            {
                yield return new WaitForSeconds(moveTime);
            }            
            if (moveState > 3) moveState = 0;
            if (moveState == 2 || moveState == 0) { 
                yield return new WaitForSeconds(stopTime);
            }
        }
    }
}
