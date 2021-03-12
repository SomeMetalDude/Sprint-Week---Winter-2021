using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string inputSound;
    [SerializeField] bool playerIsMoving;
    public float walkingSoundSpeed;

    void Start()
    {
        InvokeRepeating("PlayFootsteps", 0, walkingSoundSpeed);
    }

    void Update()
    {
        if (Input.GetAxis("Vertical") >= 0.01f || Input.GetAxis("Vertical") <= -0.01f 
            || Input.GetAxis("Horizontal") >= 0.01f || Input.GetAxis("Horizontal") <= -0.01f)
        {
            playerIsMoving = true;
        }
        else playerIsMoving = false;
    }

    void PlayFootsteps()
    {
        if (playerIsMoving == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot(inputSound);
        }
    }
}
