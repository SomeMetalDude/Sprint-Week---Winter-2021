using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityBot : DialogueNPC
{
    public bool leg1 = false;
    public bool leg2 = false;

    public bool head = false;

    public override void Interact()
    {
        if (conditionSatisfied)
        {
            // DO SOMETHING
        }
    }

    public override void OnTriggerEntered(Collider other)
    {
        // If player triggered 
        if (other.GetComponent<PlayerInputs>())
        {
            if (tooltipTextMesh)
            {
                tooltipTextMesh.gameObject.SetActive(true); //Enable the dialogue
            }

            if (!conditionSatisfied)
            {
                
                // If the item is a security bot head
                if (player.itemHeld && player.itemHeld.GetComponent<SecurityBotHeadItem>())
                {
                    if (!head)
                    {
                        Destroy(player.itemHeld);
                        head = true;
                        // Update sprite to have head
                    }
                }
                // If the item is a security bot leg
                if (player.itemHeld && player.itemHeld.GetComponent<SecurityBotLegItem>())
                {
                    if (!leg1)
                    {
                        Destroy(player.itemHeld);
                        leg1 = true;
                        // Update sprite to have one arm
                    }
                    else if (!leg2)
                    {
                        Destroy(player.itemHeld);
                        leg2 = true;
                        // Update sprite to have two arms
                    }
                }
            }
            conditionSatisfied = head && leg1 && leg2;
        }
    }
}
