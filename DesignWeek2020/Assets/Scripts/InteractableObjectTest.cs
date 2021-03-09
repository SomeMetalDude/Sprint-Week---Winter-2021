using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectTest : MonoBehaviour
{
    [SerializeField] GameObject interactPrompt;

    [SerializeField] TextMesh dialogue;
    [SerializeField] string dialogueText;

    void Update()
    {
        // Display Interact prompt

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            interactPrompt.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            interactPrompt.SetActive(false);
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
