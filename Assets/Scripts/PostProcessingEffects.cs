using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingEffects : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;

    void Start()
    {
        SetPostProcessingEffects();
    }

    void SetPostProcessingEffects()
    {
        if(PlayerPrefs.GetString("PostProcessingEffects") == "enabled")
        {
            postProcessVolume.isGlobal = true;
        }
        else
        {
            postProcessVolume.isGlobal = false;
        }
    }
}
