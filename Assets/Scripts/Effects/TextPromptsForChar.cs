using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ProjectR.SceneManagment;

namespace ProjectR.Effect 
{
    public class TextPromptsForChar : MonoBehaviour
    {
        [SerializeField] Text text;
        [SerializeField] TextOBJ[] textOBJs;
        [SerializeField] float textGenDelay = .3f;
        [SerializeField] float sentenceDisplayDelay = .7f;
        [SerializeField] AudioClip VoiceSoundBeep;
        float SavedtextGenDelay;
        float SavedsentenceDisplayDelay;
        public float volume=1;



        void Start()
        {
            SavedsentenceDisplayDelay = sentenceDisplayDelay;
            SavedtextGenDelay = textGenDelay;
            StartCoroutine(TextGen());
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Return)) 
            {
                textGenDelay=.05f;
                sentenceDisplayDelay = .2f;
                
            }
            else 
            {
                textGenDelay = SavedtextGenDelay;
                sentenceDisplayDelay = SavedsentenceDisplayDelay;
            }
        }

        IEnumerator TextGen()
        {
            for (int i = 0; i <= textOBJs.Length - 1; i++)
            {
                text.text = "";
                foreach (char letter in textOBJs[i].GetText())
                {
                    AudioSource.PlayClipAtPoint(VoiceSoundBeep, Camera.main.transform.position,volume);
                    text.text += letter;
                   
                    yield return new WaitForSeconds(textGenDelay);
                }
                yield return new WaitForSeconds(sentenceDisplayDelay);
                text.text = "";
            }

            FindObjectOfType<SceneManage>().LoadTheNextScene();
        }





    }

}