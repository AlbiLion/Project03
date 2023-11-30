using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderScript : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Vector3 randomDestination;
    public float wanderRadius = 900f;
    public float wanderTimer = 20f;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }
    private void Update()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= 0.0f)
        {
            SetRandomDestination();
        }
    }
    private void SetRandomDestination()
    {
        randomDestination = RandomNavSphere(transform.position, wanderRadius, -1);
        navMeshAgent.SetDestination(randomDestination);
    }
    private Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * dist;

        randomDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
