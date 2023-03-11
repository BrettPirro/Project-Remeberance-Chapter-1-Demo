using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectR.Effect;
using ProjectR.Core;
using ProjectR.AI;

namespace ProjectR.Options 
{
    public class VolumeControl : MonoBehaviour
    {
        [Range(0f, 1f)] [SerializeField] float volumeMultiplier = 1;

        private void Awake()
        {
            
            volumeMultiplier = PlayerPrefs.GetFloat("VOLUME",1f);
            VolumeSceneChange();
        }


        public void VolumeSceneChange() 
        {
            AudioSource[] sources = FindObjectsOfType<AudioSource>();
            TextPromptsForChar[] dialougSound = FindObjectsOfType<TextPromptsForChar>();
            FlashLight[] flashLights = FindObjectsOfType<FlashLight>();
            WalkingPosManager[] posManager = FindObjectsOfType<WalkingPosManager>();
            AiPosManager[] AiMan = FindObjectsOfType<AiPosManager>();

            foreach( AudioSource audio in sources) 
            {
                audio.volume = audio.volume *volumeMultiplier;
                Debug.Log("worked");
            }
            
            foreach(TextPromptsForChar vol in dialougSound) 
            {
                vol.volume = vol.volume * volumeMultiplier;
            }

            foreach(FlashLight flash in flashLights)
            {
                flash.volume = flash.volume * volumeMultiplier;
            }
            foreach (WalkingPosManager walkingPosManager in posManager) 
            {
                walkingPosManager.volume = walkingPosManager.volume * volumeMultiplier;
            }
            foreach (AiPosManager aiPos in AiMan) 
            {
                aiPos.volume = aiPos.volume * volumeMultiplier;
            }

        }

        public void UpdateVolume(float updatedVol) 
        {
            volumeMultiplier = updatedVol;
        }



    }
}
