using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectR.Core
{
    public class SaveLevelPosition : MonoBehaviour
    {
        Vector2 playerLastPos;
        GameObject player;

        void Start()
        {
            player = GameObject.FindWithTag("Player").gameObject;
            playerLastPos = player.transform.position;
        }


        public void UpdatePlayerLastPos(Vector2 UpdatedPosition)
        {

            playerLastPos = UpdatedPosition;
        }


        public void ResetPlayerPos()
        {
            player.transform.position = playerLastPos;
        }


    }
}
