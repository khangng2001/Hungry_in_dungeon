using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private EnemyHandle enemyHandle;

    private RangeAttack rangeAttack;

    private NavMeshAgent agent;

    private Animator animator;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private GameObject player;

    [SerializeField] private RangeDetect rangeDetect;

    // IF CAN REBORN, LET'S TICK IT
    public bool canReborn = false;

    // =============== STATE VARIABLES ========================
    public enum State
    {
        Non,
        Idle,
        Patrol,
        Follow,
        Attack,
        Hurt,
        Die
    }
    private State currentState = State.Non;
    public State changeState;
    // ======================================================

    // =============== STATE MACHINE ========================
    public void SwitchState(State newState)
    {
        if (newState != currentState)
        {
            switch (currentState)
            {
                case State.Idle:

                    break;
                case State.Patrol:

                    break;
                case State.Follow:

                    break;
                case State.Attack:

                    break;
                case State.Hurt:

                    break;
                case State.Die:

                    break;
            }

            currentState = newState;
        }

        switch (newState)
        {
            case State.Idle:

                break;
            case State.Patrol:

                break;
            case State.Follow:
                Follow();
                break;
            case State.Attack:
                Attack();
                break;
            case State.Hurt:

                break;
            case State.Die:

                break;
        }
    }
    // ======================================================

    private void Awake()
    {
        enemyHandle = GetComponent<EnemyHandle>();

        rangeAttack = GetComponentInChildren<RangeAttack>();

        animator = GetComponentInChildren<Animator>();

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        changeState = State.Idle;

        // NavMesh
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        //
    }

    private void Update()
    {
        FlipX();

        SetOrderLayer();

        SwitchState(changeState);

        if (rangeDetect.GetIsDetect())
        {
            if (rangeAttack.GetIsAttack())
            {
                changeState = State.Attack;
            }
            else
            {
                changeState = State.Follow;
            }
        }
        else
        {
            changeState = State.Idle;
        }
    }

    private void SetOrderLayer()
    {
        Vector2 dir = player.transform.position - transform.position;
        if (dir.y > 0)
        {
            spriteRenderer.sortingOrder = 6;
        }
        else if (dir.y < 0)
        {
            spriteRenderer.sortingOrder = 4;
        }
    }

    private void FlipX()
    {
        Vector2 dir = player.transform.position - transform.position;
        if (dir.x > 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (dir.x < 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }

    private void Follow()
    {
        agent.SetDestination(player.transform.position);

        animator.Play("Run");
    }

    private void Attack()
    {
        agent.SetDestination(transform.position);

        animator.Play("Attack");
    }
}
