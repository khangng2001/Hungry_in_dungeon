using Realms.Sync;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistence : MonoBehaviour
{


    private void Awake()
    {
        User user = GameObject.FindObjectOfType<ConnectMongoDb>().GetComponent<ConnectMongoDb>().user;
        var mongoDbClient = user.GetMongoClient("mongodb-atlas");
        var database = mongoDbClient.GetDatabase("HungryInDungeon");
        
    }
}
