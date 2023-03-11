using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectR.Movment;
using ProjectR.SceneManagment;

public class EndOfLevelPlatformer : MonoBehaviour
{
    bool done = false;
    [SerializeField]GameObject EndCanvas;
    [SerializeField] GameObject[] AudioToCut;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&!done) 
        {
            
            
            StartCoroutine(LoadNextLevel());
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            collision.GetComponent<PlayerMovment>().enabled = false;
            if (!(AudioToCut==null)) 
            {
                foreach(GameObject i in AudioToCut) 
                {
                    i.SetActive(false);
                }            
            }
            done = true;
        }
    }

    
    IEnumerator LoadNextLevel() 
    {
        EndCanvas.SetActive(true);
        yield return new WaitForSeconds(1f);
        FindObjectOfType<SceneManage>().LoadTheNextScene();

    }



}
