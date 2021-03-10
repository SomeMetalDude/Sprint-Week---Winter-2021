using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupItem : InteractableObject
{
    public bool isPickedUp = false;

    public void PickUp()
    {
        isPickedUp = true;
        gameObject.transform.parent = player.pickupPoint;
        gameObject.transform.localPosition = Vector3.zero;

        player.itemHeld = gameObject;
    }

    public void PutDown()
    {
        isPickedUp = false;
        gameObject.transform.parent = null;             // Remove parented transform
        Vector3 floorPosition = transform.position;     // Get world position
        floorPosition.y = 1;                            // Zero out the Y coord
        transform.position = floorPosition;             // Assign it as the new position

        player.itemHeld = null;
    }

    public override void Interact()
    {
        if (player)
        {
            if (isPickedUp)
            {
                PutDown();
            }
            else
            {
                PickUp();
            }
        }
    }
}
