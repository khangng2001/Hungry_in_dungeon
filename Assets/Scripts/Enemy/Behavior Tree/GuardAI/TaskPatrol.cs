using Unity.VisualScripting;
using UnityEngine;

namespace Enemy.Behavior_Tree.GuardAI
{
    public class TaskPatrol : Node
    {
        private Transform _transform;
        private Transform[] _waypoints;
        private int currentWaypointIndex = 0;
        private readonly float waitTime = 1f;
        private float waitCounter = 0f;
        private bool waiting = false;
        private bool isIdle = false;
        private Animator animator;
        private Vector3 dir = Vector3.zero;
        
        
        public TaskPatrol(Transform transform, Transform[] waypoints)
        {
            _transform = transform;
            _waypoints = waypoints;
            animator = transform.GetComponentInChildren<Animator>();
        }

        public override NodeState Evaluate()
        {
            if (waiting)
            {
                waitCounter += Time.deltaTime;
                if (waitCounter >= waitTime)
                {
                    waiting = false;
                }
            }
            else
            {
                Transform wp = _waypoints[currentWaypointIndex];
                if (Vector3.Distance(_transform.position, wp.position) < 0.1f)
                {
                    animator.SetBool("isMoving", false);
                    _transform.position = wp.position;
                    waitCounter = 0;
                    waiting = true;
                    currentWaypointIndex = (currentWaypointIndex + 1) % _waypoints.Length;
                }
                else
                {
                    animator.SetBool("isMoving", true);
                    _transform.position = Vector3.MoveTowards(
                        _transform.position,
                        wp.position,
                        1.5f * Time.deltaTime);
                    Vector3 dir = wp.position - _transform.position;
                    animator.SetFloat("verticalMovement", dir.y);
                    animator.SetFloat("horizontalMovement", dir.x);

                }
            }
            nodeState = NodeState.Running;
            return nodeState;
        }
        
        
    }
}
