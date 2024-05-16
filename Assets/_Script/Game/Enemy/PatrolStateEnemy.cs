using System.Collections.Generic;
using _Game._Pathfinding;
using _Game._State;
using UnityEngine;

using _Game.Utils;
namespace _Game.Enemy
{
    //Script responsible for patrol functionality
    public class PatrolStateEnemy : State
    {
        private EnemyController enemyController;
        [SerializeField] private List<Transform> points;
        private int index;
        private int indexPath;
        [SerializeField] private float speed;
        private float distancePoint = .01f;
        private List<Node> path = new();

        // Executes when init this state.
        public override void OnInit()
        {
            enemyController = GetComponent<EnemyController>();
        }

        //Executes when stay this state
        public override void OnUpdate()
        {
            if (indexPath >= path.Count)
            {
                index++;
                path = enemyController.pathfinding.FindPath(transform.position, points[index % points.Count].position);
                indexPath = 0;
            }

            var target = new Vector3(path[indexPath].worldPosition.x, transform.position.y, path[indexPath].worldPosition.z);
            transform.position = Vector3.MoveTowards(transform.position, target, speed);
            transform.LookAt(target);

            if (MyMath.Distance(transform.position, target) < distancePoint)
            {
                indexPath++;
            }
        }

        //Executes when enter this state
        public override void OnStart()
        {
            path = enemyController.pathfinding.FindPath(transform.position, points[index % points.Count].position);
            indexPath = 0;
        }
    }
}
