using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float moveSpeed;
    public bool moveRight;

    public bool touchingWall;
    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;

    void FixedUpdate()
    {
         touchingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        if (touchingWall)
            moveRight = !moveRight;

        if (moveRight)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
