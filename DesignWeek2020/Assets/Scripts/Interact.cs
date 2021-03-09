using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public bool isPickingUp = false;
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "InteractTrigger")
        {
            if (Input.GetButtonDown("Use") && isPickingUp != true)
            {
                // Get reference to object and call the ExecuteInteraction method
                other.GetComponent<InteractableObjectTest>().ExecuteInteraction();
            }
            else if (Input.GetButtonDown("Use") && isPickingUp == true)
            {
                // Get reference to object and call method to drop your pickup
                other.GetComponent<InteractableObjectTest>().DropObject();
                // set bool to false again
                isPickingUp = false;
            }
        }
    }
}
