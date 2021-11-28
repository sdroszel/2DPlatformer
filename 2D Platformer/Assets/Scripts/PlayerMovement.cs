using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 3f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float jumpDelay = 1f;
    [SerializeField] float rollDelay = 1f;

    int remainingRolls = 2;
    Vector2 moveInput;
    Rigidbody2D myRigidbody2D;
    Animator myAnimator;
    CapsuleCollider2D collider2D;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        collider2D = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        Run();
        Roll();
        FlipSprite();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    private void OnJump(InputValue value)
    {
        if (!collider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        
        if (value.isPressed)
        {
            myRigidbody2D.velocity += new Vector2(0f, jumpSpeed);
            myAnimator.SetBool("isJumping", true);
            StartCoroutine("JumpDelay");
        }
    }

    private void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * movementSpeed, myRigidbody2D.velocity.y);
        myRigidbody2D.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
        
    }

    private void Roll()
    {
        if (Keyboard.current.shiftKey.wasPressedThisFrame)
        {
            myAnimator.SetBool("isRolling", true);

            StartCoroutine("RollDelay");
        }
        
    }

    IEnumerator JumpDelay()
    {
        yield return new WaitForSeconds(jumpDelay);

        myAnimator.SetBool("isJumping", false);
    }

    IEnumerator RollDelay()
    {
        yield return new WaitForSeconds(rollDelay);

        myAnimator.SetBool("isRolling", false);
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody2D.velocity.x), 1f);
        }

    }
}
