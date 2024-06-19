using UnityEngine;
using UnityEngine.AI;

public class MonsterNavigation : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player; // Referensi ke transform pemain
    public float chaseDistance = 10f;
    public float patrolRadius = 15f;
    public float waitTime = 3f;

    private Vector3 patrolTarget;
    private float waitTimer;

    private void Start()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        patrolTarget = RandomNavMeshLocation();
        waitTimer = waitTime;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseDistance)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void Patrol()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f)
            {
                patrolTarget = RandomNavMeshLocation();
                waitTimer = waitTime;
            }
        }
        else
        {
            agent.SetDestination(patrolTarget);
        }
    }

    private Vector3 RandomNavMeshLocation()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, patrolRadius, 1);
        return hit.position;
    }
}
