using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "InteractTrigger")
        {
            if (Input.GetButtonDown("Use"))
            {
                Debug.Log("player used interact");
                // Get reference and find script in children objects
            }
        }
    }
}
