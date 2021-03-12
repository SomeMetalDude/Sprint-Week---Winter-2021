using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaBot : DialogueNPC
{
    public string thankYouText = "Thank you";
    public Sprite completedRoombaSprite;
    public override void Interact()
    {
        if (conditionSatisfied)
        {
            HUDMenuController hud = MenuManager.Instance.GetMenu<HUDMenuController>(HUDMenuClassifier);
            hud.RevealCatFact();
            if (EToolTip)
            {
                EToolTip.SetActive(false);
                showEToolTip = false;
            }
        }
    }

    public override void InteractableObjectStart()
    {
        GetComponent<NavAgentWaypointPath>().enabled = false;
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
                // If the item is a lightbulb
                if (player.itemHeld && player.itemHeld.GetComponent<RoombaAntennaItem>())
                {
                    if (tooltipTextMesh)
                    {
                        tooltipTextMesh.text = thankYouText;
                    }
                    if (EToolTip)
                    {
                        EToolTip.SetActive(true);
                        showEToolTip = true;
                    }
                    Destroy(player.itemHeld);
                    conditionSatisfied = true;
                    isInteractable = true;
                    player.interactableObject = this;
                    GetComponent<SpriteRenderer>().sprite = completedRoombaSprite;
                    GetComponent<NavAgentWaypointPath>().enabled = true;
                    GetComponent<NavAgentWaypointPath>().isBroken = false;
                }
            }
        }
    }
}
