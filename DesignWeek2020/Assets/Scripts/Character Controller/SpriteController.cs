using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    PlayerInputs playerInputs;
    Animator anim;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        playerInputs = GetComponentInParent<PlayerInputs>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("xVel", Mathf.Abs(playerInputs.Movement().x));

        if (Mathf.Abs(playerInputs.Movement().x) < 0.2) anim.SetFloat("yVel", Mathf.Abs(playerInputs.Movement().y));
        else anim.SetFloat("yVel", 0);

        if (playerInputs.Movement().x > 0.1) sr.flipX = false;
        if (playerInputs.Movement().x < -0.1) sr.flipX = true;

        if (Mathf.Abs(playerInputs.Movement().x) < 0.2)
        {
            if (playerInputs.Movement().y > 0.1) sr.flipX = true;
            if (playerInputs.Movement().y < -0.1) sr.flipX = false;
        }
    }
}
