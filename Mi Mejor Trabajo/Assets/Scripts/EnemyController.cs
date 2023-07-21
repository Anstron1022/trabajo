using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

    public Transform leftPoint, rightPoint;

    private bool movingRight;

    private Rigidbody2D theRB;
    public SpriteRenderer theRS;
    private Animator anim;

    public float moveTime, waiTime;
    private float moveCount, waiCount;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;

        moveCount = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCount > 0)
        {
            moveCount -= Time.deltaTime;

            if (movingRight)
            {
                theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);

                theRS.flipX = true;

                if (transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);

                theRS.flipX = false;

                if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }
            }

            if(moveCount <= 0)
            {
                waiCount = Random.Range(waiTime * .75f, waiTime * 1.25f);
            }

            anim.SetBool("isMoving", true);
        }else if(waiCount > 0)
        {
            waiCount -= Time.deltaTime;
            theRB.velocity = new Vector2(0f, theRB.velocity.y);


            if (waiCount <= 0)
            {
                moveCount = Random.Range(moveTime * .75f, waiTime * 1.25f); ;
            }
            anim.SetBool("isMoving", false);
        }

    }
}
