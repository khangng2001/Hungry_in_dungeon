using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entrance : MonoBehaviour
{
    [SerializeField] private Vector3 currentPos;
    private void Start()
    {
        currentPos = gameObject.transform.position;
        PlayerController.Instance.transform.position = currentPos;
    }
    
    
}
