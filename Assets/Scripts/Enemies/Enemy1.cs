using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Transform player;
    public float EnemyRunDistance = 2f;
    public UnityEngine.AI.NavMeshAgent enemyAi;

    void Start()
    {
        enemyAi = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void FixedUpdate()
    {
        enabled = true;
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < EnemyRunDistance) {
            Debug.Log("Within distance! Better Run!");
            Vector3 dirToPlayer = transform.position - player.position;
            Vector3 newPos = transform.position + dirToPlayer;
            enemyAi.SetDestination(newPos);
        }
    }
}
