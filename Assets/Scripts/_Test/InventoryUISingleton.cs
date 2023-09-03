using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUISingleton : MonoBehaviour
{
    public static InventoryUISingleton instance;

    private void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
