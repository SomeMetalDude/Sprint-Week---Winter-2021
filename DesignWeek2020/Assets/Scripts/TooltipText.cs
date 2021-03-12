using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipText : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.gameObject.SetActive(true);
        }
        else this.gameObject.SetActive(false);
    }
}
