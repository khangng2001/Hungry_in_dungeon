using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private Animator ani;

    private int numClick = 0;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (numClick == 0)
            {
                Attack_1();
                StartCoroutine(timeOfAttack_1());
            }
            numClick++;
        }
    }

    void Attack_1()
    {
        ani.Play("Attack_1"); 
    }

    void Attack_2()
    {
        ani.Play("Attack_2");
    }

    IEnumerator timeOfAttack_1()
    {
        yield return new WaitForSeconds(0.6f);

        if (numClick < 2)
        {
            numClick = 0;
        }
        else
        {
            Attack_2();
            StartCoroutine(timeOfAttack_2());
        }
    }

    IEnumerator timeOfAttack_2()
    {
        yield return new WaitForSeconds(0.4f);

        numClick = 0;
    }
}
