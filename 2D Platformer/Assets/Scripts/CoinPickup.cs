using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    Animator myAnimator;
    Rigidbody2D myRigidBody;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (myRigidBody.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            myAnimator.SetBool("isPickup", true);
            StartCoroutine("DestroyCoin");
        }
        
    }

    IEnumerator DestroyCoin()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(this.gameObject);
    }
}
