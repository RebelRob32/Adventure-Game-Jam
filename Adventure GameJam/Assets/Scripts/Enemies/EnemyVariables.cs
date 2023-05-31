using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AGJ.Enemy
{
   [CreateAssetMenu(menuName = "Enemy")]
public class EnemyVariables : ScriptableObject
{
        public float speed;
        [Range(0, 360)]
        public float radius;
        [Range(0, 360)]
        public float attackRadius;
        public float angle;
        public float health;
        public float attack;
        public float wanderRadius;
}
}

