using Realms.Sync;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    MongoClient.Collection<GameData> collection;

    private string pid = string.Empty;

    private void Awake()
    {
        // Connect database in Mongodb for HungryInDungeon
        User user = GameObject.FindObjectOfType<ConnectMongoDb>().GetComponent<ConnectMongoDb>().user;
        MongoClient mongoDbClient = user.GetMongoClient("mongodb-atlas"); // can change MongoClient = Var
        MongoClient.Database database = mongoDbClient.GetDatabase("Hungry_In_Dungeon"); // can change MongoClient.Database = var
        collection = database.GetCollection<GameData>("Player");

        FindPid(user.Id);
        Debug.Log("User.id: " + user.Id);
    }

    private async void FindPid(string findPid)
    {
        try
        {
            GameData myAccount = await collection.FindOneAsync(new { pid = findPid });
            if (myAccount != null)
            {
                Debug.Log("Pid: " + myAccount.Pid);
                pid = myAccount.Pid;
            }
            Debug.Log("findPid: " + findPid);
        }
        catch (Exception ex)
        {
            Debug.LogError("Error during FindPid: " + ex.Message);
        }
    }

}
