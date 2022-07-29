using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("CANVAS")]
    public Canvas fadeInCanvas;
    public Canvas fadeOutCanvas;
    public Canvas endCanvas;

    [Header("PARTICLES SYSTEMS")]
    public ParticleSystem movementPlayerParticles;
    public ParticleSystem deathPlayerParticles;
    public ParticleSystem endPlayerParticles;

    [Header("COLORS")]
    public Color yellowColor;
    public Color violetColor;
    public Color cyanColor;
    public Color pinkColor;

    public static string currentColor;
    public static bool canMove;
    public static bool endLineReached;
    public static bool showEndCanvas;
    public static int jumps;
    public static int attempts;
    public static float time;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    CameraAnchor cameraAnchor;
    float force = 400f;

    #region Start
    public void Start()
    {
        SetVars();
        ChangeSpriteColor();
        InvokeRepeating("SetTime", 1f, 1f);
    }

    void SetVars()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        cameraAnchor = GameObject.Find("CameraAnchor").GetComponent<CameraAnchor>();
        canMove = false;
        endLineReached = false;
        jumps = 0;
        time = 0;
        SetAttempts();
    }

    void SetAttempts()
    {
        attempts = PlayerPrefs.GetInt("Attempts");
        attempts += 1;
        PlayerPrefs.SetInt("Attempts", attempts);
    }

    void ChangeSpriteColor()
    {
        int randomNumber = Random.Range(0, 4);

        if(randomNumber == 0)
        {
            spriteRenderer.color = yellowColor;
            currentColor = "Yellow";
        }
        if(randomNumber == 1)
        {
            spriteRenderer.color = violetColor;
            currentColor = "Violet";
        }        
        if(randomNumber == 2)
        {
            spriteRenderer.color = cyanColor;
            currentColor = "Cyan";
        }        
        if(randomNumber == 3)
        {
            spriteRenderer.color = pinkColor;
            currentColor = "Pink";
        }
    }

    void SetTime()
    {
        if(canMove && !ScreenTouched())
        {
            time += 1;
        }
    }
    #endregion

    #region Update
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(canMove)
        {
            if(ScreenTouched())
            {
                AddForce();
            }
        }

        if(!canMove && !endLineReached && ScreenTouched())
        {
            canMove = true;
            AddForce();
        }
    }

    bool ScreenTouched()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButtonDown(0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void AddForce()
    {
        if(canMove)
        {
            Instantiate(movementPlayerParticles, transform.position, Quaternion.identity);
        }
        
        rb.velocity = Vector2.zero;
        rb.gravityScale = 3;
        rb.AddForce(new Vector2(0, force));
        jumps += 1;
    }
    #endregion

    #region OnTriggerEnter2D
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ColorChanger"))
        {
            ChangeSpriteColor();
            Destroy(collision.gameObject);
            return;
        }

        if(collision.gameObject.CompareTag("FinishLine"))
        {
            Invoke("FadeOut", 1f);
            Invoke("ShowEndCanvas", 2f);
            canMove = false;
            endLineReached = true;
            cameraAnchor.EndCameraShake();
            Instantiate(endPlayerParticles, transform.position, Quaternion.identity);
            endPlayerParticles.gameObject.SetActive(true);
            rb.gravityScale = -3;
            return;
        }

        if(!collision.gameObject.CompareTag(currentColor))
        {
            Death();
        }
    }

    void FadeOut()
    {
        Instantiate(fadeOutCanvas, transform.position, Quaternion.identity);
    }

    void ShowEndCanvas()
    {
        GameObject.Find("FinishLine").SetActive(false);
        Instantiate(endCanvas, Vector3.zero, Quaternion.identity);
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

    void Death()
    {
        PlayerPrefs.SetInt("Attempts", attempts);
        gameObject.SetActive(false);
        cameraAnchor.DeathCameraShake();
        Instantiate(deathPlayerParticles, transform.position, Quaternion.identity);
        Invoke("RestartCurrentScene", 1f);
    }

    void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion

    void OnBecameInvisible()
    {
        if(!endLineReached && gameObject.activeSelf)
        {
            Death();        
        }
    }
}
