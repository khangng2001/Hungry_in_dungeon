using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float horizontal;
    public float verital;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        verital = Input.GetAxisRaw("Vertical");
    }
}
