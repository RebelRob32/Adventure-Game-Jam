using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AGJ.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        public EnemyVariables stats;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Vector3 walkPoint;
        [SerializeField] private bool walkPointSet;
        [SerializeField] NavMeshAgent agent;
        public Transform player;
        public Transform patrolPoint1;
        public Transform patrolPoint2;

        public void Start()
        {
            StartCoroutine(Patrol());
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }


        public void MoveToLastPosition()
        {
            agent.SetDestination(player.transform.position);
        }

        public void AttackPlayer()
        {
            agent.SetDestination(player.transform.position);
            transform.LookAt(player);
        }
      
      public IEnumerator Patrol()
        {
            agent.SetDestination(patrolPoint2.transform.position);
            yield return new WaitForSeconds(10);
            agent.SetDestination(patrolPoint1.transform.position);
            yield return new WaitForSeconds(10);
            StartCoroutine(Patrol());
        }

        public void ReturnToPatrol()
        {
            StartCoroutine(Patrol());
        }

    }


}

