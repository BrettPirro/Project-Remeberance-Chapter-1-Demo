using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ProjectR.Options;

public class PlayerPrefSave : MonoBehaviour
{
    //add saving for res
    
    const string volume="VOLUME";
    const string resX = "RESOLUTIONX";
    const string resY = "RESOLUTIONY";
    [SerializeField] Dropdown ResDropDown;
    [SerializeField] Slider VolSlider;
    int ResIndex = 0;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("RESOLUTIONX")) PlayerPrefs.SetFloat("RESOLUTIONX", 1920);
        if (!PlayerPrefs.HasKey("RESOLUTIONY")) PlayerPrefs.SetFloat("RESOLUTIONY", 1080);
        if (!PlayerPrefs.HasKey("VOLUME")) PlayerPrefs.SetFloat("VOLUME", 1);


        if (PlayerPrefs.GetFloat(resX) == 1600) 
        {
            ResIndex = 1;
        }
       else
        {
            ResIndex = 0;
        }

        ResDropDown.value = ResIndex;

        VolSlider.value = GetVol();
    }


    public void SaveVol() 
   {
        VolumeControl volumeControl = FindObjectOfType<VolumeControl>();
        AudioSource[] source = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audio in source)
        {
            audio.volume = 1f;
        }

        PlayerPrefs.SetFloat(volume, VolSlider.value);
       volumeControl.UpdateVolume(VolSlider.value);
        volumeControl.VolumeSceneChange();

            
    }

    public float GetVol() 
    {
        return PlayerPrefs.GetFloat(volume);
        
    }

    public void SaveRes() 
    {
        UpdateRes();
        PlayerPrefs.SetFloat(resX, FindObjectOfType<ResolutionControl>().Resolution.x);
        PlayerPrefs.SetFloat(resY, FindObjectOfType<ResolutionControl>().Resolution.y);
        FindObjectOfType<ResolutionControl>().SetResolution();
    }

    public void UpdateRes()
    {
        int Index = ResDropDown.value;
        if (Index == 0)
        {
            FindObjectOfType<ResolutionControl>(). Resolution = new Vector2(1920, 1080);
        }
        else if (Index == 1)
        {
            FindObjectOfType<ResolutionControl>().Resolution = new Vector2(1600, 900);
        }


    }

}
