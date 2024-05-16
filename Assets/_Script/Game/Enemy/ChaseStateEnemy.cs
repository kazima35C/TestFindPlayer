using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Game._Pathfinding;
using _Game._State;
using _Game.Manager;
using _Game._Player;
using _Game.Utils;
namespace _Game.Enemy
{
    //Script responsible for player tracking functionality
    public class ChaseStateEnemy : State
    {
        private EnemyController enemyController;
        [SerializeField] private Vector3 target;
        [SerializeField] private float speed;
        [SerializeField] private float distanceTarget = .2f;
        private List<Node> path = new();
        [SerializeField] private int indexPath;
        private float delayCheck = .2f;

        [SerializeField] private Material newMaterial;
        private new Renderer renderer;
        private Material baseMaterial;

        // Executes when init this state.
        public override void OnInit()
        {
            enemyController = GetComponent<EnemyController>();
            renderer = GetComponent<Renderer>();
            baseMaterial = renderer.material;
        }

        //Executes when enter this state
        public override void OnStart()
        {
            renderer.material = newMaterial;
            GameManager.Instance.PlayerDetected();
            if (!enemyController.IsAvaliableTarget)
            {
                ExitState();
                return;
            }
            target = enemyController.fieldOfView.visibleTargets[0].position;
            path = enemyController.pathfinding.FindPath(transform.position, target);
            indexPath = 0;
            StopAllCoroutines();
            StartCoroutine(CheckNewPath());
        }

        //Executes when stay this state
        public override void OnUpdate()
        {
            if (MyMath.Distance(transform.position, PlayerController.Instance.transform.position) < distanceTarget)
            {
                GameManager.Instance.GameOver();
                return;
            }
            if (indexPath >= path.Count) { return; }

            if (MyMath.Distance(transform.position, path[indexPath].worldPosition) > distanceTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, path[indexPath].worldPosition, speed);
                transform.LookAt(path[indexPath].worldPosition);

                if (enemyController.IsAvaliableTarget)
                {
                    target = enemyController.fieldOfView.visibleTargets[0].position;
                }
                return;
            }
            indexPath++;
            if (indexPath < path.Count) { return; }
            if (!enemyController.IsAvaliableTarget)
            {
                StopAllCoroutines();
                ExitState();
            }

        }

        // Periodically checks the path.
        private IEnumerator CheckNewPath()
        {
            while (true)
            {
                yield return new WaitForSeconds(delayCheck);
                if (enemyController.IsAvaliableTarget)
                {
                    path = enemyController.pathfinding.FindPath(transform.position, target);
                    indexPath = 0;
                    Debug.Log(path.Count);
                }
                if (indexPath >= path.Count)
                {
                    ExitState();
                    yield break;
                }
            }
        }

        // Executes when exiting this state.
        private void ExitState()
        {
            enemyController.currentState = enemyController.idleStateEnemy;
            renderer.material = baseMaterial;
        }
    }
}
