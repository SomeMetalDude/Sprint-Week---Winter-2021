using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public TurretTerminalItem turretTerminal;
    public Material onMaterial;
    public Material offMaterial;

    private void Start()
    {
        Debug.Log($"{turretTerminal.name} - Terminal name");
        turretTerminal.turretStateChangedEvent.AddListener(SetTurretEnabled);    
    }

    public void SetTurretEnabled(bool enabled)
    {
        GetComponent<MeshRenderer>().material = enabled ? onMaterial : offMaterial;
    }
}
