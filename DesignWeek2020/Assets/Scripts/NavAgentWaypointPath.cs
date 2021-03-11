using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentWaypointPath : MonoBehaviour
{
	NavMeshAgent agent;

	public List<Transform> waypoints;
    public int waypointIndex;

	[SerializeField] float waitTime = 5f;
	[SerializeField] float timePassed;

	void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	void Start()
	{
		//StartCoroutine(AiSchedule());
	}

	void Update()
	{
		if (!agent.pathPending && agent.remainingDistance < 0.5f)
		{
			timePassed += Time.deltaTime;
			if (timePassed >= waitTime)
			{
				timePassed = 0;
				GoToNextPoint();
			}
		}
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
	}

}
