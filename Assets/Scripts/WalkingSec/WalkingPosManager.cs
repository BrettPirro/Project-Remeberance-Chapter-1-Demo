using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectR.SceneManagment;
using UnityEngine.UI;

public class WalkingPosManager : MonoBehaviour
{
   

    
    [Header("Property of Canvas")]
    [SerializeField] Animator animator;
    Fader fader;
    [Header("UI Info for movment")]
    [SerializeField] Sprite[] sprites;
    [SerializeField] Image SourceReplaceImg;
    int pos=0;
    bool movingForwardDisable = false;
    [SerializeField] bool EndSceneAtEnd = true;
    bool loaded = false;
    [SerializeField] AudioClip WalkSound;
    public float volume = .7f;
    

    void Start()
    {
        fader = FindObjectOfType<Fader>();
        
    }

 
    void Update()
    {


        if (!movingForwardDisable && Input.GetKey(KeyCode.W)) 
        {
            StartCoroutine(ForwardMove());
        
            movingForwardDisable = true;
        }

    }

    IEnumerator ForwardMove() 
    {
        animator.SetBool("Move", true);
        AudioSource.PlayClipAtPoint(WalkSound, Camera.main.transform.position,volume);
        yield return fader.fadeIn(0.6f);
        pos++; 
        SourceReplaceImg.sprite = sprites[Mathf.Clamp(pos,0,sprites.Length-1)];
        animator.SetBool("Move", false);
        if (pos >= sprites.Length)
        {

            if (!EndSceneAtEnd) { SourceReplaceImg.gameObject.SetActive(false); yield return fader.fadeOut(0.4f); Destroy(gameObject); }
            else if (EndSceneAtEnd) { DontDestroyOnLoad(gameObject); yield return FindObjectOfType<SceneManage>().LoadNextScene(); Destroy(gameObject);  }

            movingForwardDisable = true;
        }
        else 
        {
            yield return fader.fadeOut(0.4f);
        }
      
        
          
        
        
        movingForwardDisable = false;


    }

    


}
