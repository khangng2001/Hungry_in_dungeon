using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 5f;
    private Vector3 moveDir = Vector3.zero;
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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (horizontal > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
        moveDir.Set(horizontal, vertical, 0f);
        moveDir.Normalize();
        transform.Translate( moveDir * (moveSpeed * Time.deltaTime));
    }
}
