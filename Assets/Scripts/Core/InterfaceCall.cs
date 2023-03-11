using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectR.SceneManagment;


namespace ProjectR.Core 
{
    public class InterfaceCall : MonoBehaviour
    {
        bool loaded = false;
        static bool audioNoDestroyedEnabled=false;
        
        public void MainMenu() 
        {
            if (!loaded) 
            {
                loaded = true;
                FindObjectOfType<SceneManage>().LoadTheMainMenu();
            }
            
            
          
        }

        public void LoadOptionsMenu() 
        {
            if (!loaded)
            {
                loaded = true;
                FindObjectOfType<SceneManage>().LoadTheOptionsMenu();
            }
        }


        public void LoadLastScene() 
        {
            if (!loaded)
            {
                loaded = true;
                FindObjectOfType<SceneManage>().LoadTheLastLevel();
            }

        }

        public void Quit() 
        {
            if (!loaded)
            {
                loaded = true;
                FindObjectOfType<SceneManage>().LoadTheQuit();
            }

        }

        public void loadnextScene() 
        {
            if (!loaded)
            {
                loaded = true;
                FindObjectOfType<SceneManage>().LoadTheNextScene();
                
            }


        }

        public void AudioCut() 
        {
            AudioSource[] Audiosources = FindObjectsOfType<AudioSource>();
            if (Audiosources.Equals(null)) { return; }
            foreach(AudioSource i in Audiosources) 
            {
                Destroy(i);

            }
            audioNoDestroyedEnabled = false;
        }

        public void AudioKeep()
        {
            if (audioNoDestroyedEnabled == true) { return; }
            AudioSource[] Audiosources = FindObjectsOfType<AudioSource>();
            if (Audiosources.Equals(null)) { return; }
            foreach (AudioSource i in Audiosources)
            {
              
                DontDestroyOnLoad(i);
            }
            audioNoDestroyedEnabled = true;
        }


    }


}