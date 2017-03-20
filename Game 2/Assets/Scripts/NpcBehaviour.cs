using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcBehaviour : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D myRigidbody;

    public bool isWalking;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int walkDirection;

    public Transform wallDetector;
    public Transform groundDetector;
    public Transform cameraTarget;
    public Transform playerCamTarget;
    bool touchingWall;
    public LayerMask wallMask;
    public float radius;
    bool touchingGround;
    Player player;


    public bool canMove;
    private DialogueManager theDM;
    CameraController camCtrl;



    void Start()
    {
        player = FindObjectOfType<Player>();
        theDM = FindObjectOfType<DialogueManager>();
        canMove = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        camCtrl = FindObjectOfType<CameraController>();
        waitCounter = waitTime;
        walkCounter = walkTime;
        ChooseDirection();
    }


    void Update()
    {
        if (!theDM.dialogueActive)
        {
            camCtrl.target = playerCamTarget.gameObject;
            canMove = true;
        }

        if (!canMove)
        {
            camCtrl.target = cameraTarget.gameObject;
            myRigidbody.velocity = Vector2.zero;
            return;
        }

        touchingWall = Physics2D.OverlapCircle(wallDetector.position, radius, wallMask);
        touchingGround = Physics2D.OverlapCircle(groundDetector.position, radius, wallMask);
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;

            switch (walkDirection)
            {
                case 0:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                    transform.localScale = new Vector3(1, 1, 1);
                    break;

                case 1:
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                    transform.localScale = new Vector3(-1, 1, 1);
                    break;
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;

            myRigidbody.velocity = Vector2.zero;

            if (waitCounter < 0)
            {
                ChooseDirection();
            }
            if (!touchingGround)
            {
                ChooseDirection();
                //isWalking = false;
                Debug.Log("!touchingGround");
            }

        }

    }


    public void ChooseDirection()
    {
        if (!touchingGround  || touchingWall)
        {
            if (walkDirection == 0)
            {
                walkDirection = 1;
            }
            else if (walkDirection == 1)
            {
                walkDirection = 0;
            }
        }
        else
        {
            Debug.Log("else!");
            walkDirection = Random.Range(0, 2);
        }
        isWalking = true;
        walkCounter = walkTime;
    }
}
