using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ProjectR.Options;

namespace ProjectR.SceneManagment
{
    public class SceneManage : MonoBehaviour
    {

        int LastLevelToloadFromGO;
        public void LoadTheQuit()
        {
            StartCoroutine(QuitWithFade());

        }
        public void LoadTheNextScene() 
        {
            StartCoroutine(LoadNextScene());
        
        }
        public void LoadTheMainMenu()
        {
            StartCoroutine(LoadMainMenu());

        }
        public void LoadTheGameOver()
        {
            StartCoroutine(LoadGameOver());

        }

        public void LoadTheLastLevel()
        {
            StartCoroutine(LoadLastScene());

        }

        public void LoadTheOptionsMenu()
        {
            StartCoroutine(LoadOptions());

        }


        public IEnumerator LoadNextScene() 
        {
            Fader fader=FindObjectOfType<Fader>();
            yield return fader.fadeIn(.7f);
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            FindObjectOfType<VolumeControl>().VolumeSceneChange();
            FindObjectOfType<ResolutionControl>().SetResolution();
            yield return fader.fadeOut(.7f);

        }

        public IEnumerator LoadLastScene()
        {
            Fader fader = FindObjectOfType<Fader>();
            yield return fader.fadeIn(.7f);
            yield return SceneManager.LoadSceneAsync(LastLevelToloadFromGO);
            FindObjectOfType<VolumeControl>().VolumeSceneChange();
            FindObjectOfType<ResolutionControl>().SetResolution();
            yield return fader.fadeOut(.7f);

        }

        public IEnumerator LoadGameOver() 
        {
            Fader fader = FindObjectOfType<Fader>();
            yield return fader.fadeIn(.7f);
            yield return SceneManager.LoadSceneAsync("GameOver");
            FindObjectOfType<VolumeControl>().VolumeSceneChange();
            FindObjectOfType<ResolutionControl>().SetResolution();
            yield return fader.fadeOut(.7f);

        }

        public IEnumerator LoadMainMenu()
        {
            Fader fader = FindObjectOfType<Fader>();
            yield return fader.fadeIn(.3f);
            yield return SceneManager.LoadSceneAsync("MainMenu");
            FindObjectOfType<VolumeControl>().VolumeSceneChange();
            FindObjectOfType<ResolutionControl>().SetResolution();
            yield return fader.fadeOut(.2f);

        }

        public IEnumerator QuitWithFade()
        {
            Fader fader = FindObjectOfType<Fader>();
            yield return fader.fadeIn(.3f);
            Application.Quit();

        }

        public IEnumerator LoadOptions()
        {
            Fader fader = FindObjectOfType<Fader>();
            yield return fader.fadeIn(.5f);
            yield return SceneManager.LoadSceneAsync("Options");
            FindObjectOfType<VolumeControl>().VolumeSceneChange();
            FindObjectOfType<ResolutionControl>().SetResolution();
            yield return fader.fadeOut(.2f);

        }


        public void SetTheLevelToLoad(int value) 
        {
            LastLevelToloadFromGO = value;
        }
    }

}
