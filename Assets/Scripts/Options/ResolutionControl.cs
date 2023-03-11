using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionControl : MonoBehaviour
{

    public Vector2 Resolution;

    private void Awake()
    {
        Debug.Log("loaded");

        Resolution = new Vector2(PlayerPrefs.GetFloat("RESOLUTIONX",1920f), PlayerPrefs.GetFloat("RESOLUTIONY",1080f));
        SetResolution();
    }


    public void SetResolution() 
    {
        CanvasScaler[] Scaler = FindObjectsOfType<CanvasScaler>();
        foreach(CanvasScaler canvasScaler in Scaler) 
        {
            canvasScaler.referenceResolution=Resolution;
        }

        
    }

    

}
