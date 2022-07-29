using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraAnchor : MonoBehaviour
{
    Transform playerTransform;
    Animator camAnim;

    void Start()
    {
        SetVars();
    }

    void SetVars()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        camAnim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(playerTransform.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, playerTransform.transform.position.y, transform.position.z);
        }
    }

    public void EndCameraShake()
    {
        camAnim.SetTrigger("End");
    }

    public void DeathCameraShake()
    {
        camAnim.SetTrigger("Death");
    }
}
