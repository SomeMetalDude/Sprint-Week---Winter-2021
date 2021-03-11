using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentWaypointPath : MonoBehaviour
{
	NavMeshAgent agent;

	public List<Transform> waypoints;
    public int waypointIndex;

	public float agentWalkSpeed = 2;
	private Vector3 oldPos;

	[SerializeField] float waitTime = 5f;
	[SerializeField] float timePassed;

	void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	void Start()
	{
		oldPos = transform.position;
		//StartCoroutine(AiSchedule());
	}

	void Update()
	{
		agent.speed = GetComponent<Animator>().GetBool("low") ? 0 : agentWalkSpeed;
		
		// If the object moved to the left
		if (oldPos.x > transform.position.x)
        {
			//Reset X axis
			GetComponent<SpriteRenderer>().flipX = false;
        }
		else
        {
			//Invert X axis
			GetComponent<SpriteRenderer>().flipX = true;
		}

		if (!agent.pathPending && agent.remainingDistance < 0.5f)
		{
			GetComponent<Animator>().SetBool("Idle", false);
			timePassed += Time.deltaTime;
			if (timePassed >= waitTime)
			{
				timePassed = 0;
				GoToNextPoint();
			}
		}
		oldPos = transform.position;
	}

	/*
	 IEnumerator AiSchedule()
	{
		if (!agent.pathPending && agent.remainingDistance < 0.5f)
			GoToNextPoint();
		new WaitForSeconds(waitTime);
		yield return StartCoroutine(AiSchedule());
	}*/

	void GoToNextPoint()
	{
		if (waypoints.Count == 0) return;
		timePassed = 0;
		agent.destination = waypoints[waypointIndex].transform.position;
		waypointIndex = (waypointIndex + 1) % waypoints.Count;
		GetComponent<Animator>().SetBool("Idle", true);
	}

}
