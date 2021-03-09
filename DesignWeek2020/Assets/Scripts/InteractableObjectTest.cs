using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectTest : MonoBehaviour
{
    GameObject interactPrompt;
    GameObject objectType;

    Rigidbody rb;
    GameObject player;
    [SerializeField] GameObject playerPickup;

    [SerializeField] TextMesh dialogue;
    [SerializeField] string dialogueText;

    [SerializeField] GameObject[] Turrets;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // finds parented objects and assigns them to the variables
        interactPrompt = this.gameObject.transform.Find("Interact Prompt").gameObject;
        objectType = this.gameObject.transform.Find("Type").gameObject;
        // find player reference
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
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
        interactPrompt.SetActive(false);
        // Checks for the tag of gameobject Type
        if (objectType.tag == "DialogueBot")
        {
            StartCoroutine( Talk() );
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

    IEnumerator Talk()
    {
        Debug.Log("I'm talking!");

        // Change prompt text to dialogue Text
        interactPrompt.SetActive(true);
        dialogue.text = dialogueText;
        yield return null;
    }

    public void Pickup()
    {
        Debug.Log("Picked up");

        // Disable gravity, move object to pickup position, and parent object to the player pickup transform
        rb.useGravity = false;
        this.transform.position = playerPickup.transform.position;
        this.transform.parent = playerPickup.gameObject.transform;
        // gets reference to player Interact script and activates bool
        player.GetComponent<Interact>().isPickingUp = true;
    }

    public void DropObject()
    {
        // enable gravity and unparent object
        rb.useGravity = true;
        this.transform.parent = null;
    }

    public void DeactivateButton()
    {
        Debug.Log("Turret off");

        foreach (var turret in Turrets)
        {
            // Get component to a turret script and call method to deactivate
        }
    }
}
