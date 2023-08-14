using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPlayerController : MonoBehaviour
{
    PlayerInput Input;

    private void Awake()
    {
        Input = GetComponentInParent<PlayerInput>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.press_W && Input.press_S && Input.press_A && Input.press_D)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (Input.press_W  && Input.press_A && Input.press_D)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (Input.press_S && Input.press_A && Input.press_D)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
        else if (Input.press_W && Input.press_A && Input.press_S)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else if (Input.press_W && Input.press_D && Input.press_S)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
        else if (Input.press_W && Input.press_A)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 45f);
        }
        else if (Input.press_S && Input.press_A)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 135f);
        }
        else if (Input.press_S && Input.press_D)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -135f);
        }
        else if (Input.press_W && Input.press_D)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -45f);
        }
        else if (Input.press_W)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (Input.press_S)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
        else if (Input.press_A)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else if (Input.press_D)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
    }
}
