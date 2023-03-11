using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectR.SceneManagment
{
    public class Fader : MonoBehaviour
    {
        CanvasGroup canvas;


        private void Start()
        {
            canvas = GetComponent<CanvasGroup>();
        }

        public IEnumerator fadeIn(float time)
        {
            while (canvas.alpha < 1)
            {
                canvas.alpha += Time.deltaTime / time;
                yield return null;
            }
        }

        public IEnumerator fadeOut(float time)
        {

            while (canvas.alpha > 0)
            {
                canvas.alpha -= Time.deltaTime / time;
                yield return null;
            }
        }

        public void instantFadeout()
        {
            canvas.alpha = 1;
        }

    }

}
