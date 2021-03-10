using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulbRobot : DialogueNPC
{

    public string thankYouText = "Thank you!";

    public override void Interact()
    {
        
    }

    public override void OnTriggerEntered(Collider other)
    {
        Debug.Log("Trigger enter " + other.gameObject.name);
        // If the NPC collided with the player while he is holding a light bulb
        if (other.GetComponent<PlayerInputs>() && player.itemHeld)
        {
            if (player.itemHeld.GetComponent<LightBulbItem>())
            {
                Debug.Log("Bulb located!");
                tmObject.text = thankYouText;
            }
        }
    }
}
