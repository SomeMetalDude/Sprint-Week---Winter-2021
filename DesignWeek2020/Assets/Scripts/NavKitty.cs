using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavKitty : MonoBehaviour
{
    Transform player;
    NavMeshAgent agent;

    void Start()
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
}
