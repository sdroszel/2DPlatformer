using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidBody;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        myRigidBody.velocity = new Vector2(moveSpeed, UnityEngine.Random.Range(-2f, 2f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (myRigidBody.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            moveSpeed = -moveSpeed;
            FlipEnemyFacing();
        }
        
    }

    private void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
    }
}
