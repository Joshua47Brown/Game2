﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{


    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public float speed;
    public Vector3 offset;
    Vector3 targetPos;
    Player player;



    void Start()
    {
        player = FindObjectOfType<Player>();
        targetPos = transform.position;
    }


    void FixedUpdate()
    {
        if (target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;
            Vector3 targetDirection = (target.transform.position - posNoZ);
            interpVelocity = targetDirection.magnitude * speed;
            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
        }
    }
}