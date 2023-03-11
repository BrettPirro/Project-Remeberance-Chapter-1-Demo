using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectR.Core;
using UnityEngine.UI;
using ProjectR.SceneManagment;
using UnityEngine.SceneManagement;

namespace ProjectR.AI 
{
    public class AiPosManager : MonoBehaviour
    {
        [Header("Core")]
        [SerializeField] bool Disable=false;
        [SerializeField] float WaitTime = 1.5f;
        [Range(0, 20)] [SerializeField] int aggressivnessVal;
        int position = 0;
        bool NumGenDone = true;
        bool Dead = false;
        [SerializeField] int EndPos = 5;
        [Header("Main Animator For Pos")]
        [SerializeField]Animator PosAnimator;

        
        bool audioPlayed=false;
        [Header("Audio")]
        [SerializeField] AudioClip Sting, Steps;
        FlashLight flash;
        bool SavedLastVal;
        [Header("JumpScareAnimator")]
        [SerializeField] GameObject Jumpscare;
        [SerializeField] float Pause = 0.7f;
        [SerializeField] AudioClip JumpScareNoise;
        bool movedAlready=false;

        public float volume = 1f;

        private void Start()
        {
            flash = FindObjectOfType<FlashLight>();
          
        }



        void Update()
        {
            if (Disable || Dead) { return; }
            PosAnimator.SetFloat("Pos", position);

            if (NumGenDone && !Dead)
            {
                StartCoroutine(GenerateVal());
            }

            StingPlayer();
           
        }

        private void StingPlayer()
        {
            if (flash.IsTheFlashLightOn() && !audioPlayed && position == EndPos - 1 )
            {
                AudioSource.PlayClipAtPoint(Sting, Camera.main.transform.position,volume);
                audioPlayed = true;
            }
        }

        IEnumerator GenerateVal()
        {
          

            SavedLastVal = flash.IsTheFlashLightOn();

            if (flash.IsTheFlashLightOn() && position == EndPos - 1)
            {
               
                ResetPos();
                Debug.Log("Sent Back");
                audioPlayed = false;
                flash.FlashToggle(false);
            }
            NumGenDone = false;
            int randomNum = Random.Range(1, 20);
            if (ZeroCheck() && randomNum <= aggressivnessVal)
            {
                if (movedAlready == true) { movedAlready = false; yield return new WaitForSeconds(WaitTime); NumGenDone = true; Debug.Log("NO NO NO. not in a row buddy"); yield break; }
                flash.FlashDisableToggle(true, false);
                position++;

                if (randomNum == Random.Range(1, 30) && position>= EndPos - 4)
                {
                    position++;
                    Debug.Log("MovedFowardTwice");

                }
                AudioSource.PlayClipAtPoint(Steps, Camera.main.transform.position,volume);
                yield return new WaitForSeconds(.2f);
                Debug.Log(SavedLastVal);
                flash.FlashDisableToggle(false, SavedLastVal);
                Debug.Log("MovedFoward");
                movedAlready = true;
            }

            yield return new WaitForSeconds(WaitTime);
            
            NumGenDone = true;
           
            if (position >=EndPos&&!Dead)
            {
                StartCoroutine(JumpScareOccurence());
                Dead = true;
            }
            SavedLastVal = flash.IsTheFlashLightOn();

        }


        private bool ZeroCheck()
        {
            return aggressivnessVal != 0;
        }


        public void ResetPos() 
        {
            position = 0;
        }
        IEnumerator JumpScareOccurence() 
        {
            FindObjectOfType<SceneManage>().SetTheLevelToLoad(SceneManager.GetActiveScene().buildIndex);
            AudioSource.PlayClipAtPoint(JumpScareNoise, Camera.main.transform.position);
            Jumpscare.SetActive(true);
           
            yield return new WaitForSeconds(Pause);
            FindObjectOfType<SceneManage>().LoadTheGameOver();
        }

    }


   




}


