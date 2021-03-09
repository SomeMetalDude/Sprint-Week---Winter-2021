using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "InteractTrigger")
        {
            if (Input.GetButtonDown("Use"))
            {
                // Get reference to object and call the ExecuteInteraction method
                other.GetComponent<InteractableObjectTest>().ExecuteInteraction();
            }
        }
    }
}
