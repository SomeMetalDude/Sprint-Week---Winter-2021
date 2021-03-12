using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityBot : DialogueNPC
{
    public bool arm1 = false;
    public bool arm2 = false;
    public bool head = false;

    public GameObject headObj;
    public GameObject leftArm;
    public GameObject rightArm;

    public GameObject individualParts;
    public GameObject idleRobot;

    public string thankYouText = "";

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
                        headObj.SetActive(true);
                    }
                }
                // If the item is a security bot leg
                if (player.itemHeld && player.itemHeld.GetComponent<SecurityBotArmItem>())
                {
                    if (!arm1)
                    {
                        Destroy(player.itemHeld);
                        arm1 = true;

                        // Update sprite to have one arm
                        leftArm.SetActive(true);
                    }
                    else if (!arm2)
                    {
                        Destroy(player.itemHeld);
                        arm2 = true;

                        // Update sprite to have two arms
                        rightArm.SetActive(true);
                    }
                }
                conditionSatisfied = head && arm1 && arm2;
                if (conditionSatisfied)
                {
                    individualParts.SetActive(false);
                    idleRobot.SetActive(true);
                    showEToolTip = true;
                    if (EToolTip)
                    {
                        EToolTip.SetActive(true);
                    }
                    isInteractable = true;
                    player.interactableObject = this;
                    tooltipTextMesh.text = thankYouText;
                }
            }
        }
    }
}
