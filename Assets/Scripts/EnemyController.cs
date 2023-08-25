using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private float moveSpeed = 3f;
    private Vector3 moveDir = Vector3.zero;
    [SerializeField] private GameObject playerRef;
    private Vector3 prePos;
    private Vector3 preDir;
    [SerializeField] private bool isDetect;

    [SerializeField] private NavMeshAgent agent;
    private Vector3 dir = Vector3.zero;
    private void Awake()
    {
        prePos = transform.position;
    }

    private void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        EnemyStates.Instance.UpdateState(EnemyStates.States.Idle);
    }

    private void Update()
    {
        preDir = transform.position;
        Debug.Log("Distance: " + Vector3.Distance(transform.position, prePos));
        FlipX();
        InRange();
        InAttack();
    }

    private void InRange()
    {
        if ((Vector3.Distance(playerRef.transform.position, transform.position) > 10f))
        {
            if (isDetect == true)
            {
                StartCoroutine(BackToOrigin());
            }
            else
            {
                UpdateBackToOrigin();
            }
        }
        else if(CalDistance() > 2f && CalDistance() < 8f)
        {
            isDetect = true;
            EnemyStates.Instance.UpdateState(EnemyStates.States.Chase);
            Moving(playerRef.transform.position);
        }
        else if (CalDistance() < 1f)
        {
            EnemyStates.Instance.UpdateState(EnemyStates.States.Attack);
        }
           
    }
    private void Moving(Vector3 target)
    {
        isDetect = true;
        agent.SetDestination(target);
    }
    
    private void InAttack()
    {
        
    }

    private void FlipX()
    {
        if (moveDir.x < 0 || dir.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (moveDir.x > 0 || dir.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    private float CalDistance()
    {
        return Vector3.Distance(playerRef.transform.position,transform.position);
    }

    IEnumerator BackToOrigin()
    {
        agent.isStopped = false;
        yield return new WaitForSeconds(1f);
        EnemyStates.Instance.UpdateState(EnemyStates.States.Return);
        Moving(prePos);
        isDetect = false;
    }

    private void UpdateBackToOrigin()
    {
        if (EnemyStates.Instance.state != EnemyStates.States.Return) return;
        if (Vector3.Distance(transform.position, prePos) < 1f)
        {
            EnemyStates.Instance.UpdateState(EnemyStates.States.Idle);
        }
    }

    
    

 

   

}
