using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour
{   
    public Animator informationAnimator;
    public Animator informationPanelAnimator;

    public void OnHideInformationButtonClicked()
    {
        informationAnimator.Play("InformationFadeIn");
        informationPanelAnimator.Play("InformationPanelBackwards");
        Invoke("DestroyUs", 1f);
    }

    void DestroyUs()
    {
        Destroy(gameObject);
    }
}
