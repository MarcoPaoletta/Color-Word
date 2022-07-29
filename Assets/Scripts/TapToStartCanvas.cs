using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapToStartCanvas : MonoBehaviour
{
    Animator animator;
    GameObject tapToStart;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        tapToStart = GameObject.Find("TapToStart");
    }

    void Update()
    {
        if(Player.canMove)
        {
            animator.speed = 1.4f;
            if(animator.enabled)
            {
                animator.Play("TapToStartOutScreen");
            }
            Invoke("DisableTapToStart", 1);
        }
    }

    void DisableTapToStart()
    {
        animator.enabled = false;
        Destroy(gameObject);
    }
}
