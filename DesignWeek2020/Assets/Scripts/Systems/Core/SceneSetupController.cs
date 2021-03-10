using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetupController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.SetGamePaused(false);
    }
}
