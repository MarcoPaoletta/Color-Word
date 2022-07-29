using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndCanvas : MonoBehaviour
{
    public ParticleSystem confettiParticles;

    public Text levelText;
    public Text jumpsText;
    public Text attemptsText;
    public Text secondsText;

    void Start()
    {
        InstantiateConfettiParticles();
        SetTexts();
    }

    void SetTexts()
    {
        levelText.text = "LEVEL " + (SceneManager.GetActiveScene().buildIndex).ToString();
        jumpsText.text = "JUMPS: "  + Player.jumps.ToString();
        attemptsText.text = "TRIES: " + Player.attempts.ToString();
        secondsText.text = Player.time.ToString() + "″";
    }

    void InstantiateConfettiParticles()
    {
        Instantiate(confettiParticles, transform.position, Quaternion.identity);
    }

    public void OnHomeButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
        GameObject.Find("Player").GetComponent<Player>().Start();
    }
}
