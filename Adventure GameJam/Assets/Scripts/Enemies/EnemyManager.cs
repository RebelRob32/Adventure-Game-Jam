using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AGJ.Enemy
{
public class EnemyManager : MonoBehaviour
{
        public EnemyVariables stats;
        public GameObject player;
        public LayerMask playerLayer, obstructionMask;
        public bool playerFound;
        public float currentHealth;
        public float currentAngle;
        public float currentRadius;
        public float currentAttackRadius;
        private EnemyMovement movement; 

        public void Awake()
        {
            
            currentHealth = stats.health;
            currentAngle = stats.angle;
            currentRadius = stats.radius;
            currentAttackRadius = stats.attackRadius;

           movement = GetComponent<EnemyMovement>();
        }

        public void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            StartCoroutine(FieldOfView());
        }

        public void DetectPlayer()
        {
            Collider[] rangeCheck = Physics.OverlapSphere(transform.position, currentRadius, playerLayer);
            if(rangeCheck.Length != 0)
            {
                Transform target = rangeCheck[0].transform;
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                if (Vector3.Angle(transform.forward, dirToTarget) < currentAngle / 2)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, target.position);
                    if (!Physics.Raycast(transform.position, dirToTarget, distanceToTarget, obstructionMask))
                    {
                        playerFound = true;
                        
                        movement.MoveToLastPosition();
                        currentRadius = 15;
                        currentAngle = 90;
                        
                    }
                    else
                        playerFound = false;
                }
                else
                {
                    playerFound = false;
                    currentRadius = stats.radius;
                    currentAngle = stats.angle;
                    
                }
            }
            else if(playerFound)
            {
                playerFound = false;
            }

        }
        
        public void FoundPlayer()
        {
            Collider[] rangeCheck = Physics.OverlapSphere(transform.position, currentAttackRadius, playerLayer);
            if(rangeCheck.Length != 0)
            {
                Transform target = rangeCheck[0].transform;
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                if (Vector3.Angle(transform.forward, dirToTarget) < currentAngle / 2)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, target.position);
                    if (!Physics.Raycast(transform.position, dirToTarget, distanceToTarget, obstructionMask))
                    {
                        playerFound = true;
                        EnemyMovement movement = GetComponent<EnemyMovement>();
                        movement.AttackPlayer();
                        currentAttackRadius = 10;
                        currentAngle = 90;
                        
                    }
                    else
                        playerFound = false;
                    
                }
                else
                {
                    playerFound = false;
                    movement.ReturnToPatrol();
                    currentAttackRadius = stats.attackRadius;
                    currentAngle = stats.angle;
                  
                }
            }
            else if(playerFound)
            {
                playerFound = false;
                
            }

        }

        IEnumerator FieldOfView()
        {
            float delay = 0.2f;
            WaitForSeconds wait = new WaitForSeconds(delay);
            while(true)
            {
                yield return wait;
                DetectPlayer();
                FoundPlayer();
            }

        }


        public void TakeDamage(float amount)
        {
            currentHealth -= amount;
            if (currentHealth <= 0f)
            {
                Die();
            }
        }

        public void Die()
        {
            Destroy(this.gameObject);
        }

    }


}


