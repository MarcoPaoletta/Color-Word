using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuCanvas : MonoBehaviour
{
    public GameObject fadeInCanvas;
    public GameObject information;

    void Start()
    {
        FadeIn();
        Invoke("DisableFadeInCanvas", 1f);
    }

    void FadeIn()
    {
        Instantiate(fadeInCanvas, transform.position, Quaternion.identity);
    }

    void DisableFadeInCanvas()
    {
        foreach (var fadeIn in GameObject.FindGameObjectsWithTag("FadeInCanvas"))
        {
            fadeIn.SetActive(false);
        }
    }

    public void OnYouTubeButtonClicked()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCK7nhJBW05-tCmbmvbHThmw");
    }

    public void OnInformationButtonClicked()
    {
        GameObject informationGameObject = Instantiate(information, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        informationGameObject.transform.SetParent(transform, false);
    }
}
