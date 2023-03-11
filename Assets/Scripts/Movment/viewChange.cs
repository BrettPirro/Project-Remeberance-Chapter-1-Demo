using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectR.Core;


namespace ProjectR.Movment
{
    public class viewChange : MonoBehaviour
    {
        [Header("Core")]
        [SerializeField] GameObject buttonRight, buttonLeft;
        [SerializeField] Animator Movement;
        FlashLight flash;
        bool Disable = false;

        private void Start()
        {
            flash = FindObjectOfType<FlashLight>();
        }



        public void TurnLeft()
        {
            if (Disable) { return; }
            StartCoroutine(TurnToTheLeft());
        }

        public void TurnRight()
        {
            if (Disable) { return; }
            StartCoroutine(TurnToTheRight());
        }


        IEnumerator TurnToTheLeft()
        {
            Movement.SetBool("Turn", false);
            buttonLeft.SetActive(false);
            FindObjectOfType<PlayerMovment>().DisablePlayer(false);
            yield return new WaitForSeconds(0.6f);
            buttonRight.SetActive(true);
            flash.FlashDisableToggle(true, false);
        }

        IEnumerator TurnToTheRight()
        {
            Movement.SetBool("Turn", true);
            buttonRight.SetActive(false);
            FindObjectOfType<PlayerMovment>().DisablePlayer(true);
            yield return new WaitForSeconds(0.6f);
            buttonLeft.SetActive(true);
            flash.FlashDisableToggle(false, false);
        }


      


    }
}
