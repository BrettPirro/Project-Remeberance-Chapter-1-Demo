using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum Axis { Horizontal,Vertical,Jump,None};
namespace ProjectR.Core 
{
    public class TutorialPopUps : MonoBehaviour
    {
        Animator animator;
        [SerializeField] KeyCode key;
        [SerializeField] Axis InputField = Axis.None;


        private void Start()
        {
            animator = GetComponent<Animator>();
        }


        void Update()
        {

            if (InputField != Axis.None && Input.GetAxis(InputField.ToString()) != 0)
            {
                animator.SetTrigger("Fade");
            }
            else if (Input.GetKeyDown(key))
            {
                animator.SetTrigger("Fade");
            }


        }

        public void Delete()
        {
            Destroy(gameObject);
        }



    }

}
