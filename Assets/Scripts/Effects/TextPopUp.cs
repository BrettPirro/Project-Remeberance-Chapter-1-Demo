using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ProjectR.Effect
{
    public class TextPopUp : MonoBehaviour
    {
        [SerializeField] [TextArea(3,4)] string Input;
        [SerializeField] GameObject Canvas;
        [SerializeField] Text textComp;
        bool PlayerhasUsed = false;

        


        public bool IsitUsed()
        {
            return PlayerhasUsed;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player" && !PlayerhasUsed)
            {
                StartCoroutine(TextGen());
            }

        }


        IEnumerator TextGen()
        {
            
            PlayerhasUsed = true;
            Canvas.SetActive(true);
            textComp.text = "";
            foreach (char letter in Input)
            {
                textComp.text += letter;
                yield return new WaitForSeconds(.09f);

            }
            yield return new WaitForSeconds(1.5f);
            textComp.text = "";
            Canvas.SetActive(false);
            
        }



    }
}
