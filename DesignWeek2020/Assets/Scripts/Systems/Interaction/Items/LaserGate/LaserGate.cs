using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGate : MonoBehaviour
{
    public LaserGateTerminal laserTerminal;

    private void Start()
    {
        laserTerminal.toggleItemStateChangedEvent.AddListener(SetLaserEnabled);
    }

    public void SetLaserEnabled(bool enabled)
    {
        gameObject.SetActive(enabled);
    }
}
