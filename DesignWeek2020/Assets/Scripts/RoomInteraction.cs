using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInteraction : MonoBehaviour
{
    public GameObject wallToHide;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerInputs>())
        {
            wallToHide.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerInputs>())
        {
            wallToHide.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
