using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectR.Core 
{
    public class FlashLight : MonoBehaviour
    {
        bool flashLight=true;
        Image flashSprite;
        bool flashlightDisable=true;
        [Header("Audio")]
        [SerializeField]AudioClip ToggleSound;
        [Header("Sprites")]
        [SerializeField] Sprite[] sprites;
        public float volume = 1f;
      
        void Start()
        {
            flashSprite = GetComponent<Image>();
        }


        void Update()
        {
            SpriteUpdate();
            if (flashlightDisable) { return; }
            Controls();

        }

        private void SpriteUpdate()
        {
            if (flashLight)
            {
                flashSprite.sprite = sprites[1];
            }
            else
            {
                flashSprite.sprite = sprites[0];
            }
        }

        private void Controls()
        {
            if (Input.GetKeyDown(KeyCode.E) && !flashLight)
            {
                flashLight = true;
                AudioSource.PlayClipAtPoint(ToggleSound, Camera.main.transform.position,volume);
            }
            else if (Input.GetKeyDown(KeyCode.E) && flashLight)
            {
                flashLight = false;
                AudioSource.PlayClipAtPoint(ToggleSound, Camera.main.transform.position,volume);
            }
        }

        public void FlashToggle(bool toggleVal ) 
        {
            //for the individual flashlight toggle without disabling player control
            flashLight = toggleVal;
        }
    
        public void FlashDisableToggle(bool toggleValDisable,bool flashToggle) 
        {
            //for the flashlight toggle with the ability to disable player control
            flashLight = flashToggle;
            flashlightDisable = toggleValDisable;
        }

       public bool IsTheFlashLightOn() 
       {
           //a method for a flashlight val return 
            return flashLight;
       }

    }

}
