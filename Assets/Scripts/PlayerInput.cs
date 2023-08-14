using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool press_W = false;
    public bool press_S = false;
    public bool press_A = false;
    public bool press_D = false;

    void Update()
    {
        press_W = Input.GetKey(KeyCode.W);
        press_S = Input.GetKey(KeyCode.S);
        press_D = Input.GetKey(KeyCode.D);
        press_A = Input.GetKey(KeyCode.A);
    }
}
