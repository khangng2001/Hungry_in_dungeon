using Realms.Sync;
using Realms.Sync.Exceptions;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CloudDataHandler
{
    MongoClient.Collection<GameData> collection;

    public CloudDataHandler (User user)
    {
        try
        {
            var mongoDbClient = user.GetMongoClient("mongodb-atlas");
            var database = mongoDbClient.GetDatabase("HungryInDungeon");
            collection = database.GetCollection<GameData>("Player");
        }
        catch (AppException ex)
        {
            Debug.LogError(ex.Message);
        }
    }

    public async Task<GameData> Load (string findPid)
    {
        try
        {
            GameData myAccount = await collection.FindOneAsync(new { pid = findPid });
            return myAccount;
        }
        catch (AppException ex)
        {
            Debug.LogError(ex.Message);
        }
        return null;
    } 

    public async void Save (GameData data, string findPid)
    {
        try
        {
            await collection.UpdateOneAsync(new { pid = findPid }, data, upsert: true);
        }
        catch (AppException ex)
        {
            Debug.LogError(ex.Message);
        }
    }
}
