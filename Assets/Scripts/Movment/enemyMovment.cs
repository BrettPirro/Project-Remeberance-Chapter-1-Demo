using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectR.Movment 
{
    public class enemyMovment : MonoBehaviour
    {

        Rigidbody2D Myrigidbody2D;
        BoxCollider2D groundCheck;
        Vector2 velocityUpdate;
        [SerializeField]float enemySpeed = 3f;
        [SerializeField]GameObject Particles;

        
       
        void Start()
        {
            Myrigidbody2D = GetComponent<Rigidbody2D>();
            groundCheck = GetComponent<BoxCollider2D>();
           
        }

      
        void Update()
        {

            if (!groundCheck.IsTouchingLayers(LayerMask.GetMask("Ground"))) 
            {
                transform.localScale=new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                enemySpeed = -enemySpeed;
            }



            velocityUpdate = new Vector2(enemySpeed, Myrigidbody2D.velocity.y);




        }

        private void FixedUpdate()
        {
            Myrigidbody2D.velocity = velocityUpdate;
        }


        public void Death() 
        {
            Instantiate(Particles, transform.position, transform.rotation);
            Destroy(gameObject,0.1f);
           
            
        }



    }
}
