using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectR.Core;

namespace ProjectR.Movment
{
    public class PlayerMovment : MonoBehaviour
    {
        bool MovmentDisabled=false;
        [Header("Core")]
        [SerializeField] float speed = 5f;
        [SerializeField] float jump = 8f;
        Animator animator;
        Rigidbody2D myRigidbody;
        Vector2 UpdatedVelocity;
        BoxCollider2D groundCheck;
        CapsuleCollider2D PlayerBody;
        float coyoteTime;
        bool CanJump;
        [SerializeField] float Jumpwait = .6f;
        [Header("GameObjects")]
        [SerializeField] Transform dustSpawner;
        [SerializeField] GameObject cloud,cloudLandingEffect;
        [Header("Audio")]
        [SerializeField] AudioClip DeathSound;
        bool spawn=true;
        bool HitGround=false;
        bool AudioOnce = true;
        
       

        void Start()
        {
            animator = GetComponent<Animator>();
            myRigidbody = GetComponent<Rigidbody2D>();
            groundCheck = GetComponent<BoxCollider2D>();
            PlayerBody = GetComponent<CapsuleCollider2D>();

        }


        void Update()
        {

            if (!HitGround && groundCheck.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                Instantiate(cloudLandingEffect, dustSpawner.position, dustSpawner.rotation);
                HitGround = true;
            }

            CheckForDeath();

            Rotation();
            if (Input.GetAxis("Horizontal") != 0)
            {
                animator.SetBool("Walked", true);
                if (spawn && groundCheck.IsTouchingLayers(LayerMask.GetMask("Ground")))
                {
                    StartCoroutine(DustSpawner());
                }

            }
            else
            {
                animator.SetBool("Walked", false);
            }
            CoyoteTime();


        }

        private void CheckForDeath()
        {
            if (PlayerBody.IsTouchingLayers(LayerMask.GetMask("Spikes"))|| PlayerBody.IsTouchingLayers(LayerMask.GetMask("Enemy")))
            {
                FindObjectOfType<SaveLevelPosition>().ResetPlayerPos();
                if (AudioOnce)
                {
                    AudioOnce = false;
                    AudioSource.PlayClipAtPoint(DeathSound, Camera.main.transform.position);
                    
                }

              
            }
            else
            {
                AudioOnce = true;
            }
        }

        private void Rotation()
        {

            if (MovmentDisabled) { return; }
            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
            }
          

           

        }

        private void FixedUpdate()
        {
           


            UpdatedVelocity.x = speed * Input.GetAxis("Horizontal");

            Jump();
            if (MovmentDisabled) { UpdatedVelocity = Vector2.zero; }
            myRigidbody.velocity = UpdatedVelocity;


        }

        private void Jump()
        {
            if (CanJump && Input.GetKey(KeyCode.Space))
            {
                UpdatedVelocity.y = jump;
                CanJump = false;
                HitGround = false;


            }
            else 
            {

                UpdatedVelocity.y = myRigidbody.velocity.y;
                
            }
        }


        void CoyoteTime()
        {
            if (groundCheck.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                coyoteTime = 0;
                CanJump = true;
                HitGround = true;
            }
            else
            {
                coyoteTime += Time.deltaTime;
                animator.SetTrigger("Jump");

            }


            if (coyoteTime >= Jumpwait)
            {
                CanJump = false;
            }


        }

        IEnumerator DustSpawner()
        {
            spawn = false;
            Instantiate(cloud, dustSpawner.position, dustSpawner.rotation);
            yield return new WaitForSeconds(.5f);
            spawn = true;
        }

        public void DisablePlayer(bool disable)
        {
            MovmentDisabled = disable;
        }



    }

}