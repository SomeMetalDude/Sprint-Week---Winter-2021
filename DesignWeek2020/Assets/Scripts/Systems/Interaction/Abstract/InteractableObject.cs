using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    public bool isInteractable = false;
    public PlayerInputs player;


    public string tooltipText = "Interact with me!";
    public TextMesh tooltipTextMesh;

    private void Start()
    {
        if (tooltipTextMesh)
        {
            tooltipTextMesh.text = tooltipText;
            tooltipTextMesh.gameObject.SetActive(false);
        }
        player = FindObjectOfType<PlayerInputs>();
    }

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEntered(other);

        PlayerInputs pl;
        if (other.TryGetComponent(out pl))
        {
            if (!player.interactableObject)         // Only update the reference if it is null
            {
                EnableInteractions();
                player.interactableObject = this;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        OnTriggerExited(other);

        PlayerInputs pl;
        if (other.TryGetComponent(out pl))
        {
            if (player.interactableObject == this)  // Only null the reference if the player left this object's trigger
            {
                player.interactableObject = null;
                DisableInteractions();
            }
        }
    }

    protected void EnableInteractions()
    {
        isInteractable = true;
        if (tooltipTextMesh)
        {
            tooltipTextMesh.gameObject.SetActive(true);
        }
        OnInteractionEnabled();
    }

    protected void DisableInteractions()
    {
        isInteractable = false;
        if (tooltipTextMesh)
        {
            tooltipTextMesh.gameObject.SetActive(false);
        }
        OnInteractionDisabled();
    }

    public virtual void OnInteractionEnabled()
    {}

    public virtual void OnInteractionDisabled()
    {}

    public virtual void OnTriggerEntered(Collider other)
    {}

    public virtual void OnTriggerExited(Collider other)
    {}

    public abstract void Interact();
}
