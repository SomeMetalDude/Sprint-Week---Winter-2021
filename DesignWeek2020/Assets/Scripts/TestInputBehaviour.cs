using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInputBehaviour : MonoBehaviour
{
    public MenuClassifier pauseMenuClassifier;

    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.Instance.ShowMenu(pauseMenuClassifier);

            //DISABLE PLAYER INPUT HERE
        }
    }

    private void Move()
    {
        Vector3 movementInput = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movementInput.z += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementInput.x -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementInput.x += 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementInput.z -= 1;
        }
        if (movementInput != Vector3.zero)
            Debug.Log($"X: {movementInput.x}, Z: {movementInput.z}");
    }
}
