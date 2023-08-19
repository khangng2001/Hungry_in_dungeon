using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : EnemyController
{
    public void StateInProgress()
    {
        switch (currentState)
        {
            case State.NonDetech:

                break;
            case State.Detech:

                break;
        }
    }

    public void SwitchState(State newState)
    {
        switch (currentState)
        {
            case State.NonDetech:

                break;
            case State.Detech:

                break;
        }

        switch (newState)
        {
            case State.NonDetech:

                break;
            case State.Detech:

                break;
        }

        currentState = newState;
    }

    public enum StateInDetech
    {
        Idle,
        Run,
        Attack,
        Hurt,
        Die
    }
    public StateInDetech currentStateInDetech;

    public void StateInDetechInProgress()
    {
        switch (currentStateInDetech)
        {
            case StateInDetech.Idle:

                break;
            case StateInDetech.Run:

                break;
            case StateInDetech.Attack:

                break;
            case StateInDetech.Hurt:

                break;
            case StateInDetech.Die:

                break;
        }
    }

    public void SwitchStateInDetch(StateInDetech newStateInDetech)
    {
        switch (currentStateInDetech)
        {
            case StateInDetech.Idle:

                break;
            case StateInDetech.Run:

                break;
            case StateInDetech.Attack:

                break;
            case StateInDetech.Hurt:

                break;
            case StateInDetech.Die:

                break;
        }

        switch (newStateInDetech)
        {
            case StateInDetech.Idle:

                break;
            case StateInDetech.Run:

                break;
            case StateInDetech.Attack:

                break;
            case StateInDetech.Hurt:

                break;
            case StateInDetech.Die:

                break;
        }

        currentStateInDetech = newStateInDetech;
    }

    private void Awake()
    {
        SetUpMaxHealth(100f);
        SetSpeed(5f);
        SetStrength(10f);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        StateInProgress();
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            GetComponentInChildren<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            GetComponentInChildren<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            GetComponentInChildren<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        }
    }
}
