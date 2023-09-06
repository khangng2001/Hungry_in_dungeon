using Realms.Sync;
using Realms.Sync.Exceptions;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CloudDataHandler
{
    MongoClient.Collection<GameData> collection;

    public CloudDataHandler(MongoClient.Collection<GameData> collectional)
    {
        try
        {
            collection = collectional;
        }
        catch (AppException ex)
        {
            Debug.LogException(ex);
        }
    }

    public async Task<GameData> Load(string findPid)
    {
        try
        {
            GameData myAccount = await collection.FindOneAsync(new { pid = findPid });
            return myAccount;
        }
        catch (AppException ex)
        {
            Debug.LogException(ex);
            return null;
        }
    }

    public async void Save(GameData data, string findPid)
    {
        try
        {
            await collection.UpdateOneAsync(new { pid = findPid }, data, upsert: true);
        }
        catch (AppException ex)
        {
            Debug.LogException(ex);
        }
    }
}
