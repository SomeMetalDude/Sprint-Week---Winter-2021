using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectTest : MonoBehaviour
{
    GameObject interactPrompt;
    GameObject objectType;

    [SerializeField] TextMesh dialogue;
    [SerializeField] string dialogueText;

    [SerializeField] GameObject[] Turrets;

    void Start()
    {
        interactPrompt = this.gameObject.transform.Find("Interact Prompt").gameObject;
        objectType = this.gameObject.transform.Find("Type").gameObject;
    }

    void OnTriggerStay(Collider other)
    {
        // checks if collision in trigger is tagged Player
        if (other.tag == "Player")
        {
            interactPrompt.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // checks if collision exit in trigger is tagged Player
        if (other.tag == "Player")
        {
            interactPrompt.SetActive(false);
        }
    }

    public void ExecuteInteraction()
    {
        // Checks for the tag of Type gameobject
        if (objectType.tag == "DialogueBot")
        {
            Talk();
        }
        else if (objectType.tag == "Pickable Object")
        {
            Pickup();
        }
        else if (objectType.tag == "Turret Terminal")
        {
            DeactivateButton();
        }
    }

    public void Talk()
    {
        Debug.Log("I'm talking");
    }

    public void Pickup()
    {
        Debug.Log("Picked up");
    }

    public void DeactivateButton()
    {
        Debug.Log("Turret off");
    }
}
