using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBox : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Rigidbody2D PlayerRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
            Debug.Log("Hit");
            animator.SetTrigger("Hit");
            PlayerRigidBody.velocity=new Vector2(PlayerRigidBody.velocity.x, 15.5f);

        }
    }
}
