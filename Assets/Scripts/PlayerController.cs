using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator ani;

    private PlayerInput input;

    [SerializeField]private float moveSpeed = 5f;
    private Vector3 moveDir = Vector3.zero;

    private void Awake()
    {
        ani = GetComponentInChildren<Animator>();
        input = GetComponent<PlayerInput>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    private void Moving()
    {
        float horizontal = input.horizontal;
        float vertical = input.verital;

        FlipX(horizontal, vertical);

        SetAnimation(horizontal, vertical);

        moveDir.Set(horizontal, vertical, 0f);
        moveDir.Normalize();
        transform.Translate( moveDir * (moveSpeed * Time.deltaTime));
    }

    void FlipX(float horizontal, float vertical)
    {
        if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (horizontal > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

    }

    void SetAnimation(float horizontal, float vertical)
    {
        if (horizontal == 0 && vertical == 0)
        {
            return;
        }
        else if (horizontal == 0 && vertical > 0)
        {
            ani.Play("Up");
        }
        else if (horizontal == 0 && vertical < 0)
        {
            ani.Play("Down");
        }
        else if (horizontal < 0 && vertical == 0)
        {
            ani.Play("DownRight");
        }
        else if (horizontal > 0 && vertical == 0)
        {
            ani.Play("DownRight");
        }
        else if (vertical > 0 && horizontal < 0)
        {
            ani.Play("UpRight");
        }
        else if (vertical > 0 && horizontal > 0)
        {
            ani.Play("UpRight");
        }
        else if (vertical < 0 && horizontal > 0)
        {
            ani.Play("DownRight");
        }
        else if (vertical < 0 && horizontal < 0)
        {
            ani.Play("DownRight");
        }
        else if (horizontal == 0)
        {
            return;
        }
        else if (vertical == 0)
        {
            return;
        }
        else if (vertical > 0)
        {
            ani.Play("Up");
        }
        else if (vertical < 0)
        {
            ani.Play("Down");
        }
        else if (horizontal < 0)
        {
            ani.Play("DownRight");
        }
        else if (horizontal > 0)
        {
            ani.Play("DownRight");
        }
    }
}
