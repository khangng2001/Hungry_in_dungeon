using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    
    private void Start()
    {
        PlayerController.Instance.transform.position = transform.position;
    }
}
