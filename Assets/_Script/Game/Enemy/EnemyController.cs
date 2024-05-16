using System.Collections;
using System.Collections.Generic;
using _Game.Manager;
using UnityEngine;
using _Game._Pathfinding;
using _Game._State;
using _Game._FieldOfView;

namespace _Game.Enemy
{
    //Controls enemy behavior and manages all Enemy states.
    public class EnemyController : MonoBehaviour
    {
        public State idleStateEnemy;
        public State patrolStateEnemy;
        public State chaseStateEnemy;
        public FieldOfView fieldOfView;
        public Pathfinding pathfinding;

        [HideInInspector] public State currentState;

        public bool IsAvaliableTarget => fieldOfView.visibleTargets.Count > 0;
        private void Start()
        {
            currentState = idleStateEnemy;
            currentState.OnStart();
            pathfinding = FindAnyObjectByType<Pathfinding>();
        }

        private void Update()
        {
            if (GameManager.Instance.gameState != GameState.IsPlay) { return; }
            if (IsAvaliableTarget && (currentState != chaseStateEnemy))
            {
                currentState = chaseStateEnemy;
                currentState.OnStart();
                return;
            }

            currentState.OnUpdate();
        }
    }
}
