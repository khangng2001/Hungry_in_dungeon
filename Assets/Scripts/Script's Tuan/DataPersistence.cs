using Realms.Sync;
using Realms.Sync.Exceptions;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    MongoClient.Collection<GameData> collection;

    private GameData myAccount;

    private async void Awake()
    {
        User user = GameObject.FindObjectOfType<ConnectMongoDb>().GetComponent<ConnectMongoDb>().user;
        var mongoDbClient = user.GetMongoClient("mongodb-atlas");
        var database = mongoDbClient.GetDatabase("HungryInDungeon");
        collection = database.GetCollection<GameData>("Player");

        myAccount = await FindPlayerPid(user.Id);
        Debug.Log("myAccount: " + myAccount.Pid);
    }

    private async Task<GameData> FindPlayerPid(string findPid)
    {
        try
        {
            GameData myAccount = await collection.FindOneAsync(new {pid = findPid});
            return myAccount;
        }
        catch (AppException ex)
        {
            Debug.LogException(ex);
            return null;
        }
    }


}
