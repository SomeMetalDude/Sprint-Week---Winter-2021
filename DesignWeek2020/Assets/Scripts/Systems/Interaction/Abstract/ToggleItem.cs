using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ToggleItemStateChangedEvent : UnityEvent<bool> { }

public abstract class ToggleItem : InteractableObject
{
    public bool isOn = true;

    public ToggleItemStateChangedEvent toggleItemStateChangedEvent = new ToggleItemStateChangedEvent(); //Every turret will have to listen to this

    public override void Interact()
    {
        isOn = !isOn;
        Animator anim;
        if (TryGetComponent(out anim))
        {
            anim.SetBool("on", isOn);
        }

        toggleItemStateChangedEvent.Invoke(isOn);
    }
}
