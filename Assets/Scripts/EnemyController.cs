using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float moveSpeed = 3f;
    private Vector3 moveDir = Vector3.zero;
    [SerializeField] private GameObject playerRef;
    private Vector3 prePos;
    [SerializeField] private bool isDetect;

    private void Start()
    {
       
        EnemyStates.Instance.UpdateState(EnemyStates.States.Idle);
        prePos = transform.position;
    }

    private void Update()
    {
        InRange();
        InAttack();
    }

    private void InRange()
    {
        if ((Vector3.Distance(playerRef.transform.position, transform.position) > 15f))
        {
            EnemyStates.Instance.UpdateState(EnemyStates.States.Idle);
            if (isDetect == true)
            {
                StartCoroutine(BackToOrigin());
            }
        }
        else if(CalDistance() > 3f && CalDistance() < 10f)
        {
            Debug.Log(CalDistance());
            isDetect = true;
            EnemyStates.Instance.UpdateState(EnemyStates.States.Chase);
            Moving();
        }
        
        else if (Vector3.Distance(playerRef.transform.position, transform.position) < 1f)
        {
            EnemyStates.Instance.UpdateState(EnemyStates.States.Attack);
        }
           
    }
    private void Moving()
    {
        moveDir = (playerRef.transform.position - transform.position).normalized;
        transform.Translate(moveDir * (moveSpeed * Time.deltaTime)) ;
        FlipX();
    }
    
    private void InAttack()
    {
        
    }

    private void FlipX()
    {
        if (moveDir.x < 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (moveDir.x > 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    private float CalDistance()
    {
        return Vector3.Distance(playerRef.transform.position,transform.position);
    }

    IEnumerator BackToOrigin()
    {
        yield return new WaitForSeconds(1f);
        transform.position = Vector3.Lerp(transform.position, prePos, moveSpeed);
        isDetect = false;
    }
    

 

   

}
