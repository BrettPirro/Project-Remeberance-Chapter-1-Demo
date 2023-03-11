using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectR.Effect 
{
    public class EnemyKill : MonoBehaviour
    {
        [SerializeField]float EnemyLaunch = 15.5f;
       
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag=="Player") 
            {
                Rigidbody2D player = collision.GetComponent<Rigidbody2D>();
                player.velocity = new Vector2(player.velocity.x, EnemyLaunch);
                GetComponentInParent<Animator>().SetTrigger("Hit");
               
            }
            

        }


    }

}
