using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleItemStateChangedEvent : UnityEvent<bool> { }

public abstract class ToggleItem : InteractableObject
{
    public bool isOn = true;

    public ToggleItemStateChangedEvent toggleItemStateChangedEvent = new ToggleItemStateChangedEvent(); //Every turret will have to listen to this

    public override void Interact()
    {
        isOn = !isOn;
        toggleItemStateChangedEvent.Invoke(isOn);
    }
}
