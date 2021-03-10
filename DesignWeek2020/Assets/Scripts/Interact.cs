using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public bool isPickingUp = false;
    bool inTrigger = false;
    [SerializeField] GameObject collisionObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger && isPickingUp != true)
        {
            if (collisionObject != null)
            {
                // Get reference to object and call the ExecuteInteraction method
                collisionObject.GetComponent<InteractableObjectTest>().ExecuteInteraction();
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) && isPickingUp == true)
        {
            if (collisionObject != null)
            {
                // Get reference to object and call method to drop your pickup
                collisionObject.GetComponent<InteractableObjectTest>().DropObject();
                // set bool to false again
                isPickingUp = false;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "InteractTrigger" && collisionObject == null)
        {
            inTrigger = true;
            // get reference to object in collision
            collisionObject = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == collisionObject.gameObject)
        {
            collisionObject = null;
            inTrigger = false;
        }
    }
}
