using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : MonoBehaviour
{
    public enum States
    {
        Idle,
        Chase,
        Attack,
        Hurt,
        Die
    }

    [SerializeField] private Animator animator;
    public States state;
    public static EnemyStates Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
       
        Debug.Log("State: " + state);
    }

    public void UpdateState(States newState)
    {
        switch (state)
        {
            case States.Idle:
                Animate("Idle");
                break;
            case States.Chase:
                Animate("Run");
                break;
            case States.Attack:
                Animate("Attack");
                break;
            case States.Hurt:
                
                break;
            case States.Die:
               
                break;
            default:
                break;
        }
        state = newState;
    }

    private void Animate(string nameClip)
    {
        animator.Play(nameClip);
    }
}
