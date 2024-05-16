using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Game._State;

namespace _Game.Enemy
{
    public class IdleStateEnemy : State
    {
        private EnemyController enemyController;
        private float duration = 2;
        private float time = 0;

        // Executes when init this state.
        public override void OnInit()
        {
            enemyController = GetComponent<EnemyController>();
        }


        //Executes when enter this state
        public override void OnStart()
        {
            time = 0;
        }

        //Executes when stay this state
        public override void OnUpdate()
        {
            time += Time.deltaTime;
            if (time > duration)
            {
                enemyController.currentState = enemyController.patrolStateEnemy;
            }
        }
    }
}
