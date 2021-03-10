using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurretStateChangedEvent : UnityEvent<bool>
{}

public class TurretTerminalItem : ToggleItem
{
    public TurretStateChangedEvent turretStateChangedEvent = new TurretStateChangedEvent(); //Every turret will have to listen to this

    public override void Interact()
    {
        isOn = !isOn;
        turretStateChangedEvent.Invoke(isOn);
    }
}
