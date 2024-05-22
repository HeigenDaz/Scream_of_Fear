using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public AudioSource playerAudioSource; // Referensi ke AudioSource pemain
    public NavMeshAgent agent;
    public float hearingRange = 10f;
    public float chaseSpeed = 5f;
    public float wanderSpeed = 2f;
    public float wanderRadius = 15f;

    private Vector3 wanderTarget;

    private void Start()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        wanderTarget = RandomNavMeshLocation();
    }

    private void Update()
    {
        if (playerAudioSource.isPlaying && Vector3.Distance(transform.position, playerAudioSource.transform.position) <= hearingRange)
        {
            ChasePlayer();
        }
        else
        {
            Wander();
        }
    }

    private void ChasePlayer()
    {
        agent.speed = chaseSpeed;
        agent.SetDestination(playerAudioSource.transform.position);
    }

    private void Wander()
    {
        agent.speed = wanderSpeed;

        if (Vector3.Distance(transform.position, wanderTarget) < 2f)
        {
            wanderTarget = RandomNavMeshLocation();
        }

        agent.SetDestination(wanderTarget);
    }

    private Vector3 RandomNavMeshLocation()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, 1);
        return hit.position;
    }
}
