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
                    isIdle = true;
                    _transform.position = wp.position;
                    waitCounter = 0;
                    waiting = true;
                    currentWaypointIndex = (currentWaypointIndex + 1) % _waypoints.Length;
                }
                else
                {
                    _transform.position = Vector3.MoveTowards(
                        _transform.position,
                        wp.position,
                        1.5f * Time.deltaTime);
                    /*_transform.LookAt(wp.position);*/
                }
            }
            nodeState = NodeState.Running;
            Animate();
            return nodeState;
        }

        public void Animate()
        {
            isIdle = _transform.position.x == 0 && _transform.position.y == 0;
            if (isIdle)
            {
                animator.SetBool("isMoving", false);
            }
            else
            {
                animator.SetFloat("verticalMovement", _transform.position.y);
                animator.SetFloat("horizontalMovement", _transform.position.x);
            }
        }
        
    }
}
