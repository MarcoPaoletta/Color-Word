using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlowButton : MonoBehaviour
{
    Toggle toggle;

    void Start()
    {
        SetVars();
        SetToggle();
    }

    void SetVars()
    {
        toggle = GetComponent<Toggle>();
    }

    void SetToggle()
    {
        if(PlayerPrefs.GetString("PostProcessingEffects") == "enabled")
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
    }

    void Update()
    {
        CheckToggle();
    }

    void CheckToggle()
    {
        if(toggle.isOn)
        {
            PlayerPrefs.SetString("PostProcessingEffects", "enabled");
        }
        else
        {
            PlayerPrefs.SetString("PostProcessingEffects", "disabled");
        }
    }
}
