using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectR.Core
{
    public class CheckpointDetection : MonoBehaviour
    {
        public bool Active;
        [SerializeField]Sprite ActiveS, NonActiveS;
        SpriteRenderer spriteRenderer;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }



        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                FindObjectOfType<SaveLevelPosition>().UpdatePlayerLastPos(transform.position);
                foreach(CheckpointDetection checkpoint in GameObject.FindObjectsOfType<CheckpointDetection>())
                {
                    checkpoint.Active = false;
                }

                Active = true;

            }

            

            

        }

        private void Update()
        {
            if (Active)
            {
                spriteRenderer.sprite = ActiveS;
            }
            else
            {
                spriteRenderer.sprite = NonActiveS;
            }
        }




    }

}
