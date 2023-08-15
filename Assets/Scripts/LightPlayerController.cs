using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPlayerController : MonoBehaviour
{
    PlayerInput input;

    private void Awake()
    {
        input = GetComponentInParent<PlayerInput>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (input.horizontal == 0 && input.verital == 0)
        {
            return;
        }
        else if (input.horizontal == 0 && input.verital > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (input.horizontal == 0 && input.verital < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
        else if (input.horizontal < 0 && input.verital == 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else if (input.horizontal > 0 && input.verital == 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
        else if (input.horizontal < 0 && input.verital > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 45f);
        }
        else if (input.horizontal < 0 && input.verital < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 135f);
        }
        else if (input.horizontal > 0 && input.verital < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -135f);
        }
        else if (input.horizontal > 0 && input.verital > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -45f);
        }
        else if (input.verital == 0)
        {
            return;
        }
        else if (input.horizontal == 0)
        {
            return;
        }
        else if (input.verital > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (input.verital < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
        else if (input.horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else if (input.horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
    }
}
