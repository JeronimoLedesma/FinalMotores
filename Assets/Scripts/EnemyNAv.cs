using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNAv : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform objective;
    public float startingDelay;
    public float furtherDelay;
    public float enemySpeed;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        objective = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("findobjective", startingDelay, furtherDelay);
        agent.speed = enemySpeed;
    }

    void findobjective()
    {
        agent.destination = objective.position;
    }
}
