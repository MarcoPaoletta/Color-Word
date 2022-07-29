using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level10")
        {
            gameObject.SetActive(false);
        }
    }

    public void OnPlayButtonClicked()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            SceneManager.LoadScene("Level1");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        PlayerPrefs.SetInt("Attempts", 0);
    }
}
