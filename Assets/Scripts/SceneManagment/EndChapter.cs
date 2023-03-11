using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectR.SceneManagment 
{
    public class EndChapter : MonoBehaviour
    {
        [SerializeField] float TimeDelay = .9f;




        private void Start()
        {
            StartCoroutine(LoadTooMainMenu());
        }

        IEnumerator LoadTooMainMenu()
        {
           
            yield return new WaitForSeconds(TimeDelay);
            FindObjectOfType<SceneManage>().LoadTheMainMenu();
        }


    }

}
