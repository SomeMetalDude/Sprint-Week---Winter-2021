using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavKitty : MonoBehaviour
{
    Transform player;
    NavMeshAgent agent;

    [SerializeField] GameObject name;

    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (!player)
        {
            Debug.Log("Player not found!");
            return;
        }
    }

    void Update()
    {
        agent.destination = player.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            name.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            name.gameObject.SetActive(false);
        }
    }
}
