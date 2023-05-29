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

        public void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            StartCoroutine(FieldOfView());
        }

        public void DetectPlayer()
        {
            Collider[] rangeCheck = Physics.OverlapSphere(transform.position, stats.radius, playerLayer);
            if(rangeCheck.Length != 0)
            {
                Transform target = rangeCheck[0].transform;
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                if (Vector3.Angle(transform.forward, dirToTarget) < stats.angle / 2)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, target.position);
                    if (!Physics.Raycast(transform.position, dirToTarget, distanceToTarget, obstructionMask))
                    {
                        playerFound = true;
                        Debug.Log("Player Found");
                    }
                    else
                        playerFound = false;
                }
                else
                {
                    playerFound = false;
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
            }

        }

}


}


