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
        // If player triggered 
        if (other.GetComponent<PlayerInputs>())
        {
            tooltipTextMesh.gameObject.SetActive(true); //Enable the dialogue

            if (!conditionSatisfied)
            {
                // If the item is a lightbulb
                if (player.itemHeld && player.itemHeld.GetComponent<LightBulbItem>())
                {
                    tooltipTextMesh.text = thankYouText;
                    Destroy(player.itemHeld);
                    conditionSatisfied = true;
                    GetComponent<Animator>().SetBool("low", false);
                }
            }
        }
    }
}
