using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerMotor))]

public class PlayerInputs : MonoBehaviour
{
    PlayerMotor playerMotor;
    public InteractableObject interactableObject;
    public Transform pickupPoint;
    public GameObject itemHeld;

    private void Awake()
    {
        playerMotor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        InteractionInput();
    }

    public Vector2 Movement()
    {
        Vector2 moveMent = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        return moveMent;
    }

    public void JumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerMotor._jumpInput = true;
        }
    }

    public void InteractionInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interactableObject && interactableObject.isInteractable)
            {
                interactableObject.Interact();
            }
        }
    }
}
