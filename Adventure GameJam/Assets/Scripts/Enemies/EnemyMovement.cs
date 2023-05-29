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
        

       public void AttackPlayer()
        {

        }
      
       

        public void Wander()
        {
            if (!walkPointSet)
            {
                float randomZ = Random.Range(-stats.wanderRadius, stats.wanderRadius);
                float randomX = Random.Range(-stats.wanderRadius, stats.wanderRadius);

                walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

                if (Physics.Raycast(walkPoint, -transform.up, 2f, groundLayer))
                {
                    walkPointSet = true;
                    //anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
                }
            }

            if (walkPointSet == true)
            {
                agent.speed = stats.speed;
                agent.SetDestination(walkPoint);
                //anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
            }

            Vector3 distToWalkPoint = transform.position - walkPoint;
            if (distToWalkPoint.magnitude < 1f)
            {
                walkPointSet = false;
            }


        }

    }


}

